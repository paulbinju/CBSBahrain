using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CBSBahrainMVC.Models
{
    public partial class CBSBahrainContext : DbContext
    {
        public CBSBahrainContext()
        {
        }

        public CBSBahrainContext(DbContextOptions<CBSBahrainContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<ClassStd> ClassStd { get; set; }
        public virtual DbSet<Cmsuser> Cmsuser { get; set; }
        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<LessonClassStd> LessonClassStd { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<SongBank> SongBank { get; set; }
        public virtual DbSet<SongBankCategory> SongBankCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=LAPTOP-ATCC4QH4;Database=CBSBahrain;User Id= sa; Password=kenw000d;");
                optionsBuilder.UseSqlServer("Server=sql5050.site4now.net;Database=DB_A512F4_CBSBahrain;User Id=DB_A512F4_CBSBahrain_admin; Password=Majlis@bahrain20;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Category1)
                    .HasColumnName("Category")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ClassStd>(entity =>
            {
                entity.HasKey(e => e.ClassId)
                    .HasName("PK_Class");

                entity.Property(e => e.ClassName).HasMaxLength(50);
            });

            modelBuilder.Entity<Cmsuser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("CMSUser");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("smalldatetime");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Lesson)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_Lesson_ClassStd");
            });

            modelBuilder.Entity<LessonClassStd>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LessonClassStd");

                entity.Property(e => e.ClassName).HasMaxLength(50);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.NotificationId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Settings>(entity =>
            {
                entity.Property(e => e.SettingsId).HasColumnName("SettingsID");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<SongBank>(entity =>
            {
                entity.HasKey(e => e.SongId);

                entity.Property(e => e.SongId).HasColumnName("SongID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.YoutubeUrl).HasColumnName("YoutubeURL");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SongBank)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_SongBank_Category");
            });

            modelBuilder.Entity<SongBankCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SongBankCategory");

                entity.Property(e => e.CatCategoryId).HasColumnName("CatCategoryID");

                entity.Property(e => e.Category).HasMaxLength(100);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.SongId).HasColumnName("SongID");

                entity.Property(e => e.YoutubeUrl).HasColumnName("YoutubeURL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
