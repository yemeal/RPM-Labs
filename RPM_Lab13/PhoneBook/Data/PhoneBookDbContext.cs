using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Data.Models;

namespace PhoneBook.Data;

public partial class PhoneBookDbContext : DbContext
{
    public PhoneBookDbContext()
    {
    }

    public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Строка подключения передаётся через DI из appsettings.json.
        // Этот метод не содержит захардкоженных значений —
        // конфигурация выполняется в App.xaml.cs через AddDbContext.
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Contacts_pkey");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
