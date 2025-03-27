using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivityTracker.Infrastructure.Migrations;

/// <inheritdoc />
public partial class Init : Migration
{
  /// <inheritdoc />
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.CreateTable(
        name: "Projects",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Projects", x => x.Id);
        });

    migrationBuilder.CreateTable(
        name: "Users",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          FullName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
          ProfilePhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Users", x => x.Id);
        });

    migrationBuilder.CreateTable(
        name: "Activities",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
          EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
          Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
          Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
          UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Activities", x => x.Id);
          table.ForeignKey(
                    name: "FK_Activities_Projects_ProjectId",
                    column: x => x.ProjectId,
                    principalTable: "Projects",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
          table.ForeignKey(
                    name: "FK_Activities_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
        });

    migrationBuilder.CreateTable(
        name: "ProjectUser",
        columns: table => new
        {
          ProjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_ProjectUser", x => new { x.ProjectsId, x.UsersId });
          table.ForeignKey(
                    name: "FK_ProjectUser_Projects_ProjectsId",
                    column: x => x.ProjectsId,
                    principalTable: "Projects",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
          table.ForeignKey(
                    name: "FK_ProjectUser_Users_UsersId",
                    column: x => x.UsersId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
        });

    migrationBuilder.CreateIndex(
        name: "IX_Activities_ProjectId",
        table: "Activities",
        column: "ProjectId");

    migrationBuilder.CreateIndex(
        name: "IX_Activities_UserId",
        table: "Activities",
        column: "UserId");

    migrationBuilder.CreateIndex(
        name: "IX_ProjectUser_UsersId",
        table: "ProjectUser",
        column: "UsersId");
  }

  /// <inheritdoc />
  protected override void Down(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.DropTable(
        name: "Activities");

    migrationBuilder.DropTable(
        name: "ProjectUser");

    migrationBuilder.DropTable(
        name: "Projects");

    migrationBuilder.DropTable(
        name: "Users");
  }
}
