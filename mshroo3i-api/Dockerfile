#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["mshroo3i-api/Mshroo3i.WebApi.csproj", "mshroo3i-api/"]
RUN dotnet restore "mshroo3i-api/Mshroo3i.WebApi.csproj"
COPY . .
WORKDIR "/src/mshroo3i-api"
RUN dotnet build "Mshroo3i.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mshroo3i.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mshroo3i.WebApi.dll"]