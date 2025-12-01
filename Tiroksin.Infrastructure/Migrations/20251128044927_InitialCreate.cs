using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tiroksin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "achievements",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    icon = table.Column<string>(type: "text", nullable: false),
                    category = table.Column<string>(type: "text", nullable: false),
                    difficulty = table.Column<int>(type: "integer", nullable: false),
                    xp_reward = table.Column<int>(type: "integer", nullable: false),
                    requirements = table.Column<string>(type: "text", nullable: true),
                    is_hidden = table.Column<bool>(type: "boolean", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_achievements", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    icon = table.Column<string>(type: "text", nullable: false),
                    color = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "parameter_definitions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    key = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    data_type = table.Column<string>(type: "text", nullable: false),
                    default_value = table.Column<string>(type: "text", nullable: true),
                    is_required = table.Column<bool>(type: "boolean", nullable: false),
                    validation_rules = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_parameter_definitions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    display_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    avatar = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "parameter_values",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    parameter_definition_id = table.Column<Guid>(type: "uuid", nullable: false),
                    entity_type = table.Column<string>(type: "text", nullable: false),
                    entity_id = table.Column<Guid>(type: "uuid", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_parameter_values", x => x.id);
                    table.ForeignKey(
                        name: "fk_parameter_values_parameter_definitions_parameter_definition",
                        column: x => x.parameter_definition_id,
                        principalTable: "parameter_definitions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exam",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    duration_minutes = table.Column<int>(type: "integer", nullable: false),
                    pass_score = table.Column<int>(type: "integer", nullable: false),
                    is_published = table.Column<bool>(type: "boolean", nullable: false),
                    shuffle_questions = table.Column<bool>(type: "boolean", nullable: false),
                    shuffle_options = table.Column<bool>(type: "boolean", nullable: false),
                    creator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
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
                name: "questions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    image_url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    options_layout = table.Column<int>(type: "integer", nullable: false),
                    exam_type = table.Column<int>(type: "integer", nullable: false),
                    difficulty = table.Column<int>(type: "integer", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    is_public = table.Column<bool>(type: "boolean", nullable: false),
                    view_count = table.Column<int>(type: "integer", nullable: false),
                    attempt_count = table.Column<int>(type: "integer", nullable: false),
                    correct_count = table.Column<int>(type: "integer", nullable: false),
                    points = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_questions", x => x.id);
                    table.ForeignKey(
                        name: "fk_questions_users_created_by",
                        column: x => x.created_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    room_code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    max_players = table.Column<int>(type: "integer", nullable: false),
                    min_players = table.Column<int>(type: "integer", nullable: false),
                    is_public = table.Column<bool>(type: "boolean", nullable: false),
                    is_password_protected = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    question_count = table.Column<int>(type: "integer", nullable: false),
                    host_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    started_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    finished_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rooms", x => x.id);
                    table.ForeignKey(
                        name: "fk_rooms_users_host_user_id",
                        column: x => x.host_user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_achievements",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    achievement_id = table.Column<Guid>(type: "uuid", nullable: false),
                    unlocked_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    progress = table.Column<int>(type: "integer", nullable: false),
                    is_completed = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_achievements", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_achievements_achievements_achievement_id",
                        column: x => x.achievement_id,
                        principalTable: "achievements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_achievements_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_stats",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    level = table.Column<int>(type: "integer", nullable: false),
                    current_xp = table.Column<int>(type: "integer", nullable: false),
                    xp_to_next_level = table.Column<int>(type: "integer", nullable: false),
                    total_xp = table.Column<int>(type: "integer", nullable: false),
                    total_games_played = table.Column<int>(type: "integer", nullable: false),
                    total_games_won = table.Column<int>(type: "integer", nullable: false),
                    total_games_lost = table.Column<int>(type: "integer", nullable: false),
                    win_rate = table.Column<double>(type: "double precision", nullable: false),
                    total_questions_answered = table.Column<int>(type: "integer", nullable: false),
                    total_correct_answers = table.Column<int>(type: "integer", nullable: false),
                    total_wrong_answers = table.Column<int>(type: "integer", nullable: false),
                    accuracy_rate = table.Column<double>(type: "double precision", nullable: false),
                    current_win_streak = table.Column<int>(type: "integer", nullable: false),
                    best_win_streak = table.Column<int>(type: "integer", nullable: false),
                    highest_score = table.Column<int>(type: "integer", nullable: false),
                    fastest_answer_time = table.Column<int>(type: "integer", nullable: false),
                    global_rank = table.Column<int>(type: "integer", nullable: false),
                    weekly_rank = table.Column<int>(type: "integer", nullable: false),
                    monthly_rank = table.Column<int>(type: "integer", nullable: false),
                    last_played_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_stats", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_stats_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exam_attempt",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    exam_id = table.Column<Guid>(type: "uuid", nullable: false),
                    started_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    completed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    total_score = table.Column<int>(type: "integer", nullable: false),
                    correct_answers = table.Column<int>(type: "integer", nullable: false),
                    wrong_answers = table.Column<int>(type: "integer", nullable: false),
                    empty_answers = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
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
                name: "question_options",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    question_id = table.Column<Guid>(type: "uuid", nullable: false),
                    option_key = table.Column<string>(type: "text", nullable: false),
                    text = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: true),
                    is_correct = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_question_options", x => x.id);
                    table.ForeignKey(
                        name: "fk_question_options_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "game_sessions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    room_id = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    current_question_index = table.Column<int>(type: "integer", nullable: false),
                    started_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    finished_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    question_ids = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_sessions", x => x.id);
                    table.ForeignKey(
                        name: "fk_game_sessions_rooms_room_id",
                        column: x => x.room_id,
                        principalTable: "rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "room_players",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    room_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    is_ready = table.Column<bool>(type: "boolean", nullable: false),
                    team = table.Column<int>(type: "integer", nullable: true),
                    joined_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    left_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_room_players", x => x.id);
                    table.ForeignKey(
                        name: "fk_room_players_rooms_room_id",
                        column: x => x.room_id,
                        principalTable: "rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_room_players_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
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
                    selected_option_key = table.Column<string>(type: "text", nullable: true),
                    is_correct = table.Column<bool>(type: "boolean", nullable: false),
                    answered_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "game_answers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    game_session_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    question_id = table.Column<Guid>(type: "uuid", nullable: false),
                    selected_option_id = table.Column<Guid>(type: "uuid", nullable: true),
                    is_correct = table.Column<bool>(type: "boolean", nullable: false),
                    time_spent = table.Column<int>(type: "integer", nullable: false),
                    is_timeout = table.Column<bool>(type: "boolean", nullable: false),
                    answered_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_answers", x => x.id);
                    table.ForeignKey(
                        name: "fk_game_answers_game_sessions_game_session_id",
                        column: x => x.game_session_id,
                        principalTable: "game_sessions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_game_answers_question_options_selected_option_id",
                        column: x => x.selected_option_id,
                        principalTable: "question_options",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_game_answers_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_game_answers_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "game_session_players",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    game_session_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    score = table.Column<int>(type: "integer", nullable: false),
                    correct_answers = table.Column<int>(type: "integer", nullable: false),
                    wrong_answers = table.Column<int>(type: "integer", nullable: false),
                    timeout_count = table.Column<int>(type: "integer", nullable: false),
                    rank = table.Column<int>(type: "integer", nullable: false),
                    is_eliminated = table.Column<bool>(type: "boolean", nullable: false),
                    eliminated_at_question_index = table.Column<int>(type: "integer", nullable: true),
                    is_winner = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_session_players", x => x.id);
                    table.ForeignKey(
                        name: "fk_game_session_players_game_sessions_game_session_id",
                        column: x => x.game_session_id,
                        principalTable: "game_sessions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_game_session_players_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "parameter_definitions",
                columns: new[] { "id", "created_at", "created_by", "data_type", "default_value", "description", "is_required", "key", "name", "updated_at", "updated_by", "validation_rules" },
                values: new object[,]
                {
                    { new Guid("00000001-1111-1111-1111-111111111111"), new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3448), null, "int", "60", "Her soru için veril en süre (saniye cinsinden)", false, "QUESTION_TIME", "Soru Başına Süre", new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3448), null, "{\"min\": 10, \"max\": 300}" },
                    { new Guid("00000002-2222-2222-2222-222222222222"), new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3453), null, "string", null, "Sorunun ait olduğu kategori (örn: Matematik, Fizik, Kimya)", false, "CATEGORY", "Kategori", new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3453), null, "{\"maxLength\": 100}" },
                    { new Guid("00000003-3333-3333-3333-333333333333"), new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3466), null, "string", null, "Sorunun ait olduğu konu (örn: Türev, Integral)", false, "SUBJECT", "Konu", new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3466), null, "{\"maxLength\": 200}" },
                    { new Guid("00000004-4444-4444-4444-444444444444"), new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3470), null, "string", null, "Sorunun ait olduğu alt konu", false, "TOPIC", "Alt Konu", new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3470), null, "{\"maxLength\": 200}" },
                    { new Guid("00000005-5555-5555-5555-555555555555"), new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3473), null, "string", "Orta", "Sorunun zorluk seviyesi (Kolay, Orta, Zor)", false, "DIFFICULTY", "Zorluk Seviyesi", new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3474), null, "{\"enum\": [\"Kolay\", \"Orta\", \"Zor\"]}" },
                    { new Guid("00000006-6666-6666-6666-666666666666"), new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3477), null, "json", "[]", "Soru etiketleri (JSON array)", false, "TAGS", "Etiketler", new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3478), null, "{\"type\": \"array\"}" },
                    { new Guid("00000007-7777-7777-7777-777777777777"), new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3481), null, "string", null, "Sorunun kaynağı (örn: TYT 2023, AYT 2022)", false, "SOURCE", "Kaynak", new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3481), null, "{\"maxLength\": 100}" },
                    { new Guid("00000008-8888-8888-8888-888888888888"), new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3484), null, "int", null, "Sorunun ait olduğu sınav yılı", false, "YEAR", "Yıl", new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3485), null, "{\"min\": 2000, \"max\": 2100}" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "avatar", "created_at", "created_by", "display_name", "email", "password_hash", "updated_at", "updated_by", "username" },
                values: new object[] { new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"), "👤", new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3273), null, "muhammed", "muhammedturan@yahoo.com", "$2a$11$MKiZ20zeoqBTNPV5HxwRruNo8uK4KQmNcD9eK3ndrZQZCHyOoesAW", new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3274), null, "muhammedturan" });

            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "id", "attempt_count", "correct_count", "created_at", "created_by", "difficulty", "exam_type", "image_url", "is_public", "options_layout", "points", "status", "text", "updated_at", "updated_by", "view_count" },
                values: new object[,]
                {
                    { new Guid("eeeeeeee-1111-1111-1111-111111111111"), 0, 0, new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3534), new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"), 0, 0, null, true, 0, 2, 1, "5 + 3 x 2 işleminin sonucu kaçtır?", new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3534), null, 0 },
                    { new Guid("eeeeeeee-2222-2222-2222-222222222222"), 0, 0, new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3538), new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"), 1, 0, null, true, 0, 3, 1, "x² - 4 = 0 denkleminin çözüm kümesi nedir?", new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3538), null, 0 },
                    { new Guid("eeeeeeee-3333-3333-3333-333333333333"), 0, 0, new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3545), new Guid("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6"), 0, 0, null, true, 0, 2, 1, "Bir dikdörtgenin alanı 24 cm², kısa kenarı 4 cm ise uzun kenarı kaç cm'dir?", new DateTime(2025, 11, 28, 4, 49, 27, 333, DateTimeKind.Utc).AddTicks(3545), null, 0 }
                });

            migrationBuilder.InsertData(
                table: "question_options",
                columns: new[] { "id", "image_url", "is_correct", "option_key", "question_id", "text" },
                values: new object[,]
                {
                    { new Guid("00000001-0001-0001-0001-000000000001"), null, false, "", new Guid("eeeeeeee-1111-1111-1111-111111111111"), "16" },
                    { new Guid("00000001-0001-0001-0001-000000000002"), null, true, "", new Guid("eeeeeeee-1111-1111-1111-111111111111"), "11" },
                    { new Guid("00000001-0001-0001-0001-000000000003"), null, false, "", new Guid("eeeeeeee-1111-1111-1111-111111111111"), "13" },
                    { new Guid("00000001-0001-0001-0001-000000000004"), null, false, "", new Guid("eeeeeeee-1111-1111-1111-111111111111"), "10" },
                    { new Guid("00000001-0001-0001-0001-000000000005"), null, false, "", new Guid("eeeeeeee-1111-1111-1111-111111111111"), "8" },
                    { new Guid("00000001-0002-0002-0002-000000000001"), null, false, "", new Guid("eeeeeeee-2222-2222-2222-222222222222"), "{2}" },
                    { new Guid("00000001-0002-0002-0002-000000000002"), null, false, "", new Guid("eeeeeeee-2222-2222-2222-222222222222"), "{-2}" },
                    { new Guid("00000001-0002-0002-0002-000000000003"), null, true, "", new Guid("eeeeeeee-2222-2222-2222-222222222222"), "{-2, 2}" },
                    { new Guid("00000001-0002-0002-0002-000000000004"), null, false, "", new Guid("eeeeeeee-2222-2222-2222-222222222222"), "{4}" },
                    { new Guid("00000001-0002-0002-0002-000000000005"), null, false, "", new Guid("eeeeeeee-2222-2222-2222-222222222222"), "Çözüm yok" },
                    { new Guid("00000001-0003-0003-0003-000000000001"), null, false, "", new Guid("eeeeeeee-3333-3333-3333-333333333333"), "4 cm" },
                    { new Guid("00000001-0003-0003-0003-000000000002"), null, false, "", new Guid("eeeeeeee-3333-3333-3333-333333333333"), "5 cm" },
                    { new Guid("00000001-0003-0003-0003-000000000003"), null, true, "", new Guid("eeeeeeee-3333-3333-3333-333333333333"), "6 cm" },
                    { new Guid("00000001-0003-0003-0003-000000000004"), null, false, "", new Guid("eeeeeeee-3333-3333-3333-333333333333"), "8 cm" },
                    { new Guid("00000001-0003-0003-0003-000000000005"), null, false, "", new Guid("eeeeeeee-3333-3333-3333-333333333333"), "10 cm" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_achievements_code",
                table: "achievements",
                column: "code",
                unique: true);

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
                name: "ix_game_answers_game_session_id",
                table: "game_answers",
                column: "game_session_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_answers_question_id",
                table: "game_answers",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_answers_selected_option_id",
                table: "game_answers",
                column: "selected_option_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_answers_user_id",
                table: "game_answers",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_session_players_game_session_id",
                table: "game_session_players",
                column: "game_session_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_session_players_user_id",
                table: "game_session_players",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_sessions_room_id",
                table: "game_sessions",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "ix_parameter_definitions_key",
                table: "parameter_definitions",
                column: "key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_parameter_values_entity_type_entity_id_parameter_definition",
                table: "parameter_values",
                columns: new[] { "entity_type", "entity_id", "parameter_definition_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_parameter_values_parameter_definition_id",
                table: "parameter_values",
                column: "parameter_definition_id");

            migrationBuilder.CreateIndex(
                name: "ix_question_options_question_id",
                table: "question_options",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "ix_questions_created_by",
                table: "questions",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_room_players_room_id",
                table: "room_players",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "ix_room_players_user_id",
                table: "room_players",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_rooms_host_user_id",
                table: "rooms",
                column: "host_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_rooms_room_code",
                table: "rooms",
                column: "room_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_achievements_achievement_id",
                table: "user_achievements",
                column: "achievement_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_achievements_user_id",
                table: "user_achievements",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_answer_exam_attempt_id",
                table: "user_answer",
                column: "exam_attempt_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_answer_question_id",
                table: "user_answer",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_stats_user_id",
                table: "user_stats",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_username",
                table: "users",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exam_question");

            migrationBuilder.DropTable(
                name: "game_answers");

            migrationBuilder.DropTable(
                name: "game_session_players");

            migrationBuilder.DropTable(
                name: "parameter_values");

            migrationBuilder.DropTable(
                name: "room_players");

            migrationBuilder.DropTable(
                name: "user_achievements");

            migrationBuilder.DropTable(
                name: "user_answer");

            migrationBuilder.DropTable(
                name: "user_stats");

            migrationBuilder.DropTable(
                name: "question_options");

            migrationBuilder.DropTable(
                name: "game_sessions");

            migrationBuilder.DropTable(
                name: "parameter_definitions");

            migrationBuilder.DropTable(
                name: "achievements");

            migrationBuilder.DropTable(
                name: "exam_attempt");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "exam");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
