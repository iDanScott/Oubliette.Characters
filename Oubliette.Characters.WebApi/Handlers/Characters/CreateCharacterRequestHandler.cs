using AutoMapper;
using MediatR;
using Oubliette.Characters.Domain.Models;
using Oubliette.Characters.Core.Repositories.Interfaces;
using Oubliette.Characters.WebApi.Models.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Oubliette.Characters.WebApi.Handlers.Characters
{
    public class CreateCharacterRequestHandler : IRequestHandler<CreateCharacterRequest, Guid>
    {
        private readonly IOublietteCharacterRepository repository;
        private readonly IMapper mapper;

        public CreateCharacterRequestHandler(IOublietteCharacterRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Task<Guid> Handle(CreateCharacterRequest request, CancellationToken cancellationToken)
        {
            var character = mapper.Map<Character>(request);
            var result = repository.AddCharacter(character);
            return result;
        }
    }
}
