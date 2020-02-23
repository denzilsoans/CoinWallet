# Coin Wallet

This Application is a Simple Coin Wallet that supports common wallet functions such as Credit,Debit and Balance Checks. 

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
3. Run the command **docker-compose up --build**. This will download the necessary images and run the containers necessary.
4. Wait for step 3 to complete and the message "Now listening on: http://0.0.0.0:7888" to be displayed.
5. Now we can run the tests in postman(https://www.getpostman.com/) to verify that the service is working as intended. 
   Use the file **VGW LND-Web-API.postman_collection_7888.json** to import and test the wallet actions.
