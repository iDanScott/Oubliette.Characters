using MediatR;
using Microsoft.AspNetCore.Mvc;
using Oubliette.Characters.WebApi.Models.Characters;
using System.Threading.Tasks;

namespace Oubliette.Characters.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharactersController : Controller
    {
        private readonly IMediator mediator;

        public CharactersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> AddCharacter(CreateCharacterRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
    }
}
