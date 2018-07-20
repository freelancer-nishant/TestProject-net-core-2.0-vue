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
    /// Department Controller
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService _departmentService;

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="departmentService"></param>
        public DepartmentsController(IDepartmentService departmentService)
        {
            this._departmentService = departmentService;
        }
        #endregion


        #region Action Methods

        /// <summary>
        /// GET api/departments
        /// </summary>      
        /// <remarks>
        /// Sample request:
        ///  1. GET: /api/departments      
        /// </remarks>      
        /// <returns>It returns list of department.</returns>
        /// <response code="200">It returns list of department.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="500">Internal Server Error.</response>
        [SwaggerResponse(400, type: null, description: "Bad Request")]
        [SwaggerResponse(500, type: null, description: "Internal Server Error")]
        [ProducesResponseType(typeof(ApiResponse<List<DepartmentModel>>), 200)]
        [HttpGet]
        [EnableCors("MyPolicy")]
        public async Task<ActionResult> Get()
        {
            var result = await _departmentService.GetDepartmentAsync();
            return new OkObjectResult(result);
        }

        #endregion

    }
}
