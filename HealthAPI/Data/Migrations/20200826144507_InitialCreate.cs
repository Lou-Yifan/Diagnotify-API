using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthAPI.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    Event = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Floor = table.Column<string>(nullable: true),
                    Room = table.Column<string>(nullable: true),
                    PatientId = table.Column<string>(nullable: true),
                    ClinicianId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                });

            migrationBuilder.CreateTable(
                name: "Clinicians",
                columns: table => new
                {
                    ClinicianId = table.Column<string>(nullable: false),
                    ClinicianName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinicians", x => x.ClinicianId);
                });

            migrationBuilder.CreateTable(
                name: "Observations",
                columns: table => new
                {
                    ObservationId = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    PatientId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observations", x => x.ObservationId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<string>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<string>(nullable: false),
                    Datetime = table.Column<string>(nullable: true),
                    PatientId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                });

            migrationBuilder.CreateTable(
                name: "WatchLists",
                columns: table => new
                {
                    WatchListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<string>(nullable: true),
                    ClinicianId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchLists", x => x.WatchListId);
                });

            migrationBuilder.CreateTable(
                name: "ObservedItems",
                columns: table => new
                {
                    ObservedItemId = table.Column<string>(nullable: false),
                    ObservationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObservedItems", x => x.ObservedItemId);
                    table.ForeignKey(
                        name: "FK_ObservedItems_Observations_ObservationId",
                        column: x => x.ObservationId,
                        principalTable: "Observations",
                        principalColumn: "ObservationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diagnoses",
                columns: table => new
                {
                    DiagnoseId = table.Column<string>(nullable: false),
                    SelfDescription = table.Column<string>(nullable: true),
                    ClinicianDescription = table.Column<string>(nullable: true),
                    Suggestions = table.Column<string>(nullable: true),
                    ReportId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnoses", x => x.DiagnoseId);
                    table.ForeignKey(
                        name: "FK_Diagnoses_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<string>(nullable: false),
                    ImageName = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    ReportId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Images_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    MedicationId = table.Column<string>(nullable: false),
                    ReportId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.MedicationId);
                    table.ForeignKey(
                        name: "FK_Medications_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BloodPressures",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Item = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    ObservedItemId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodPressures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BloodPressures_ObservedItems_ObservedItemId",
                        column: x => x.ObservedItemId,
                        principalTable: "ObservedItems",
                        principalColumn: "ObservedItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BodyHeats",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Item = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    ObservedItemId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyHeats", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BodyHeats_ObservedItems_ObservedItemId",
                        column: x => x.ObservedItemId,
                        principalTable: "ObservedItems",
                        principalColumn: "ObservedItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RespiratoryRates",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Item = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    ObservedItemId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespiratoryRates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RespiratoryRates_ObservedItems_ObservedItemId",
                        column: x => x.ObservedItemId,
                        principalTable: "ObservedItems",
                        principalColumn: "ObservedItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SinusRhythms",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Item = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    ObservedItemId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinusRhythms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SinusRhythms_ObservedItems_ObservedItemId",
                        column: x => x.ObservedItemId,
                        principalTable: "ObservedItems",
                        principalColumn: "ObservedItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    MedicineId = table.Column<string>(nullable: false),
                    MedicineName = table.Column<string>(nullable: true),
                    MedicineUrl = table.Column<string>(nullable: true),
                    TimesPerDay = table.Column<string>(nullable: true),
                    PiecesPerTime = table.Column<string>(nullable: true),
                    Directions = table.Column<string>(nullable: true),
                    MedicationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.MedicineId);
                    table.ForeignKey(
                        name: "FK_Medicines_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "MedicationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodPressures_ObservedItemId",
                table: "BloodPressures",
                column: "ObservedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_BodyHeats_ObservedItemId",
                table: "BodyHeats",
                column: "ObservedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_ReportId",
                table: "Diagnoses",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ReportId",
                table: "Images",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Medications_ReportId",
                table: "Medications",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_MedicationId",
                table: "Medicines",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ObservedItems_ObservationId",
                table: "ObservedItems",
                column: "ObservationId");

            migrationBuilder.CreateIndex(
                name: "IX_RespiratoryRates_ObservedItemId",
                table: "RespiratoryRates",
                column: "ObservedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SinusRhythms_ObservedItemId",
                table: "SinusRhythms",
                column: "ObservedItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "BloodPressures");

            migrationBuilder.DropTable(
                name: "BodyHeats");

            migrationBuilder.DropTable(
                name: "Clinicians");

            migrationBuilder.DropTable(
                name: "Diagnoses");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "RespiratoryRates");

            migrationBuilder.DropTable(
                name: "SinusRhythms");

            migrationBuilder.DropTable(
                name: "WatchLists");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "ObservedItems");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Observations");
        }
    }
}
