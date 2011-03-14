/**
 * Copyright (c) 2006-2011 Dan Hable. Code is provided as-is.
 * Licensed for use under the LGPL. See LICENCE.txt for complete details.
 */

using System;
using System.Configuration;


namespace CI.Common.Data.Configuration {

    public class ProviderConfigElement: ConfigurationElement {

        public ProviderConfigElement() { }

        [ConfigurationProperty("name", IsRequired=true, IsKey=true)]
        public string Name {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("connectionType", IsRequired=true)]
        public string ConnectionType {
            get { return (string)this["connectionType"]; }
            set { this["connectionType"] = value; }
        }

        [ConfigurationProperty("adapterType", IsRequired=false)]
        public string AdapterType {
            get { return (string)this["adapterType"]; }
            set { this["adapterType"] = value; }
        }

        [ConfigurationProperty("connectionString", IsRequired=true)]
        public string ConnectionString {
            get { return (string)this["connectionString"]; }
            set { this["connectionString"] = value; }
        }

        [ConfigurationProperty("closeDelay", DefaultValue=5, IsRequired=false)]
        [IntegerValidator(MinValue=5)]
        public int CloseDelay {
            get { return (int)this["closeDelay"]; }
            set { this["closeDelay"] = value; }
        }

        [ConfigurationProperty("distributed", DefaultValue=false, IsRequired=false)]
        public bool IsDistributed {
            get { return false; }
            set { this["distributed"] = false; }
        }

    }

}
