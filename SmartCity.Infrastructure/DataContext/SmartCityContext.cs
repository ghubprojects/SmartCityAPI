using Microsoft.EntityFrameworkCore;
using SmartCity.Domain.Entities;

namespace SmartCity.Infrastructure.DataContext;

public partial class SmartCityContext : DbContext {
    public SmartCityContext() { }

    public SmartCityContext(DbContextOptions<SmartCityContext> options) : base(options) { }

    public virtual DbSet<PoiDetail> PoiDetails { get; set; }

    public virtual DbSet<PoiPhoto> PoiPhotos { get; set; }

    public virtual DbSet<PoiReview> PoiReviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<PoiDetail>(entity => {
            entity.HasKey(e => e.DetailId).HasName("poi_detail_pkey");

            entity.ToTable("poi_detail");

            entity.Property(e => e.DetailId)
                .ValueGeneratedNever()
                .HasColumnName("detail_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.DeleteFlag)
                .HasDefaultValue(false)
                .HasColumnName("delete_flag");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.LastModifiedBy).HasColumnName("last_modified_by");
            entity.Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_modified_date");
            entity.Property(e => e.OpeningHours)
                .HasMaxLength(100)
                .HasColumnName("opening_hours");
            entity.Property(e => e.PoiGid).HasColumnName("poi_gid");
        });

        modelBuilder.Entity<PoiPhoto>(entity => {
            entity.HasKey(e => e.PhotoId).HasName("poi_photo_pkey");

            entity.ToTable("poi_photo");

            entity.Property(e => e.PhotoId)
                .ValueGeneratedNever()
                .HasColumnName("photo_id");
            entity.Property(e => e.Caption)
                .HasMaxLength(255)
                .HasColumnName("caption");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.DeleteFlag)
                .HasDefaultValue(false)
                .HasColumnName("delete_flag");
            entity.Property(e => e.DetailId).HasColumnName("detail_id");
            entity.Property(e => e.LastModifiedBy).HasColumnName("last_modified_by");
            entity.Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_modified_date");
            entity.Property(e => e.Url).HasColumnName("url");

            entity.HasOne(d => d.Detail).WithMany(p => p.PoiPhotos)
                .HasForeignKey(d => d.DetailId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("poi_photo_detail_id_fkey");
        });

        modelBuilder.Entity<PoiReview>(entity => {
            entity.HasKey(e => e.ReviewId).HasName("poi_review_pkey");

            entity.ToTable("poi_review");

            entity.Property(e => e.ReviewId)
                .ValueGeneratedNever()
                .HasColumnName("review_id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.DeleteFlag)
                .HasDefaultValue(false)
                .HasColumnName("delete_flag");
            entity.Property(e => e.DetailId).HasColumnName("detail_id");
            entity.Property(e => e.LastModifiedBy).HasColumnName("last_modified_by");
            entity.Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_modified_date");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Detail).WithMany(p => p.PoiReviews)
                .HasForeignKey(d => d.DetailId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("poi_review_detail_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.PoiReviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("poi_review_user_id_fkey");
        });

        modelBuilder.Entity<User>(entity => {
            entity.HasKey(e => e.UserId).HasName("user_pkey");

            entity.ToTable("user");

            entity.HasIndex(e => e.Email, "user_email_key").IsUnique();

            entity.HasIndex(e => e.Username, "user_username_key").IsUnique();

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.DeleteFlag)
                .HasDefaultValue(false)
                .HasColumnName("delete_flag");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.LastModifiedBy).HasColumnName("last_modified_by");
            entity.Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_modified_date");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
