﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SmartCity.Infrastructure.DataContext;

#nullable disable

namespace SmartCity.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241128163023_v2")]
    partial class v2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SmartCity.Domain.Entities.MAdministrativeArea", b =>
                {
                    b.Property<int>("AreaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("area_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AreaId"));

                    b.Property<string>("AreaName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("area_name");

                    b.Property<string>("AreaType")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("area_type");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("now()");

                    b.Property<bool>("DeleteFlag")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("delete_flag");

                    b.Property<string>("EngType")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("eng_type");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("integer")
                        .HasColumnName("last_modified_by");

                    b.Property<DateTime>("LastModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("last_modified_date")
                        .HasDefaultValueSql("now()");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer")
                        .HasColumnName("parent_id");

                    b.HasKey("AreaId")
                        .HasName("m_administrative_area_pk");

                    b.HasIndex("ParentId");

                    b.ToTable("m_administrative_area", (string)null);
                });

            modelBuilder.Entity("SmartCity.Domain.Entities.MFile", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("file_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FileId"));

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("now()");

                    b.Property<bool>("DeleteFlag")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("delete_flag");

                    b.Property<string>("FileName")
                        .HasColumnType("text")
                        .HasColumnName("file_name");

                    b.Property<string>("FilePath")
                        .HasColumnType("text")
                        .HasColumnName("file_path");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("last_modified_by");

                    b.Property<DateTime>("LastModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("last_modified_date")
                        .HasDefaultValueSql("now()");

                    b.HasKey("FileId")
                        .HasName("m_file_pk");

                    b.ToTable("m_file", (string)null);
                });

            modelBuilder.Entity("SmartCity.Domain.Entities.MPlaceDetail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("detail_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DetailId"));

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("now()");

                    b.Property<bool>("DeleteFlag")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("delete_flag");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("integer")
                        .HasColumnName("last_modified_by");

                    b.Property<DateTime>("LastModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("last_modified_date")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("OpeningHours")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("opening_hours");

                    b.Property<string>("OsmId")
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)")
                        .HasColumnName("osm_id");

                    b.HasKey("DetailId")
                        .HasName("m_place_detail_pk");

                    b.ToTable("m_place_detail", (string)null);
                });

            modelBuilder.Entity("SmartCity.Domain.Entities.MPlaceType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("type_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TypeId"));

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("now()");

                    b.Property<bool>("DeleteFlag")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("delete_flag");

                    b.Property<string>("Fclass")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("fclass");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("last_modified_by");

                    b.Property<DateTime>("LastModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("last_modified_date")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("TypeName")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("type_name");

                    b.HasKey("TypeId")
                        .HasName("m_place_type_pk");

                    b.ToTable("m_place_type", (string)null);
                });

            modelBuilder.Entity("SmartCity.Domain.Entities.MUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<int>("AvatarId")
                        .HasColumnType("integer")
                        .HasColumnName("avatar_id");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("now()");

                    b.Property<bool>("DeleteFlag")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("delete_flag");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("last_modified_by");

                    b.Property<DateTime>("LastModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("last_modified_date")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("password_hash");

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("username");

                    b.HasKey("UserId")
                        .HasName("m_user_pk");

                    b.HasIndex("AvatarId");

                    b.HasIndex(new[] { "Username" }, "m_user_name_key")
                        .IsUnique();

                    b.ToTable("m_user", (string)null);
                });

            modelBuilder.Entity("SmartCity.Domain.Entities.TPlacePhoto", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("photo_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PhotoId"));

                    b.Property<string>("Caption")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("caption");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("now()");

                    b.Property<bool>("DeleteFlag")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("delete_flag");

                    b.Property<int>("DetailId")
                        .HasColumnType("integer")
                        .HasColumnName("detail_id");

                    b.Property<int>("FileId")
                        .HasColumnType("integer")
                        .HasColumnName("file_id");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("last_modified_by");

                    b.Property<DateTime>("LastModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("last_modified_date")
                        .HasDefaultValueSql("now()");

                    b.HasKey("PhotoId")
                        .HasName("t_place_photo_pk");

                    b.HasIndex("DetailId");

                    b.HasIndex("FileId");

                    b.ToTable("t_place_photo", (string)null);
                });

            modelBuilder.Entity("SmartCity.Domain.Entities.TPlaceReview", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("review_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ReviewId"));

                    b.Property<string>("Comment")
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("now()");

                    b.Property<bool>("DeleteFlag")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("delete_flag");

                    b.Property<int>("DetailId")
                        .HasColumnType("integer")
                        .HasColumnName("detail_id");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("last_modified_by");

                    b.Property<DateTime>("LastModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("last_modified_date")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("ReviewId")
                        .HasName("t_place_review_pk");

                    b.HasIndex("DetailId");

                    b.HasIndex("UserId");

                    b.ToTable("t_place_review", (string)null);
                });

            modelBuilder.Entity("SmartCity.Domain.Entities.MAdministrativeArea", b =>
                {
                    b.HasOne("SmartCity.Domain.Entities.MAdministrativeArea", "Parent")
                        .WithMany("InverseParent")
                        .HasForeignKey("ParentId")
                        .HasConstraintName("m_administrative_area_m_administrative_area_fk");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("SmartCity.Domain.Entities.MUser", b =>
                {
                    b.HasOne("SmartCity.Domain.Entities.MFile", "Avatar")
                        .WithMany("MUsers")
                        .HasForeignKey("AvatarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("m_user_m_file_fk");

                    b.Navigation("Avatar");
                });

            modelBuilder.Entity("SmartCity.Domain.Entities.TPlacePhoto", b =>
                {
                    b.HasOne("SmartCity.Domain.Entities.MPlaceDetail", "Detail")
                        .WithMany("TPlacePhotos")
                        .HasForeignKey("DetailId")
                        .IsRequired()
                        .HasConstraintName("t_place_photo_m_place_detail_fk");

                    b.HasOne("SmartCity.Domain.Entities.MFile", "File")
                        .WithMany("TPlacePhotos")
                        .HasForeignKey("FileId")
                        .IsRequired()
                        .HasConstraintName("t_place_photo_m_file_fk");

                    b.Navigation("Detail");

                    b.Navigation("File");
                });

            modelBuilder.Entity("SmartCity.Domain.Entities.TPlaceReview", b =>
                {
                    b.HasOne("SmartCity.Domain.Entities.MPlaceDetail", "Detail")
                        .WithMany("TPlaceReviews")
                        .HasForeignKey("DetailId")
                        .IsRequired()
                        .HasConstraintName("t_place_review_m_place_detail_fk");

                    b.HasOne("SmartCity.Domain.Entities.MUser", "User")
                        .WithMany("TPlaceReviews")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("t_place_review_m_user_fk");

                    b.Navigation("Detail");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartCity.Domain.Entities.MAdministrativeArea", b =>
                {
                    b.Navigation("InverseParent");
                });

            modelBuilder.Entity("SmartCity.Domain.Entities.MFile", b =>
                {
                    b.Navigation("MUsers");

                    b.Navigation("TPlacePhotos");
                });

            modelBuilder.Entity("SmartCity.Domain.Entities.MPlaceDetail", b =>
                {
                    b.Navigation("TPlacePhotos");

                    b.Navigation("TPlaceReviews");
                });

            modelBuilder.Entity("SmartCity.Domain.Entities.MUser", b =>
                {
                    b.Navigation("TPlaceReviews");
                });
#pragma warning restore 612, 618
        }
    }
}
