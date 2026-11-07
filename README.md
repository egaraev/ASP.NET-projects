# ASP.NET Projects

Archive of my early ASP.NET WebForms / C# / SQL Server projects, moved from local repositories to GitHub. They are legacy code (Visual Studio 2010 era, written between 2011 and 2014 alongside my datacenter engineering work, before I moved into cloud and DevOps) and are kept as a record of my early software work, not as maintained software.

| Project | Year | What it is | Domain | UI language |
|---|---|---|---|---|
| [Software_for_couriers_and_parcels](./Software_for_couriers_and_parcels) | ~2011 | Order log built for ARS, a logistics company in Baku | Logistics | Russian |
| [Feedration](./Feedration-My_Final_Year_Project) | 2012 | Livestock feed ration calculator (university final-year project) | Agriculture | English |
| [azagrotech.com](./www.azagrotech.com) | ~2013 | Multilingual company website with a database-driven CMS and the feed calculator embedded | Agriculture / web | Russian, Azerbaijani (English column in DB) |
| [agrosoft](./agrosoft) | 2014 | Internal sales and production tracking for manufactured machinery (Agro.az) | Manufacturing / back office | Russian |

## Common stack

- ASP.NET WebForms with C# code-behind, master pages, GridView / SqlDataSource data binding
- Microsoft SQL Server (schema scripts in `SQL.txt` / `ARS_SQL.txt` in each project)
- ADO.NET (`SqlConnection`, `SqlCommand`) with parameterised queries for most inserts, updates and deletes
- Forms authentication, with the user ID and role carried in the auth cookie (`AuthCookieParse.cs`)
- Third-party UI components of the time: Telerik RadControls (Calendar, Editor), FCKeditor, Lightbox JS
- Visual Studio 2010 solutions (`.sln`)

---

## 1. Feedration – feed ration calculator (final-year project, 2012)

A web application that helps a farmer or livestock keeper work out a feeding ration for a herd, based on the animals, the growth target and the feed available on the farm.

**Roles** (set in `Web.config`, forms authentication + membership):

- **administrator** (`Admin.aspx`) manages the reference data (see below)
- **farmer** (`farmer.aspx`) records the farm and the feed stock
- **takecarer** (`Takecarer.aspx`) runs the ration calculation

**Reference data managed by the administrator:** feed categories and feeds with nutrient values (dry matter, crude fibre, protein, energy, Ca, P), animal groups / breeds, age groups, weight groups, growth targets (category, name, value), feeding tables (nutrient requirements per animal and target, by season and keeping type), and the concentrate / roughage / succulent ratio (`FEEDRATIO`). Each has its own `*mgmt.aspx` page.

**Calculation (`Takecarer.aspx.cs`):**

1. The user picks an animal herd, a growth target, a season and a ration group, then selects up to five feeds with weights.
2. The code requires feeds from at least two different categories.
3. It loads the nutrient requirement (`ENERGYCHANGE`) and the concentrate / roughage / succulent split (`FEEDRATIO`), plus the nutrient content of the chosen feeds.
4. It sums energy, dry matter, crude fibre, protein, Ca and P for each feed group (concentrate, roughage, succulent), applies the ratio coefficients and the animal quantity, and shows the required weight of each feed plus a total. If a group has no suitable feed selected, it prompts the user to add one from that category.

**Data model (abridged):** `USERS` / `USER_GROUP`, `FEED` / `FEEDCATEGORY`, `ANIMALS` (group + weight + age), `TARGETINCREASE` (category + name + value), `ENERGYCHANGE` (requirements), `FEEDRATIO`, `ANIMALFEEDTYPE` (which feeds suit which animal group), `FARM` (herd per user), `FEED_STOCK` (feed per user).

**Run it:** create a SQL Server database, run `SQL.txt` (it needs small fixes first: `FEEDRATIO` has to be created before `ENERGYCHANGE`, and `FARM` is missing a comma), set the `DBpath` and `ConnectionString` connection strings in `www/Web.config`, then open `www/` in Visual Studio 2010 or later (.NET 4.0) and run with IIS Express. Seed the reference data through the admin pages.

