using _4___E_CODING_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace _4___E_CODING_DAL
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TemplateProject>()
            .HasData(new TemplateProject()
            {
                TemplateProjectId = 1,
                TemplateProjectDescription = "TemplateProjectDescription1",
                TemplateProjectName = "TemplateProjectName1",
                TemplateProjectTitle = "TemplateProjectTitle1",
                TemplateProjectVersion = "TemplateProjectVersion1",
                TemplateProjectVersionNet = "TemplateProjectVersionNet1",
            });

            modelBuilder.Entity<TemplateProject>()
            .HasData(new TemplateProject()
            {
                TemplateProjectId = 2,
                TemplateProjectDescription = "TemplateProjectDescription2",
                TemplateProjectName = "TemplateProjectName2",
                TemplateProjectTitle = "TemplateProjectTitle2",
                TemplateProjectVersion = "TemplateProjectVersion2",
                TemplateProjectVersionNet = "TemplateProjectVersionNet2",
            });

            modelBuilder.Entity<TemplateTechnique>()
            .HasData(
            new TemplateTechnique
            {
                TemplateTechniqueId = 1,
                TemplateTechniqueDescription = "TemplateTechniqueDescription1",
                TemplateTechniqueName = "TemplateTechniqueName1",
                TemplateTechniqueTitle = "TemplateTechniqueTitle1",
                TemplateTechniqueVersion = "TemplateTechniqueVersion1",
                TemplateTechniqueVersionNET = "TemplateTechniqueVersionNET1",
                TemplateProjectId = 1
            });

            modelBuilder.Entity<TemplateTechnique>()
            .HasData(
            new TemplateTechnique
            {
                TemplateTechniqueId = 2,
                TemplateTechniqueDescription = "TemplateTechniqueDescription2",
                TemplateTechniqueName = "TemplateTechniqueName2",
                TemplateTechniqueTitle = "TemplateTechniqueTitle2",
                TemplateTechniqueVersion = "TemplateTechniqueVersion2",
                TemplateTechniqueVersionNET = "TemplateTechniqueVersionNET2",
                TemplateProjectId = 1
            });

            modelBuilder.Entity<TemplateTechniqueItem>()
            .HasData(new TemplateTechniqueItem
            {
                TemplateTechniqueItemId = 1,
                TemplateTechniqueItemDescription = "TemplateTechniqueItemDescription1",
                TemplateTechniqueItemName = "TemplateTechniqueItemName1",
                TemplateTechniqueItemTitle = "TemplateTechniqueItemTitle1",
                TemplateTechniqueItemVersion = "TemplateTechniqueItemVersion1",
                TemplateTechniqueItemVersionNET = "TemplateTechniqueItemVersionNET1",
                TemplateTechniqueId = 1
            });

            modelBuilder.Entity<ProjectTechnique>()
            .HasData(
            new ProjectTechnique
            {
                TemplateProjectId = 1,
                TemplateTechniqueId = 1
            });

            modelBuilder.Entity<ProjectTechnique>()
            .HasData(
            new ProjectTechnique
            {
                TemplateProjectId = 1,
                TemplateTechniqueId = 2
            });

            modelBuilder.Entity<TemplateFonctionnel>()
            .HasData(new TemplateFonctionnel
            {
                TemplateFonctionnelId = 1,
                TemplateFonctionnelDescription = "TemplateFonctionnelDescription",
                TemplateFonctionnelName = "TemplateFonctionnelName",
                TemplateFonctionnelTitle = "TemplateFonctionnelTitle",
                TemplateFonctionnelContent = "TemplateFonctionnelContent",
                TemplateFonctionnelEFVersion = "TemplateFonctionnelEFVersion",
                TemplateProjectId = 1
            });

            modelBuilder.Entity<TemplateFonctionnelEntity>()
            .HasData(new TemplateFonctionnelEntity()
            {
                TemplateFonctionnelEntityId = 1,
                TemplateFonctionnelId = 1,
                TemplateFonctionnelEntityDescription = "TemplateFonctionnelEntityDescription",
                TemplateFonctionnelEntityName = "TemplateFonctionnelEntityName",
                TemplateFonctionnelEntityTitle = "TemplateFonctionnelEntityTitle",
                TemplateFonctionnelEntityContent = "TemplateFonctionnelEntityContent",
                TemplateFonctionnelEntityVersionEF = "TemplateFonctionnelEntityVersionEF",
                TemplateFonctionnelEntityVersionNET = "TemplateFonctionnelEntityVersionNET",
                TemplateFonctionnelEntityTypeNet = "TemplateFonctionnelEntityTypeNet",
                TemplateFonctionnelEntityTypeSQL = "TemplateFonctionnelEntityTypeSQL"
            });

            modelBuilder.Entity<TemplateFonctionnelProperty>()
            .HasData(new TemplateFonctionnelProperty()
            {
                TemplateFonctionnelPropertyId = 1,
                TemplateFonctionnelEntityId = 1,
                TemplateFonctionnelId = 1,
                TemplateFonctionnelPropertyDescription = "TemplateFonctionnelPropertyDescription",
                TemplateFonctionnelPropertyName = "TemplateFonctionnelPropertyName",
                TemplateFonctionnelPropertyTitle = "TemplateFonctionnelPropertyTitle",
                TemplateFonctionnelPropertyVersionEF = "TemplateFonctionnelPropertyVersionEF",
                TemplateFonctionnelPropertyVersionNET = "TemplateFonctionnelPropertyVersionNET"
            });

            modelBuilder.Entity<TemplateFonctionnelProperty>()
            .HasData(new TemplateFonctionnelProperty()
            {
                TemplateFonctionnelPropertyId = 2,
                TemplateFonctionnelEntityId = 1,
                TemplateFonctionnelId = 1,
                TemplateFonctionnelPropertyDescription = "TemplateFonctionnelPropertyDescription",
                TemplateFonctionnelPropertyName = "TemplateFonctionnelPropertyName",
                TemplateFonctionnelPropertyTitle = "TemplateFonctionnelPropertyTitle",
                TemplateFonctionnelPropertyVersionEF = "TemplateFonctionnelPropertyVersionEF",
                TemplateFonctionnelPropertyVersionNET = "TemplateFonctionnelPropertyVersionNET"
            });


            modelBuilder.Entity<TemplateResult>()
            .HasData(new TemplateResult
            {
                TemplateResultId = 1,
                TemplateProjectId = 1,
                TemplateResultDescription = "TemplateResultDescription",
                TemplateResultName = "TemplateResultName",
                TemplateResultTitle = "TemplateResultTitle",
                TemplateResultVersion = "TemplateResultVersion",
                TemplateResultVersionNET = "TemplateResultVersionNET",
            });

            modelBuilder.Entity<TemplateResult>()
            .HasData(new TemplateResult
            {
                TemplateResultId = 2,
                TemplateProjectId = 1,
                TemplateResultDescription = "TemplateResultDescription",
                TemplateResultName = "TemplateResultName",
                TemplateResultTitle = "TemplateResultTitle",
                TemplateResultVersion = "TemplateResultVersion",
                TemplateResultVersionNET = "TemplateResultVersionNET",
            });

            modelBuilder.Entity<TemplateResultItem>()
            .HasData(new TemplateResultItem
            {
                TemplateResultItemId = 1,
                TemplateResultItemDescription = "TemplateResultItemDescription",
                TemplateResultItemName = "TemplateResultItemName",
                TemplateResultItemTitle = "TemplateResultItemTitle",
                TemplateResultItemVersion = "TemplateResultItemVersion",
                TemplateResultItemVersionNET = "TemplateResultItemVersionNET",
                TemplateTechniqueId = 1,
                TemplateFonctionnelId = 1,
                TemplateResultId = 1,
                TemplateResultFinalContent = "TemplateResultFinalContent",
                TemplateResultInitialContent = "TemplateResultInitialContent"
            });

            modelBuilder.Entity<TemplateResultItem>()
            .HasData(new TemplateResultItem
            {
                TemplateResultItemId = 2,
                TemplateResultItemDescription = "TemplateResultItemDescription",
                TemplateResultItemName = "TemplateResultItemName",
                TemplateResultItemTitle = "TemplateResultItemTitle",
                TemplateResultItemVersion = "TemplateResultItemVersion",
                TemplateResultItemVersionNET = "TemplateResultItemVersionNET",
                TemplateTechniqueId = 1,
                TemplateFonctionnelId = 1,
                TemplateResultId = 2,
                TemplateResultFinalContent = "TemplateResultFinalContent",
                TemplateResultInitialContent = "TemplateResultInitialContent"
            });

            modelBuilder.Entity<ProjectResult>()
            .HasData(new ProjectResult
            {
                TemplateProjectId = 1,
                TemplateResultId = 1
            });

            modelBuilder.Entity<ProjectResult>()
            .HasData(new ProjectResult
            {
                TemplateProjectId = 1,
                TemplateResultId = 2
            });
        }
    }
}
