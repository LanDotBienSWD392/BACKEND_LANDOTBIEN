FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Add a local NuGet package source
RUN dotnet nuget add source /app/packages

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining files and build the application
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "LanDotBien_BackEnd.dll"]