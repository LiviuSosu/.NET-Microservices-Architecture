using System;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using MicroservicesProjectArchitecture.Application.Articles.Queries.GetArticles;
using MicroservicesProjectArchitecture.Application.Paging;
using MicroservicesProjectArchitecture.Common;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MicroservicesProjectArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public class ArticlesController : BaseController
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        //inject other services here in constructor
        public ArticlesController(ILogger logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetArticles([FromQuery] PagingModel paginationModel)
        {
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            try
            {
                _logger.LogInformation(actionName, JsonConvert.SerializeObject(paginationModel));
                return Ok(await Mediator.Send(new GetArticlesListQuery(paginationModel)));
            }
            catch (Exception exception)
            {
                _logger.LogException(exception, actionName, JsonConvert.SerializeObject(paginationModel));
                return StatusCode(500, _configuration.DisplayUserErrorMessage);
            }
        }
    }
}
