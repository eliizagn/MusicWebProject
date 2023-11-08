﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicWebProject.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MusicWebProject.Migrations
{
    [DbContext(typeof(MusicDbContext))]
    partial class MusicDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MusicWebProject.Data.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SingerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SingerId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("MusicWebProject.Data.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MusicWebProject.Data.Models.MusicCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("MusicCollections");
                });

            modelBuilder.Entity("MusicWebProject.Data.Models.Singer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Singers");
                });

            modelBuilder.Entity("MusicWebProject.Data.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AlbumId")
                        .HasColumnType("integer");

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<int?>("MusicCollectionId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SingerId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("SongYear")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("GenreId");

                    b.HasIndex("MusicCollectionId");

                    b.HasIndex("SingerId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("MusicWebProject.Data.Models.Album", b =>
                {
                    b.HasOne("MusicWebProject.Data.Models.Singer", "Singer")
                        .WithMany("Albums")
                        .HasForeignKey("SingerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Singer");
                });

            modelBuilder.Entity("MusicWebProject.Data.Models.MusicCollection", b =>
                {
                    b.HasOne("MusicWebProject.Data.Models.Genre", "Genre")
                        .WithMany("Collections")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MusicWebProject.Data.Models.Song", b =>
                {
                    b.HasOne("MusicWebProject.Data.Models.Album", "Album")
                        .WithMany()
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicWebProject.Data.Models.Genre", "Genre")
                        .WithMany("Albums")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicWebProject.Data.Models.MusicCollection", null)
                        .WithMany("Albums")
                        .HasForeignKey("MusicCollectionId");

                    b.HasOne("MusicWebProject.Data.Models.Singer", "Singer")
                        .WithMany()
                        .HasForeignKey("SingerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Genre");

                    b.Navigation("Singer");
                });

            modelBuilder.Entity("MusicWebProject.Data.Models.Genre", b =>
                {
                    b.Navigation("Collections");

                    b.Navigation("Albums");
                });

            modelBuilder.Entity("MusicWebProject.Data.Models.MusicCollection", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("MusicWebProject.Data.Models.Singer", b =>
                {
                    b.Navigation("Albums");
                });
#pragma warning restore 612, 618
        }
    }
}
