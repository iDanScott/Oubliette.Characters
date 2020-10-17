using Oubliette.Characters.Domain.Models;
using Oubliette.Characters.Core.Database;
using Oubliette.Characters.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oubliette.Characters.Core.Repositories
{
    public class OublietteCharacterRepository : IOublietteCharacterRepository
    {
        private readonly OublietteCharacterContext context;

        public OublietteCharacterRepository(
            OublietteCharacterContext context
        )
        {
            this.context = context;
        }

        public async Task<IReadOnlyCollection<Character>> GetAllCharacters()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<Character>> GetAllCharactersForOwner(
            Guid ownerGuid
        )
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> AddCharacter(
            Character character
        )
        {
            context.Characters.Add(character);
            await context.SaveChangesAsync();
            return character.Id;
        }
    }
}
