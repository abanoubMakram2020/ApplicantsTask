using ApplicantsTask.Application.DTOs.InputDTO;
using ApplicantsTask.Application.DTOs.OutputDTO;
using ApplicantsTask.Application.ServicesInterfaces;
using ApplicantsTask.Application.UnitOfWork;
using ApplicantsTask.Domain.Entities;
using ApplicantsTask.Domain.RepositriesInterfaces;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SharedKernal.Common.Enum;
using SharedKernal.Middlewares.Basees;
using SharedKernal.Middlewares.ResourcesReader;
using SharedKernal.Middlewares.ResourcesReader.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicantsTask.Application.ServicesImplementation
{
    public class ApplicantService : IApplicantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicantRepository _applicantRepository;
        private readonly IMapper _autoMapper;
        private readonly IValidator<ApplicantInputDTO> _validator;
        private readonly IMessageResourceReader _messageResourceReader;
        public ApplicantService(IUnitOfWork unitOfWork, IApplicantRepository applicantRepository,
                                  IMapper autoMapper, IValidator<ApplicantInputDTO> validator,
                                  IMessageResourceReader messageResourceReader)
        {
            _unitOfWork = unitOfWork;
            _autoMapper = autoMapper;
            _applicantRepository = applicantRepository;
            _validator = validator;
            _messageResourceReader = messageResourceReader;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseResultDto<List<ApplicantOutputDTO>>> GetAll()
        {
            var ApplicantList = await _applicantRepository.Get().ToListAsync();
            if (ApplicantList is null)
                return ResponseResultDto<List<ApplicantOutputDTO>>.NotFound(result: null, message: _messageResourceReader.GetMessage(ResourcesMessageKey.NotDataFound));

            var result = _autoMapper.Map<List<ApplicantOutputDTO>>(ApplicantList);
            return ResponseResultDto<List<ApplicantOutputDTO>>.Success(result: result, message: _messageResourceReader.GetMessage(ResourcesMessageKey.Successfully));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<ResponseResultDto<ApplicantOutputDTO>> GetById(BaseRequestDto<int> Id)
        {
            var Applicant = await _applicantRepository.Get(expression: r => r.Id == Id.Data).FirstOrDefaultAsync();
            if (Applicant is null)
                return ResponseResultDto<ApplicantOutputDTO>.NotFound(result: null, message: _messageResourceReader.GetMessage(ResourcesMessageKey.NotDataFound));

            var result = _autoMapper.Map<ApplicantOutputDTO>(Applicant);
            return ResponseResultDto<ApplicantOutputDTO>.Success(result: result, message: _messageResourceReader.GetMessage(ResourcesMessageKey.Successfully));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ApplicantInputDTO"></param>
        /// <returns></returns>
        public async Task<ResponseResultDto<bool>> SaveApplicant(BaseRequestDto<ApplicantInputDTO> ApplicantInputDTO)
        {
            

            var result = _validator.Validate(ApplicantInputDTO.Data);
            if (!result.IsValid)
            {
                Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
                result.Errors.GroupBy(p => p.PropertyName).ToList().ForEach(item => dict.Add(item.Key, item.Distinct().Select(e => e.ErrorMessage).ToList()));
                return ResponseResultDto<bool>.MultiError(dic: dict, message: "error");
            }
            
            if (ApplicantInputDTO.Data.Id > 0)
            {
                Applicant applicantObj = await _applicantRepository.Get(ApplicantInputDTO.Data.Id);
                if (applicantObj is null)
                    return ResponseResultDto<bool>.InvalidData(result: false, message: _messageResourceReader.GetMessage(ResourcesMessageKey.ApplicantNotExist));

                _autoMapper.Map(ApplicantInputDTO.Data, applicantObj);
                applicantObj.ModificationDate = DateTime.Now;
                applicantObj.ModifiedBy = 1;
                _applicantRepository.Update(applicantObj);
            }
            else
            {
                Applicant applicantObj = _autoMapper.Map<Applicant>(ApplicantInputDTO.Data);
                applicantObj.CreationDate = DateTime.Now;
                applicantObj.CreatedBy = 1;
                await _applicantRepository.Add(applicantObj);
            }
            return ResponseResultDto<bool>.Success(result: await _unitOfWork.Complete() > 0, message: _messageResourceReader.GetMessage(ResourcesMessageKey.Successfully));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<ResponseResultDto<bool>> DeleteById(BaseRequestDto<int> Id)
        {
            var ApplicantObj = await _applicantRepository.Get(Id.Data);
            if (ApplicantObj == null)
                return ResponseResultDto<bool>.NotFound(result: false, message: _messageResourceReader.GetMessage(ResourcesMessageKey.ApplicantNotExist));


            _applicantRepository.Delete(ApplicantObj);
            await _unitOfWork.Complete();
            return ResponseResultDto<bool>.Success(result: true, message: _messageResourceReader.GetMessage(ResourcesMessageKey.Successfully));
        }

    }
}
