/**
 * Copyright (c) 2006-2011 Dan Hable. Code is provided as-is.
 * Licensed for use under the LGPL. See LICENCE.txt for complete details.
 */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;


public class DataAccess {
    private static Dictionary<string, DataAccess> _cachedInstances = new Dictionary<string, DataAccess>();
    private LazyDatabaseConnection _connection = null;

    public static DataAccess Handle( string providerName ) {
        if ( !_cachedInstances.ContainsKey( providerName ) ) {
            _cachedInstances.Add( providerName, new DataAccess( DatabaseConnectionManager.Connections[providerName] ) );
        }
        return _cachedInstances[providerName];
    }

    private DataAccess( LazyDatabaseConnection conn ) {
        _connection = conn;
    }

    public DataSet Query( IQuery selectQuery ) {
        DataSet ds = new DataSet();
        IDbDataAdapter adapter = _connection.ADODataAdapter;

        IDbCommand cmd = _connection.CreateCommand();
        cmd.CommandText = selectQuery.QueryCommand;
        cmd.CommandType = CommandType.Text;
        foreach ( KeyValuePair<string, object> kv in selectQuery.Parameters ) {
            cmd.Parameters[kv.Key] = kv.Value;
        }

        adapter.SelectCommand = cmd;
        adapter.Fill( ds );
        return ds;
    }
}