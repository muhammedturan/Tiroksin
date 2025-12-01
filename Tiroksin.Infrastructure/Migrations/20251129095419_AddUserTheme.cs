using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiroksin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTheme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "theme",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "created_at", "theme", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4182), "dark", new DateTime(2025, 11, 29, 9, 54, 18, 813, DateTimeKind.Utc).AddTicks(4183) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "theme",
                table: "users");

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(3893), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(3894) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(3905), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(3906) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(3910), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(3910) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(3914), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(3914) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000005-5555-5555-5555-555555555555"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(3917), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(3917) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(3920), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(3921) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(3923), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(3924) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(3927), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(3927) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4040), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4041) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4047), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4047) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4052), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4052) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4055), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4055) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4058), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4059) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4062), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4062) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4065), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4065) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4068), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4068) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4071), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4071) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4077), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4077) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4080), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4080) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4083), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4083) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4086), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4086) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4136), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4136) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4140), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4144), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(4144) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(3775), new DateTime(2025, 11, 28, 18, 14, 8, 665, DateTimeKind.Utc).AddTicks(3777) });
        }
    }
}
