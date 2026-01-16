# UserManager

User Manager API with C# and EF

# Config instructions

## Add user-secrets (set env values)

`cd root-dir`  
`dotnet user-secrets init`  
`dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=...;Database=...;Username=...;Password=..."`

<small>Check new env variable:</small>  
`dotnet user-secrets list`

## Build docker image via Dockerfile

`cd root-dir`  
`docker build -t image-name .`

## Run PostgreSQL container

`docker run -d --name container-name -p 5432:5432 --env-file=.docker.env image-name`

### .docker.env file contains:

```
POSTGRES_DB=dbname
POSTGRES_USER=username
POSTGRES_PASSWORD=password
```

## Generate models via Scaffolding

- DefaultConnection => Env variable from user-secrets.
- Models => Output directory.
- UserDbContext => Manage communication between DB <=> App.

```
dotnet ef dbcontext scaffold "Name=DefaultConnection" Npgsql.EntityFrameworkCore.PostgreSQL -o Models -c UserDbContext
```
