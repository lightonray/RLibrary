#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src


COPY ["RLibrary.Web/RLibrary.Web.csproj", "RLibrary.Web/"]
COPY ["RLibrary.Infrastructure/RLibrary.Infrastructure.csproj", "RLibrary.Infrastructure/"]
COPY ["RLibrary.Application/RLibrary.Application.csproj", "RLibrary.Application/"]


RUN dotnet restore "RLibrary.Web/RLibrary.Web.csproj"

COPY . .
WORKDIR "/src/RLibrary.Web"

RUN dotnet build "RLibrary.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RLibrary.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:5000

EXPOSE 5000

ENTRYPOINT ["dotnet", "RLibrary.Web.dll"]