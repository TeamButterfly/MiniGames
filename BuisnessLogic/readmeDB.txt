
*** HUSK cd til BuisnessLogic projektet, da det er her DB arbejdet bliver lavet ***
cd .\BuisnessLogic\



//AUTOMATISK
--------------------------------------------------------------------------------------------------------------------------
/*
 Kør update script, så bliver alle DB opdateret
*/

.\updateDB.ps1
--------------------------------------------------------------------------------------------------------------------------










//MANUELT
--------------------------------------------------------------------------------------------------------------------------
/*
Hvis man ikke har installeret "entity framework (ef)" til konsollen, kan det installeres via nedenstående
*/

dotnet tool install -g dotnet-ef
--------------------------------------------------------------------------------------------------------------------------

--------------------------------------------------------------------------------------------------------------------------
/*
Når migrationsfilerne skal opdatere databasen, skal nedenstående kaldes. 
Dette er tilfældet hvis en anden udvikler har lavet en DB ændring, som så også skal virke hos den person der har pulled.
*/

dotnet ef database update --context DatabaseContext
dotnet ef database update --context TestDatabaseContext
--------------------------------------------------------------------------------------------------------------------------

--------------------------------------------------------------------------------------------------------------------------
/*
Hvis man har lavet en DB ændring (Eks. oprettelse af tabel, ændring af tabel) så skal man tilføje migrationen
Det er ikke en ændring af databasen at tilføje data til tabellen, så i de tilfælde skal man ikke lave en migration
NAVN_PÅ_MIGRATION ændres blot til den DB ændring man har lavet (Tilføjet en bruger klasse eller andet?)
*/

dotnet ef migrations add NAVN_PÅ_MIGRATION --context DatabaseContext
dotnet ef migrations add NAVN_PÅ_MIGRATION --context TestDatabaseContext
--------------------------------------------------------------------------------------------------------------------------