using System;

namespace LegacyApp.Core.Validators.Clients;

public class ValidatorFactory : IValidatorFactory
{
    public ClientValidator Create(Client client)
    {
        if (client.Type == "VeryImportantClient")
        {
            return new VeryImportantClientValidator();
        }

        if (client.Type == "ImportantClient")
        {
            return new ImportantClientValidator();
        }

        if (client.Type == "NormalClient")
        {
            return new NormalClientValidator();
        }

        if (client.Type == "OtherClient")
        {
            return new OtherClientValidator();
        }

        throw new ApplicationException("Unknown client type");
    }
}