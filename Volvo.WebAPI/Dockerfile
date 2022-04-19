#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Volvo.WebAPI/Volvo.WebAPI.csproj", "Volvo.WebAPI/"]
RUN dotnet restore "Volvo.WebAPI/Volvo.WebAPI.csproj"
COPY . .
WORKDIR "/src/Volvo.WebAPI"
RUN dotnet build "Volvo.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Volvo.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Volvo.WebAPI.dll"]