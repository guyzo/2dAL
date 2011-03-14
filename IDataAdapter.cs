/**
 * Copyright (c) 2006-2011 Dan Hable. Code is provided as-is.
 * Licensed for use under the LGPL. See LICENCE.txt for complete details.
 */

using System;

public interface IDataAdapter {

    void Create( object dataComponent );

    void Retrieve( IQuery query, object dataComponent );

    void Update( object dataComponent );

    void Delete( IQuery query );

    void Delete( object dataComponent );

}