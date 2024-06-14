using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestEnergyProject;

public partial class TsdbContext : DbContext
{
    public TsdbContext()
    {
    }

    public TsdbContext(DbContextOptions<TsdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PowerReading> PowerReadings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=dvio26z5gk.bvcnlkv5qe.tsdb.cloud.timescale.com;port=32079;Username=tsdbadmin;Password=dnqt05srpb99j980;Database=tsdb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("pg_stat_statements")
            .HasPostgresExtension("timescaledb")
            .HasPostgresExtension("timescaledb_toolkit");

        modelBuilder.Entity<PowerReading>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("power_readings_pkey");

            entity.ToTable("power_readings");

            entity.HasIndex(e => new { e.DeviceId, e.ReadingTimestamp }, "idx_power_readings_device_reading");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amperage)
                .HasPrecision(2, 2)
                .HasColumnName("amperage");
            entity.Property(e => e.CreationTimestamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("creation_timestamp");
            entity.Property(e => e.DeviceId)
                .HasMaxLength(24)
                .HasColumnName("device_id");
            entity.Property(e => e.Frequency)
                .HasPrecision(2, 2)
                .HasColumnName("frequency");
            entity.Property(e => e.ReadingTimestamp)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("reading_timestamp");
            entity.Property(e => e.Voltage)
                .HasPrecision(3, 2)
                .HasColumnName("voltage");
            entity.Property(e => e.Watts)
                .HasPrecision(4, 2)
                .HasColumnName("watts");
        });
        modelBuilder.HasSequence("chunk_constraint_name", "_timescaledb_catalog");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
