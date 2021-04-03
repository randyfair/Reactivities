using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        //??= means if _mediator is null, the value to the right is used
        protected IMediator Mediator => _mediator ??= HttpContext
            .RequestServices.GetService<IMediator>();         
    }
}