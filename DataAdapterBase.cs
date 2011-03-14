/**
 * Copyright (c) 2006-2011 Dan Hable. Code is provided as-is.
 * Licensed for use under the LGPL. See LICENCE.txt for complete details.
 */

using System;


public abstract class DataAdapterBase: IDataAdapter {

    public virtual void Create( object dataComponent) {
        throw new DataAccessMethodNotImplemented();
    }

    public virtual void Retrieve( IQuery query, object dataComponent) {
        throw new DataAccessMethodNotImplemented();
    }

    public virtual void Update( object dataComponent) {
        throw new DataAccessMethodNotImplemented();
    }

    public virtual void Delete( IQuery query) {
        throw new DataAccessMethodNotImplemented();
    }

    public virtual void Delete( object dataComponent) {
        throw new DataAccessMethodNotImplemented();
    }

}