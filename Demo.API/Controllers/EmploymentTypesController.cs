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
    /// Employment Type Controller
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EmploymentTypesController : Controller
    {
        private readonly IEmploymentTypeService _employmentTypeService;

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="employmentTypeService"></param>
        public EmploymentTypesController(IEmploymentTypeService employmentTypeService)
        {
            this._employmentTypeService = employmentTypeService;
        }
        #endregion


        #region Action Methods

        /// <summary>
        /// GET api/employmentTypes
        /// </summary>      
        /// <remarks>
        /// Sample request:
        ///  1. GET: /api/employmentTypes      
        /// </remarks>      
        /// <returns>It returns list of employmentType.</returns>
        /// <response code="200">It returns list of employmentType.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="500">Internal Server Error.</response>
        [SwaggerResponse(400, type: null, description: "Bad Request")]
        [SwaggerResponse(500, type: null, description: "Internal Server Error")]
        [ProducesResponseType(typeof(ApiResponse<List<EmploymentTypeModel>>), 200)]
        [HttpGet]
        [EnableCors("MyPolicy")]
        public async Task<ActionResult> Get()
        {
            var result = await _employmentTypeService.GetEmploymentTypeAsync();
            return new OkObjectResult(result);
        }

        #endregion

    }
}
