#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["StudentJournalManager.App/StudentJournalManager.App.csproj", "StudentJournalManager.App/"]
RUN dotnet restore "StudentJournalManager.App/StudentJournalManager.App.csproj"
COPY . .
WORKDIR "/src/StudentJournalManager.App"
RUN dotnet build "StudentJournalManager.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudentJournalManager.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentJournalManager.App.dll"]