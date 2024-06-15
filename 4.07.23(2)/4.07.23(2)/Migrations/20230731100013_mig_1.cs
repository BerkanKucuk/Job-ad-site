using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4._07._23_2_.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "calismaTuru",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calismaTuru", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "deneyims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deneyims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "isSahibis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    soyisim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telno = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    KullanıcıSifresi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_isSahibis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mesleks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mesleks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seekers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    soyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telno = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    sehir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ilce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dogumtarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    egitimSeviyesi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cinsiyet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullanıcıSifresi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seekers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sektors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sektors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "firmas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kurulusYili = table.Column<int>(type: "int", nullable: true),
                    website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telno = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSahibiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_firmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_firmas_isSahibis_IsSahibiId",
                        column: x => x.IsSahibiId,
                        principalTable: "isSahibis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ısBakanMesleks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeslekId = table.Column<int>(type: "int", nullable: false),
                    JobSeekerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ısBakanMesleks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ısBakanMesleks_Seekers_JobSeekerId",
                        column: x => x.JobSeekerId,
                        principalTable: "Seekers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ısBakanMesleks_mesleks_MeslekId",
                        column: x => x.MeslekId,
                        principalTable: "mesleks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "firmaSektors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirmaId = table.Column<int>(type: "int", nullable: false),
                    SektorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_firmaSektors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_firmaSektors_firmas_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "firmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_firmaSektors_sektors_SektorId",
                        column: x => x.SektorId,
                        principalTable: "sektors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ilans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeneyimId = table.Column<int>(type: "int", nullable: false),
                    GetDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    egitimseviyesi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    maaş = table.Column<int>(type: "int", nullable: false),
                    FirmaId = table.Column<int>(type: "int", nullable: false),
                    firmaWebSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalismaTuruId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ilans_calismaTuru_CalismaTuruId",
                        column: x => x.CalismaTuruId,
                        principalTable: "calismaTuru",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ilans_deneyims_DeneyimId",
                        column: x => x.DeneyimId,
                        principalTable: "deneyims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ilans_firmas_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "firmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ısBakanIlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobSeekerId = table.Column<int>(type: "int", nullable: false),
                    IlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ısBakanIlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ısBakanIlans_Ilans_IlanId",
                        column: x => x.IlanId,
                        principalTable: "Ilans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ısBakanIlans_Seekers_JobSeekerId",
                        column: x => x.JobSeekerId,
                        principalTable: "Seekers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_firmas_IsSahibiId",
                table: "firmas",
                column: "IsSahibiId");

            migrationBuilder.CreateIndex(
                name: "IX_firmaSektors_FirmaId",
                table: "firmaSektors",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_firmaSektors_SektorId",
                table: "firmaSektors",
                column: "SektorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ilans_CalismaTuruId",
                table: "Ilans",
                column: "CalismaTuruId");

            migrationBuilder.CreateIndex(
                name: "IX_Ilans_DeneyimId",
                table: "Ilans",
                column: "DeneyimId");

            migrationBuilder.CreateIndex(
                name: "IX_Ilans_FirmaId",
                table: "Ilans",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_ısBakanIlans_IlanId",
                table: "ısBakanIlans",
                column: "IlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ısBakanIlans_JobSeekerId",
                table: "ısBakanIlans",
                column: "JobSeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_ısBakanMesleks_JobSeekerId",
                table: "ısBakanMesleks",
                column: "JobSeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_ısBakanMesleks_MeslekId",
                table: "ısBakanMesleks",
                column: "MeslekId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "firmaSektors");

            migrationBuilder.DropTable(
                name: "ısBakanIlans");

            migrationBuilder.DropTable(
                name: "ısBakanMesleks");

            migrationBuilder.DropTable(
                name: "sektors");

            migrationBuilder.DropTable(
                name: "Ilans");

            migrationBuilder.DropTable(
                name: "Seekers");

            migrationBuilder.DropTable(
                name: "mesleks");

            migrationBuilder.DropTable(
                name: "calismaTuru");

            migrationBuilder.DropTable(
                name: "deneyims");

            migrationBuilder.DropTable(
                name: "firmas");

            migrationBuilder.DropTable(
                name: "isSahibis");
        }
    }
}
