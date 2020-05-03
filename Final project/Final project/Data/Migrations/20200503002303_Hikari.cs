using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_project.Data.Migrations
{
    public partial class Hikari : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EvaluationModelId",
                table: "EstimatedTasks",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EvaluationModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Risk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstimatedTasks_EvaluationModelId",
                table: "EstimatedTasks",
                column: "EvaluationModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_EstimatedTasks_EvaluationModel_EvaluationModelId",
                table: "EstimatedTasks",
                column: "EvaluationModelId",
                principalTable: "EvaluationModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstimatedTasks_EvaluationModel_EvaluationModelId",
                table: "EstimatedTasks");

            migrationBuilder.DropTable(
                name: "EvaluationModel");

            migrationBuilder.DropIndex(
                name: "IX_EstimatedTasks_EvaluationModelId",
                table: "EstimatedTasks");

            migrationBuilder.DropColumn(
                name: "EvaluationModelId",
                table: "EstimatedTasks");
        }
    }
}
