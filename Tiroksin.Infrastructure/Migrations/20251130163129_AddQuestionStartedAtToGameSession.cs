using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiroksin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionStartedAtToGameSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "question_started_at",
                table: "game_sessions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8361), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8362) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8366), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8367) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8370), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8370) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8374), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000005-5555-5555-5555-555555555555"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8377), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8378) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8388), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8388) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8391), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8392) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8394), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8395) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8431), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8431) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8435), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8436) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8439), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8439) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8442), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8443) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8445), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8445) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8451), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8451) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8454), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8454) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8457), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8457) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8460), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8460) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8462), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8463) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8465), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8466) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8468), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8468) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8471), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8471) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8516), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8516) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8520), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8520) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8523), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8523) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8239), new DateTime(2025, 11, 30, 16, 31, 28, 489, DateTimeKind.Utc).AddTicks(8240) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "question_started_at",
                table: "game_sessions");

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4313), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4314) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4319), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4319) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4324), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4324) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4328), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4329) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000005-5555-5555-5555-555555555555"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4332), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4332) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4336), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4337) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4340), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4340) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4347), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4348) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4385), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4386) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4389), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4390) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4393), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4394) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4397), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4397) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4400), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4401) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4405), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4405) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4409), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4409) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4415), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4415) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4418), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4419) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4422), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4422) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4425), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4426) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4429), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4429) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4432), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4433) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4484), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4484) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4488), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4488) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4494), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4495) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4182), new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4183) });
        }
    }
}
