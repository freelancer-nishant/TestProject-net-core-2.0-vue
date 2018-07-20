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
using System.Linq;

namespace Demo.BLL.Service
{
    public class ReportService : IReportService
    {
        private readonly IEmployeeTaskRepository _employeeTaskRepository;

        public ReportService(IEmployeeTaskRepository employeeTaskRepository)
        {
            this._employeeTaskRepository = employeeTaskRepository;
        }

        /// <summary>
        /// Get TaskReport
        /// </summary>
        /// <returns></returns>
        public ApiResponse<List<ReportModel>> GetTaskReport(int? departmentId, int? employmentTypeId, int? employeeId)
        {
            try
            {
                var tasks = _employeeTaskRepository.GetTasks(departmentId, employmentTypeId, employeeId);

                var result = (from d in tasks
                        group d by d.Task.StartDate.DayOfWeek into groupedDays
                        select new ReportModel
                        {
                            Day = groupedDays.Key.ToString(),
                            Tasks = (from t in groupedDays
                                    group t by t.Task.Name into groupedTasks
                                    select new TaskReportModel
                                    {
                                        Task = groupedTasks.Key,
                                        Departments = (from dt in groupedTasks
                                                      group dt by dt.Employee.Department.Name into groupedDepartments
                                                      select new DepartmentReportModel
                                                      {
                                                          Department = groupedDepartments.Key,
                                                          EmploymentTypes = (from et in groupedDepartments
                                                                            group et by et.Employee.EmploymentType.Type into groupedEmploymentTypes
                                                                            select new EmploymentTypeReportModel
                                                                            {
                                                                                EmploymentType = groupedEmploymentTypes.Key,
                                                                                Employees = groupedEmploymentTypes.Select(x => x.Employee.Name).ToList()
                                                                            }).ToList()
                                                      }).ToList()
                                    }).ToList()
                        }).ToList();

                return ApiResponse<List<ReportModel>>.SuccessResult(result);
            }
            catch (Exception ex) when (ex is FailException || ex is ValidationException || ex is ArgumentException)
            {
                return ApiResponse<List<ReportModel>>.ErrorResult(message: ex.Message, statusCode: HttpStatusCode.BadRequest);
            }
            catch (Exception ex) when (ex is ErrorException)
            {
                //LoggingManager.Error(ex.ToString());
                return ApiResponse<List<ReportModel>>.ErrorResult(message: ex.Message);
            }
            catch (Exception ex)
            {
                //LoggingManager.Error(ex.ToString());
                return ApiResponse<List<ReportModel>>.ErrorResult(message: ex.Message);
            }
        }
    }
}
