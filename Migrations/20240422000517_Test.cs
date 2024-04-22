using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Papalandia.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Pests_PestId",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Plots_PlotsId",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Potatoes_PotatoesId",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_StateCrops_StateCropsId",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_StateGames_StateGameId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_UserId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_GamesAchievements_Achievements_AchievementId",
                table: "GamesAchievements");

            migrationBuilder.DropForeignKey(
                name: "FK_GamesAchievements_Games_GameId",
                table: "GamesAchievements");

            migrationBuilder.DropForeignKey(
                name: "FK_Pests_Supplies_SuppliesId",
                table: "Pests");

            migrationBuilder.DropForeignKey(
                name: "FK_Potatoes_TypePotatoes_TypePotatoesId",
                table: "Potatoes");

            migrationBuilder.DropForeignKey(
                name: "FK_StateGames_PlayerLocation_PlayerLocationId",
                table: "StateGames");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplies_TypeSupplies_TypeSuppliesId",
                table: "Supplies");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Crops_CropsId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_StateTasks_StateTasksId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRols_UserRolId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_StateGames_PlayerLocationId",
                table: "StateGames");

            migrationBuilder.AlterColumn<int>(
                name: "UserRolId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserRolName",
                table: "UserRols",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NameTypeSupplies",
                table: "TypeSupplies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TypeNamePotatoes",
                table: "TypePotatoes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StateTasksId",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateTask",
                table: "Tasks",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "CropsId",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TypeSuppliesId",
                table: "Supplies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "SuppliesName",
                table: "Supplies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SuppliesDescription",
                table: "Supplies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "StateTasksName",
                table: "StateTasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerLocationId",
                table: "StateGames",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "StateCrop",
                table: "StateCrops",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TypePotatoesId",
                table: "Potatoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "TimeGrowth",
                table: "Potatoes",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "PotatoesName",
                table: "Potatoes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Potatoes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PlotsSize",
                table: "Plots",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Plots",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Plots",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "CoordinateZ",
                table: "PlayerLocation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CoordinateY",
                table: "PlayerLocation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CoordinateX",
                table: "PlayerLocation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "SuppliesId",
                table: "Pests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PestsName",
                table: "Pests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PestsDescription",
                table: "Pests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "GamesAchievements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AchievementUnlocked",
                table: "GamesAchievements",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "AchievementId",
                table: "GamesAchievements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Games",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StateGameId",
                table: "Games",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartGame",
                table: "Games",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndGame",
                table: "Games",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "StateCropsId",
                table: "Crops",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "SowingDate",
                table: "Crops",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "PotatoesId",
                table: "Crops",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PlotsId",
                table: "Crops",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PestId",
                table: "Crops",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AchievementsName",
                table: "Achievements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AchievementsDescription",
                table: "Achievements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_StateGames_PlayerLocationId",
                table: "StateGames",
                column: "PlayerLocationId",
                unique: true,
                filter: "[PlayerLocationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Pests_PestId",
                table: "Crops",
                column: "PestId",
                principalTable: "Pests",
                principalColumn: "PestsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Plots_PlotsId",
                table: "Crops",
                column: "PlotsId",
                principalTable: "Plots",
                principalColumn: "PlotsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Potatoes_PotatoesId",
                table: "Crops",
                column: "PotatoesId",
                principalTable: "Potatoes",
                principalColumn: "PotatoesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_StateCrops_StateCropsId",
                table: "Crops",
                column: "StateCropsId",
                principalTable: "StateCrops",
                principalColumn: "StateCropsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_StateGames_StateGameId",
                table: "Games",
                column: "StateGameId",
                principalTable: "StateGames",
                principalColumn: "StateGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_UserId",
                table: "Games",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GamesAchievements_Achievements_AchievementId",
                table: "GamesAchievements",
                column: "AchievementId",
                principalTable: "Achievements",
                principalColumn: "AchievementsId");

            migrationBuilder.AddForeignKey(
                name: "FK_GamesAchievements_Games_GameId",
                table: "GamesAchievements",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pests_Supplies_SuppliesId",
                table: "Pests",
                column: "SuppliesId",
                principalTable: "Supplies",
                principalColumn: "SuppliesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Potatoes_TypePotatoes_TypePotatoesId",
                table: "Potatoes",
                column: "TypePotatoesId",
                principalTable: "TypePotatoes",
                principalColumn: "TypePotatoesId");

            migrationBuilder.AddForeignKey(
                name: "FK_StateGames_PlayerLocation_PlayerLocationId",
                table: "StateGames",
                column: "PlayerLocationId",
                principalTable: "PlayerLocation",
                principalColumn: "PlayerLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplies_TypeSupplies_TypeSuppliesId",
                table: "Supplies",
                column: "TypeSuppliesId",
                principalTable: "TypeSupplies",
                principalColumn: "TypeSuppliesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Crops_CropsId",
                table: "Tasks",
                column: "CropsId",
                principalTable: "Crops",
                principalColumn: "CropsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_StateTasks_StateTasksId",
                table: "Tasks",
                column: "StateTasksId",
                principalTable: "StateTasks",
                principalColumn: "StateTasksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRols_UserRolId",
                table: "Users",
                column: "UserRolId",
                principalTable: "UserRols",
                principalColumn: "UserRolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Pests_PestId",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Plots_PlotsId",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Potatoes_PotatoesId",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_StateCrops_StateCropsId",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_StateGames_StateGameId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_UserId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_GamesAchievements_Achievements_AchievementId",
                table: "GamesAchievements");

            migrationBuilder.DropForeignKey(
                name: "FK_GamesAchievements_Games_GameId",
                table: "GamesAchievements");

            migrationBuilder.DropForeignKey(
                name: "FK_Pests_Supplies_SuppliesId",
                table: "Pests");

            migrationBuilder.DropForeignKey(
                name: "FK_Potatoes_TypePotatoes_TypePotatoesId",
                table: "Potatoes");

            migrationBuilder.DropForeignKey(
                name: "FK_StateGames_PlayerLocation_PlayerLocationId",
                table: "StateGames");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplies_TypeSupplies_TypeSuppliesId",
                table: "Supplies");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Crops_CropsId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_StateTasks_StateTasksId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRols_UserRolId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_StateGames_PlayerLocationId",
                table: "StateGames");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "UserRolId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserRolName",
                table: "UserRols",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameTypeSupplies",
                table: "TypeSupplies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypeNamePotatoes",
                table: "TypePotatoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StateTasksId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateTask",
                table: "Tasks",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CropsId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypeSuppliesId",
                table: "Supplies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SuppliesName",
                table: "Supplies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SuppliesDescription",
                table: "Supplies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StateTasksName",
                table: "StateTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlayerLocationId",
                table: "StateGames",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StateCrop",
                table: "StateCrops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypePotatoesId",
                table: "Potatoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TimeGrowth",
                table: "Potatoes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PotatoesName",
                table: "Potatoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Potatoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PlotsSize",
                table: "Plots",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Plots",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Plots",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CoordinateZ",
                table: "PlayerLocation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CoordinateY",
                table: "PlayerLocation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CoordinateX",
                table: "PlayerLocation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SuppliesId",
                table: "Pests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PestsName",
                table: "Pests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PestsDescription",
                table: "Pests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "GamesAchievements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AchievementUnlocked",
                table: "GamesAchievements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AchievementId",
                table: "GamesAchievements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StateGameId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartGame",
                table: "Games",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndGame",
                table: "Games",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StateCropsId",
                table: "Crops",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "SowingDate",
                table: "Crops",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PotatoesId",
                table: "Crops",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlotsId",
                table: "Crops",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PestId",
                table: "Crops",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AchievementsName",
                table: "Achievements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AchievementsDescription",
                table: "Achievements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StateGames_PlayerLocationId",
                table: "StateGames",
                column: "PlayerLocationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Pests_PestId",
                table: "Crops",
                column: "PestId",
                principalTable: "Pests",
                principalColumn: "PestsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Plots_PlotsId",
                table: "Crops",
                column: "PlotsId",
                principalTable: "Plots",
                principalColumn: "PlotsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Potatoes_PotatoesId",
                table: "Crops",
                column: "PotatoesId",
                principalTable: "Potatoes",
                principalColumn: "PotatoesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_StateCrops_StateCropsId",
                table: "Crops",
                column: "StateCropsId",
                principalTable: "StateCrops",
                principalColumn: "StateCropsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_StateGames_StateGameId",
                table: "Games",
                column: "StateGameId",
                principalTable: "StateGames",
                principalColumn: "StateGameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_UserId",
                table: "Games",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamesAchievements_Achievements_AchievementId",
                table: "GamesAchievements",
                column: "AchievementId",
                principalTable: "Achievements",
                principalColumn: "AchievementsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamesAchievements_Games_GameId",
                table: "GamesAchievements",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pests_Supplies_SuppliesId",
                table: "Pests",
                column: "SuppliesId",
                principalTable: "Supplies",
                principalColumn: "SuppliesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Potatoes_TypePotatoes_TypePotatoesId",
                table: "Potatoes",
                column: "TypePotatoesId",
                principalTable: "TypePotatoes",
                principalColumn: "TypePotatoesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StateGames_PlayerLocation_PlayerLocationId",
                table: "StateGames",
                column: "PlayerLocationId",
                principalTable: "PlayerLocation",
                principalColumn: "PlayerLocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplies_TypeSupplies_TypeSuppliesId",
                table: "Supplies",
                column: "TypeSuppliesId",
                principalTable: "TypeSupplies",
                principalColumn: "TypeSuppliesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Crops_CropsId",
                table: "Tasks",
                column: "CropsId",
                principalTable: "Crops",
                principalColumn: "CropsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_StateTasks_StateTasksId",
                table: "Tasks",
                column: "StateTasksId",
                principalTable: "StateTasks",
                principalColumn: "StateTasksId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRols_UserRolId",
                table: "Users",
                column: "UserRolId",
                principalTable: "UserRols",
                principalColumn: "UserRolId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
