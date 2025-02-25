﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using ClassDemoRazorWithDatabase.services;
using Microsoft.EntityFrameworkCore;

namespace ClassDemoRazorWithDatabase.model;

public partial class EFDrinkContext : DbContext
{
    public EFDrinkContext()
    {
    }

    public EFDrinkContext(DbContextOptions<EFDrinkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AlkoholView> AlkoholViews { get; set; }

    public virtual DbSet<Drink> Drinks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(Secret.ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlkoholView>(entity =>
        {
            entity.ToView("AlkoholView");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Drink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Drink__3214EC071B91FA51");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}