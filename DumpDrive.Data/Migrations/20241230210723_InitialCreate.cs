using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DumpDrive.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerId = table.Column<int>(name: "Owner_Id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentDriveId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folders_Drives_ParentDriveId",
                        column: x => x.ParentDriveId,
                        principalTable: "Drives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FolderId = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastChanged = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Folders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "Folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SharedFoldersUsers",
                columns: table => new
                {
                    FolderId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedFoldersUsers", x => new { x.UserId, x.FolderId });
                    table.ForeignKey(
                        name: "FK_SharedFoldersUsers_Folders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "Folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SharedFoldersUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FileLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileLines_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilesComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilesComment_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilesComment_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SharedFilesUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    FileId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedFilesUsers", x => new { x.FileId, x.UserId });
                    table.ForeignKey(
                        name: "FK_SharedFilesUsers_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SharedFilesUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Drives",
                columns: new[] { "Id", "Owner_Id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password" },
                values: new object[,]
                {
                    { 1, "manje@mail.com", "123loz_abc" },
                    { 2, "duje@mail.com", "456pass_xyz" }
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "Name", "ParentDriveId" },
                values: new object[,]
                {
                    { 1, "Homework", 1 },
                    { 2, "Essay", 1 },
                    { 3, "Random", 1 },
                    { 4, "Work", 2 }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "Created", "FolderId", "LastChanged", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 30, 21, 7, 23, 119, DateTimeKind.Utc).AddTicks(9750), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "First Draft" },
                    { 2, new DateTime(2024, 12, 30, 21, 7, 23, 119, DateTimeKind.Utc).AddTicks(9753), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Second Draft" },
                    { 3, new DateTime(2024, 12, 30, 21, 7, 23, 119, DateTimeKind.Utc).AddTicks(9754), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Favorite foods" },
                    { 4, new DateTime(2024, 12, 30, 21, 7, 23, 119, DateTimeKind.Utc).AddTicks(9756), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quarter report" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileLines_FileId",
                table: "FileLines",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_FolderId",
                table: "Files",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_FilesComment_FileId",
                table: "FilesComment",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_FilesComment_UserId",
                table: "FilesComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_ParentDriveId",
                table: "Folders",
                column: "ParentDriveId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedFilesUsers_UserId",
                table: "SharedFilesUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedFoldersUsers_FolderId",
                table: "SharedFoldersUsers",
                column: "FolderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileLines");

            migrationBuilder.DropTable(
                name: "FilesComment");

            migrationBuilder.DropTable(
                name: "SharedFilesUsers");

            migrationBuilder.DropTable(
                name: "SharedFoldersUsers");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropTable(
                name: "Drives");
        }
    }
}
