FROM mcr.microsoft.com/dotnet/sdk:5.0 AS publish
WORKDIR /app
# Copy everything and build
COPY . ./

RUN dotnet restore "./TestMongo.csproj"
RUN dotnet publish "TestMongo.csproj" -c Release -o out

FROM  mcr.microsoft.com/dotnet/aspnet:5.0 AS final
WORKDIR /app
COPY --from=publish /app/out .

ENTRYPOINT ["dotnet", "TestMongo.dll"]