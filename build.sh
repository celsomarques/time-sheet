cd src/time-sheet
dotnet restore
dotnet lambda package --configuration release --framework netcoreapp2.1 --output-package bin/Release/netcoreapp2.1/deploy-package.zip
