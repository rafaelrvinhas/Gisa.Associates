#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Associates.Services.Api/Associates.Services.Api.csproj", "Associates.Services.Api/"]
COPY ["Associates.Application/Associates.Application.csproj", "Associates.Application/"]
COPY ["Associates.Domain/Associates.Domain.csproj", "Associates.Domain/"]
COPY ["Associates.Domain.Core/Associates.Domain.Core.csproj", "Associates.Domain.Core/"]
COPY ["Associates.Infra.Data/Associates.Infra.Data.csproj", "Associates.Infra.Data/"]
COPY ["Associates.Infra.CrossCutting.Bus/Associates.Infra.CrossCutting.Bus.csproj", "Associates.Infra.CrossCutting.Bus/"]
COPY ["Associates.Infra.CrossCutting.IoC/Associates.Infra.CrossCutting.IoC.csproj", "Associates.Infra.CrossCutting.IoC/"]
RUN dotnet restore "Associates.Services.Api/Associates.Services.Api.csproj"
COPY . .
WORKDIR "/src/Associates.Services.Api"
RUN dotnet build "Associates.Services.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Associates.Services.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Associates.Services.Api.dll"]