# ModularMonolith.Api Overview

The ModularMonolith.Api provides a comprehensive set of endpoints to manage companies, their employees, and visitor interactions through visits. This API is designed to handle CRUD (Create, Read, Update, Delete) operations for companies and employees, as well as manage visit sign-ins and sign-outs.
## Company Management

The API allows users to retrieve, create, update, and delete company records.

Retrieve all companies: \
The GET `/api/companies` endpoint fetches a list of all companies. This allows users to see all the companies currently stored in the system.

Create a new company: \
The POST `/api/companies` endpoint allows users to create a new company by providing the necessary details in the request body. This endpoint is used to add new companies to the system.

Retrieve a specific company by ID: \
The GET `/api/companies/{id}` endpoint fetches the details of a specific company identified by its unique ID. This is useful for viewing the information of a particular company.

Update a specific company by ID: \
The PUT `/api/companies/{id}` endpoint updates the details of a specific company identified by its ID. Users can modify the company's information using this endpoint.

Delete a specific company by ID: \
The DELETE `/api/companies/{id}` endpoint deletes a company identified by its ID. This endpoint is used to remove a company from the system.

## Employee Management within Companies

The API also provides endpoints to manage employees within a company.

Add a new employee to a company: \
The POST `/api/companies/{id}/employee` endpoint allows users to add a new employee to the specified company. Users must provide the employee's details in the request body.

Update a specific employee of a company: \
The PUT `/api/companies/{id}/employee/{employeeId}` endpoint updates the details of a specific employee within a company. This endpoint is used to modify the employee's information.

Delete a specific employee from a company: \ 
The DELETE `/api/companies/{id}/employee/{employeeId}` endpoint deletes an employee from the specified company. This is used to remove an employee from the company's records.

## Visit Management

The API includes functionality to manage visits, including signing in and signing out visitors.

Retrieve open visits: \
The GET `/api/visits/open` endpoint fetches details of currently open visits. This is useful for viewing all ongoing visits.

Retrieve all visits: \
The GET `/api/visits endpoint` retrieves details of all visits, including both open and closed ones. This provides a comprehensive view of all visitor interactions.

Sign in for a visit: \
The POST `/api/visits/signin` endpoint allows a visitor to sign in for a visit. Users must provide visitor details in the request body, which are then recorded in the system.

Sign out from a visit: \
The POST `/api/visits/signout` endpoint signs out a visitor using their email address provided in the query parameter. This marks the end of the visit for the specified visitor.

## Data Models

The API uses several data models to represent companies, employees, and visits.
### Company Data Model

`CompanyDetail`: Represents the detailed information of a company, including its ID, name, and a list of employees. \
`CompanyRequest`: Represents the data required to create or update a company, including its ID and name.

### Employee Data Model

`EmployeeDetail`: Represents the detailed information of an employee, including their ID, name, email, and function within the company. \
`EmployeeRequest`: Represents the data required to create or update an employee, including their ID, name, email, function, and associated company ID.

### Visit Data Model

`VisitDetail`: Represents the detailed information of a visit, including visitor's name, email, company, the company being visited, the employee being visited, and the start and end times of the visit. \
`StartVisitRequest`: Represents the data required to start a visit, including the visitor's name, email, company, the employee being visited, and the company being visited. \
`BooleanResponse`: Represents a generic response model indicating success or failure, with optional messages and boolean values. \


In summary, the ModularMonolith.Api is a robust API that provides endpoints to manage companies, employees, and visits. It supports various operations such as creating, retrieving, updating, and deleting records, as well as handling visit sign-ins and sign-outs.