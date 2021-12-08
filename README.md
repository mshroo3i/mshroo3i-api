[![deploy_to_webapps](https://github.com/mshroo3i/mshroo3i-api/actions/workflows/push-to-acr.yml/badge.svg)](https://github.com/mshroo3i/mshroo3i-api/actions/workflows/push-to-acr.yml)

# TODO

* [x] Finalize DB Context
* [x] build docker compose
* [x] Generate initial script
* [x] apply db
* [x] build seed
* [ ] build test
* [ ] build

# Commands

## EF Core

```
dotnet-ef dbcontext script

dotnet-ef migrations add <NAME>

dotnet-ef database update
dotnet-ef database drop
```

## MSI

```sql
CREATE USER [Db Read Write Access] FROM EXTERNAL PROVIDER;
ALTER ROLE db_datareader ADD MEMBER [Db Read Write Access];
ALTER ROLE db_datawriter ADD MEMBER [Db Read Write Access];

SELECT name, type, type_desc, CAST(CAST(sid as varbinary(16)) as uniqueidentifier) as appId
from sys.database_principals
    GO

select m.name as Member, r.name as Role
from sys.database_role_members
         inner join sys.database_principals m on sys.database_role_members.member_principal_id = m.principal_id
         inner join sys.database_principals r on sys.database_role_members.role_principal_id = r.principal_id
```
