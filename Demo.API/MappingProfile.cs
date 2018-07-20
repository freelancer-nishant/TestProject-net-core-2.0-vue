using AutoMapper;
using Demo.DomainModels.Entities;
using Demo.DomainModels.Models;
using System;
using System.Globalization;

namespace Demo.API
{
    /// <summary>
    /// Profile mappings
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Mapping entity with Dto
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeModel>()
                .ForMember(x => x.DepartmentName, opt => opt.MapFrom(c => c.Department == null ? string.Empty : c.Department.Name))
                .ForMember(x => x.EmploymentType, opt => opt.MapFrom(c => c.EmploymentType == null ? string.Empty : c.EmploymentType.Type));
            CreateMap<EmployeeModel, Employee>();

            CreateMap<Department, DepartmentModel>();
            CreateMap<DepartmentModel, Department>();

            CreateMap<EmploymentType, EmploymentTypeModel>();
            CreateMap<EmploymentTypeModel, EmploymentType>();
        }
    }
}
