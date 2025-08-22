using Application.Workers.Create;
using Application.Workers.Delete;
using Application.Workers.GetById;
using Application.Workers.Update;
using ErrorOr;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var GetResult = await _mediator.Send(new GetWorkerByIdQuery(id));

            return GetResult.Match(
                WorkerId => Ok(WorkerId),
                errors => Problem(
                    title: "Error to search person",
                    detail: string.Join("; ", errors.Select(e => e.Description)),
                    statusCode: StatusCodes.Status404NotFound
                    )
                );


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var getResult = await _mediator.Send(new DeleteWorkerCommand(id));
            return getResult.Match(
                workerId => Ok(workerId),
                errors => Problem(
                    title: "Error to delete person",
                    detail: string.Join("; ", errors.Select(error => error.Description)),
                    statusCode: StatusCodes.Status404NotFound
                    )
                );
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateById(Guid id, [FromBody] UpdateWorkerCommand command)
        {
            if(command.Id != id)
            {
                List<Error> errors = new();
                {
                    Error.Validation("Worker.UpdateInvalid", "The request Id does not match with the url id");
                }
                return problem(errors);
            }
            var getResult = await _mediator.Send(command);

            return getResult.Match(
                workerId => Ok(workerId),
                errors => Problem(title: "We can update it",
                detail: string.Join("; ", errors.Select(e => e.Description)),
                statusCode: StatusCodes.Status404NotFound
                    )
                );
        }
    }
}
