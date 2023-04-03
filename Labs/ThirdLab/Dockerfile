FROM mcr.microsoft.com/dotnet/sdk:6.0

WORKDIR /app

EXPOSE 8888

COPY . .

RUN dotnet restore

RUN dotnet build -c Release

CMD ["dotnet", "run"]