# DapperMapper

This library provides a Dapper mapper that maps the properties of a class/entity to database column names. 

All classes that are decorated with the TableAttribute are reflected and processed when the MapAll method is called.

For the properties of a class that are decorated with a ColumnAttribute, the name value of the ColumnAttribute represents the name of the column in the database.

## Usage

Finds all the classes/entities that are part of the application that are decorated with a TableAttribute and maps the properties that are decored with a ColumnAttribute to a database column name.
```

	DapperCustomPropertyTypeMapper.MapAll();
```

Maps all the properties of the given class/entity that are decorated with a ColumnAttribute to a database column name.
```

	DapperCustomPropertyTypeMapper.Map<Entity>();
```