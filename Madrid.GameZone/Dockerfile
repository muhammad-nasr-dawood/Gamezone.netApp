# ───────────────────────────────
# STAGE 1: Build the application
# ───────────────────────────────
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory inside the container
WORKDIR /src

# Copy solution and project file for layer caching
COPY ["Madrid.sln", "."]
COPY ["Madrid.GameZone/Madrid.GameZone.csproj", "Madrid.GameZone/"]

# Restore dependencies
RUN dotnet restore "Madrid.GameZone/Madrid.GameZone.csproj"

# Copy everything (the full project directory)
COPY . .

# Publish the app to /app/publish
RUN dotnet publish "Madrid.GameZone/Madrid.GameZone.csproj" -c Release -o /app/publish

# ───────────────────────────────
# STAGE 2: Create runtime image
# ───────────────────────────────
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

WORKDIR /app

# Set environment (can be Development or Production)
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:80

# Copy the published app from the build stage
COPY --from=build /app/publish .

# Expose port 80 for the app
EXPOSE 80

# Run the application
ENTRYPOINT ["dotnet", "Madrid.GameZone.dll"]
