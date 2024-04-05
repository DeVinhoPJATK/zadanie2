namespace LegacyApp.Core.Validators.Clients;

public class NormalClientValidator : ClientValidator
{
    public override void CreditCheck(ref User user)
    {
        user.HasCreditLimit = true;
        using (var userCreditService = new UserCreditService())
        {
            int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
            user.CreditLimit = creditLimit;
        }
    }
}