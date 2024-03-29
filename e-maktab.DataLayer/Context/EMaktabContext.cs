﻿using System;
using System.Collections.Generic;

using e_maktab.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_maktab.DataLayer.Context;

public partial class EMaktabContext : DbContext
{
    public EMaktabContext()
    {
    }

    public EMaktabContext(DbContextOptions<EMaktabContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<EnumState> EnumStates { get; set; }

    public virtual DbSet<Homework> Homeworks { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleModule> RoleModules { get; set; }

    public virtual DbSet<Science> Sciences { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserClass> UserClasses { get; set; }

    public virtual DbSet<UserLessonAttendance> UserLessonAttendances { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
         => optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=postgres;Database=e-maktab-test");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("attendance_pkey");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("class_pkey");

            entity.Property(e => e.DateOfCreated).HasDefaultValueSql("now()");

            entity.HasOne(d => d.State).WithMany(p => p.Classes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Classes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_teacher_id");
        });

        modelBuilder.Entity<EnumState>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_state_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Homework>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("homework_pkey");

            entity.HasOne(d => d.Lesson).WithMany(p => p.Homeworks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_lesson_id");

            entity.HasOne(d => d.State).WithMany(p => p.Homeworks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Homeworks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_teacher_id");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("lesson_pkey");

            entity.HasOne(d => d.Class).WithMany(p => p.Lessons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_class_id");

            entity.HasOne(d => d.Science).WithMany(p => p.Lessons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_science_id");

            entity.HasOne(d => d.State).WithMany(p => p.Lessons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Lessons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_teacher_id");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("modules_pkey");

            entity.HasOne(d => d.State).WithMany(p => p.Modules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("organization_pkey");

            entity.Property(e => e.DateOfCreated).HasDefaultValueSql("now()");

            entity.HasOne(d => d.State).WithMany(p => p.Organizations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.Property(e => e.DateOfCreated).HasDefaultValueSql("now()");

            entity.HasOne(d => d.State).WithMany(p => p.Roles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<RoleModule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_module_pkey");

            entity.HasOne(d => d.Module).WithMany(p => p.RoleModules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_module_id");

            entity.HasOne(d => d.Role).WithMany(p => p.RoleModules).HasConstraintName("fk_role_id");
        });

        modelBuilder.Entity<Science>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("science_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.State).WithMany(p => p.Sciences)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("teacher_pkey");

            entity.Property(e => e.DateOfCreated).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Organization).WithMany(p => p.Teachers).HasConstraintName("fk_organization_id");

            entity.HasOne(d => d.State).WithMany(p => p.Teachers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.Property(e => e.DateOfCreated).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Organization).WithMany(p => p.Users).HasConstraintName("fk_organization_id");

            entity.HasOne(d => d.State).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<UserClass>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_class_pkey");

            entity.HasOne(d => d.Class).WithMany(p => p.UserClasses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_class_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserClasses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_id");
        });

        modelBuilder.Entity<UserLessonAttendance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_lesson_attendance_pkey");

            entity.HasOne(d => d.Attendance).WithMany(p => p.UserLessonAttendances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_attendance_id");

            entity.HasOne(d => d.Lesson).WithMany(p => p.UserLessonAttendances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_lesson_id");

            entity.HasOne(d => d.State).WithMany(p => p.UserLessonAttendances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserLessonAttendances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_id");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_role_pkey");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_role_id");

            entity.HasOne(d => d.State).WithMany(p => p.UserRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
