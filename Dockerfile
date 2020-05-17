# FROM mcr.microsoft.com/dotnet/core/runtime:3.1-nanoserver-1903 AS base
FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS base
WORKDIR /app

EXPOSE 5001 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["02-Services/Demo.Service.Api/Demo.Service.Api.csproj", "02-Services/Demo.Service.Api/"]
COPY ["03-Application/Demo.Application/Demo.Application.csproj", "03-Application/Demo.Application/"]
COPY ["04-Domain/Demo.Domain/Demo.Domain.csproj", "04-Domain/Demo.Domain/"]
COPY ["05-Infrastructure/Demo.Infrastructure.Data/Demo.Infrastructure.Data.csproj", "05-Infrastructure/Demo.Infrastructure.Data/"]
COPY ["05-Infrastructure/Demo.Infrastructure.Ioc/Demo.Infrastructure.Ioc.csproj", "05-Infrastructure/Demo.Infrastructure.Ioc/"]

RUN dotnet restore "02-Services/Demo.Service.Api/Demo.Service.Api.csproj"
COPY . .
WORKDIR "/src/02-Services/Demo.Service.Api"
RUN dotnet build "Demo.Service.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Demo.Service.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Demo.Service.Api.dll"]

