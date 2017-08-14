# ASP.NET-BookPlatform-demo

**Beschrijving:** Een demo webapplicatie waarbij ik een Code-First project opzet met het Entity framework. Ik maak gebruik van een many-to-many, one-to-many en one-to-one relatie om code te demonstreeren met het repository pattern en Unit of Work. Dit is geen "must" voorstelling voor eenvoudige websites, maar een voorstelling van een "groot" ASP.NET project waar een goede code-structuur van groot belang is.

**Note:** Aangezien de nadruk ligt op de code-structuur, heb ik de views eenvoudig gehouden.
- - - -
### Gebruikte technologie ###
* ASP.NET MVC
* Entity framework (Code-First)
* Fluent API
* Web API
* Office Word Add-in
* LINQ extenstion methods
* Entity Configurations voor het overschrijven van de Code-First conventions
* Migrations
* Repository pattern met Unit of Work
* CORS (Cross-Origin Resource Sharing)
* (Bootstrap)
- - - -
### Gebruikte software/tools ###
* Visual Studio (2017)
* ReSharper 
* Productivity Power Tools 2017
* Web Essentials 2017
- - - -
### Code/asset beschrijving ###

#### BookPlatform project ####

Bestanden/map  | Beschrijving
------------- | -------------
Context/* | Context klasse
Controllers/*  | Controllers
Controllers/Api/*  | Web API Controllers
EntityConfigurations/*  | Fluent API configuratie (overschrijven van "Convention over configuration")
Migrations/Configuration.cs  | Om data te genereren via het "update-database" command
Models/*  | Model klassen
Repositories/*  | Repository klassen
- - - -

#### AuthorAddIn project ####

**Beschrijving:** Office Word Add-in waarbij er data kan opgehaald worden via de API.

