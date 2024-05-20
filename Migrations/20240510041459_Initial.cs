using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Papalandia.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    AchievementsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AchievementsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AchievementsDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.AchievementsId);
                });

            migrationBuilder.CreateTable(
                name: "PlayerLocation",
                columns: table => new
                {
                    PlayerLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoordinateX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoordinateY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoordinateZ = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerLocation", x => x.PlayerLocationId);
                });

            migrationBuilder.CreateTable(
                name: "Plots",
                columns: table => new
                {
                    PlotsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlotsSize = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plots", x => x.PlotsId);
                });

            migrationBuilder.CreateTable(
                name: "StateCrops",
                columns: table => new
                {
                    StateCropsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateCrop = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateCrops", x => x.StateCropsId);
                });

            migrationBuilder.CreateTable(
                name: "StateTasks",
                columns: table => new
                {
                    StateTasksId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateTasksName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateTasks", x => x.StateTasksId);
                });

            migrationBuilder.CreateTable(
                name: "TypePotatoes",
                columns: table => new
                {
                    TypePotatoesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeNamePotatoes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePotatoes", x => x.TypePotatoesId);
                });

            migrationBuilder.CreateTable(
                name: "TypeSupplies",
                columns: table => new
                {
                    TypeSuppliesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTypeSupplies = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeSupplies", x => x.TypeSuppliesId);
                });

            migrationBuilder.CreateTable(
                name: "UserRols",
                columns: table => new
                {
                    UserRolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRolName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRols", x => x.UserRolId);
                });

            migrationBuilder.CreateTable(
                name: "StateGames",
                columns: table => new
                {
                    StateGameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerLocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateGames", x => x.StateGameId);
                    table.ForeignKey(
                        name: "FK_StateGames_PlayerLocation_PlayerLocationId",
                        column: x => x.PlayerLocationId,
                        principalTable: "PlayerLocation",
                        principalColumn: "PlayerLocationId");
                });

            migrationBuilder.CreateTable(
                name: "Potatoes",
                columns: table => new
                {
                    PotatoesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PotatoesName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeGrowth = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TypePotatoesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Potatoes", x => x.PotatoesId);
                    table.ForeignKey(
                        name: "FK_Potatoes_TypePotatoes_TypePotatoesId",
                        column: x => x.TypePotatoesId,
                        principalTable: "TypePotatoes",
                        principalColumn: "TypePotatoesId");
                });

            migrationBuilder.CreateTable(
                name: "Supplies",
                columns: table => new
                {
                    SuppliesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuppliesName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuppliesDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeSuppliesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies", x => x.SuppliesId);
                    table.ForeignKey(
                        name: "FK_Supplies_TypeSupplies_TypeSuppliesId",
                        column: x => x.TypeSuppliesId,
                        principalTable: "TypeSupplies",
                        principalColumn: "TypeSuppliesId");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserRolId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_UserRols_UserRolId",
                        column: x => x.UserRolId,
                        principalTable: "UserRols",
                        principalColumn: "UserRolId");
                });

            migrationBuilder.CreateTable(
                name: "Pests",
                columns: table => new
                {
                    PestsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PestsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PestsDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuppliesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pests", x => x.PestsId);
                    table.ForeignKey(
                        name: "FK_Pests_Supplies_SuppliesId",
                        column: x => x.SuppliesId,
                        principalTable: "Supplies",
                        principalColumn: "SuppliesId");
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartGame = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndGame = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    StateGameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_StateGames_StateGameId",
                        column: x => x.StateGameId,
                        principalTable: "StateGames",
                        principalColumn: "StateGameId");
                    table.ForeignKey(
                        name: "FK_Games_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Crops",
                columns: table => new
                {
                    CropsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlotsId = table.Column<int>(type: "int", nullable: true),
                    PotatoesId = table.Column<int>(type: "int", nullable: true),
                    PestId = table.Column<int>(type: "int", nullable: true),
                    SowingDate = table.Column<DateOnly>(type: "date", nullable: true),
                    StateCropsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crops", x => x.CropsId);
                    table.ForeignKey(
                        name: "FK_Crops_Pests_PestId",
                        column: x => x.PestId,
                        principalTable: "Pests",
                        principalColumn: "PestsId");
                    table.ForeignKey(
                        name: "FK_Crops_Plots_PlotsId",
                        column: x => x.PlotsId,
                        principalTable: "Plots",
                        principalColumn: "PlotsId");
                    table.ForeignKey(
                        name: "FK_Crops_Potatoes_PotatoesId",
                        column: x => x.PotatoesId,
                        principalTable: "Potatoes",
                        principalColumn: "PotatoesId");
                    table.ForeignKey(
                        name: "FK_Crops_StateCrops_StateCropsId",
                        column: x => x.StateCropsId,
                        principalTable: "StateCrops",
                        principalColumn: "StateCropsId");
                });

            migrationBuilder.CreateTable(
                name: "GamesAchievements",
                columns: table => new
                {
                    AchievementUnlockedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AchievementUnlocked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AchievementId = table.Column<int>(type: "int", nullable: true),
                    GameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesAchievements", x => x.AchievementUnlockedId);
                    table.ForeignKey(
                        name: "FK_GamesAchievements_Achievements_AchievementId",
                        column: x => x.AchievementId,
                        principalTable: "Achievements",
                        principalColumn: "AchievementsId");
                    table.ForeignKey(
                        name: "FK_GamesAchievements_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId");
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TasksId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropsId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTask = table.Column<DateOnly>(type: "date", nullable: true),
                    StateTasksId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TasksId);
                    table.ForeignKey(
                        name: "FK_Tasks_Crops_CropsId",
                        column: x => x.CropsId,
                        principalTable: "Crops",
                        principalColumn: "CropsId");
                    table.ForeignKey(
                        name: "FK_Tasks_StateTasks_StateTasksId",
                        column: x => x.StateTasksId,
                        principalTable: "StateTasks",
                        principalColumn: "StateTasksId");
                    table.ForeignKey(
                        name: "FK_Tasks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crops_PestId",
                table: "Crops",
                column: "PestId");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_PlotsId",
                table: "Crops",
                column: "PlotsId");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_PotatoesId",
                table: "Crops",
                column: "PotatoesId");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_StateCropsId",
                table: "Crops",
                column: "StateCropsId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_StateGameId",
                table: "Games",
                column: "StateGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_UserId",
                table: "Games",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesAchievements_AchievementId",
                table: "GamesAchievements",
                column: "AchievementId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesAchievements_GameId",
                table: "GamesAchievements",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Pests_SuppliesId",
                table: "Pests",
                column: "SuppliesId");

            migrationBuilder.CreateIndex(
                name: "IX_Potatoes_TypePotatoesId",
                table: "Potatoes",
                column: "TypePotatoesId");

            migrationBuilder.CreateIndex(
                name: "IX_StateGames_PlayerLocationId",
                table: "StateGames",
                column: "PlayerLocationId",
                unique: true,
                filter: "[PlayerLocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_TypeSuppliesId",
                table: "Supplies",
                column: "TypeSuppliesId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CropsId",
                table: "Tasks",
                column: "CropsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StateTasksId",
                table: "Tasks",
                column: "StateTasksId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRolId",
                table: "Users",
                column: "UserRolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamesAchievements");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Crops");

            migrationBuilder.DropTable(
                name: "StateTasks");

            migrationBuilder.DropTable(
                name: "StateGames");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Pests");

            migrationBuilder.DropTable(
                name: "Plots");

            migrationBuilder.DropTable(
                name: "Potatoes");

            migrationBuilder.DropTable(
                name: "StateCrops");

            migrationBuilder.DropTable(
                name: "PlayerLocation");

            migrationBuilder.DropTable(
                name: "UserRols");

            migrationBuilder.DropTable(
                name: "Supplies");

            migrationBuilder.DropTable(
                name: "TypePotatoes");

            migrationBuilder.DropTable(
                name: "TypeSupplies");
        }
    }
}
