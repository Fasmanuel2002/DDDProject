using Application.Workers.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Route("Workers")]
    public class WorkerController : ApiController
    {
        private readonly ISender _mediator;

        public WorkerController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorker([FromBody] CreateWorkerCommand command)
        {
            var createResult = await _mediator.Send(command);

            return createResult.Match(
                customerId => Ok(customerId),
                errors => Problem(
                    title: "Error To create Person",
                    detail: string.Join("; ", errors.Select(e => e.Description)),
                    statusCode: StatusCodes.Status409Conflict
                    )
                );
        }
        
    }
}
