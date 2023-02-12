# XPAND Coding Challenge

## Description

The purpose of the application is to keep track of the status of each expedition of the 
human race that traverses multiple unknown solar systems in order to find life.

## Getting Started

### Prepare the data

* Create database structure - to create the tables to store the application's data we first need 
to run on the local MS SQL Server the query from the "TableCreation.txt" file found in this repository;

* Populate tables - after creating all the tables, repeat the process by running the inserts from the "PopulateTables.txt" file;

* Create user accounts - the final step consists in running the XPandAuthentication project and using Swagger to create some
user accounts. By using the register API exposed by swagger, insert all the users found in the "userCreationSwagger.txt" file.

### Configuration

* Configure the connection string in the appsettings.json

* Configure the ports for the projects: 
XPandAuthentication - https 6200 - http 6201,
XpandCrewAPI - https 7200 - http 7201,
XpandPlanetAPI - https 8200 - http 8201

### Starting the application

* Start all projects from the XPandAPI solution

* Run the following command to start the Angular app
```
ng serve
```
