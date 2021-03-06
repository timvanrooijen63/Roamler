FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 9001
ENV ASPNETCORE_URLS=http://*:9001

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["location.search.web/location.search.web.csproj", "location.search.web/"]
RUN dotnet restore "location.search.web/location.search.web.csproj"
COPY . .
WORKDIR "/src/location.search.web"
RUN dotnet build "location.search.web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "location.search.web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "location.search.web.dll"]
