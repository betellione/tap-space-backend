﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API.Models.Achievement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("Id");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("API.Models.GunType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("Id");

                    b.ToTable("GunTypes");
                });

            modelBuilder.Entity("API.Models.LootBoxType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("Id");

                    b.ToTable("LootBoxTypes");
                });

            modelBuilder.Entity("API.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AsteroidsDestroyed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("Crystals")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("Experience")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("Gold")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("Level")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("OpenGunSlots")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("OpenLootBoxSlots")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("Shields")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("API.Models.PlayerAchievement", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<int>("AchievementId")
                        .HasColumnType("integer");

                    b.Property<int>("Progress")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.HasKey("PlayerId", "AchievementId");

                    b.HasIndex("AchievementId");

                    b.ToTable("PlayerAchievements");
                });

            modelBuilder.Entity("API.Models.PlayerGun", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<int>("SlotNumber")
                        .HasColumnType("integer");

                    b.Property<int>("GunTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.HasKey("PlayerId", "SlotNumber");

                    b.HasIndex("GunTypeId");

                    b.ToTable("PlayerGuns");
                });

            modelBuilder.Entity("API.Models.PlayerLootBox", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<int>("SlotNumber")
                        .HasColumnType("integer");

                    b.Property<int>("LootBoxTypeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartOpeningTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("PlayerId", "SlotNumber");

                    b.HasIndex("LootBoxTypeId");

                    b.ToTable("PlayerLootBoxes");
                });

            modelBuilder.Entity("API.Models.PlayerAchievement", b =>
                {
                    b.HasOne("API.Models.Achievement", "Achievement")
                        .WithMany("PlayerAchievements")
                        .HasForeignKey("AchievementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Player", "Player")
                        .WithMany("PlayerAchievements")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Achievement");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("API.Models.PlayerGun", b =>
                {
                    b.HasOne("API.Models.GunType", "GunType")
                        .WithMany("PlayerGuns")
                        .HasForeignKey("GunTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PlayerGun_GunType");

                    b.HasOne("API.Models.Player", "Player")
                        .WithMany("PlayerGuns")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GunType");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("API.Models.PlayerLootBox", b =>
                {
                    b.HasOne("API.Models.LootBoxType", "LootBoxType")
                        .WithMany("PlayerLootBoxes")
                        .HasForeignKey("LootBoxTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PlayerLootBox_LootBoxType");

                    b.HasOne("API.Models.Player", "Player")
                        .WithMany("PlayerLootBoxes")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LootBoxType");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("API.Models.Achievement", b =>
                {
                    b.Navigation("PlayerAchievements");
                });

            modelBuilder.Entity("API.Models.GunType", b =>
                {
                    b.Navigation("PlayerGuns");
                });

            modelBuilder.Entity("API.Models.LootBoxType", b =>
                {
                    b.Navigation("PlayerLootBoxes");
                });

            modelBuilder.Entity("API.Models.Player", b =>
                {
                    b.Navigation("PlayerAchievements");

                    b.Navigation("PlayerGuns");

                    b.Navigation("PlayerLootBoxes");
                });
#pragma warning restore 612, 618
        }
    }
}