using LegacyApp.Core.Validators.Clients;

namespace LegacyApp.Core.Validators;

public interface IValidatorFactory
{
    public ClientValidator Create(Client client);
}