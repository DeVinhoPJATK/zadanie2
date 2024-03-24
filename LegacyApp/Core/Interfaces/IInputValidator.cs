using System;

namespace LegacyApp.Core.Validators;

public interface IInputValidator
{
    public bool ValidateEmail(string email);
    public bool ValidateName(string firstName, string lastName);
    public bool ValidateAge(DateTime dateOfBirth);
}