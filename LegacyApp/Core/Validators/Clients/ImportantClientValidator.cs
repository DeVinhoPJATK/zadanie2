namespace LegacyApp.Core.Validators.Clients;

public class ImportantClientValidator : ClientValidator
{
    public override void CreditCheck(ref User user)
    {
        using (var userCreditService = new UserCreditService())
        {
            int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
            creditLimit = creditLimit * 2;
            user.CreditLimit = creditLimit;
        }
    }
}