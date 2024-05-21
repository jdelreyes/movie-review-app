# Review App

## Installation

### Locally

1. Pull MS SQL Server Docker Image and run it as a container

   ```shell
   docker-compose -f docker-compose-local.yml up -d
   ```

2. Apply Migration/s

   ```shell
   dotnet ef database update
   ```

3. Run the app with your favourite IDE

### Docker

1.  ```shell
    docker-compose up -d
    ```
