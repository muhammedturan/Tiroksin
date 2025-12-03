using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tiroksin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDifficultyColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000005-0001-0001-0001-000000000001"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000005-0001-0001-0001-000000000002"));

            migrationBuilder.DeleteData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000005-0001-0001-0001-000000000003"));

            migrationBuilder.DeleteData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000005-5555-5555-5555-555555555555"));

            migrationBuilder.DropColumn(
                name: "difficulty",
                table: "questions");

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3695), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3695) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3700), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3700) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3703), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3704) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3707), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3707) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3711), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3711) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3714), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3715) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3725), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3726) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000009-9999-9999-9999-999999999999"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3730), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3730) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3807), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3807) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3811), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3811) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3814), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3814) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3817), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3818) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3821), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3821) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3824), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3824) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3830), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3831) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3834), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3834) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3837), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3837) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3840), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3841) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3844), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3844) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3847), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3847) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3850), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3851) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3853), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3854) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3859), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3860) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3863), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3863) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3866), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3867) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3869), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3870) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000006"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3873), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3873) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000007"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3876), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3876) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000008"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3879), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3879) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3934), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3934) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3940), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3941) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3944), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3944) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3511), new DateTime(2025, 12, 2, 22, 56, 21, 78, DateTimeKind.Utc).AddTicks(3512) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "difficulty",
                table: "questions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9034), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9035) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9041), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9042) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9046), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9046) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9050), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9051) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9064), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9065) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9077), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9078) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9081), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9082) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000009-9999-9999-9999-999999999999"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9086), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9086) });

            migrationBuilder.InsertData(
                table: "parameter_definitions",
                columns: new[] { "id", "created_at", "created_by", "data_type", "default_value", "description", "is_required", "key", "name", "updated_at", "updated_by", "validation_rules" },
                values: new object[] { new Guid("00000005-5555-5555-5555-555555555555"), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9054), null, "string", "Orta", "Sorunun zorluk seviyesi (Kolay, Orta, Zor)", false, "DIFFICULTY", "Zorluk Seviyesi", new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9055), null, "{\"enum\": [\"Kolay\", \"Orta\", \"Zor\"]}" });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9129), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9129) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9184), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9185) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9190), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9190) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9194), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9194) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9198), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9198) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9206), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9207) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9210), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9211) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9214), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9215) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9219), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9219) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9223), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9223) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9226), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9227) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9230), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9231) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9235), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9235) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9241), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9242) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9245), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9245) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9249), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9250) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9253), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9254) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9257), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9258) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000006"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9261), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9262) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000007"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9265), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9266) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000008"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9269), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9270) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "difficulty", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9356), 0, new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9357) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "difficulty", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9362), 1, new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9363) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "difficulty", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9366), 0, new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9367) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(8821), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(8822) });

            migrationBuilder.InsertData(
                table: "parameter_values",
                columns: new[] { "id", "created_at", "created_by", "name", "order_no", "parameter_definition_id", "updated_at", "updated_by", "value" },
                values: new object[,]
                {
                    { new Guid("10000005-0001-0001-0001-000000000001"), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9276), null, "Kolay", 1, new Guid("00000005-5555-5555-5555-555555555555"), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9276), null, "Easy" },
                    { new Guid("10000005-0001-0001-0001-000000000002"), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9280), null, "Orta", 2, new Guid("00000005-5555-5555-5555-555555555555"), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9281), null, "Medium" },
                    { new Guid("10000005-0001-0001-0001-000000000003"), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9285), null, "Zor", 3, new Guid("00000005-5555-5555-5555-555555555555"), new DateTime(2025, 12, 2, 22, 40, 0, 255, DateTimeKind.Utc).AddTicks(9285), null, "Hard" }
                });
        }
    }
}