---

## 2. azagrotech.com – company website with CMS (~2013)

Public website of an agricultural company, with content stored in the database instead of static pages.

- **Three-level content model:** `HEADERS` (top menu and header text), `MENU` (sub-menu under each header) and `CONTENT` (page body for each menu item).
- **Languages:** every table has Russian (`NAMERU`), Azerbaijani (`NAMEAZ`) and English (`NAMEEN`) columns. The master page switches language through links and builds the menu and content queries from the chosen language (`MasterPage.master.cs`).
- **Admin area (`/admin`):** after login the editor can add headers and sub-menus and edit page content with a WYSIWYG editor (FCKeditor / RadEditor). `Contentheader.aspx` and `Contentmenu.aspx` edit headers and menu content.
- **Embedded calculator:** `farmer.aspx` contains the feed-ration calculator from Feedration for the site's farmer users.
- `www/db_scripts/*.docx` hold the SQL for the CMS tables; `SQL.txt` holds the farm and ration tables.

**Run it:** create the database, apply the SQL from `SQL.txt` and `db_scripts`, update the `CS` connection string in `www/web.config`, open `azagrotech.com.sln` in Visual Studio.

---

## 3. agrosoft (Agro.az) – sales and production tracking (2014)

Internal tool for a company that builds and sells machinery. It tracks what was made, for whom, at what cost and on what warranty.

- **Products:** model, category, serial number, price, own cost, cost for client, build time in days, warranty, date sold, technical data (height, weight, voltage, RPM, throughput in kg/h, engine power, hammer count), comment, and up to five photos stored under `files/fotos/<id>/`.
- **Customers** (name, phone, address), **product categories**, **users** with roles (`ROLES` / `USERS`).
- **Soft delete:** the `ACTIVE` flag on categories, customers and products hides records instead of removing them.
- **Login and roles:** `Default.aspx` checks the login against `USERS` / `ROLES`, stores the user ID, name and role in the forms-auth cookie, and redirects to `Products.aspx`. `Products.aspx` has an admin grid (serial, client, category, date sold, price) and a per-client grid. `Prodadminfo.aspx` shows the cost and technical details. `Fotos.aspx` displays the product photos.
- `DB_Design.jpg` is the database diagram.

**Run it:** create a database, run `SQL.txt`, set the `CS` connection string in `web.config`, create the `files/fotos` folder, open `Agro.az.sln`.

---

## 4. Software for couriers and parcels (ARS, ~2011)

A single-page order log built for ARS, a logistics company in Baku (`ARS/Default.aspx`). Chronologically the first of the four.

- Records each order: date and time, company, consignment number (`CN`), number of pieces, address, phone, client name, local or international flag, type and destination.
- Filters the list by year and month, with a calendar picker (Telerik RadCalendar) for the date.
- Add, edit and delete orders in a GridView.
- A single `ORDERS` table (`ARS_SQL.txt`).

**Run it:** create a database, run `ARS_SQL.txt`, set the `CS` connection string in `ARS/web.config`, open `ARS/ARS.sln`.

---

## Known limitations

This is old student and early-career code. If any of it were reused today, these would need to be fixed first:

- Some queries are built with `string.Format` instead of parameters (for example in `Takecarer.aspx.cs` and `farmer.aspx.cs`), which is open to SQL injection.
- The `agrosoft` login compares plain-text passwords stored in the `USERS` table. Passwords should be hashed and salted.
- No automated tests, no CI, and no documented deployment. Calculation and page logic live in code-behind files.
- The Telerik, FCKeditor and .NET 2.0 / 4.0 components are long out of support.
- Some code-behind files contain commented-out code and debugging leftovers.

## Author

Eldar Garayev – [github.com/egaraev](https://github.com/egaraev)
