FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

LABEL Mark Roger Patanga

EXPOSE 80

# Copiar csproj e restaurar dependencias
COPY ["02-Services/Demo.Service.Api/*.csproj", "02-Services/Demo.Service.Api/"]
COPY ["03-Application/Demo.Application/*.csproj", "03-Application/Demo.Application/"]
COPY ["04-Domain/Demo.Domain/*.csproj", "04-Domain/Demo.Domain/"]
COPY ["05-Infrastructure/Demo.Infrastructure.Data/*.csproj", "05-Infrastructure/Demo.Infrastructure.Data/"]
COPY ["05-Infrastructure/Demo.Infrastructure.Ioc/*.csproj", "05-Infrastructure/Demo.Infrastructure.Ioc/"]

RUN dotnet restore "02-Services/Demo.Service.Api/Demo.Service.Api.csproj"

# Build da aplicacao
COPY . ./
RUN dotnet publish "02-Services/Demo.Service.Api/Demo.Service.Api.csproj" -c Release -o out

# Build da imagem
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Demo.Service.Api.dll"]

