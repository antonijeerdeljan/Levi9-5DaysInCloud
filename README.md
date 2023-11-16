# Levi9-5DaysInCloud

Potrebno je instalirati .NET SDK i Docker,
Opcija A:
Pozicionirati se u "Levi9-5DaysInCloud" folder i pokrenuti build "dotnet build Levi9-5DaysInCloud.csproj",
Pokrenuti pomoću komande "dotnet run", za lakše testiranje moguće je takođe pokrenuti putem "dotnet run --environment Development" što će otvoritit swagger na localhost-u,
Opcija B:
Pokrenuti "docker compose up --build" u Levi9-5DaysInCloud folderu, swaggeru je moguće pristupiti na localhost:4300/swagger

Za parsiranje CSV fajla sam korostio sam CsvHelper biblioteku, za testiranje sam koristio XUnit Framework
i NSubstitute za mock-ovanje
