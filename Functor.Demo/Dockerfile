FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Functor.Demo/Functor.Demo.csproj", "Functor.Demo/"]
RUN dotnet restore "Functor.Demo/Functor.Demo.csproj"
COPY . .
WORKDIR "/src/Functor.Demo"
RUN dotnet build "Functor.Demo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Functor.Demo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Functor.Demo.dll"]