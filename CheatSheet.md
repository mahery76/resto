- dotnet new webapi -n resto.api --no-openapi -controllers 
- dotnet new sln -n resto
- dotnet sln add ./resto.api

- creation des dossiers pre, appli, dom, infra
- referencement 
- installing packages 



- dotnet build

# generate migration file
- dotnet ef migrations add UpdateCommande --startup-project ./resto.api --project ./resto.infrastructure

# apply migrations
- dotnet ef database update UpdateCommande --startup-project ./resto.api --project ./resto.infrastructure

# remove the last migration file 
- dotnet ef migrations remove --startup-project ./resto.api --project ./resto.infrastructure

- dotnet run





Steps for addin new entities: 
domain
- entity file
- repository for the entity

application
- contract
- service

Infrastructure
- context
- repository

Presentation
- controller
- program.cs


