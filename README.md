# ProjectManager
ASP.NET Core alapú webes munkaidő nyilvántartó rendszer. A korábban (~2016) általam készített frontend projekt "fölé" készült update-elt backend.
 
![App image](https://raw.githubusercontent.com/gaaaron/ProjectManager/master/project_manager.gif)

## Alkalmazott technológiák a backend területen

* [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1) - REST api kialakítása a ProjectManager.RestApi projekten belül
* [Microsoft.Extensions.DependencyInjection](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1/) - Függőségek kezelése
* [SqLite](https://www.sqlite.org/index.html/) - Adatbázis-kezelő rendszer
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/) - ORM mapper (SQLite-ot is támogat), ProjectManager.Dal projektben
* [NLog](https://nlog-project.org/) - Logolás
* [AutoMapper](https://github.com/AutoMapper/AutoMapper/) - Entitás osztályok és DTO osztályok közötti mappalés
* [JSON Web Token](https://jwt.io/introduction/) - Felhasználók authorizációja

## Frontend projekt

ProjectManager.RestAPI/wwwroot mappán belül. AngularJS és Bootstrap technológiát használ.
