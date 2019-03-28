using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scientific_report.Migrations
{
    public partial class new_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facultets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facultets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkEnums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkEnums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cafedras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    FacultetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cafedras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cafedras_Facultets_FacultetId",
                        column: x => x.FacultetId,
                        principalTable: "Facultets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Works_WorkEnums_TypeId",
                        column: x => x.TypeId,
                        principalTable: "WorkEnums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SurName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Chair = table.Column<string>(nullable: true),
                    Year_of_birth = table.Column<int>(nullable: false),
                    Year_of_graduation = table.Column<int>(nullable: false),
                    Degree = table.Column<string>(nullable: true),
                    year_of_Protection = table.Column<int>(nullable: false),
                    Academic_status = table.Column<string>(nullable: true),
                    Year_of_Assignment = table.Column<int>(nullable: false),
                    CafedraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Cafedras_CafedraId",
                        column: x => x.CafedraId,
                        principalTable: "Cafedras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Work_Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WorkId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Work_Users_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Work_Users_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cafedras_FacultetId",
                table: "Cafedras",
                column: "FacultetId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_CafedraId",
                table: "Teachers",
                column: "CafedraId");

            migrationBuilder.CreateIndex(
                name: "IX_Work_Users_TeacherId",
                table: "Work_Users",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Work_Users_WorkId",
                table: "Work_Users",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_TypeId",
                table: "Works",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Work_Users");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "Cafedras");

            migrationBuilder.DropTable(
                name: "WorkEnums");

            migrationBuilder.DropTable(
                name: "Facultets");
        }
    }
}
