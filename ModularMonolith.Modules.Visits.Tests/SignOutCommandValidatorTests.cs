using ModularMonolith.Modules.Visits.Commands.Visits.SignOut;

namespace ModularMonolith.Modules.Visits.Tests;

public class SignOutCommandValidatorTests
{
   
// Validate a command where VisitorEmail is a correct and valid email address
[Fact]
public void validate_correct_email_address()
{
    // Arrange
    var validator = new SignOutCommandValidator();
    var command = new SignOutCommand ("test@example.com");

    // Act
    var result = validator.Validate(command);

    // Assert
    Assert.True(result.IsValid);
}

// Validate a command with a VisitorEmail that includes common email characters (letters, numbers, periods, and hyphens)
[Fact]
public void validate_email_with_common_characters()
{
    // Arrange
    var validator = new SignOutCommandValidator();
    var command = new SignOutCommand ("user.name-123@example.com");

    // Act
    var result = validator.Validate(command);

    // Assert
    Assert.True(result.IsValid);
}

// Validate a command where VisitorEmail is empty
[Fact]
public void validate_empty_email()
{
    // Arrange
    var validator = new SignOutCommandValidator();
    var command = new SignOutCommand ("");

    // Act
    var result = validator.Validate(command);

    // Assert
    Assert.False(result.IsValid);
}

// Validate a command where VisitorEmail is not in a proper email format
[Fact]
public void validate_improper_email_format()
{
    // Arrange
    var validator = new SignOutCommandValidator();
    var command = new SignOutCommand( "testexample" );

    // Act
    var result = validator.Validate(command);

    // Assert
    Assert.False(result.IsValid);
}

// Validate a command where VisitorEmail is missing the domain part
[Fact]
public void validate_missing_domain_part()
{
    // Arrange
    var validator = new SignOutCommandValidator();
    var command = new SignOutCommand ("username@" );

    // Act
    var result = validator.Validate(command);

    // Assert
    Assert.False(result.IsValid);
}

// Validate a command where VisitorEmail is missing the '@' symbol
[Fact]
public void validate_missing_at_symbol()
{
    // Arrange
    var validator = new SignOutCommandValidator();
    var command = new SignOutCommand ("usernameexample.com");

    // Act
    var result = validator.Validate(command);

    // Assert
    Assert.False(result.IsValid);
}

// Validate a command where VisitorEmail contains special characters not typically found in emails
[Fact]
public void validate_email_with_special_characters()
{
    // Arrange
    var validator = new SignOutCommandValidator();
    var command = new SignOutCommand ("user#name@example.com");

    // Act
    var result = validator.Validate(command);

    // Assert
    Assert.False(result.IsValid);
}

// Validate a command where VisitorEmail is excessively long
[Fact]
public void validate_excessively_long_email()
{
    // Arrange
    var validator = new SignOutCommandValidator();
    string longEmail = new string('a', 256) + "@example.com";
    var command = new SignOutCommand (longEmail);

    // Act
    var result = validator.Validate(command);

    // Assert
    Assert.False(result.IsValid);
}

// Validate a command where VisitorEmail is null
[Fact]
public void validate_null_email()
{
    // Arrange
    var validator = new SignOutCommandValidator();
    var command = new SignOutCommand(  null );

    // Act
    var result = validator.Validate(command);

    // Assert
    Assert.False(result.IsValid);
}

// Validate a command where VisitorEmail is a string of whitespace
[Fact]
public void validate_whitespace_email()
{
    // Arrange
    var validator = new SignOutCommandValidator();
    var command = new SignOutCommand ("   " );

    // Act
    var result = validator.Validate(command);

    // Assert
    Assert.False(result.IsValid);
}


}