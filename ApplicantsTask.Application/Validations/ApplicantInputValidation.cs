using ApplicantsTask.Application.DTOs.InputDTO;
using ApplicantsTask.Domain.Entities;
using ApplicantsTask.Domain.RepositriesInterfaces;
using FluentValidation;
using SharedKernal.Common.Configuration;
using SharedKernal.Middlewares.ResourcesReader;
using SharedKernal.Middlewares.ResourcesReader.Message;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApplicantsTask.Application.Validations
{
    public class ApplicantInputValidation : AbstractValidator<ApplicantInputDTO>
    {
        private const string EMAIL_REGULAR_EXPRESSSION = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        private readonly string SERVICE_NAME = RestCountriesConfigurations.ServiceName;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMessageResourceReader _messageResourceReader;
        private readonly IApplicantRepository _applicantRepository;
        public ApplicantInputValidation(IHttpClientFactory httpClientFactory, IMessageResourceReader messageResourceReader,
            IApplicantRepository applicantRepository)
        {
            _httpClientFactory = httpClientFactory;
            _messageResourceReader = messageResourceReader;
            _applicantRepository = applicantRepository;
            IsValid();
        }
        void IsValid()
        {
        
            RuleFor(x => x.EmailAddress).Must((model, emailAddress) => { return CheckIfApplicantExists(model.Id, emailAddress); })
                .WithMessage(_messageResourceReader.GetValidationMessage(ValidationMessageKey.ApplicantAlreadyExist));

            RuleFor(x => x.Name).Must((applicantName) => { return CheckApplicantName(applicantName); })
                                 .WithMessage(_messageResourceReader.GetValidationMessage(ValidationMessageKey.ApplicantNameValidation));

            RuleFor(x => x.FamilyName).Must((applicantFamilyName) => { return CheckApplicantFamilyName(applicantFamilyName); })
                                  .WithMessage(_messageResourceReader.GetValidationMessage(ValidationMessageKey.ApplicantFamilyNameValidation));

            RuleFor(x => x.Address).Must((applicantAddress) => { return CheckApplicantAddress(applicantAddress); })
                                .WithMessage(_messageResourceReader.GetValidationMessage(ValidationMessageKey.ApplicantAddressValidation));


            RuleFor(x => x.EmailAddress).Matches(EMAIL_REGULAR_EXPRESSSION).
                WithMessage(_messageResourceReader.GetValidationMessage(ValidationMessageKey.ApplicantEmailValidation));

            RuleFor(x => x.Age).Must((applicantAge) => { return CheckApplicantAge(applicantAge); })
                                           .WithMessage(_messageResourceReader.GetValidationMessage(ValidationMessageKey.ApplicantAgeValidation));

            RuleFor(x => x.Hired).Must((applicantHired) => { return CheckApplicantHired(applicantHired); })
                               .WithMessage(_messageResourceReader.GetValidationMessage(ValidationMessageKey.ApplicantHiredValidation));


            RuleFor(x => x.CountryOfOrigion).MustAsync(async (CountryOfOrigion, model) =>
            {
                return await CheckCountryValidation(CountryOfOrigion);
            }).WithMessage(_messageResourceReader.GetValidationMessage(ValidationMessageKey.ApplicantCountryValidation));
        }
        bool CheckApplicantName(string arg) => !(string.IsNullOrWhiteSpace(arg) || arg.Length < 5 || arg.Length > 50);
        bool CheckApplicantFamilyName(string arg) => !(string.IsNullOrWhiteSpace(arg) || arg.Length < 5 || arg.Length > 50);
        bool CheckApplicantAddress(string arg) => !(string.IsNullOrWhiteSpace(arg) || arg.Length < 10 || arg.Length > 50);
        bool CheckApplicantAge(int arg) => !(arg < 10 || arg > 60);
        bool CheckApplicantHired(bool? arg) => arg.HasValue;

        async Task<bool> CheckCountryValidation(string arg)
        {
            var client = _httpClientFactory.CreateClient(name: SERVICE_NAME);
            HttpResponseMessage response = await client.GetAsync(arg);

            return response.IsSuccessStatusCode;
        }

        bool CheckIfApplicantExists(int id, string arg)
        {
            Applicant applicantObj =  _applicantRepository.Get(x => x.Id!= id && x.EmailAddress.Trim().ToLower() == arg.Trim().ToLower()).FirstOrDefault();
            return applicantObj is null;
        }

    }
}
