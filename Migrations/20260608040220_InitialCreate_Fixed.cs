using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace neoHorizonApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_Fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PredictionsMade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IsGoingToCollide = table.Column<short>(type: "NUMBER(5)", nullable: false),
                    TimeUntilImpact = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredictionsMade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpaceObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    X = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Y = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Z = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    VelocityX = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    VelocityY = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    VelocityZ = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Radius = table.Column<double>(type: "BINARY_DOUBLE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PredictionsMadeSpaceObject",
                columns: table => new
                {
                    ObjectsInvolvedId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PredictionsId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredictionsMadeSpaceObject", x => new { x.ObjectsInvolvedId, x.PredictionsId });
                    table.ForeignKey(
                        name: "FK_PredictionsMadeSpaceObject_PredictionsMade_PredictionsId",
                        column: x => x.PredictionsId,
                        principalTable: "PredictionsMade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PredictionsMadeSpaceObject_SpaceObjects_ObjectsInvolvedId",
                        column: x => x.ObjectsInvolvedId,
                        principalTable: "SpaceObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PredictionsMadeSpaceObject_PredictionsId",
                table: "PredictionsMadeSpaceObject",
                column: "PredictionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PredictionsMadeSpaceObject");

            migrationBuilder.DropTable(
                name: "PredictionsMade");

            migrationBuilder.DropTable(
                name: "SpaceObjects");
        }
    }
}
