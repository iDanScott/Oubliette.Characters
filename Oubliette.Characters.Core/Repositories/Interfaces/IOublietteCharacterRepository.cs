using Oubliette.Characters.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oubliette.Characters.Core.Repositories.Interfaces
{
    public interface IOublietteCharacterRepository
    {
        public Task<IReadOnlyCollection<Character>> GetAllCharacters();
        public Task<IReadOnlyCollection<Character>> GetAllCharactersForOwner(Guid guid);
        public Task<Guid> AddCharacter(Character character);
    }
}
