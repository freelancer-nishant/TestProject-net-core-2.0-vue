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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this._employeeRepository = employeeRepository;
            this._mapper = mapper;
        }

        /// <summary>
        /// Get All Employee Async
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResponse<List<EmployeeModel>>> GetEmployeesAsync()
        {
            try
            {
                var result = _employeeRepository.GetEmployeesAsync();
                var model = _mapper.Map<List<Employee>, List<EmployeeModel>>(result);

                return ApiResponse<List<EmployeeModel>>.SuccessResult(model);
            }
            catch (Exception ex) when (ex is FailException || ex is ValidationException || ex is ArgumentException)
            {
                return ApiResponse<List<EmployeeModel>>.ErrorResult(message: ex.Message, statusCode: HttpStatusCode.BadRequest);
            }
            catch (Exception ex) when (ex is ErrorException)
            {
                //LoggingManager.Error(ex.ToString());
                return ApiResponse<List<EmployeeModel>>.ErrorResult(message: ex.Message);
            }
            catch (Exception ex)
            {
                //LoggingManager.Error(ex.ToString());
                return ApiResponse<List<EmployeeModel>>.ErrorResult(message: ex.Message);
            }
        }


        /// <summary>
        /// Get Employee By Id Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ApiResponse<EmployeeModel>> GetEmployeeByIdAsync(int id)
        {
            try
            {
                var result = _employeeRepository.GetEmployeeByIdAsync(id);
                var model = _mapper.Map<Employee, EmployeeModel>(result);

                return ApiResponse<EmployeeModel>.SuccessResult(model);
            }
            catch (Exception ex) when (ex is FailException || ex is ValidationException || ex is ArgumentException)
            {
                return ApiResponse<EmployeeModel>.ErrorResult(message: ex.Message, statusCode: HttpStatusCode.BadRequest);
            }
            catch (Exception ex) when (ex is ErrorException)
            {
                //LoggingManager.Error(ex.ToString());
                return ApiResponse<EmployeeModel>.ErrorResult(message: ex.Message);
            }
            catch (Exception ex)
            {
                //LoggingManager.Error(ex.ToString());
                return ApiResponse<EmployeeModel>.ErrorResult(message: ex.Message);
            }
        }

        /// <summary>
        /// Add or Update Employee Async
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ApiResponse<bool>> AddEmployeeAsync(EmployeeModel model)
        {
            try
            {
                var result = _mapper.Map<EmployeeModel, Employee>(model);
                _employeeRepository.Add(result);

                var successResult = await System.Threading.Tasks.Task.FromResult(true);

                return ApiResponse<bool>.SuccessResult(successResult);
            }
            catch (Exception ex) when (ex is FailException || ex is ValidationException || ex is ArgumentException)
            {
                return ApiResponse<bool>.ErrorResult(message: ex.Message, statusCode: HttpStatusCode.BadRequest);
            }
            catch (Exception ex) when (ex is ErrorException)
            {
                //LoggingManager.Error(ex.ToString());
                return ApiResponse<bool>.ErrorResult(message: ex.Message);
            }
            catch (Exception ex)
            {
                //LoggingManager.Error(ex.ToString());
                return ApiResponse<bool>.ErrorResult(message: ex.Message);
            }

        }


    }
}
