
# Employee Management API

This API is responsible for managing employees within the company. The "Servem" endpoints are used for sending and requesting information, while "Siga" contains the instructions for running projects.

## Prerequisites

To run this project, you need the following prerequisites:

- **Docker**: To manage the MySQL database in a container.
- **.NET 8**: The latest version of .NET, required to run the application.
- **Visual Studio or another IDE**: Used to open and edit the source code of the application.

## Docker Configuration

This project uses Docker to run the MySQL database in a container. Follow the instructions below to set up the container:

1. Access the `db` folder in the repository.
2. Run the following command to start the container:
   ```bash
   docker-compose up -d
   ```
3. Wait for Docker to initialize the database.
4. If the command runs successfully, you can access the database using a database management tool (like DBeaver or MySQL Workbench).

### Database Initialization

To set up the database and ensure it's ready for use, follow the steps below to run the migrations:

1. **Create a new migration**:

   When you add or modify the database structure (such as creating new tables or columns), use the following command to generate a migration:

   ```bash
   dotnet ef migrations add MigrationName --project ../infra --startup-project .
   ```

   Replace `MigrationName` with a name that describes the changes you made (e.g., `UpdatingColumns`).

2. **Update the database with the migrations**:

   After creating the migration, apply the changes to the database by running:

   ```bash
   dotnet ef database update --project ../infra --startup-project .
   ```

3. **Remove the last migration**:

   If you made a mistake and want to remove the last migration, use the following command:

   ```bash
   dotnet ef migrations remove --project ../infra --startup-project .
   ```

4. **Check the migration status**:

   To list all applied or pending migrations, run:

   ```bash
   dotnet ef migrations list --project ../infra --startup-project .
   ```

5. **Apply a specific migration**:

   If you want to apply a specific migration instead of all pending migrations, run:

   ```bash
   dotnet ef database update MigrationName --project ../infra --startup-project .
   ```

   Replace `MigrationName` with the name of the migration you want to apply.

6. **Revert to a previous migration**:

   If you need to revert to a previous migration, use the following command:

   ```bash
   dotnet ef database update PreviousMigrationName --project ../infra --startup-project .
   ```

   Replace `PreviousMigrationName` with the name of the migration you want to revert to.

---
