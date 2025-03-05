FROM mcr.microsoft.com/dotnet/sdk:9.0@sha256:3fcf6f1e809c0553f9feb222369f58749af314af6f063f389cbd2f913b4ad556 AS build
WORKDIR /app
COPY dojo.api .

RUN dotnet restore dojo.api.csproj
RUN dotnet publish dojo.api.csproj -r linux-x64 -o publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0.2-noble-chiseled@sha256:ecaecad2614c3c946727a3fc22ef829771ce6527e9d82c639080771c2f67ea0a
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "dojo.api.dll"]