using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCorePract.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersRelationManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InterestGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InterestGroupUsers",
                columns: table => new
                {
                    InterestGroupsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestGroupUsers", x => new { x.InterestGroupsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_InterestGroupUsers_InterestGroups_InterestGroupsId",
                        column: x => x.InterestGroupsId,
                        principalTable: "InterestGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestGroupUsers_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersInterestGroups",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InterestGroupId = table.Column<int>(type: "int", nullable: false),
                    JoinedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    IsModerator = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInterestGroups", x => new { x.UserId, x.InterestGroupId });
                    table.ForeignKey(
                        name: "FK_UsersInterestGroups_InterestGroups_InterestGroupId",
                        column: x => x.InterestGroupId,
                        principalTable: "InterestGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersInterestGroups_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterestGroupUsers_UsersId",
                table: "InterestGroupUsers",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInterestGroups_InterestGroupId",
                table: "UsersInterestGroups",
                column: "InterestGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestGroupUsers");

            migrationBuilder.DropTable(
                name: "UsersInterestGroups");

            migrationBuilder.DropTable(
                name: "InterestGroups");
        }
    }
}
