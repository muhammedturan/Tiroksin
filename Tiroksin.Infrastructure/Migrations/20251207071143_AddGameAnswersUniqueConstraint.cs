using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiroksin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGameAnswersUniqueConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add unique constraint to prevent duplicate answers
            migrationBuilder.CreateIndex(
                name: "ix_game_answers_session_user_question",
                table: "game_answers",
                columns: new[] { "game_session_id", "user_id", "question_id" },
                unique: true);

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9329), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9330) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9338), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9338) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9343), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9343) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9347), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9348) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9351), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9351) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9356), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9356) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9359), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9360) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000009-9999-9999-9999-999999999999"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9368), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9369) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000101"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9429), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9430) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000102"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9434), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9434) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000103"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9438), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9438) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000104"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9444), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9444) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000105"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9447), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9448) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000106"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9451), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9451) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000201"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9455), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9455) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000202"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9458), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9459) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000203"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9462), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9462) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000204"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9465), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9466) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000205"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9529), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9529) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000206"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9535), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9536) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000207"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9539), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9539) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000101"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9542), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9543) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000102"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9546), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9546) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000103"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9549), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9550) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000201"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9553), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9553) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000202"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9556), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9556) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000203"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9559), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9560) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000204"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9565), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9566) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000101"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9575), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9575) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000102"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9578), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9579) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000201"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9582), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9583) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000202"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9586), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9587) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000203"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9591), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9592) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9413), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9414) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9417), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9418) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9421), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9421) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9425), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9426) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9658), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9658) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9662), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9663) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9669), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9669) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9187), new DateTime(2025, 12, 7, 7, 11, 42, 510, DateTimeKind.Utc).AddTicks(9188) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_game_answers_session_user_question",
                table: "game_answers");

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6100), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6101) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6108), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6109) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6114), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6114) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6196), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6196) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6202), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6202) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6208), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6208) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6211), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6212) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000009-9999-9999-9999-999999999999"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6218), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6219) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000101"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6279), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6279) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000102"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6282), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6283) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000103"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6286), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6286) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000104"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6296), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6296) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000105"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6299), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6299) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000106"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6302), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6303) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000201"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6305), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6306) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000202"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6309), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6309) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000203"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6312), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6312) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000204"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6315), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6316) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000205"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6319), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000206"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6324), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6325) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000207"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6328), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6329) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000101"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6331), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6332) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000102"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6335), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6335) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000103"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6338), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6338) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000201"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6341), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6341) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000202"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6346), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6346) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000203"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6349), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6350) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000204"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6355), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6355) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000101"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6359), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6359) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000102"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6363), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6364) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000201"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6367), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6372) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000202"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6376), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6376) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000203"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6379), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6380) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6262), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6262) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6266), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6267) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6270), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6271) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000004-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6275), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6275) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6479), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6479) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6483), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6484) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6489), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(6490) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(5965), new DateTime(2025, 12, 5, 5, 22, 10, 823, DateTimeKind.Utc).AddTicks(5966) });
        }
    }
}
