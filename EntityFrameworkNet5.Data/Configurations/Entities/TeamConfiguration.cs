﻿using EntityFrameworkNet5.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkNet5.Data.Configurations.Entities
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasData(
                new Team
                {
                    Id = 20,
                    Name = "Trevoir Williams - Sample Team",
                    LeagueId = 20
                },
                new Team
                {
                    Id = 21,
                    Name = "Trevoir Williams - Sample Team 2",
                    LeagueId = 20
                },
                new Team
                {
                    Id = 22,
                    Name = "Trevoir Williams - Sample Team 3",
                    LeagueId = 20
                }
            );

            builder.Property(p => p.Name).HasMaxLength(50);
            builder.HasIndex(h => h.Name);

            builder.HasMany(m => m.HomeMatches)
                .WithOne(m => m.HomeTeam)
                .HasForeignKey(m => m.HomeTeamId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.AwayMatches)
                .WithOne(m => m.AwayTeam)
                .HasForeignKey(m => m.AwayTeamId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
