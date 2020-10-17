﻿using Microsoft.EntityFrameworkCore;
using Oubliette.Characters.Domain.Models;

namespace Oubliette.Characters.Shared.Database
{
    public class OublietteCharacterContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }


        public OublietteCharacterContext(
            DbContextOptions<OublietteCharacterContext> options
        ) : base(options)
        {

        }
    }
}
