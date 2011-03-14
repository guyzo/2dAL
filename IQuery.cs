/**
 * Copyright (c) 2006-2011 Dan Hable. Code is provided as-is.
 * Licensed for use under the LGPL. See LICENCE.txt for complete details.
 */

using System;
using System.Collections.Generic;


public interface IQuery {
    
    Dictionary<string, object> Parameters {
        get;
    }


    string QueryCommand {
        get;
        set;
    }

    bool IsValid {
        get;
    }

}