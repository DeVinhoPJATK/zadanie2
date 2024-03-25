namespace LegacyApp.Core.Validators.Clients;

public class VeryImportantClientValidator : ClientValidator
{
    public override void CreditCheck(ref User user)
    {
        user.HasCreditLimit = false;
    }
}