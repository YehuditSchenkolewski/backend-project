using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dot_net_userInfo.Migrations
{
    public partial class InitialDBAndSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Team = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JoinedAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Auth_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Score = table.Column<int>(type: "int", nullable: true),
                    DurationInDays = table.Column<int>(type: "int", nullable: true),
                    BugsCount = table.Column<int>(type: "int", nullable: true),
                    MadeDadeline = table.Column<bool>(type: "bit", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auth_Id",
                table: "Auth",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder
            .Sql("INSERT INTO Auth(Id, Token, UserId) Values (1, '1111-2222-3333-4444', '1')");

            migrationBuilder
          .Sql("INSERT INTO User(Id, Email, Password, Name, Team, Avatar, JoinedAt) Values (1, 'Email@example.com', '1234', 'Test Test', 'Developers', 'https://avatarfiles.alphacoders.co-m/164/thumb-164632.jpg', '2018-10-01')");

            migrationBuilder
            .Sql("INSERT INTO Project (Id, Name, Score, DurationInDays, BugsCount, MadeDadeline, UserId) Values ('5fb9953bd98214b6df37174d', 'Backend Project', 88, 35, 74, false, 1)," +
                                                                                                                    "('5fb9953b9937c7bcd60c4bc5', 'Design Project', 68, 55, 52, false, 1)," +
                                                                                                                    "('5fb9953b899dd436c5604120', 'Backend Project', 90, 36, 34, true, 1)," +
                                                                                                                    "('5fb9953b97e765bfc40b0e64', 'Frontend Project', 99, 51, 32, true, 1)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auth");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}