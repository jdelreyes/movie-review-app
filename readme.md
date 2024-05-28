# Review App

## Overview

A simple movie review app utilizing .NET Web APIs and a SQL Server.
It features RESTful api and a clean, organized folders for separation of concerns.
While practicing using the technology, I learned that .NET is very similar to Spring with minor differences of implementation.

## Installation

### Locally

1. Pull SQL Server Docker image and run it as a container.

   ```shell
   docker-compose -f docker-compose-local.yml up -d
   ```

2. Apply migrations.

   ```shell
   cd ReviewApp
   dotnet ef database update
   ```

3. Run the app using your favourite IDE.

### Docker

1. Pull a SQL Server and .NET docker images and run them as containers.
   
   ```shell
   docker-compose up -d
   ```

2. Apply migrations.

   ```shell
   cd ReviewApp
   dotnet ef database update
   ```

## Notes
> This app uses SQL Server Docker image since I use a mac, and it doesn't come with the database. However, you can use your own locally.

