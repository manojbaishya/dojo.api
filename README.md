# Developer Notes

Scaffolding new controller:

```
dotnet aspnet-codegenerator controller -name TodoController -m Dojo.Api.Todo.TodoItem -dc Dojo.Api.Todo.TodoRepository -async -api -outDir Todo --useDefaultLayout --referenceScriptLibraries
```

Remove all the compile time dependencies after scaffolding.

Kubernetes deployment commands:
```
dotnet publish dojo.api.csproj -r linux-x64 -o publish

docker build -t manojbaishya/dojo.api -f Dockerfile .
helm upgrade --install dojo.api . --namespace=app --dry-run
helm upgrade --install dojo-api dojo.api.charts --namespace=app

docker create --name dojo.api.run dojo.api
docker exec -it dojo.api.run sh
```

# Theory

https://tldp.org/LDP/solrhe/Securing-Optimizing-Linux-RH-Edition-v1.3/chap9sec95.html

https://en.wikipedia.org/wiki/Hosts_(file)#Location_in_the_file_system

# Linux

https://linuxjourney.com/

https://linuxcommand.org/lc3_learning_the_shell.php

https://linuxcommand.org/lc3_writing_shell_scripts.php

# Learn ASP.NET CORE

https://learn.microsoft.com/en-us/dotnet/

https://learn.microsoft.com/en-us/dotnet/navigate/advanced-programming/

https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-8.0

https://learn.microsoft.com/en-in/aspnet/core/web-api/?view=aspnetcore-8.0

https://learn.microsoft.com/en-us/ef/dotnet-data/

# Reference Implementation

https://github.com/dotnet/eShop

# Local Automation

https://taskfile.dev/

# Useful Application Libraries

https://github.com/ardalis/SmartEnum

https://github.com/altmann/FluentResults

https://github.com/riok/mapperly

https://www.npgsql.org/doc/index.html

https://www.npgsql.org/efcore/index.html?tabs=onconfiguring

# Distributed Applications

https://masstransit.io/documentation/concepts

https://docs.nats.io/

# Kubernetes Material

https://docs.docker.com/reference/dockerfile/

https://github.com/containerd/nerdctl

https://goharbor.io/

https://containerd.io/

https://docs.k3s.io/

https://helm.sh/docs/

https://github.com/komodorio/helm-dashboard

https://github.com/kubernetes/dashboard

