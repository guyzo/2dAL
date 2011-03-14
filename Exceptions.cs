/**
 * Copyright (c) 2006-2011 Dan Hable. Code is provided as-is.
 * Licensed for use under the LGPL. See LICENCE.txt for complete details.
 */

using System;


public class DataAccessException: Exception {

    public DataAccessException(): base() {
    }

    public DataAccessException( string msg): base( msg) {
    }

    public DataAccessException( string msg, Exception innerEx): base( msg, innerEx) {
    }

}

public class DataAccessConnectionException: DataAccessException {

    public DataAccessConnectionException(): base() {
    }

    public DataAccessConnectionException( string msg): base(msg) {
    }

    public DataAccessConnectionException( string msg, Exception inner): base( msg, inner) {
    }
}

public class DataAccessMethodNotImplemented: DataAccessException {

    public DataAccessMethodNotImplemented(): base() {
    }

    public DataAccessMethodNotImplemented( string msg): base( msg) {
    }

    public DataAccessMethodNotImplemented( string msg, Exception innerEx ): base( msg, innerEx) {
    }
}

public class DataAccessNotAuth: DataAccessException {

    public DataAccessNotAuth(): base() {
    }

    public DataAccessNotAuth( string msg): base( msg) {
    }

    public DataAccessNotAuth( string msg, Exception innerEx): base( msg, innerEx) {
    }

}

public class DataAccessOperationNotAllowed: DataAccessException {

    public DataAccessOperationNotAllowed(): base() {
    }

    public DataAccessOperationNotAllowed( string msg )
        : base( msg ) {
    }

    public DataAccessOperationNotAllowed( string msg, Exception innerEx )
        : base( msg, innerEx ) {
    }

}