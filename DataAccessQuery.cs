/**
 * Copyright (c) 2006-2011 Dan Hable. Code is provided as-is.
 * Licensed for use under the LGPL. See LICENCE.txt for complete details.
 */

using System;
using System.Collections.Generic;


public class DataAccessQuery: IQuery {
    private Dictionary<string, object> _params = new Dictionary<string, object>();
    private string _cmd = string.Empty;

    public DataAccessQuery() {
    }

    public DataAccessQuery( string cmd) {
        _cmd = cmd;
    }

    public Dictionary<string, object> Parameters {
        get { return _params; }
    }

    public string QueryCommand {
        get { return _cmd; }
        set { _cmd = value; }
    }

    public bool IsValid {
        get { return true; }
    }
}
