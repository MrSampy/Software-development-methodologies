# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build

WORKDIR /app

COPY . .

RUN dotnet restore

RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/runtime:6.0-alpine AS runtime

WORKDIR /app

COPY --from=build /app/out .

RUN apk add curl

CMD ["dotnet", "ThirdLab.dll"]