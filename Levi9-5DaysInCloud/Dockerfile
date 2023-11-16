#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Levi9-5DaysInCloud/Levi9-5DaysInCloud.csproj", "Levi9-5DaysInCloud/"]

RUN dotnet restore "Levi9-5DaysInCloud/Levi9-5DaysInCloud.csproj"
COPY . .
WORKDIR "/src/Levi9-5DaysInCloud"
RUN dotnet build "Levi9-5DaysInCloud.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Levi9-5DaysInCloud.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Levi9-5DaysInCloud.dll"]