#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build
WORKDIR /src
COPY ["LanDotBien_BackEnd/LanDotBien_BackEnd.csproj", "LanDotBien_BackEnd/"]
COPY ["LanVar.Core/LanVar.Core.csproj", "LanVar.Core/"]
COPY ["LanVar.DTO/LanVar.DTO.csproj", "LanVar.DTO/"]
COPY ["Tools/Tools.csproj", "Tools/"]
COPY ["LanVar.Insfrastructure/LanVar.Insfrastructure.csproj", "LanVar.Insfrastructure/"]
COPY ["LanVar.Services/LanVar.Services.csproj", "LanVar.Services/"]
RUN dotnet restore "LanDotBien_BackEnd/LanDotBien_BackEnd.csproj"
COPY . .
WORKDIR "/src/LanDotBien_BackEnd"
RUN dotnet build "LanDotBien_BackEnd.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LanDotBien_BackEnd.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LanDotBien_BackEnd.dll"]