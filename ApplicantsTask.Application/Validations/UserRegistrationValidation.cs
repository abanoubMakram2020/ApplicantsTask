using ApplicantsTask.Application.DTOs.InputDTO;
using ApplicantsTask.Domain.Entities;
using ApplicantsTask.Domain.RepositriesInterfaces;
using FluentValidation;
using SharedKernal.Middlewares.ResourcesReader;
using SharedKernal.Middlewares.ResourcesReader.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApplicantsTask.Application.Validations
{
    public class UserRegistrationValidation : AbstractValidator<RegistrationDTO>
    {
        private readonly IMessageResourceReader _messageResourceReader;
        private readonly IUserRepository _userRepository;
        private const string PASSWORD_REGULAR_EXPRESSSION = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$";
        public UserRegistrationValidation(IMessageResourceReader messageResourceReader, IUserRepository userRepository)
        {
            _messageResourceReader= messageResourceReader;
            _userRepository= userRepository;
            IsValid();
        }
        void IsValid()
        {
            RuleFor(x => x.FullName).Must((fullName) => { return CheckUserFullName(fullName); })
                              .WithMessage(_messageResourceReader.GetValidationMessage(ValidationMessageKey.UserFullNameValidation));

            RuleFor(x => x.UserName).Must((userName) => { return CheckUserName(userName); })
                                  .WithMessage(_messageResourceReader.GetValidationMessage(ValidationMessageKey.UserUserNameValidation));

            RuleFor(x => x.UserName).Must((model, userName) => { return CheckDuplicateUserName(model.Id, userName); })
                .WithMessage(_messageResourceReader.GetValidationMessage(ValidationMessageKey.UserNameAlreadyExist));

   
            RuleFor(x => x.Password).Matches(PASSWORD_REGULAR_EXPRESSSION).
                            WithMessage(_messageResourceReader.GetValidationMessage(ValidationMessageKey.UserPasswordValidation));

        }

        bool CheckUserFullName(string arg) => !(string.IsNullOrWhiteSpace(arg) || arg.Length < 5 || arg.Length > 50);
        bool CheckUserName(string arg) => !(string.IsNullOrWhiteSpace(arg) || arg.Length < 5 || arg.Length > 50);

        bool CheckDuplicateUserName(int id, string arg)
        {
            User applicantObj = _userRepository.Get(x => x.Id != id && x.UserName.Trim().ToLower()== arg.Trim().ToLower()).FirstOrDefault();
            return applicantObj is null;
        }
    }
}
