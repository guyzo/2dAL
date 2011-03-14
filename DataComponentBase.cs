/**
 * Copyright (c) 2006-2011 Dan Hable. Code is provided as-is.
 * Licensed for use under the LGPL. See LICENCE.txt for complete details.
 */

using System;



public abstract class DataComponentBase<K,DA>: IDataComponent<K,DA> 
                                                where DA: IDataAdapter, new() {

    private K _keyValue = default( K );
    private bool _new = false;
    private bool _changed = false;
    private bool _deleted = false;
    private bool _local = true;
    private bool _framework = false;
    private DA _adapter = new DA();
    
    
    public DataComponentBase() {
        _framework = true;
        IsNew = true;
        _framework = false;
    }

    public DataComponentBase( IQuery query) {
        _framework = true;
        _adapter.Retrieve( query, this );
        _framework = false;
    }

    public K Key {
        get { return _keyValue; }
        set {
            if( !_framework)
                throw new DataAccessNotAuth();
            _keyValue = value;
        }
    }

    public bool IsNew {
        get { return _new; }
        set {
            if( !_framework)
                throw new DataAccessNotAuth();
            _new = value;
        }
    }

    public bool IsChanged {
        get { return _changed; }
        set{
            if( !_framework)
                throw new DataAccessNotAuth();
            _changed = value;
        }
    }

    public bool IsDeleted {
        get { return _deleted; }
        set {
            if( !_framework)
                throw new DataAccessNotAuth();
            _deleted = value;
        }
    }

    public bool IsLocal {
        get { return _local; }
        set {
            if( !_framework)
                throw new DataAccessNotAuth();
            //_local = value;
        }
    }

    public virtual void Save() {
        _framework = true;
        if ( IsDeleted )
            //throw new DataAccessOperationNotAllowed( "You can't save an object that's already been deleted" );
            throw new DataAccessOperationNotAllowed();

        if( IsNew) {
            _adapter.Create( this);
        } else if( IsChanged) {
            _adapter.Update( this);
        }

        IsNew = false;
        IsChanged = false;
        _framework = false;
    }

    public virtual void Delete() {
        _framework = true;
        if ( IsNew )
            throw new Exception( "You can't delete an object that hasn't been saved yet." );

        _adapter.Delete( this );
        _framework = false;
    }

    protected void BeginEdit() {
        _framework = true;
        IsChanged = true;
        _framework = false;
    }

    protected void EndEdit( bool changedValues) {
        _framework = true;
        if( changedValues) {
            IsChanged = true;
        } else {
            IsChanged = false;
        }
        _framework = false;
    }
}