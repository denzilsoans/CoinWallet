# Coin Wallet

Simple Coin Wallet API that supports common wallet operations such as Credit,Debit and Balance Checks. 

## Tools & Technologies
1. ASP.NET Core 3.1
2. ASP.NET Web API 5.2
3. ORM - Entity Framework Core 3.1
4. Database - SQL Server
5. Containerized with Docker
6. Code Editor - Visual Studio 2019 

## Set-Up
1. Download the entire codebase to your local system.
2. Open the command line prompt and navigate to the root folder containing the solution file.
3. Run the command **docker-compose up --build**. This will download the necessary images and run the containers.
4. Wait for step 3 to complete, the prompt should display "Now listening on: http://0.0.0.0:7888".
5. Now run the tests using postman(https://www.getpostman.com/) to verify that the service is working as intended. 
   Use the file **Postman_Test_7888.json** to import and test the wallet actions.
   
## Other Tests
1. Unit Tests for the project is available in the project "CoinWallet.DomainModel.Tests". 
   Run command **dotnet test --no-build** to execute the tests
2. Code Coverage Report can be run using the below command after navigating test project folder
   **dotnet test /p:CollectCoverage=true /p:CoverletOutput=TestResults/ /p:CoverletOutputFormat=lcov**
