using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutoReferenceSystem.ApplicationServer.Data.PostgreSql.Migrations.AutoReferenceSystemDb
{
    /// <inheritdoc />
    public partial class InitAutoReferenceSystemDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttachmentsTypes",
                columns: table => new
                {
                    id_attachment_type = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentsTypes", x => x.id_attachment_type);
                });

            migrationBuilder.CreateTable(
                name: "CharacteristicsTypes",
                columns: table => new
                {
                    id_characteristics_type = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacteristicsTypes", x => x.id_characteristics_type);
                });

            migrationBuilder.CreateTable(
                name: "Measures",
                columns: table => new
                {
                    measure_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measures", x => x.measure_id);
                });

            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    id_server = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    address = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    user = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    user_password = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.id_server);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    last_name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    patronymic = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    login = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    password = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Characteristics",
                columns: table => new
                {
                    id_characteristics = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    id_characteristics_type = table.Column<int>(type: "integer", nullable: false),
                    id_measure = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characteristics", x => x.id_characteristics);
                    table.ForeignKey(
                        name: "FK_Characteristics_CharacteristicsTypes_id_characteristics_type",
                        column: x => x.id_characteristics_type,
                        principalTable: "CharacteristicsTypes",
                        principalColumn: "id_characteristics_type",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characteristics_Measures_id_measure",
                        column: x => x.id_measure,
                        principalTable: "Measures",
                        principalColumn: "measure_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    id_model = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    id_server = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.id_model);
                    table.ForeignKey(
                        name: "FK_Models_Servers_id_server",
                        column: x => x.id_server,
                        principalTable: "Servers",
                        principalColumn: "id_server",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    id_session = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    begin_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.id_session);
                    table.ForeignKey(
                        name: "FK_Sessions_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListValuesCharacteristics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_characteristics = table.Column<int>(type: "integer", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListValuesCharacteristics", x => x.id);
                    table.ForeignKey(
                        name: "FK_ListValuesCharacteristics_Characteristics_id_characteristics",
                        column: x => x.id_characteristics,
                        principalTable: "Characteristics",
                        principalColumn: "id_characteristics",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelCharacteristics",
                columns: table => new
                {
                    id_model = table.Column<int>(type: "integer", nullable: false),
                    id_characteristics = table.Column<int>(type: "integer", nullable: false),
                    value = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelCharacteristics", x => new { x.id_model, x.id_characteristics });
                    table.ForeignKey(
                        name: "FK_ModelCharacteristics_Characteristics_id_characteristics",
                        column: x => x.id_characteristics,
                        principalTable: "Characteristics",
                        principalColumn: "id_characteristics",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelCharacteristics_Models_id_model",
                        column: x => x.id_model,
                        principalTable: "Models",
                        principalColumn: "id_model",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReferencingQueries",
                columns: table => new
                {
                    id_query = table.Column<Guid>(type: "uuid", nullable: false),
                    query_number = table.Column<int>(type: "integer", nullable: false),
                    id_session = table.Column<Guid>(type: "uuid", nullable: false),
                    id_model = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferencingQueries", x => x.id_query);
                    table.ForeignKey(
                        name: "FK_ReferencingQueries_Models_id_model",
                        column: x => x.id_model,
                        principalTable: "Models",
                        principalColumn: "id_model",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReferencingQueries_Sessions_id_session",
                        column: x => x.id_session,
                        principalTable: "Sessions",
                        principalColumn: "id_session",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    id_attachment = table.Column<Guid>(type: "uuid", nullable: false),
                    creation_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    attachment_size_in_bytes = table.Column<long>(type: "bigint", nullable: true),
                    id_attachment_type = table.Column<int>(type: "integer", nullable: false),
                    path = table.Column<string>(type: "text", nullable: false),
                    id_query = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.id_attachment);
                    table.ForeignKey(
                        name: "FK_Attachments_AttachmentsTypes_id_attachment_type",
                        column: x => x.id_attachment_type,
                        principalTable: "AttachmentsTypes",
                        principalColumn: "id_attachment_type",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attachments_ReferencingQueries_id_query",
                        column: x => x.id_query,
                        principalTable: "ReferencingQueries",
                        principalColumn: "id_query",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReferencingQueryCharacteristics",
                columns: table => new
                {
                    id_characteristics = table.Column<int>(type: "integer", nullable: false),
                    id_query = table.Column<Guid>(type: "uuid", nullable: false),
                    value = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferencingQueryCharacteristics", x => new { x.id_characteristics, x.id_query });
                    table.ForeignKey(
                        name: "FK_ReferencingQueryCharacteristics_Characteristics_id_characte~",
                        column: x => x.id_characteristics,
                        principalTable: "Characteristics",
                        principalColumn: "id_characteristics",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReferencingQueryCharacteristics_ReferencingQueries_id_query",
                        column: x => x.id_query,
                        principalTable: "ReferencingQueries",
                        principalColumn: "id_query",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_id_attachment_type",
                table: "Attachments",
                column: "id_attachment_type");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_id_query",
                table: "Attachments",
                column: "id_query");

            migrationBuilder.CreateIndex(
                name: "IX_Characteristics_id_characteristics_type",
                table: "Characteristics",
                column: "id_characteristics_type");

            migrationBuilder.CreateIndex(
                name: "IX_Characteristics_id_measure",
                table: "Characteristics",
                column: "id_measure");

            migrationBuilder.CreateIndex(
                name: "IX_ListValuesCharacteristics_id_characteristics",
                table: "ListValuesCharacteristics",
                column: "id_characteristics");

            migrationBuilder.CreateIndex(
                name: "IX_ModelCharacteristics_id_characteristics",
                table: "ModelCharacteristics",
                column: "id_characteristics");

            migrationBuilder.CreateIndex(
                name: "IX_Models_id_server",
                table: "Models",
                column: "id_server");

            migrationBuilder.CreateIndex(
                name: "IX_ReferencingQueries_id_model",
                table: "ReferencingQueries",
                column: "id_model");

            migrationBuilder.CreateIndex(
                name: "IX_ReferencingQueries_id_session",
                table: "ReferencingQueries",
                column: "id_session");

            migrationBuilder.CreateIndex(
                name: "IX_ReferencingQueryCharacteristics_id_query",
                table: "ReferencingQueryCharacteristics",
                column: "id_query");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_user_id",
                table: "Sessions",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "ListValuesCharacteristics");

            migrationBuilder.DropTable(
                name: "ModelCharacteristics");

            migrationBuilder.DropTable(
                name: "ReferencingQueryCharacteristics");

            migrationBuilder.DropTable(
                name: "AttachmentsTypes");

            migrationBuilder.DropTable(
                name: "Characteristics");

            migrationBuilder.DropTable(
                name: "ReferencingQueries");

            migrationBuilder.DropTable(
                name: "CharacteristicsTypes");

            migrationBuilder.DropTable(
                name: "Measures");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Servers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
