using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiroksin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAchievementStatsToUserStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "best_accuracy",
                table: "user_stats",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "best_streak",
                table: "user_stats",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fastest_average_time",
                table: "user_stats",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "total_score",
                table: "user_stats",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "total_wins",
                table: "user_stats",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9864), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9865) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9873), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9873) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9877), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9878) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9894), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9894) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9898), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9898) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9901), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9901) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9904), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9905) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000009-9999-9999-9999-999999999999"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9908), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9908) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000101"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9966), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9966) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000102"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9970), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9970) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000103"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9973), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9973) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000104"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9976), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9977) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000105"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9980), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9980) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000106"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9983), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9983) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000201"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9986), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9987) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000202"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9992), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9992) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000203"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9995), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9995) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000204"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9999), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000205"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(2), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(3) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000206"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(6), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(6) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000207"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(9), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(9) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000101"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(12), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(12) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000102"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(15), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(16) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000103"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(21), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(21) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000201"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(25), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(25) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000202"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(66), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(66) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000203"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(70), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(70) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000204"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(73), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(73) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000101"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(78), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(78) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000102"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(81), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(82) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000201"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(86), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(86) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000202"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(92), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(92) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000203"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(96), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(96) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9944), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9945) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9948), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9948) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9951), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9952) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9958), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9958) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(154), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(155) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(159), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(159) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(163), new DateTime(2025, 12, 7, 10, 51, 24, 771, DateTimeKind.Utc).AddTicks(163) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9753), new DateTime(2025, 12, 7, 10, 51, 24, 770, DateTimeKind.Utc).AddTicks(9754) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "best_accuracy",
                table: "user_stats");

            migrationBuilder.DropColumn(
                name: "best_streak",
                table: "user_stats");

            migrationBuilder.DropColumn(
                name: "fastest_average_time",
                table: "user_stats");

            migrationBuilder.DropColumn(
                name: "total_score",
                table: "user_stats");

            migrationBuilder.DropColumn(
                name: "total_wins",
                table: "user_stats");

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3324), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3325) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3332), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3333) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3337), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3337) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3341), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3341) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3345), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3345) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3348), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3349) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3353), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3353) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000009-9999-9999-9999-999999999999"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3356), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3356) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000101"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3412), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3412) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000102"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3414), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3415) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000103"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3417), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3418) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000104"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3421), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3421) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000105"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3426), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3426) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000106"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3430), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3430) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000201"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3433), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3433) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000202"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3436), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3436) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000203"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3439), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3440) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000204"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3442), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3442) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000205"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3445), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3445) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000206"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3448), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3449) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000207"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3454), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3454) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000101"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3457), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3457) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000102"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3498), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3499) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000103"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3502), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3502) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000201"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3505), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3505) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000202"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3510), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3511) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000203"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3513), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3514) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000204"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3516), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3517) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000101"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3523), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3523) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000102"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3526), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3526) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000201"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3530), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3530) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000202"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3533), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3533) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000203"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3537), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3538) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3398), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3398) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3401), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3402) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3404), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3405) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3408), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3409) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3596), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3596) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3599), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3600) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3603), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3603) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3191), new DateTime(2025, 12, 7, 7, 34, 43, 857, DateTimeKind.Utc).AddTicks(3191) });
        }
    }
}
