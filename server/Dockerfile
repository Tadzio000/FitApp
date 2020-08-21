# FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /server
EXPOSE 5005
# ENV ASPNETCORE_URLS =http://*:5005

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /server
COPY --from=build-env /server/out .
ENTRYPOINT ["dotnet", "WebApi.dll"]


