﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jean_P2_AP2.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "Cobros",
                columns: table => new
                {
                    CobroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobros", x => x.CobroID);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    VentaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.VentaID);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CobrosDetalle",
                columns: table => new
                {
                    CobroDetalleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CobroID = table.Column<int>(type: "int", nullable: false),
                    VentaID = table.Column<int>(type: "int", nullable: false),
                    Cobrado = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobrosDetalle", x => x.CobroDetalleID);
                    table.ForeignKey(
                        name: "FK_CobrosDetalle_Cobros_CobroID",
                        column: x => x.CobroID,
                        principalTable: "Cobros",
                        principalColumn: "CobroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteID", "Nombres" },
                values: new object[] { 1, "FERRETERIA GAMA" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteID", "Nombres" },
                values: new object[] { 2, "AVALON DISCO" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteID", "Nombres" },
                values: new object[] { 3, "PRESTAMOS CEFIPROD" });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "VentaID", "Balance", "ClienteID", "Fecha", "Monto" },
                values: new object[,]
                {
                    { 1, 1000.0, 1, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000.0 },
                    { 2, 800.0, 1, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 900.0 },
                    { 3, 2000.0, 2, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000.0 },
                    { 4, 1800.0, 2, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1900.0 },
                    { 5, 3000.0, 3, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3000.0 },
                    { 6, 1900.0, 3, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2900.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CobrosDetalle_CobroID",
                table: "CobrosDetalle",
                column: "CobroID");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ClienteID",
                table: "Ventas",
                column: "ClienteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CobrosDetalle");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Cobros");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
