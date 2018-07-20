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
    public class ReportsController : Controller
    {
        private readonly IReportService _reportService;

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="departmentService"></param>
        public ReportsController(IReportService reportService)
        {
            this._reportService = reportService;
        }
        #endregion


        #region Action Methods

        /// <summary>
        /// GET api/reports
        /// </summary>      
        /// <remarks>
        /// Sample request:
        ///  1. GET: /api/reports      
        /// </remarks>      
        /// <returns>It returns report data.</returns>
        /// <response code="200">It returns report data.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="500">Internal Server Error.</response>
        [SwaggerResponse(400, type: null, description: "Bad Request")]
        [SwaggerResponse(500, type: null, description: "Internal Server Error")]
        [ProducesResponseType(typeof(ApiResponse<List<ReportModel>>), 200)]
        [HttpGet]
        [EnableCors("MyPolicy")]
        public ActionResult Get(int? departmentId, int? employmentTypeId, int? employeeId)
        {
            var result = _reportService.GetTaskReport(departmentId, employmentTypeId, employeeId);
            return new OkObjectResult(result);
        }

        #endregion

    }
}
