FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PlayerApi/PlayerApi.csproj", "PlayerApi/"]
RUN dotnet restore "PlayerApi/PlayerApi.csproj"
COPY . .
WORKDIR "/src/PlayerApi"
RUN dotnet build "PlayerApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PlayerApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PlayerApi.dll"]
