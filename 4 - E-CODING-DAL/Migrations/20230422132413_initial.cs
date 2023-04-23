using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4___E_CODING_DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TemplateProject",
                columns: table => new
                {
                    TemplateProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateProjectTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateProjectVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateProjectVersionNet = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateProject", x => x.TemplateProjectId);
                });

            migrationBuilder.CreateTable(
                name: "TemplateResult",
                columns: table => new
                {
                    TemplateResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateResultName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateResultVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateResultVersionNET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateResultTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateResultDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateResult", x => x.TemplateResultId);
                });

            migrationBuilder.CreateTable(
                name: "TemplateTechnique",
                columns: table => new
                {
                    TemplateTechniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateTechniqueName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateTechniqueVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateTechniqueTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateTechniqueDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateTechniqueVersionNET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateTechnique", x => x.TemplateTechniqueId);
                });

            migrationBuilder.CreateTable(
                name: "TemplateFonctionnel",
                columns: table => new
                {
                    TemplateFonctionnelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateFonctionnelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateFonctionnelTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateFonctionnelDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateFonctionnelContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateFonctionnelEFVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateFonctionnel", x => x.TemplateFonctionnelId);
                    table.ForeignKey(
                        name: "FK_TemplateFonctionnel_TemplateProject_TemplateProjectId",
                        column: x => x.TemplateProjectId,
                        principalTable: "TemplateProject",
                        principalColumn: "TemplateProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectResult",
                columns: table => new
                {
                    TemplateProjectId = table.Column<int>(type: "int", nullable: false),
                    TemplateResultId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectResult", x => new { x.TemplateProjectId, x.TemplateResultId });
                    table.ForeignKey(
                        name: "FK_ProjectResult_TemplateProject_TemplateProjectId",
                        column: x => x.TemplateProjectId,
                        principalTable: "TemplateProject",
                        principalColumn: "TemplateProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectResult_TemplateResult_TemplateResultId",
                        column: x => x.TemplateResultId,
                        principalTable: "TemplateResult",
                        principalColumn: "TemplateResultId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateResultItem",
                columns: table => new
                {
                    TemplateResultItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateResultId = table.Column<int>(type: "int", nullable: false),
                    TemplateTechniqueId = table.Column<int>(type: "int", nullable: false),
                    TemplateFonctionnelId = table.Column<int>(type: "int", nullable: false),
                    TemplateResultItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateResultItemTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateResultItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateResultItemVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateResultItemVersionNET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateResultInitialContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateResultFinalContent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateResultItem", x => x.TemplateResultItemId);
                    table.ForeignKey(
                        name: "FK_TemplateResultItem_TemplateResult_TemplateResultId",
                        column: x => x.TemplateResultId,
                        principalTable: "TemplateResult",
                        principalColumn: "TemplateResultId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTechnique",
                columns: table => new
                {
                    TemplateProjectId = table.Column<int>(type: "int", nullable: false),
                    TemplateTechniqueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTechnique", x => new { x.TemplateProjectId, x.TemplateTechniqueId });
                    table.ForeignKey(
                        name: "FK_ProjectTechnique_TemplateProject_TemplateProjectId",
                        column: x => x.TemplateProjectId,
                        principalTable: "TemplateProject",
                        principalColumn: "TemplateProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTechnique_TemplateTechnique_TemplateTechniqueId",
                        column: x => x.TemplateTechniqueId,
                        principalTable: "TemplateTechnique",
                        principalColumn: "TemplateTechniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateTechniqueItem",
                columns: table => new
                {
                    TemplateTechniqueItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateTechniqueId = table.Column<int>(type: "int", nullable: false),
                    TemplateTechniqueItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateTechniqueItemTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateTechniqueItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateTechniqueItemVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateTechniqueItemVersionNET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateTechniqueInitialFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateTechniqueFinalContent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateTechniqueItem", x => x.TemplateTechniqueItemId);
                    table.ForeignKey(
                        name: "FK_TemplateTechniqueItem_TemplateTechnique_TemplateTechniqueId",
                        column: x => x.TemplateTechniqueId,
                        principalTable: "TemplateTechnique",
                        principalColumn: "TemplateTechniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateFonctionnelEntity",
                columns: table => new
                {
                    TemplateFonctionnelEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateFonctionnelId = table.Column<int>(type: "int", nullable: false),
                    TemplateFonctionnelEntityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateFonctionnelEntityTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateFonctionnelEntityDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateFonctionnelEntityContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateFonctionnelEntityTypeNet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateFonctionnelEntityTypeSQL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateFonctionnelEntityVersionEF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateFonctionnelEntityVersionNET = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateFonctionnelEntity", x => x.TemplateFonctionnelEntityId);
                    table.ForeignKey(
                        name: "FK_TemplateFonctionnelEntity_TemplateFonctionnel_TemplateFonctionnelId",
                        column: x => x.TemplateFonctionnelId,
                        principalTable: "TemplateFonctionnel",
                        principalColumn: "TemplateFonctionnelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateFonctionnelProperty",
                columns: table => new
                {
                    TemplateFonctionnelPropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateFonctionnelEntityId = table.Column<int>(type: "int", nullable: false),
                    TemplateFonctionnelId = table.Column<int>(type: "int", nullable: false),
                    TemplateFonctionnelPropertyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateFonctionnelPropertyTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateFonctionnelPropertyDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateFonctionnelPropertyVersionEF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateFonctionnelPropertyVersionNET = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateFonctionnelProperty", x => x.TemplateFonctionnelPropertyId);
                    table.ForeignKey(
                        name: "FK_TemplateFonctionnelProperty_TemplateFonctionnelEntity_TemplateFonctionnelEntityId",
                        column: x => x.TemplateFonctionnelEntityId,
                        principalTable: "TemplateFonctionnelEntity",
                        principalColumn: "TemplateFonctionnelEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TemplateProject",
                columns: new[] { "TemplateProjectId", "TemplateProjectDescription", "TemplateProjectName", "TemplateProjectTitle", "TemplateProjectVersion", "TemplateProjectVersionNet" },
                values: new object[,]
                {
                    { 1, "TemplateProjectDescription1", "TemplateProjectName1", "TemplateProjectTitle1", "TemplateProjectVersion1", "TemplateProjectVersionNet1" },
                    { 2, "TemplateProjectDescription2", "TemplateProjectName2", "TemplateProjectTitle2", "TemplateProjectVersion2", "TemplateProjectVersionNet2" }
                });

            migrationBuilder.InsertData(
                table: "TemplateResult",
                columns: new[] { "TemplateResultId", "TemplateProjectId", "TemplateResultDescription", "TemplateResultName", "TemplateResultTitle", "TemplateResultVersion", "TemplateResultVersionNET" },
                values: new object[,]
                {
                    { 1, 1, "TemplateResultDescription", "TemplateResultName", "TemplateResultTitle", "TemplateResultVersion", "TemplateResultVersionNET" },
                    { 2, 1, "TemplateResultDescription", "TemplateResultName", "TemplateResultTitle", "TemplateResultVersion", "TemplateResultVersionNET" }
                });

            migrationBuilder.InsertData(
                table: "TemplateTechnique",
                columns: new[] { "TemplateTechniqueId", "TemplateProjectId", "TemplateTechniqueDescription", "TemplateTechniqueName", "TemplateTechniqueTitle", "TemplateTechniqueVersion", "TemplateTechniqueVersionNET" },
                values: new object[,]
                {
                    { 1, 1, "TemplateTechniqueDescription1", "TemplateTechniqueName1", "TemplateTechniqueTitle1", "TemplateTechniqueVersion1", "TemplateTechniqueVersionNET1" },
                    { 2, 1, "TemplateTechniqueDescription2", "TemplateTechniqueName2", "TemplateTechniqueTitle2", "TemplateTechniqueVersion2", "TemplateTechniqueVersionNET2" }
                });

            migrationBuilder.InsertData(
                table: "ProjectResult",
                columns: new[] { "TemplateProjectId", "TemplateResultId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProjectTechnique",
                columns: new[] { "TemplateProjectId", "TemplateTechniqueId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "TemplateFonctionnel",
                columns: new[] { "TemplateFonctionnelId", "TemplateFonctionnelContent", "TemplateFonctionnelDescription", "TemplateFonctionnelEFVersion", "TemplateFonctionnelName", "TemplateFonctionnelTitle", "TemplateProjectId" },
                values: new object[] { 1, "TemplateFonctionnelContent", "TemplateFonctionnelDescription", "TemplateFonctionnelEFVersion", "TemplateFonctionnelName", "TemplateFonctionnelTitle", 1 });

            migrationBuilder.InsertData(
                table: "TemplateResultItem",
                columns: new[] { "TemplateResultItemId", "TemplateFonctionnelId", "TemplateResultFinalContent", "TemplateResultId", "TemplateResultInitialContent", "TemplateResultItemDescription", "TemplateResultItemName", "TemplateResultItemTitle", "TemplateResultItemVersion", "TemplateResultItemVersionNET", "TemplateTechniqueId" },
                values: new object[,]
                {
                    { 1, 1, "TemplateResultFinalContent", 1, "TemplateResultInitialContent", "TemplateResultItemDescription", "TemplateResultItemName", "TemplateResultItemTitle", "TemplateResultItemVersion", "TemplateResultItemVersionNET", 1 },
                    { 2, 1, "TemplateResultFinalContent", 2, "TemplateResultInitialContent", "TemplateResultItemDescription", "TemplateResultItemName", "TemplateResultItemTitle", "TemplateResultItemVersion", "TemplateResultItemVersionNET", 1 }
                });

            migrationBuilder.InsertData(
                table: "TemplateTechniqueItem",
                columns: new[] { "TemplateTechniqueItemId", "TemplateTechniqueFinalContent", "TemplateTechniqueId", "TemplateTechniqueInitialFile", "TemplateTechniqueItemDescription", "TemplateTechniqueItemName", "TemplateTechniqueItemTitle", "TemplateTechniqueItemVersion", "TemplateTechniqueItemVersionNET" },
                values: new object[] { 1, "", 1, "", "TemplateTechniqueItemDescription1", "TemplateTechniqueItemName1", "TemplateTechniqueItemTitle1", "TemplateTechniqueItemVersion1", "TemplateTechniqueItemVersionNET1" });

            migrationBuilder.InsertData(
                table: "TemplateFonctionnelEntity",
                columns: new[] { "TemplateFonctionnelEntityId", "TemplateFonctionnelEntityContent", "TemplateFonctionnelEntityDescription", "TemplateFonctionnelEntityName", "TemplateFonctionnelEntityTitle", "TemplateFonctionnelEntityTypeNet", "TemplateFonctionnelEntityTypeSQL", "TemplateFonctionnelEntityVersionEF", "TemplateFonctionnelEntityVersionNET", "TemplateFonctionnelId" },
                values: new object[] { 1, "TemplateFonctionnelEntityContent", "TemplateFonctionnelEntityDescription", "TemplateFonctionnelEntityName", "TemplateFonctionnelEntityTitle", "TemplateFonctionnelEntityTypeNet", "TemplateFonctionnelEntityTypeSQL", "TemplateFonctionnelEntityVersionEF", "TemplateFonctionnelEntityVersionNET", 1 });

            migrationBuilder.InsertData(
                table: "TemplateFonctionnelProperty",
                columns: new[] { "TemplateFonctionnelPropertyId", "TemplateFonctionnelEntityId", "TemplateFonctionnelId", "TemplateFonctionnelPropertyDescription", "TemplateFonctionnelPropertyName", "TemplateFonctionnelPropertyTitle", "TemplateFonctionnelPropertyVersionEF", "TemplateFonctionnelPropertyVersionNET" },
                values: new object[] { 1, 1, 1, "TemplateFonctionnelPropertyDescription", "TemplateFonctionnelPropertyName", "TemplateFonctionnelPropertyTitle", "TemplateFonctionnelPropertyVersionEF", "TemplateFonctionnelPropertyVersionNET" });

            migrationBuilder.InsertData(
                table: "TemplateFonctionnelProperty",
                columns: new[] { "TemplateFonctionnelPropertyId", "TemplateFonctionnelEntityId", "TemplateFonctionnelId", "TemplateFonctionnelPropertyDescription", "TemplateFonctionnelPropertyName", "TemplateFonctionnelPropertyTitle", "TemplateFonctionnelPropertyVersionEF", "TemplateFonctionnelPropertyVersionNET" },
                values: new object[] { 2, 1, 1, "TemplateFonctionnelPropertyDescription", "TemplateFonctionnelPropertyName", "TemplateFonctionnelPropertyTitle", "TemplateFonctionnelPropertyVersionEF", "TemplateFonctionnelPropertyVersionNET" });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectResult_TemplateResultId",
                table: "ProjectResult",
                column: "TemplateResultId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTechnique_TemplateTechniqueId",
                table: "ProjectTechnique",
                column: "TemplateTechniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateFonctionnel_TemplateProjectId",
                table: "TemplateFonctionnel",
                column: "TemplateProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TemplateFonctionnelEntity_TemplateFonctionnelId",
                table: "TemplateFonctionnelEntity",
                column: "TemplateFonctionnelId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateFonctionnelProperty_TemplateFonctionnelEntityId",
                table: "TemplateFonctionnelProperty",
                column: "TemplateFonctionnelEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateResultItem_TemplateResultId",
                table: "TemplateResultItem",
                column: "TemplateResultId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateTechniqueItem_TemplateTechniqueId",
                table: "TemplateTechniqueItem",
                column: "TemplateTechniqueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectResult");

            migrationBuilder.DropTable(
                name: "ProjectTechnique");

            migrationBuilder.DropTable(
                name: "TemplateFonctionnelProperty");

            migrationBuilder.DropTable(
                name: "TemplateResultItem");

            migrationBuilder.DropTable(
                name: "TemplateTechniqueItem");

            migrationBuilder.DropTable(
                name: "TemplateFonctionnelEntity");

            migrationBuilder.DropTable(
                name: "TemplateResult");

            migrationBuilder.DropTable(
                name: "TemplateTechnique");

            migrationBuilder.DropTable(
                name: "TemplateFonctionnel");

            migrationBuilder.DropTable(
                name: "TemplateProject");
        }
    }
}
