FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NCTServices.API.Common/NCTServices.API.Common.csproj", "NCTServices.API.Common/"]
COPY ["NCTServices.Application.Common/NCTServices.Application.Common.csproj", "NCTServices.Application.Common/"]
COPY ["NCTServices.Contracts/NCTServices.Contracts.csproj", "NCTServices.Contracts/"]
COPY ["NCTServices.Domain/NCTServices.Domain.csproj", "NCTServices.Domain/"]
COPY ["NCTServices.Infrastructure/NCTServices.Infrastructure.csproj", "NCTServices.Infrastructure/"]
COPY ["NCTServices.Infrastructure.Shared/NCTServices.Infrastructure.Shared.csproj", "NCTServices.Infrastructure.Shared/"]
COPY ["NCTServices.Model/NCTServices.Model.csproj", "NCTServices.Model/"]
COPY ["NCTServices.Shared/NCTServices.Shared.csproj", "NCTServices.Shared/"]
RUN dotnet restore "NCTServices.API.Common/NCTServices.API.Common.csproj"
COPY . .
WORKDIR "/src/NCTServices.API.Common/"
RUN dotnet build "NCTServices.API.Common.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NCTServices.API.Common.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NCTServices.API.Common.dll"]