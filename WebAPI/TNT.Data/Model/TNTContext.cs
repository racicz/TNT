using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using TNT.Shared.Model.User;

namespace TNT.Data.Model
{
    public partial class TNTContext : DbContext
    {
        

        public TNTContext()
        {
        }

        public TNTContext(DbContextOptions<TNTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AutoNumber> AutoNumbers { get; set; }
        public virtual DbSet<Business> Businesses { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<FishType> FishTypes { get; set; }
        public virtual DbSet<FishTypePreparation> FishTypePreparations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderDetailPreparation> OrderDetailPreparations { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Preparation> Preparations { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectContactType> SubjectContactTypes { get; set; }
        public virtual DbSet<Town> Towns { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AutoNumber>(entity =>
            {
                entity.ToTable("AutoNumber");
            });

            modelBuilder.Entity<Business>(entity =>
            {
                entity.HasKey(e => e.SubjectId);

                entity.ToTable("Business");

                entity.Property(e => e.SubjectId).ValueGeneratedNever();

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contact)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Town)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Subject)
                    .WithOne(p => p.Business)
                    .HasForeignKey<Business>(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Business_Subject");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.SubjectContactId);

                entity.ToTable("Contact");

                entity.Property(e => e.ContactValue)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.SubjectContactType)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.SubjectContactTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contact_SubjectContactType");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contact_Subject");
            });

            modelBuilder.Entity<FishType>(entity =>
            {
                entity.ToTable("FishType");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(12, 2)");
            });

            modelBuilder.Entity<FishTypePreparation>(entity =>
            {
                entity.ToTable("FishTypePreparation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.FishType)
                    .WithMany(p => p.FishTypePreparations)
                    .HasForeignKey(d => d.FishTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FishTypePreparation_FishType");

                entity.HasOne(d => d.Preparation)
                    .WithMany(p => p.FishTypePreparations)
                    .HasForeignKey(d => d.PreparationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FishTypePreparation_Preparation");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.DeliveryDate)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryTime)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OrderTime)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Subject");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.Property(e => e.AmountDue).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.AmountPaid).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.DeliveredKg).HasColumnType("decimal(12, 3)");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.OrderKg).HasColumnType("decimal(12, 3)");

                entity.Property(e => e.PricePerKg).HasColumnType("decimal(12, 3)");

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.HasOne(d => d.FishType)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.FishTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_FishType");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Order");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Status");
            });

            modelBuilder.Entity<OrderDetailPreparation>(entity =>
            {
                entity.ToTable("OrderDetailPreparation");

                entity.HasOne(d => d.OrderDetail)
                    .WithMany(p => p.OrderDetailPreparations)
                    .HasForeignKey(d => d.OrderDetailId)
                    .HasConstraintName("FK_OrderDetailPreparation_OrderDetail");

                entity.HasOne(d => d.Preparation)
                    .WithMany(p => p.OrderDetailPreparations)
                    .HasForeignKey(d => d.PreparationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetailPreparation_Preparation");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.SubjectId);

                entity.ToTable("Person");

                entity.Property(e => e.SubjectId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Subject)
                    .WithOne(p => p.Person)
                    .HasForeignKey<Person>(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_Subject");
            });

            modelBuilder.Entity<Preparation>(entity =>
            {
                entity.ToTable("Preparation");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.SubjectType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.Town)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.TownId)
                    .HasConstraintName("FK_Subject_Town");
            });

            modelBuilder.Entity<SubjectContactType>(entity =>
            {
                entity.ToTable("SubjectContactType");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.ToTable("Town");

                entity.Property(e => e.TownName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
            
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
