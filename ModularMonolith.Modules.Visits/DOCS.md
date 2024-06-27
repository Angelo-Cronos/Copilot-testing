# VISITS MODULE DOCUMENTATION
## Introduction
This module handles the sign-in and sign-out of a visitor to a location. The visitor is visiting a company and needs to sign in and out. This module is responsible for handling this process.

## Commands
The commands that are available in this module are:
- SignInCommand
- SignOutCommand

### SignInCommand
This command is used to sign in a visitor to a location. The command contains the following properties:
- VisitorId: The id of the visitor that is signing in
- VisitorName: The name of the visitor that is signing in
- VisitorEmail: The email of the visitor that is signing in
- CompanyId: The id of the company that the visitor is visiting
- EmployeeId: The id of the employee that is signing in the visitor

The command is validated by the `SignInCommandValidator`. This validator checks if the command properties are not null or empty.
the command is handled by the `SignInCommandHandler`. This handler is responsible for signing in the visitor.


Example of a SignInCommand:
```csharp
var command = new SignInCommand
{
	VisitorId = Guid.NewGuid(),
	VisitorName = "John Doe",
	VisitorEmail = "john.doe@email.com",
	CompanyId = Guid.NewGuid(),
	EmployeeId = Guid.NewGuid()
};
```

### SignOutCommand
//TODO - Add documentation for SignOutCommand
