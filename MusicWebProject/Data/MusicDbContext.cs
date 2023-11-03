using Microsoft.EntityFrameworkCore;
using MusicWebProject.Data.Models;

namespace MusicWebProject.Data;

public sealed class MusicDbContext : DbContext
{
    // модификатор доступа - тип - название - гет сет
    public DbSet<Singer> Singers { get; set; } 
    public DbSet<Album> Albums { get; set; } 
    public DbSet<Song> Songs { get; set; } 
    public DbSet<Genre> Genres { get; set; }
    public DbSet<MusicCollection> MusicCollections { get; set; }
    public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options)
    {
    }
}

  

