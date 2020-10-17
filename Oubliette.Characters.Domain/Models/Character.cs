using System;

namespace Oubliette.Characters.Domain.Models
{
    public class Character
    {
        public Guid Id { get; set; }
        public CharacterClass Class { get; set; }
        public string Name { get; set; }
    }
}
