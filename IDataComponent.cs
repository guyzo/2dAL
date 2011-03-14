/**
 * Copyright (c) 2006-2011 Dan Hable. Code is provided as-is.
 * Licensed for use under the LGPL. See LICENCE.txt for complete details.
 */

using System;


public interface IDataComponent<K,DA> where DA: IDataAdapter {
    
    K Key {
        get;
    }

    bool IsNew {
        get;
    }

    bool IsChanged {
        get;
    }

    bool IsDeleted {
        get;
    }

    bool IsLocal {
        get;
    }

    void Save();

    void Delete();

}