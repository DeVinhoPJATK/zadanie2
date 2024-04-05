using System;
using LegacyApp.Core.Validators;
using LegacyApp.Core.Validators.Clients;
using LegacyApp.Core.Validators.Users;

namespace LegacyApp
{
    public class UserService
    {
        private IInputValidator _inputValidator;
        private IClientRepository _clientRepository;
        private IValidatorFactory _validatorFactory;
        
        public UserService()
        {
            _inputValidator = new InputValidator();
            _clientRepository = new ClientRepository();
            _validatorFactory = new ValidatorFactory();
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!_inputValidator.ValidateName(firstName, lastName))
            {
                return false;
            }
            if (!_inputValidator.ValidateEmail(email))
            {
                return false;
            }
            if (!_inputValidator.ValidateAge(dateOfBirth))
            {
                return false;
            }

            var client = _clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            var clientValidator = _validatorFactory.Create(client);
            clientValidator.CreditCheck(ref user);

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
