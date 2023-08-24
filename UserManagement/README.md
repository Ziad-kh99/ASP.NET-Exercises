# User Management Quiz

## Introduction

In this exercise you have to extend a given ASP.NET Core API. The API is about *user and group management*.

The exercise's goal is to practice the following skills that you will need in the upcoming exam:

* Designing web APIs and data models
* Build non-trivial ASP.NET Core API controllers
* Writing non-trivial C# algorithms
* Claims-based authorization
* *Swagger* aka *Open API Specification*



## Requirements

### Levels

This exercise consists of multiple levels. The more levels you master the more understanding 
you get.

### Level 1: ASP.NET Core and EFCore Basics

* Build the EFCore data model so that the program also stores *groups* (i.e. user groups).
  * Each group must have a unique, numeric identifier (i.e. primary key).
  * Each group must have a name (mandatory, max. 100 characters long).
  * Each user can belong to 0..n groups.
  * Each group can have 0..n users as members.

* Design and build a web API controller for user management that supports the following operations:
  * Get details about the currently signed-in user (see comments about simulated authentication above).
    * The API has to return a JSON object containing the user's ID, name identifier, email, first name, and last name.
  * Get a list of all users.
    * The API has to return a JSON array containing all users. Each user must consist of the user's ID, name identifier, email, first name, and last name.
    * The API has to return an empty array if there are no users in the DB.

* Design and build a web API controller for group management that supports the following operations:
  * Get details about a single group.
    * The caller has to specify the ID of the group to return.
    * The API has to return *not found* if there is no group with the given ID.
    * If a group with the given ID exists, the API has to return a JSON object containing the groups's ID and name.
  * Get a list of all groups.
    * The API has to return a JSON array containing all groups. Each group must consist of the group's ID and name.
    * The API has to return an empty array if there are no groups in the DB.

### Level 2: More Advanced Web APIs

* Extend the web API for returning a list of all users.
  * The API has to accept a query-string parameter `filter`.
  * If given, only user must be returned where the given filter parameter is contained in the user's email **or** first name **or** last name.
  
* Add generation of *Swagger* aka *Open API Specification* to the ASP.NET Core project.
  * Tip: Use the *NSwag.AspNetCore* NuGet package for that.

### Level 3: More Advanced Data Model

* Extend your data model as follows:
  * In addition to all existing properties, each group can have 0..n *child groups* (i.e. recursive data structure).
  * Each group can have 0..1 parent groups.
  * You can assume that there will never be loops in group memberships (e.g. A is member of B, B is member of C, C is member of A). You do not need to handle such cases.

* Extend your web API controller for group management with the following operations:
  * Get all group members of a given group.
    * The caller has to specify the ID of the group to return.
    * The API has to return *not found* if there is no group with the given ID.
    * The API has to return a JSON array containing all groups that are members of the given group. Each group must consist of the group's ID and name.
    * The API has to return an empty array if there are no group members.

### Level 4: Non-Trivial Web API Algorithm

* Extend your web API controller for group management with the following operations:
  * Get all user members of a given group.
    * The caller has to specify the ID of the group to return.
    * The API has to return *not found* if there is no group with the given ID.
    * The API has to return a JSON array containing all users that are members of the given group. Each user must consist of the user's ID, name identifier, email, first name, and last name.
    * The API has to return an empty array if there are no user members.

* Allow the caller to specify a `recursive` parameter for the new web API. If it is `true`, the API does not only return direct members, but also users who are indirect members through nested group memberships.
  * Example:
    * Group *All*
    * Group *Management*, is member of *All*
    * User *Jane* is member of *Management*
    * User *John* is member of *All*
    * API would return only *John* for *All* if `recursive` is `false`.
    * API would return *John* and *Jane* for *All* if `recursive` is `true`.


## Side Notes:
### Prepare Database and use Reverse Engineering(scaffolding):
1. Create database: [`Create Database`](db/UserManagementQuizDB.sql)
2. Scaffold this database into your app: 
  - run in .NET/CLI: `dotnet ef dbcontext scaffold "Name=ConnectionStrings:UserManagement" Microsoft.EntityFrameworkCore.SqlServer --context AppDbContext --output-dir Models --context-dir Data --no-onconfiguring`



## Extra Points:
[] Separate entity types configuration into a separate class.
  - this separate class must inhert from interface `IEntityTypeConfiguration` and implement it.
  - then, call grouping configuration using the Assembly in `OnModelCreating` method.
