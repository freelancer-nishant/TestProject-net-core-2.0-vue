using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Demo.BLL.IService;
using Swashbuckle.AspNetCore.SwaggerGen;
using Demo.DomainModels.ApiResponse;
using Demo.DomainModels.Models;
using Microsoft.AspNetCore.Cors;
using StackExchange.Redis;

namespace Demo.API.Controllers
{
    /// <summary>
    /// Employee Controller
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="employeeService"></param>
        public EmployeesController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }
        #endregion

        #region Action Methods

        /// <summary>
        /// GET api/employees
        /// </summary>      
        /// <remarks>
        /// Sample request:
        ///  1. GET: /api/employees      
        /// </remarks>      
        /// <returns>It returns list of employee.</returns>
        /// <response code="200">It returns list of employee.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="500">Internal Server Error.</response>
        [SwaggerResponse(400, type: null, description: "Bad Request")]
        [SwaggerResponse(500, type: null, description: "Internal Server Error")]
        [ProducesResponseType(typeof(ApiResponse<List<EmployeeModel>>), 200)]
        [HttpGet]
        [EnableCors("MyPolicy")]
        public async Task<ActionResult> Get()
        {
            var result = await _employeeService.GetEmployeesAsync();
            return new OkObjectResult(result);
        }

        /// <summary>
        /// GET api/employees/5
        /// </summary>      
        /// <remarks>
        /// Sample request:
        ///  1. GET: /api/employees/5     
        /// </remarks>      
        /// <returns>It returns true in case of suceess.</returns>
        /// <response code="200">It returns employee.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="500">Internal Server Error.</response>
        [SwaggerResponse(400, type: null, description: "Bad Request")]
        [SwaggerResponse(500, type: null, description: "Internal Server Error")]
        [ProducesResponseType(typeof(ApiResponse<List<EmployeeModel>>), 200)]
        [HttpGet("{id}")]
        [EnableCors("MyPolicy")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _employeeService.GetEmployeeByIdAsync(id);
            return new OkObjectResult(result);
        }

        /// <summary>
        /// Insert employee.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///  1. POST: /api/employees
        ///  2. 
        ///      {
        ///         "id": 0,
        ///         "name": "string",
        ///         "sex": "string",
        ///         "email": "string",
        ///         "phoneNo": "string",
        ///         "address": "string",
        ///         "employmentTypeId": 0,
        ///         "departmentId": 0,
        ///      }
        /// </remarks> 
        /// <returns>It returns true in case of suceess.</returns>
        /// <response code="200">It returns employee.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="500">Internal Server Error.</response>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [EnableCors("MyPolicy")]
        [SwaggerResponse(400, type: null, description: "Bad Request")]
        [SwaggerResponse(500, type: null, description: "Internal Server Error")]
        [ProducesResponseType(typeof(ApiResponse<bool>), 200)]
        public async Task<ActionResult> Post([FromBody]EmployeeModel model)
        {
            var result = await _employeeService.AddEmployeeAsync(model);
            return new OkObjectResult(result);
        }

        #endregion
    }
}
