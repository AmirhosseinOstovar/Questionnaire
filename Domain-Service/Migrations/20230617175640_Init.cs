using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainService.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Question");

            migrationBuilder.CreateTable(
                name: "CategoryQuestion",
                schema: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryQuestion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                schema: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    questionType = table.Column<int>(type: "int", nullable: false),
                    CategoryQuestionId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_CategoryQuestion_CategoryQuestionId",
                        column: x => x.CategoryQuestionId,
                        principalSchema: "Question",
                        principalTable: "CategoryQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultipleOptionsResponse",
                schema: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleOptionsResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleOptionsResponse_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "Question",
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Response",
                schema: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Insertdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Response_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "Question",
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categoryresponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Responseid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoryresponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categoryresponses_CategoryQuestion_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Question",
                        principalTable: "CategoryQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Categoryresponses_Response_Responseid",
                        column: x => x.Responseid,
                        principalSchema: "Question",
                        principalTable: "Response",
                        principalColumn: "Id",
                      onDelete: ReferentialAction.NoAction,
                      onUpdate: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoryresponses_CategoryId",
                table: "Categoryresponses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categoryresponses_Responseid",
                table: "Categoryresponses",
                column: "Responseid");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleOptionsResponse_QuestionId",
                schema: "Question",
                table: "MultipleOptionsResponse",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_CategoryQuestionId",
                schema: "Question",
                table: "Question",
                column: "CategoryQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Response_QuestionId",
                schema: "Question",
                table: "Response",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoryresponses");

            migrationBuilder.DropTable(
                name: "MultipleOptionsResponse",
                schema: "Question");

            migrationBuilder.DropTable(
                name: "Response",
                schema: "Question");

            migrationBuilder.DropTable(
                name: "Question",
                schema: "Question");

            migrationBuilder.DropTable(
                name: "CategoryQuestion",
                schema: "Question");
        }
    }
}
