FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Employee.API/Employee.API.csproj", "Employee.API/"]
COPY ["../Employee.Core/Employee.Core.csproj", "Employee.Core/"]
COPY ["Employee.Infrastructure/Employee.Infrastructure.csproj", "Employee.Infrastructure/"]

RUN dotnet restore "Employee.API/Employee.API.csproj"

COPY . .
WORKDIR "/src/Employee.API"
RUN dotnet publish "Employee.API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "Employee.API.dll"]
