/**
 * A simple configuration class.
 *
 * Copyright (c) 2006-2011 Dan Hable. Code is provided as-is.
 * Licensed for use under the LGPL. See LICENCE.txt for complete details.
 */

using System;
using System.Configuration;


namespace CI.Common.Data.Configuration {

    public class DataAccessConfigHandler: ConfigurationSection {

        public DataAccessConfigHandler() {
        }

        [ConfigurationProperty("provider", IsRequired=false)]
        public ProviderConfigElement Provider {
            get { return (ProviderConfigElement)this["provider"]; }
            set { this["provider"] = value; }
        }


        [ConfigurationProperty("providers", IsDefaultCollection=false, IsRequired=false)]
        public ProviderConfigElementCollection Providers {
            get { return (ProviderConfigElementCollection)base["providers"]; }
        }
        
    }

}
