FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source
ARG service=AuthService
COPY ./${service}/*.csproj ./${service}/
COPY ./Common/ ./Common/
RUN dotnet restore ./${service}
COPY ./${service}/ ./${service}/
RUN dotnet publish -c release -o /app --no-restore ./${service}

FROM ms-migrator as migrator
WORKDIR /app
COPY --from=build /app/AuthService.dll ./
ENTRYPOINT ["dotnet", "Migrator.dll", "--dll", "AuthService.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine
WORKDIR /app
COPY --from=build /app ./
ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_BASE=/api/auth
EXPOSE 5000
HEALTHCHECK CMD curl --fail http://localhost:5000/health || exit
ENTRYPOINT ["dotnet", "AuthService.dll"]
