using Demographics.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Demographics.Api.Controllers
{

    [ApiController]
    [Route("api/state-populations")]
    public class StatePopulationsController : ControllerBase
    {
        private readonly IStatePopulationQueryService _queryService;

        public StatePopulationsController(IStatePopulationQueryService queryService)
        {
            _queryService = queryService;
        }

        /// <summary>
        /// Returns population aggregated by US states.
        /// </summary>
        /// <param name="stateName">Optional state name filter</param>


        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] string? stateName,
            CancellationToken cancellationToken)
        {
            var result = await _queryService.GetAsync(stateName, cancellationToken);
            return Ok(result);
        }
    }
}
