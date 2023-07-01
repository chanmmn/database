using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConAppRandomState.Models;

public partial class PocContext : DbContext
{
    public PocContext()
    {
    }

    public PocContext(DbContextOptions<PocContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CountryState> CountryStates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=poc;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CountryState>(entity =>
        {
            entity.HasKey(e => e.Gid);

            entity.ToTable("CountryState");

            entity.Property(e => e.Gid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("gid");
            entity.Property(e => e.StateName)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
