using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiroksin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPerformanceIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Performance indexes for frequently queried columns

            // Index for room_players: frequently queried by room_id and left_at
            migrationBuilder.CreateIndex(
                name: "ix_room_players_room_id_left_at",
                table: "room_players",
                columns: new[] { "room_id", "left_at" });

            // Index for game_sessions: frequently queried by status
            migrationBuilder.CreateIndex(
                name: "ix_game_sessions_status",
                table: "game_sessions",
                column: "status");

            // Index for game_session_players: frequently queried by game_session_id
            migrationBuilder.CreateIndex(
                name: "ix_game_session_players_game_session_id_is_eliminated",
                table: "game_session_players",
                columns: new[] { "game_session_id", "is_eliminated" });

            // Index for questions: frequently queried by status
            migrationBuilder.CreateIndex(
                name: "ix_questions_status",
                table: "questions",
                column: "status");

            // Index for rooms: frequently queried by status and expires_at
            migrationBuilder.CreateIndex(
                name: "ix_rooms_status_expires_at",
                table: "rooms",
                columns: new[] { "status", "expires_at" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(name: "ix_room_players_room_id_left_at", table: "room_players");
            migrationBuilder.DropIndex(name: "ix_game_sessions_status", table: "game_sessions");
            migrationBuilder.DropIndex(name: "ix_game_session_players_game_session_id_is_eliminated", table: "game_session_players");
            migrationBuilder.DropIndex(name: "ix_questions_status", table: "questions");
            migrationBuilder.DropIndex(name: "ix_rooms_status_expires_at", table: "rooms");

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
    }
}
