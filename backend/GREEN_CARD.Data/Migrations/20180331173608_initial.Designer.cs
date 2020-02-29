﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using GREEN_CARD.Data;

namespace GREEN_CARD.Data.Migrations
{
    [DbContext(typeof(GREEN_CARDContext))]
    [Migration("20180331173608_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-preview1-28290")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GREEN_CARD.Core.Models.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abbreviation");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("GREEN_CARD.Core.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("BirthPlace");

                    b.Property<string>("Height");

                    b.Property<string>("Name");

                    b.Property<int>("WeightLbs");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("GREEN_CARD.Core.Models.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("GREEN_CARD.Core.Models.SkaterStatistic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<ushort>("Assists");

                    b.Property<ushort>("GamesPlayed");

                    b.Property<ushort>("Goals");

                    b.Property<int>("LeagueId");

                    b.Property<ushort>("PenaltyMinutes");

                    b.Property<int>("PlayerId");

                    b.Property<short?>("PlusMinus");

                    b.Property<ushort>("Points");

                    b.Property<int>("SeasonId");

                    b.Property<int>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SeasonId");

                    b.HasIndex("TeamId");

                    b.ToTable("SkaterStatistics");
                });

            modelBuilder.Entity("GREEN_CARD.Core.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abbreviation");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("GREEN_CARD.Core.Models.SkaterStatistic", b =>
                {
                    b.HasOne("GREEN_CARD.Core.Models.League", "League")
                        .WithMany()
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GREEN_CARD.Core.Models.Player")
                        .WithMany("SkaterStatistics")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GREEN_CARD.Core.Models.Season", "Season")
                        .WithMany()
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GREEN_CARD.Core.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
