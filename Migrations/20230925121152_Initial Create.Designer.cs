﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Minimal_API.Data;

#nullable disable

namespace Minimal_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230925121152_Initial Create")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Minimal_API.Models.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseYear")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Author = "Robert McLeod",
                            Description = "Dive into the heroic stories of Scottish warriors throughout the history, chronicling their bravery and sacrifices on the battlefield.",
                            Genre = "Scottish Military History",
                            Name = "Braveheart and Battles",
                            ReleaseYear = new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 2,
                            Author = "Fiona Campbell",
                            Description = "Explore the intricate web of clan conflicts that shaped Scotland's history, from ancient feuds to power struggles.",
                            Genre = "Scottish Clan Warfare",
                            Name = "Clan Conflicts",
                            ReleaseYear = new DateTime(2019, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 3,
                            Author = "Angus MacGregor",
                            Description = "Examine the events leading up to the Battle of Culloden  in 1746, the tragic culmination of the Jacobite uprising, and it's impact on Scotland",
                            Genre = "Jacobite Uprising",
                            Name = "Culloden: Last Stand of the Highlanders",
                            ReleaseYear = new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 4,
                            Author = "Isobel Fraser",
                            Description = "Trace the battle that defined medieval Scotland, including the iconinc Battle of Bannockburn and the devastating Battle of Flodden.",
                            Genre = "Medieval Scottish Warfare",
                            Name = "From Bannockburn to Flodden",
                            ReleaseYear = new DateTime(2017, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 5,
                            Author = "Malcolm Sinclair",
                            Description = "Shed light on the lesser-known stories of Scottish soldiers and their contributions during World War I, highlighting their sacrifices on the global stage.",
                            Genre = "Scottish Involvement in WWI",
                            Name = "Forgotten Frontlines: World War I",
                            ReleaseYear = new DateTime(2023, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
