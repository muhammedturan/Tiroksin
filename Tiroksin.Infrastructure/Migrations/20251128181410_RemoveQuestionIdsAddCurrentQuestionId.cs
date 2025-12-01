using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiroksin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveQuestionIdsAddCurrentQuestionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "question_ids",
                table: "game_sessions");

            migrationBuilder.AlterColumn<Guid>(
                name: "created_by",
                table: "questions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "current_question_id",
                table: "game_sessions",
                type: "uuid",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "ix_game_sessions_current_question_id",
                table: "game_sessions",
                column: "current_question_id");

            migrationBuilder.AddForeignKey(
                name: "fk_game_sessions_questions_current_question_id",
                table: "game_sessions",
                column: "current_question_id",
                principalTable: "questions",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_game_sessions_questions_current_question_id",
                table: "game_sessions");

            migrationBuilder.DropIndex(
                name: "ix_game_sessions_current_question_id",
                table: "game_sessions");

            migrationBuilder.DropColumn(
                name: "current_question_id",
                table: "game_sessions");

            migrationBuilder.AlterColumn<Guid>(
                name: "created_by",
                table: "questions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "question_ids",
                table: "game_sessions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9588), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9588) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9593), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9594) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9597), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9598) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9601), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9602) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000005-5555-5555-5555-555555555555"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9605), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9605) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9608), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9609) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9612), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9612) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9619), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9619) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9655), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9656) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9660), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9660) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9663), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9663) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9666), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9666) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9669), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9669) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9673), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9673) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9676), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9676) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9681), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9682) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9684), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9685) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0001-0001-0001-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9688), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9688) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9691), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9692) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9694), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9695) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9697), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9698) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9746), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9746) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9750), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9750) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9755), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9756) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9456), new DateTime(2025, 11, 28, 5, 43, 14, 458, DateTimeKind.Utc).AddTicks(9457) });
        }
    }
}
