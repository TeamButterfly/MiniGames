
*** HUSK cd til BuisnessLogic projektet, da det er her DB arbejdet bliver lavet ***
cd .\BuisnessLogic\


--------------------------------------------------------------------------------------------------------------------------
/*
Når migrationsfilerne skal opdatere databasen, skal nedenstående kaldes. 
Dette er tilfældet hvis en anden udvikler har lavet en DB ændring, som så også skal virke hos den person der har pulled.
*/


dotnet ef database update
--------------------------------------------------------------------------------------------------------------------------

--------------------------------------------------------------------------------------------------------------------------
/*
Hvis man har lavet en DB ændring (Eks. oprettelse af tabel, ændring af tabel) så skal man tilføje migrationen
Det er ikke en ændring af databasen at tilføje data til tabellen, så i de tilfælde skal man ikke lave en migration
NAVN_PÅ_MIGRATION ændres blot til den DB ændring man har lavet (Tilføjet en bruger klasse eller andet?)
*/

dotnet ef migrations add NAVN_PÅ_MIGRATION
--------------------------------------------------------------------------------------------------------------------------

--------------------------------------------------------------------------------------------------------------------------
/*
Hvis man ikke har installeret "entity framework (ef)" til konsollen, kan det installeres via nedenstående
*/

dotnet tool install --global dotnet-ef
--------------------------------------------------------------------------------------------------------------------------