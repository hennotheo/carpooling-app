cd CarPoolingAPI/CarPoolingAPI
dotnet restore
dotnet build
dotnet publish -c Release -o ../publish

cd ../publish

# Ensure HTTPS is enabled by setting ASP.NET Core environment variables
export ASPNETCORE_HTTPS_PORT=5001
export ASPNETCORE_URLS=http://localhost:5000
export ASPNETCORE_ENVIRONMENT=Development

dotnet CarPoolingAPI.dll