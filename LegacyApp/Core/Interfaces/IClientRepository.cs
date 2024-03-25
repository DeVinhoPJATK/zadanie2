namespace LegacyApp.Core.Validators;

public interface IClientRepository
{
    public Client GetById(int clientId);
}