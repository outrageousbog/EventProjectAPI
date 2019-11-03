FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["EventProject.csproj", "./EventProject"]
RUN dotnet restore "./EventProject.csproj"
COPY . .
RUN dotnet build "EventProject.csproj" -c Release -o /app

# # FROM microsoft/dotnet:2.2-sdk AS build-env
# # WORKDIR /app

# # # Copy csproj and restore as distinct layers
# # COPY EventProject/*.csproj ./EventProject/
# # RUN dotnet restore

# # # Copy everything else and build
# # COPY EventProject/. ./EventProject/
# # WORKDIR /app/EventProject
# # RUN dotnet publish -c Release -o out

# # # Build runtime image
# # FROM microsoft/dotnet:2.2-aspnetcore-runtime
# # WORKDIR /app
# # COPY --from=build-env /app/out .
# # CMD dotnet AspNetCoreHerokuDocker.dll


# # # # copy everything else and build app
# # # COPY aspnetapp/. ./aspnetapp/
# # # WORKDIR /app/aspnetapp
# # # RUN dotnet publish -c Release -o out


# # # FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
# # # WORKDIR /app
# # # COPY --from=build /app/aspnetapp/out ./
# # # ENTRYPOINT ["dotnet", "aspnetapp.dll"]

# FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
# WORKDIR /app

# # Copy csproj and restore as distinct layers
# COPY *.csproj ./
# RUN dotnet restore

# # Copy everything else and build
# COPY . ./
# RUN dotnet publish -c Release -o out

# # Build runtime image
# FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
# WORKDIR /app
# COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "EventProject.dll"]
