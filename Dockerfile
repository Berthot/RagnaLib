FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
 
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RagnaLib.API/RagnaLib.API.csproj", "PizzaSystemAPI/"]
RUN dotnet restore "RagnaLib.API/RagnaLib.API.csproj"
WORKDIR "/src/RagnaLib.API"
COPY . .
RUN dotnet build "RagnaLib.API/RagnaLib.API.csproj" -c Release -o /app/build
 
FROM build AS publish
RUN dotnet publish "RagnaLib.API/RagnaLib.API.csproj" -c Release -o /app/publish
 
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet RagnaLib.API.dll
