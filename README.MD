# VATSIM Data with ENTITY FRAMEWORK CORE

This program creates a library and client to fetch and load [VATSIM](https://www.vatsim.net/) flight data into a [SQLite database](https://sqlite.org/index.html) using [EntityFramework Core](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/3.1.9).

We'll be able to review the data directly, and even double-check with SQL queries, using the [DB Browser for SQLite](https://sqlitebrowser.org/).

We'll also develop some comfort with pushing our code to Github for [source code management](https://en.wikipedia.org/wiki/Version_control).

## Library

The lirbary reads from a text file on the Internet/WWW every two minutes and writes data to the database.  We can then query the database to answer a few basic questions.  We also collect [METAR](https://en.wikipedia.org/wiki/METAR) and Vatsim User (Pilots and Controllers) information.

## Client

We will query for airports or aircraft to find flights where we can then view some basic data about those flights.

## HW

A brief demonstration of the first homework assignment that used this project.

## API

HTTP endpoints are provided to provide text output for various queries.  A precursor to a proper REST api.

# How to Run

1. You always want to run the `client` app a few times to get some data into the database or update the database.
    1. If this is your first time running the application, you must first run `dotnet ef database update` from within the `library` project
    2. Because the client program and library are separated, you must specify a startup project: `dotnet ef database update --startup-project ..\client\client.csproj`
2. Once the database is taken care of, you can run the client like this: `dotnet run {number_of_minutes}`
    1. that `{number_of_minutes}` indicates that you should pass the total number of minutes you'd like client to run (not to exceed 10)
    2. Here is how you'd call it: `dotnet run 5` for 5 minutes
    3. Each **pass** through the program takes around 2 minutes, once that time expires, another **pass** commences
3. The **hw** project was created to demonstrate LINQ queries against the database
4. The **api** project was created to demonstrate using HTTP Endpoints to request data to the browser that also uses LINQ queries.
5. Each project - **client**,**hw**,**api** - must be run from within their own project folder.

## Entity Framework Core

Follow the steps in this tutorial carefully: [Getting Started with EF Core](https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=netcore-cli)

In general, the concepts of [Entity Framework as an Object/Relational Mapper](https://docs.microsoft.com/en-us/ef/core/) are also mentioned in Microsoft's documentation.  You can read more on the [basics of Object-Relational Mapping here too](https://en.wikipedia.org/wiki/Object%E2%80%93relational_mapping).

* **Install EF Core from Nuget** `dotnet add package Microsoft.EntityFrameworkCore.Sqlite`
* **Install Tooling** `dotnet tool install --global dotnet-ef`
* **Install Design Package** `dotnet add package Microsoft.EntityFrameworkCore.Design`
* **Create Migration** `dotnet ef migrations add InitialCreate`
* **Make changes to database** `dotnet ef database update`

These are generalized steps and not the steps required to run my code, those steps are covered below.

## Working with this code.

First, let's discuss some pre-requisites. You need [Git for Windows](https://git-scm.com/download/win) or for [Mac OSX](https://git-scm.com/download/mac).

Also, you need a Github account.  Do so with your student emaila address to enjoy the additional advantages of the [GitHub Student Development Pack](https://education.github.com/pack).

When you navigate to my code repository on Github, you have two choices on how to obtain it.  You can see some of these in this image:

![Github choices](https://i.imgur.com/foGC8s8.png)

To clone, you would create a directory where you want to keep the code you download from me and then from a command-line interface (PowerShell, CMD, or Git-Bash), you would run this command:

`git clone https://github.com/ahuimanu/CIDM3312.git`

Or, you can simply download the ZIP as you can see in the picture above.  A third option is to use Github Desktop which is a more familiar GUI interface.

Once you have cloned or downloaded this code, here are the basic steps to make it work:

1. In VS Code, navigate to the place that you've cloned or downloaded the file
1. Navigate into the `VATSIMData\client` directory and type `dotnet restore`
1. Navigate into the `VATSIMData\library` direcotyr and type `dotnet restore`
1. Ensure that you've installed the dotnet entity framework tooling as mentioned above: `dotnet tool install --global dotnet-ef`
1. While still in the `library` directory, run `dotnet ef database update --startup-project ../client/client.csproj`
1. You can then run my project from the client folder: `dotnet run 5`
1. the extra number in the program is the number of minutes the program should run

## What does this do? What is it?

Every two minutes, VATSIM publishes a list of 
* who is connected to the network
* what role they are connected as: Pilot or Controller
* various other data pertinent to those roles
    * Controllers have a fequency and position they occupy
    * Pilots have a callsign and flight plan if they are operating as Instrument Pilots.
    * Each record shows the latitude and longitude of where this pilot is at in the virtual world that corresponds to the real world.

This program downloads that list, parses it, and then creates data objects for the following types:

* Pilots
* Controllers
* Flights
* Pilot Positions (a snapshot of where they are and how state their flight is in (speed, altitude, direciton, etc.))

That's it, I simply organize and collect this information.

# Your Assignment

Both in Chapter 17 of Freeman's book and also in my own code, I demonstrate the use of Entity Framework for working with databases in ASP.NET Core.

After you've run my program a few times, you have enough data stored in the `VATSIMData\client\vatsim.db` database to query against.

I would like for you to write a console application that connects to this database and answers the following queries?

1) Which pilot has been logged on the longest?
2) Which controller has been logged on the longest?
3) Which airport has the most departures?
4) Which airport has the most arrivals?
5) Who is flying at the highest altitude and what kind of plane are they flying?
6) Who is flying the slowest (hint: they can't be on the ground)
7) Which aircraft type is being used the most?
8) Who is flying the fastest?
9) How many pilots are flying North? (270 degrees to 90 degrees)
10) Which pilot has the longest remarks section of their flight?

All of these require LINQ queries. 

Further you'll need to use both Chapter 17, my code, and this tutorial to help you develop your own client application that can read the VatsimCientPilot, VatsimClientController, VatsimClientPlannedFlight, and VatsimClientPilotSnapshot records from the `vatsim.db` file to answer these questions.  The more times and longer you run my program, the greater amout of data you will collect in the vatsim.db file.

Don't forget my hint above that you can use the [DB Browser for SQLite](https://sqlitebrowser.org/) to review the contents of the `vatsim.db` file after you've run my program.

## Video

I will follow this up with an orientation video soon, but I wanted to get you started.  The dropbox for this will be in Blackboard.

# Using ASP.NET Core Platform Features to Work with this data

Part II of Freeman's book discusses some of the basic mechanics of how an HTTP Request and Response work within ASP.NET.

I have created Request/Response Endpoints similar to chapters 12-14.

For Flights, I have created the following endpoints:

* `/flights/type/{type}` - where `{type}` is a placeholder/segment for an aircraft type code (common: A320, B738, B77L, A319, B737)
* `/flights/departure/{departure}` - where `{depature}` is a placeholder/segment for an the departure airprt (common: EDDF, EGGL, KATL, KLAX, RJAA)
* `/flights/destination/{destination}` - where `{destination}` is a placeholder/segment for an the destination airprt (common: EDDF, EGGL, KATL, KLAX, RJAA)

# Using ASP.NET MVC/RazorPages to Work with this data


