# DapperMapper

This library provides a Dapper mapper that maps the properties of a class/entity to database column names. 

All classes that are decorated with the TableAttribute are reflected and processed when the MapAll method is called.

For the properties of a class/entity that are decorated with a ColumnAttribute, the name value of the ColumnAttribute represents the name of the column in the database.

## Usage

In the example below, all the classes/entities that are part of the application that are decorated with a TableAttribute are discovered and their properties that are decorated with a ColumnAttribute are mapped to a database column name.
```

	DapperCustomPropertyTypeMapper.MapAll();

```

In the example below, all the properties of the given class/entity {T} that are decorated with a ColumnAttribute are mapped to a database column name.
```

	DapperCustomPropertyTypeMapper.Map<T>();

```