#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["E-CODING-MVC-NET6-0/E-CODING-MVC-NET6-0.csproj", "E-CODING-MVC-NET6-0/"]
COPY ["4 - E-CODING-DAL/E-CODING-DAL.csproj", "4 - E-CODING-DAL/"]
COPY ["E-CODING-Service-Abstraction/E-CODING-Service-Abstraction.csproj", "E-CODING-Service-Abstraction/"]
COPY ["E-CODING-Services/E-CODING-Services.csproj", "E-CODING-Services/"]
RUN dotnet restore "E-CODING-MVC-NET6-0/E-CODING-MVC-NET6-0.csproj"
COPY . .
WORKDIR "/src/E-CODING-MVC-NET6-0"
RUN dotnet build "E-CODING-MVC-NET6-0.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "E-CODING-MVC-NET6-0.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "E-CODING-MVC-NET6-0.dll"]