/**
 * Copyright (c) 2006-2011 Dan Hable. Code is provided as-is.
 * Licensed for use under the LGPL. See LICENCE.txt for complete details.
 */

using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

using CI.Common.Data.Configuration;


internal class DatabaseConnectionManager {

    private const string CONFIG_DATA_NAME = "caffeinatedIdeas/dataAccess";
    private static IDictionary<string, LazyDatabaseConnection> _instances = new Dictionary<string, LazyDatabaseConnection>();


    static DatabaseConnectionManager() {
        Configuration config = ConfigurationManager.OpenExeConfiguration( ConfigurationUserLevel.None);
        DataAccessConfigHandler hnd = (DataAccessConfigHandler)config.GetSection( CONFIG_DATA_NAME);

        if ( hnd.Provider != null )
            _instances[hnd.Provider.Name] = CreateConnection( hnd.Provider );

        foreach ( ProviderConfigElement element in hnd.Providers )
            _instances[element.Name] = CreateConnection( element );

        if ( _instances.Count == 0 )
            throw new DataAccessException();
    }


    internal static IDictionary<string, LazyDatabaseConnection> Connections {
        get { return _instances; }
    }


    private static LazyDatabaseConnection CreateConnection( ProviderConfigElement provider) {
        LazyDatabaseConnection conn = null;

        try {
            ConstructorInfo connCtor = Type.GetType( provider.ConnectionType).GetConstructor( new Type[] { typeof(string) });
            ConstructorInfo adapCtor = Type.GetType( provider.AdapterType ).GetConstructor( new Type[] { } );

            conn = new LazyDatabaseConnection( (IDbConnection)connCtor.Invoke( new object[] { provider.ConnectionString } ), 
                                               (IDbDataAdapter)adapCtor.Invoke( null),
                                               provider.CloseDelay, 
                                               provider.IsDistributed);
        } catch( Exception ex) {
            throw new DataAccessConnectionException( "Error attempting to create an object of type " + provider.ConnectionString, ex );
        }

        return conn;
    }

}
