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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            this._departmentRepository = departmentRepository;
            this._mapper = mapper;
        }

        /// <summary>
        /// Get All Department Async
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResponse<List<DepartmentModel>>> GetDepartmentAsync()
        {
            try
            {
                var result = _departmentRepository.GetAll();
                var model = _mapper.Map<List<Department>, List<DepartmentModel>>(result);

                return ApiResponse<List<DepartmentModel>>.SuccessResult(model);
            }
            catch (Exception ex) when (ex is FailException || ex is ValidationException || ex is ArgumentException)
            {
                return ApiResponse<List<DepartmentModel>>.ErrorResult(message: ex.Message, statusCode: HttpStatusCode.BadRequest);
            }
            catch (Exception ex) when (ex is ErrorException)
            {
                //LoggingManager.Error(ex.ToString());
                return ApiResponse<List<DepartmentModel>>.ErrorResult(message: ex.Message);
            }
            catch (Exception ex)
            {
                //LoggingManager.Error(ex.ToString());
                return ApiResponse<List<DepartmentModel>>.ErrorResult(message: ex.Message);
            }
        }
    }
}
