# CompanyInterviewApi
Api for paired programming during interview process

Multiple solutions are available for working in .NET 6, .NET 5 and .NET Core 3.1.
Run `dotnet --version` and open the sln file for the latest matching version

The purpose of this API is to allow retrival of data of a given company and allows a compnay to buy another company.

This solution does not adhere to any standards and does not have any error handling or tests written against it. 
  
# Tasks

You must look to refactor the code in a way that it adheres to SOLID principals, follows a given design pattern and allows the code to be placed under test

Following on from that the code must do the following:

- Able to get a company by name or partial name
- 404 response codes introduced
- Ability to create a company
- Buyout correctly sets all values 
- Company should not be able to buy itself
- A company should not be able to buy one that doesn't exist
- A company who does not exist is not allowed to buy another company

All of these criteria should have tests against them


