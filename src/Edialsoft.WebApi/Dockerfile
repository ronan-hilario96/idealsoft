#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Edialsoft.WebApi/Edialsoft.WebApi.csproj", "src/Edialsoft.WebApi/"]
COPY ["src/Edialsoft.IoC/Edialsoft.Ioc.csproj", "src/Edialsoft.IoC/"]
COPY ["src/Edialsoft.Data/Edialsoft.Data.csproj", "src/Edialsoft.Data/"]
COPY ["src/Edialsoft.Domain/Edialsoft.Domain.csproj", "src/Edialsoft.Domain/"]
RUN dotnet restore "src/Edialsoft.WebApi/Edialsoft.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Edialsoft.WebApi"
RUN dotnet build "Edialsoft.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Edialsoft.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Edialsoft.WebApi.dll"]