using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiroksin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddParentDefinitionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "parent_definition_id",
                table: "parameter_definitions",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "parent_definition_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3423), null, new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3424) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "parent_definition_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3429), null, new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3429) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "parent_definition_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3433), null, new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3434) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "parent_definition_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3437), null, new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3437) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "parent_definition_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3441), null, new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3441) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "parent_definition_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3445), null, new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3445) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "parent_definition_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3457), null, new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3458) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000009-9999-9999-9999-999999999999"),
                columns: new[] { "created_at", "parent_definition_id", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3462), null, new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3462) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3502), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3502) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3506), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3506) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3509), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3510) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3513), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3513) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3516), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3517) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3520), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3520) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3526), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3526) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3529), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3530) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3533), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3533) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3536), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3537) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3615), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3616) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3619), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3620) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3623), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3623) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3626), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3626) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3632), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3632) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3635), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3636) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3639), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3639) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3642), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3643) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000006"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3646), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3646) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000007"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3650), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3650) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000008"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3653), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3653) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3717), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3717) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3723), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3724) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3728), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3728) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3289), new DateTime(2025, 12, 2, 23, 50, 25, 739, DateTimeKind.Utc).AddTicks(3290) });

            migrationBuilder.CreateIndex(
                name: "ix_parameter_definitions_parent_definition_id",
                table: "parameter_definitions",
                column: "parent_definition_id");

            migrationBuilder.AddForeignKey(
                name: "fk_parameter_definitions_parameter_definitions_parent_definiti",
                table: "parameter_definitions",
                column: "parent_definition_id",
                principalTable: "parameter_definitions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_parameter_definitions_parameter_definitions_parent_definiti",
                table: "parameter_definitions");

            migrationBuilder.DropIndex(
                name: "ix_parameter_definitions_parent_definition_id",
                table: "parameter_definitions");

            migrationBuilder.DropColumn(
                name: "parent_definition_id",
                table: "parameter_definitions");

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
    }
}
