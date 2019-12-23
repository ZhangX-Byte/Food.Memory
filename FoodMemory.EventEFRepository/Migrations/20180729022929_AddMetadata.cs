using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodMemory.EventEFRepository.Migrations
{
    public partial class AddMetadata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MetadataContainers",
                columns: table => new
                {
                    EventId = table.Column<Guid>(nullable: false),
                    EventName = table.Column<string>(maxLength: 500, nullable: false),
                    EventVersion = table.Column<long>(nullable: false),
                    AggregateId = table.Column<Guid>(nullable: false),
                    AggregateName = table.Column<string>(maxLength: 500, nullable: false),
                    AggregateVersion = table.Column<long>(nullable: false),
                    Data = table.Column<byte[]>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetadataContainers", x => x.EventId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetadataContainers");
        }
    }
}
