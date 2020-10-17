using MediatR;
using System;

namespace Oubliette.Characters.WebApi.Models.Characters
{
    public class CreateCharacterRequest : IRequest<Guid>
    {
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public Guid CharacterClass { get; set; }
    }
}
