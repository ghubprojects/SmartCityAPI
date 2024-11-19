using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SmartCity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "m_administrative_area",
                columns: table => new
                {
                    area_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    area_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    area_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    eng_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    parent_id = table.Column<int>(type: "integer", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    last_modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<int>(type: "integer", nullable: false),
                    delete_flag = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("m_administrative_area_pk", x => x.area_id);
                    table.ForeignKey(
                        name: "m_administrative_area_m_administrative_area_fk",
                        column: x => x.parent_id,
                        principalTable: "m_administrative_area",
                        principalColumn: "area_id");
                });

            migrationBuilder.CreateTable(
                name: "m_file",
                columns: table => new
                {
                    file_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    file_name = table.Column<string>(type: "text", nullable: true),
                    file_path = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    created_by = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    delete_flag = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("m_file_pk", x => x.file_id);
                });

            migrationBuilder.CreateTable(
                name: "m_place_detail",
                columns: table => new
                {
                    detail_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    osm_id = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    opening_hours = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    created_by = table.Column<int>(type: "integer", nullable: false),
                    last_modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<int>(type: "integer", nullable: false),
                    delete_flag = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("m_place_detail_pk", x => x.detail_id);
                });

            migrationBuilder.CreateTable(
                name: "m_place_type",
                columns: table => new
                {
                    type_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    fclass = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    created_by = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    delete_flag = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("m_place_type_pk", x => x.type_id);
                });

            migrationBuilder.CreateTable(
                name: "m_user",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    password_hash = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    avatar_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    created_by = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    delete_flag = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("m_user_pk", x => x.user_id);
                    table.ForeignKey(
                        name: "m_user_m_file_fk",
                        column: x => x.avatar_id,
                        principalTable: "m_file",
                        principalColumn: "file_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_place_photo",
                columns: table => new
                {
                    photo_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    detail_id = table.Column<int>(type: "integer", nullable: false),
                    file_id = table.Column<int>(type: "integer", nullable: false),
                    caption = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    created_by = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    delete_flag = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("t_place_photo_pk", x => x.photo_id);
                    table.ForeignKey(
                        name: "t_place_photo_m_file_fk",
                        column: x => x.file_id,
                        principalTable: "m_file",
                        principalColumn: "file_id");
                    table.ForeignKey(
                        name: "t_place_photo_m_place_detail_fk",
                        column: x => x.detail_id,
                        principalTable: "m_place_detail",
                        principalColumn: "detail_id");
                });

            migrationBuilder.CreateTable(
                name: "t_place_review",
                columns: table => new
                {
                    review_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    detail_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    rating = table.Column<int>(type: "integer", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    created_by = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    delete_flag = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("t_place_review_pk", x => x.review_id);
                    table.ForeignKey(
                        name: "t_place_review_m_place_detail_fk",
                        column: x => x.detail_id,
                        principalTable: "m_place_detail",
                        principalColumn: "detail_id");
                    table.ForeignKey(
                        name: "t_place_review_m_user_fk",
                        column: x => x.user_id,
                        principalTable: "m_user",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_m_administrative_area_parent_id",
                table: "m_administrative_area",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_m_user_avatar_id",
                table: "m_user",
                column: "avatar_id");

            migrationBuilder.CreateIndex(
                name: "m_user_email_key",
                table: "m_user",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_place_photo_detail_id",
                table: "t_place_photo",
                column: "detail_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_place_photo_file_id",
                table: "t_place_photo",
                column: "file_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_place_review_detail_id",
                table: "t_place_review",
                column: "detail_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_place_review_user_id",
                table: "t_place_review",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "m_administrative_area");

            migrationBuilder.DropTable(
                name: "m_place_type");

            migrationBuilder.DropTable(
                name: "t_place_photo");

            migrationBuilder.DropTable(
                name: "t_place_review");

            migrationBuilder.DropTable(
                name: "m_place_detail");

            migrationBuilder.DropTable(
                name: "m_user");

            migrationBuilder.DropTable(
                name: "m_file");
        }
    }
}
