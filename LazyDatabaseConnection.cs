/**
 * Copyright (c) 2006-2011 Dan Hable. Code is provided as-is.
 * Licensed for use under the LGPL. See LICENCE.txt for complete details.
 */


using System;
using System.Data;
using System.Threading;


internal sealed class LazyDatabaseConnection: IDbConnection, IDisposable {

    private IDbConnection _connection = null;
    private IDbDataAdapter _adapter = null;
    private Timer _delayCloseTimer = null;
    private bool _canRecycle = true;


    public LazyDatabaseConnection( IDbConnection rawConnection, IDbDataAdapter adapter, int closeDelay, bool distributed) {
        _connection = rawConnection;
        _delayCloseTimer = new Timer( this.DelayClose, null, new TimeSpan( 0, closeDelay, 0 ), new TimeSpan( 0, closeDelay, 0 ) );
    }

    public void Dispose( bool disposing) {
        if( disposing) {
            _delayCloseTimer.Dispose();
            _connection.Dispose();
        }
    }

    public void Dispose() {
        Dispose( true);
        GC.SuppressFinalize( this);
    }

    ~LazyDatabaseConnection() {
        Dispose( false);
    }

    public string ConnectionString {
        get { return _connection.ConnectionString; }
        set { /* Do nothing. Go through the connection manager instead. */ }
    }

    public int ConnectionTimeout {
        get { return _connection.ConnectionTimeout; }
    }

    public string Database {
        get { return _connection.Database; }
    }

    public ConnectionState State {
        get { return _connection.State; }
    }

    public IDbTransaction BeginTransaction() {
        return _connection.BeginTransaction();
    }

    public IDbTransaction BeginTransaction( IsolationLevel level) {
        return _connection.BeginTransaction( level);
    }

    public IDbCommand CreateCommand() {
        return _connection.CreateCommand();
    }

    public void ChangeDatabase( string databaseName) {
        _connection.ChangeDatabase( databaseName);
    }

    public void Open() {
        Monitor.Enter( _connection );

        _canRecycle = false;
        if ( _connection.State == ConnectionState.Closed )
            _connection.Open();

        Monitor.Exit( _connection );
    }

    public void Close() {
        Monitor.Enter( _connection );
        _canRecycle = true;
        Monitor.Exit( _connection );
    }

    private void DelayClose(object stateInfo) {
        Monitor.Enter( _connection);

        if ( _canRecycle == true && _connection.State != ConnectionState.Closed )
            _connection.Close();

        Monitor.Exit( _connection);
    }

    public IDbDataAdapter ADODataAdapter {
        get { return _adapter; }
        set { _adapter = value; }
    }
}