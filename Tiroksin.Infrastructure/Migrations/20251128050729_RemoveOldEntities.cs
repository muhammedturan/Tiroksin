using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiroksin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOldEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exam_question");

            migrationBuilder.DropTable(
                name: "user_answer");

            migrationBuilder.DropTable(
                name: "exam_attempt");

            migrationBuilder.DropTable(
                name: "exam");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "description", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6904), "Her soru için verilen süre (saniye cinsinden)", new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6904) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6909), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6910) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6913), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6913) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6916), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6917) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000005-5555-5555-5555-555555555555"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6920), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6921) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6931), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6932) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6941), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6941) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6944), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6944) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7138), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7139) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7143), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7143) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7146), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7146) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0002-0002-0002-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7152), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7153) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0002-0002-0002-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7156), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7156) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0002-0002-0002-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7159), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7160) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0003-0003-0003-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7163), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7163) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0003-0003-0003-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7166), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7166) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0003-0003-0003-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7169), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(7169) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6984), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6985) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6988), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6989) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6992), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6992) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6773), new DateTime(2025, 11, 28, 5, 7, 28, 583, DateTimeKind.Utc).AddTicks(6774) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    color = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    description = table.Column<string>(type: "text", nullable: false),
                    icon = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "exam",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    creator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    duration_minutes = table.Column<int>(type: "integer", nullable: false),
                    is_published = table.Column<bool>(type: "boolean", nullable: false),
                    pass_score = table.Column<int>(type: "integer", nullable: false),
                    shuffle_options = table.Column<bool>(type: "boolean", nullable: false),
                    shuffle_questions = table.Column<bool>(type: "boolean", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exam", x => x.id);
                    table.ForeignKey(
                        name: "fk_exam_category_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_exam_users_creator_id",
                        column: x => x.creator_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exam_attempt",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    exam_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    completed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    correct_answers = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    empty_answers = table.Column<int>(type: "integer", nullable: false),
                    started_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    total_score = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true),
                    wrong_answers = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exam_attempt", x => x.id);
                    table.ForeignKey(
                        name: "fk_exam_attempt_exam_exam_id",
                        column: x => x.exam_id,
                        principalTable: "exam",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_exam_attempt_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exam_question",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    exam_id = table.Column<Guid>(type: "uuid", nullable: false),
                    question_id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_index = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exam_question", x => x.id);
                    table.ForeignKey(
                        name: "fk_exam_question_exam_exam_id",
                        column: x => x.exam_id,
                        principalTable: "exam",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_exam_question_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_answer",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    exam_attempt_id = table.Column<Guid>(type: "uuid", nullable: false),
                    question_id = table.Column<Guid>(type: "uuid", nullable: false),
                    answered_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_correct = table.Column<bool>(type: "boolean", nullable: false),
                    selected_option_key = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_answer", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_answer_exam_attempt_exam_attempt_id",
                        column: x => x.exam_attempt_id,
                        principalTable: "exam_attempt",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_answer_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000001-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "description", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1754), "Her soru için veril en süre (saniye cinsinden)", new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1754) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000002-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1808), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1809) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000003-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1813), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1814) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000004-4444-4444-4444-444444444444"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1817), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1817) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000005-5555-5555-5555-555555555555"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1833), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1833) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000006-6666-6666-6666-666666666666"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1837), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1837) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000007-7777-7777-7777-777777777777"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1842), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1842) });

            migrationBuilder.UpdateData(
                table: "parameter_definitions",
                keyColumn: "id",
                keyValue: new Guid("00000008-8888-8888-8888-888888888888"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1845), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1846) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1993), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1993) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1997), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1997) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000001-0001-0001-0001-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2002), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2002) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0002-0002-0002-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2006), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2006) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0002-0002-0002-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2010), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2010) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000002-0002-0002-0002-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2013), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2013) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0003-0003-0003-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2016), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2016) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0003-0003-0003-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2019), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2019) });

            migrationBuilder.UpdateData(
                table: "parameter_values",
                keyColumn: "id",
                keyValue: new Guid("10000003-0003-0003-0003-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2023), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(2023) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1894), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1894) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1898), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1899) });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-3333-3333-3333-333333333333"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1902), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1902) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1622), new DateTime(2025, 11, 28, 4, 53, 35, 232, DateTimeKind.Utc).AddTicks(1623) });

            migrationBuilder.CreateIndex(
                name: "ix_exam_category_id",
                table: "exam",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_exam_creator_id",
                table: "exam",
                column: "creator_id");

            migrationBuilder.CreateIndex(
                name: "ix_exam_attempt_exam_id",
                table: "exam_attempt",
                column: "exam_id");

            migrationBuilder.CreateIndex(
                name: "ix_exam_attempt_user_id",
                table: "exam_attempt",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_exam_question_exam_id",
                table: "exam_question",
                column: "exam_id");

            migrationBuilder.CreateIndex(
                name: "ix_exam_question_question_id",
                table: "exam_question",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_answer_exam_attempt_id",
                table: "user_answer",
                column: "exam_attempt_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_answer_question_id",
                table: "user_answer",
                column: "question_id");
        }
    }
}
