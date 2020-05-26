using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BigScreen.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arena",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArenaName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arena", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TifoGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TifoGroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TifoGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArenaSection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArenaId = table.Column<int>(nullable: false),
                    SectionHeight = table.Column<int>(nullable: false),
                    SectionWidth = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArenaSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArenaSection_Arena_ArenaId",
                        column: x => x.ArenaId,
                        principalTable: "Arena",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TifoPartScreen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Width = table.Column<int>(nullable: false),
                    TifoPartScreenHeight = table.Column<int>(nullable: false),
                    TifoPartScreenWidth = table.Column<int>(nullable: false),
                    AbsScreenHeight = table.Column<int>(nullable: false),
                    AbsScreenWidth = table.Column<int>(nullable: false),
                    DotsPerPixel = table.Column<decimal>(nullable: false),
                    DotsPerInch = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TifoPartScreen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TifoPartScreen_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tifo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    ContentType = table.Column<string>(nullable: true),
                    LengthOfMedia = table.Column<long>(nullable: false),
                    TifoHeight = table.Column<int>(nullable: false),
                    TifoWidth = table.Column<int>(nullable: false),
                    TifoGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tifo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tifo_TifoGroup_TifoGroupId",
                        column: x => x.TifoGroupId,
                        principalTable: "TifoGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    SeatId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SectionRow = table.Column<int>(nullable: false),
                    SectionColumn = table.Column<int>(nullable: false),
                    SeatWidth = table.Column<string>(nullable: true),
                    SeatHeight = table.Column<string>(nullable: true),
                    SeatWidthInt = table.Column<int>(nullable: false),
                    SeatHeightInt = table.Column<int>(nullable: false),
                    ArenaSectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seat_ArenaSection_ArenaSectionId",
                        column: x => x.ArenaSectionId,
                        principalTable: "ArenaSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArenaEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventName = table.Column<string>(nullable: true),
                    EventDate = table.Column<DateTime>(nullable: false),
                    ContentType = table.Column<string>(nullable: true),
                    LengthOfMedia = table.Column<string>(nullable: true),
                    TifoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArenaEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArenaEvent_Tifo_TifoId",
                        column: x => x.TifoId,
                        principalTable: "Tifo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSeat",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    SeatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSeat", x => new { x.UserId, x.SeatId });
                    table.ForeignKey(
                        name: "FK_UserSeat_Seat_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seat",
                        principalColumn: "SeatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSeat_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArenaEventSeat",
                columns: table => new
                {
                    ArenaEventId = table.Column<int>(nullable: false),
                    SeatId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Registered = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArenaEventSeat", x => new { x.ArenaEventId, x.SeatId });
                    table.ForeignKey(
                        name: "FK_ArenaEventSeat_Seat_ArenaEventId",
                        column: x => x.ArenaEventId,
                        principalTable: "Seat",
                        principalColumn: "SeatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArenaEventSeat_ArenaEvent_SeatId",
                        column: x => x.SeatId,
                        principalTable: "ArenaEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArenaEventTifoPartScreen",
                columns: table => new
                {
                    ArenaEventId = table.Column<int>(nullable: false),
                    TifoPartScreenId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArenaEventTifoPartScreen", x => new { x.ArenaEventId, x.TifoPartScreenId });
                    table.ForeignKey(
                        name: "FK_ArenaEventTifoPartScreen_TifoPartScreen_ArenaEventId",
                        column: x => x.ArenaEventId,
                        principalTable: "TifoPartScreen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArenaEventTifoPartScreen_ArenaEvent_TifoPartScreenId",
                        column: x => x.TifoPartScreenId,
                        principalTable: "ArenaEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    ArenaEventId = table.Column<int>(nullable: true),
                    SeatId = table.Column<int>(nullable: true),
                    TifoId = table.Column<int>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_ArenaEvent_ArenaEventId",
                        column: x => x.ArenaEventId,
                        principalTable: "ArenaEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Seat_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seat",
                        principalColumn: "SeatId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Tifo_TifoId",
                        column: x => x.TifoId,
                        principalTable: "Tifo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArenaEvent_TifoId",
                table: "ArenaEvent",
                column: "TifoId");

            migrationBuilder.CreateIndex(
                name: "IX_ArenaEventSeat_SeatId",
                table: "ArenaEventSeat",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_ArenaEventTifoPartScreen_TifoPartScreenId",
                table: "ArenaEventTifoPartScreen",
                column: "TifoPartScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_ArenaSection_ArenaId",
                table: "ArenaSection",
                column: "ArenaId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seat_ArenaSectionId",
                table: "Seat",
                column: "ArenaSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ApplicationUserId",
                table: "Ticket",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ArenaEventId",
                table: "Ticket",
                column: "ArenaEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_SeatId",
                table: "Ticket",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TifoId",
                table: "Ticket",
                column: "TifoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tifo_TifoGroupId",
                table: "Tifo",
                column: "TifoGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TifoPartScreen_ApplicationUserId",
                table: "TifoPartScreen",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSeat_SeatId",
                table: "UserSeat",
                column: "SeatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArenaEventSeat");

            migrationBuilder.DropTable(
                name: "ArenaEventTifoPartScreen");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "UserSeat");

            migrationBuilder.DropTable(
                name: "TifoPartScreen");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ArenaEvent");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Tifo");

            migrationBuilder.DropTable(
                name: "ArenaSection");

            migrationBuilder.DropTable(
                name: "TifoGroup");

            migrationBuilder.DropTable(
                name: "Arena");
        }
    }
}
