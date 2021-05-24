using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RpgApplication.Areas.Identity.Data;
using RpgApplication.Models;

namespace RpgApplication.Areas.Identity.Data
{
    public class DatabaseContext : IdentityDbContext<UserModel>
    {
        public DbSet<MistbornCharacterSheetModel> MistbornCharacters { get; set; }
        public DbSet<GameModel> Games { get; set; }
        public DbSet<GameMessages> GameMessages { get; set; }
        public DbSet<GameUser> GameUsers { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<GameModel>()
                .HasMany(x => x.Messages)
                .WithOne(x => x.Game)
                .HasForeignKey(x => x.GameId);

            builder.Entity<GameUser>()
                .HasKey(x => new { x.GameId, x.UserId });

            builder.Entity<GameUser>()
                .HasOne(x => x.UserModel)
                .WithMany(x => x.Games)
                .HasForeignKey(x => x.UserId);

            builder.Entity<GameUser>()
                  .HasOne(x => x.Game)
                  .WithMany(x => x.Players)
                  .HasForeignKey(x => x.GameId);

            builder.Entity<GameMessages>()
                  .HasOne(x => x.User)
                  .WithMany(x => x.GameMessages)
                  .HasForeignKey(x => x.FromUserId);

            builder.Entity<MistbornCharacterSheetModel>()
                  .HasOne(x => x.UserModel)
                  .WithMany(x => x.Characters)
                  .HasForeignKey(x => x.UserId);
        }
    }
}
