# Developer Notes

Scaffolding new controller:

```
dotnet aspnet-codegenerator controller -name TodoController -m Dojo.Api.Todo.TodoItem -dc Dojo.Api.Todo.TodoRepository -async -api -outDir Todo --useDefaultLayout --referenceScriptLibraries
```

Miscelleaneous:

```
dotnet aspnet-codegenerator controller -name TodoController -async -api -m TodoItem -dc TodoRepository -outDir Todo

dotnet aspnet-codegenerator controller -name TodoController -m Dojo.Api.Todo.TodoItem -dc Dojo.Api.Todo.TodoRepository -async -api -outDir Todo --relativeFolderPath Todo --useDefaultLayout --referenceScriptLibraries --databaseProvider sqlite

dotnet aspnet-codegenerator controller -name TodoController -m Dojo.Api.Todo.TodoItem -dc Dojo.Api.Todo.TodoRepository -async -api -outDir Todo --useDefaultLayout --referenceScriptLibraries
```

Remove all the compile time dependencies after scaffolding.

# Docs

https://learn.microsoft.com/en-in/aspnet/core/web-api/?view=aspnetcore-8.0

# Useful Libraries

https://github.com/ardalis/SmartEnum
https://github.com/altmann/FluentResults
https://github.com/riok/mapperly