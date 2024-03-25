namespace LegacyApp.Core.Validators.Clients;

public abstract class ClientValidator
{
    public abstract void CreditCheck(ref User user);
}