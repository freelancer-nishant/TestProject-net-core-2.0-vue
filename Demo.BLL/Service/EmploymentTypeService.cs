using Demo.BLL.IService;
using Demo.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Demo.DomainModels.ApiResponse;
using System.Net;
using Demo.DomainModels.Exceptions;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Demo.DomainModels.Models;
using Demo.DomainModels.Entities;
using System.Threading.Tasks;

namespace Demo.BLL.Service
{
    public class EmploymentTypeService : IEmploymentTypeService
    {
        private readonly IEmploymentTypeRepository _employmentTypeRepository;
        private readonly IMapper _mapper;

        public EmploymentTypeService(IEmploymentTypeRepository employmentTypeRepository, IMapper mapper)
        {
            this._employmentTypeRepository = employmentTypeRepository;
            this._mapper = mapper;
        }

        /// <summary>
        /// Get All Employment Type Async
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResponse<List<EmploymentTypeModel>>> GetEmploymentTypeAsync()
        {
            try
            {
                var result = _employmentTypeRepository.GetAll();
                var model = _mapper.Map<List<EmploymentType>, List<EmploymentTypeModel>>(result);

                return ApiResponse<List<EmploymentTypeModel>>.SuccessResult(model);
            }
            catch (Exception ex) when (ex is FailException || ex is ValidationException || ex is ArgumentException)
            {
                return ApiResponse<List<EmploymentTypeModel>>.ErrorResult(message: ex.Message, statusCode: HttpStatusCode.BadRequest);
            }
            catch (Exception ex) when (ex is ErrorException)
            {
                //LoggingManager.Error(ex.ToString());
                return ApiResponse<List<EmploymentTypeModel>>.ErrorResult(message: ex.Message);
            }
            catch (Exception ex)
            {
                //LoggingManager.Error(ex.ToString());
                return ApiResponse<List<EmploymentTypeModel>>.ErrorResult(message: ex.Message);
            }
        }
    }
}
