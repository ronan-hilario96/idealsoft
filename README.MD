```bash
docker-compose up --build -d
```


API - http://localhost:3698/api/v1/Person/

DB  - 3305

```bash
dotnet run src/Edialsoft.UI/Edialsoft.UI.csproj
```

Bug ao executar as Migrations

Build só o container da api com

```bash
docker-compose up --build -d api
```