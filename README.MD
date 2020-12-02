```bash
docker-compose up --build -d
```

Bug ao executar as Migrations, será necessário realizar executar o build quando o banco subir

```bash
docker-compose up --build -d api
```

Executar a interface
```bash
dotnet run src/Edialsoft.UI/Edialsoft.UI.csproj
```

API - http://localhost:3698/api/v1/Person/

DB  - 3305