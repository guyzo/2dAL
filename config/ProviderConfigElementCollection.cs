/**
 * Copyright (c) 2006-2011 Dan Hable. Code is provided as-is.
 * Licensed for use under the LGPL. See LICENCE.txt for complete details.
 */

using System;
using System.Configuration;


namespace CI.Common.Data.Configuration {

    public class ProviderConfigElementCollection: ConfigurationElementCollection {

        public override ConfigurationElementCollectionType CollectionType {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }

        protected override ConfigurationElement CreateNewElement() {
            return new ProviderConfigElement();
        }

        protected override ConfigurationElement CreateNewElement( string elementName ) {
            return base.CreateNewElement( elementName );
        }

        protected override object GetElementKey( ConfigurationElement element ) {
            return ( (ProviderConfigElement)element ).Name;
        }

        public ProviderConfigElement this[int index] {
            get { return (ProviderConfigElement)BaseGet( index); }
            set {
                if( BaseGet( index) != null) { BaseRemoveAt( index); }
                BaseAdd(index, value);
            }
        }

        public new ProviderConfigElement this[ string name] {
            get { return (ProviderConfigElement)BaseGet( name); }
        }

        public int IndexOf( ProviderConfigElement element) {
            return BaseIndexOf( element);
        }

        public void Add( ProviderConfigElement element) {
            BaseAdd( element); 
        }

        public void Remove( ProviderConfigElement element) {
            if( BaseIndexOf( element) >= 0)
                BaseRemove( element.Name);
        }

        public void RemoveAt( int index) {
            BaseRemoveAt( index );
        }

        public void Remove( string name) {
            BaseRemove( name);
        }

        public void Clear() {
            BaseClear();
        }
    }

}