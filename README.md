# Tenant Management System
## Logical architecture
Logically, our solution is divided into five projects. The following is the architecture
diagram showing how each project is lined up and represents each layer of the layered
architecture:

* **Common layer:** The common layer project is a .NET Core class library project and we have named it
EA.TMS.Common. This is shared between all the layers.
* **Data access layer:** The data access layer project is named EA.TMS.DataAccess. This will be the .NET Core
class library project. In this project, we will implement Repository and Unit of Work
patterns and define our custom Data Context class to use with Entity Framework Core.
* **Business layer:** The business layer project is named EA.TMS.Business. This is a .NET Core class
library project and contains business manager classes to implement business requirements.
This will call the data access layer to perform the CRUD operations.
* **Service layer:** The service layer project is named as EA.TMS.ServiceApp. This is an ASP.NET Core
project and contains Web APIs. This is also protected using CAS. This service layer interacts
with the BL (business layer) to perform business functionality.
* **Presentation layer:** Web application project is named as EA.TMS.WebApp. This is an ASP.NET Core project and
contains views, Angular components, and TypeScript files to interact with the service layer
to perform HTTP operations. It also provides user authentication using the CAS
(centralized authentication system) system.
