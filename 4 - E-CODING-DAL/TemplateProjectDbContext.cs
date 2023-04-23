using _4___E_CODING_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4___E_CODING_DAL
{

    public class TemplateProjectDbContext : DbContext
    {

        public TemplateProjectDbContext(DbContextOptions<TemplateProjectDbContext> options)
            : base(options)
        {
            
            var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if (databaseCreator != null)
            {
                if (!databaseCreator.CanConnect()) databaseCreator.Create();
                if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
            }
        }

        public virtual DbSet<TemplateProject> TemplateProject { get; set; }        
        public virtual DbSet<TemplateFonctionnel> TemplateFonctionnel { get; set; }
        public virtual DbSet<TemplateFonctionnelEntity> TemplateFonctionnelEntity { get; set; }
        public virtual DbSet<TemplateFonctionnelProperty> TemplateFonctionnelProperty { get; set; }
        public virtual DbSet<TemplateTechnique> TemplateTechnique { get; set; }
        public virtual DbSet<TemplateTechniqueItem> TemplateTechniqueItem { get; set; }
        public virtual DbSet<TemplateResult> TemplateResult { get; set; }
        public virtual DbSet<TemplateResultItem> TemplateResultItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var dbHost = "sqldata";
                var dbName = "dockerecoding";
                var dbPassword = "Ricardinho@1407";
                var connectionString = $"Data Source={dbHost}; Initial Catalog={dbName}; User ID=sa; Password={dbPassword};";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TemplateProject>(entity =>
            {
                entity.HasKey(z => z.TemplateProjectId);
                entity.Property(p => p.TemplateProjectId)
                .ValueGeneratedOnAdd();
            });
            
            modelBuilder.Entity<TemplateFonctionnel>(entity =>
            {
                entity.HasKey(e => e.TemplateFonctionnelId);
                entity.Property(p => p.TemplateFonctionnelId)
                .ValueGeneratedOnAdd();

                entity.HasOne<TemplateProject>(ad => ad.TemplateProject)
                .WithOne(s => s.TemplateFonctionnel)
                .HasForeignKey<TemplateFonctionnel>(ad => ad.TemplateProjectId);
            });

            modelBuilder.Entity<TemplateFonctionnelEntity>(entity =>
            {
                entity.HasKey(e => e.TemplateFonctionnelEntityId);
                entity.Property(p => p.TemplateFonctionnelEntityId)
                .ValueGeneratedOnAdd();

                entity.HasOne(d => d.TemplateFonctionnel)
                    .WithMany(p => p.TemplateFonctionnelEntity)
                    .HasForeignKey(d => d.TemplateFonctionnelId);
            });


            modelBuilder.Entity<TemplateFonctionnelProperty>(entity =>
            {
                entity.HasKey(e => e.TemplateFonctionnelPropertyId);
                entity.Property(p => p.TemplateFonctionnelPropertyId)
                .ValueGeneratedOnAdd();

                entity.HasOne(d => d.TemplateFonctionnelEntity)
                    .WithMany(p => p.TemplateFonctionnelProperty)
                    .HasForeignKey(d => d.TemplateFonctionnelEntityId);
            });

            modelBuilder.Entity<ProjectTechnique>()
                .HasKey(sc => new { sc.TemplateProjectId, sc.TemplateTechniqueId });

            modelBuilder.Entity<ProjectTechnique>()
                .HasOne<TemplateProject>(sc => sc.TemplateProject)
                .WithMany(s => s.ProjectTechnique)
                .HasForeignKey(sc => sc.TemplateProjectId);

            modelBuilder.Entity<ProjectTechnique>()
                .HasOne<TemplateTechnique>(sc => sc.TemplateTechnique)
                .WithMany(s => s.ProjectTechnique)
                .HasForeignKey(sc => sc.TemplateTechniqueId);

            modelBuilder.Entity<TemplateTechnique>(entity =>
            {
                entity.HasKey(e => e.TemplateTechniqueId);
                entity.Property(p => p.TemplateTechniqueId)
                .ValueGeneratedOnAdd();
            });

            
            modelBuilder.Entity<TemplateTechniqueItem>(entity =>
            {
                entity.HasKey(e => e.TemplateTechniqueItemId);
                entity.Property(p => p.TemplateTechniqueItemId)
                .ValueGeneratedOnAdd();

                entity.HasOne(d => d.TemplateTechnique)
                    .WithMany(p => p.TemplateTechniqueItem)
                    .HasForeignKey(d => d.TemplateTechniqueId);
            });
            /*
            modelBuilder.Entity<TemplateParameter>(entity =>
            {
                entity.HasKey(e => e.TemplateParameterId);
                entity.Property(p => p.TemplateParameterId)
                .ValueGeneratedOnAdd();

                entity.HasOne(d => d.TemplateTechniqueItem)
                    .WithMany(p => p.TemplateParameter)
                    .HasForeignKey(d => d.TemplateTechniqueItemId);
            });*/

            modelBuilder.Entity<TemplateResult>(entity =>
            {
                entity.HasKey(e => e.TemplateResultId);
                entity.Property(p => p.TemplateResultId)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ProjectResult>()
                .HasKey(sc => new { sc.TemplateProjectId, sc.TemplateResultId });

            modelBuilder.Entity<ProjectResult>()
                .HasOne<TemplateProject>(sc => sc.TemplateProject)
                .WithMany(s => s.ProjectResult)
                .HasForeignKey(sc => sc.TemplateProjectId);

            modelBuilder.Entity<ProjectResult>()
                .HasOne<TemplateResult>(sc => sc.TemplateResult)
                .WithMany(s => s.ProjectResult)
                .HasForeignKey(sc => sc.TemplateResultId);           

            modelBuilder.Entity<TemplateResultItem>(entity =>
            {
                entity.HasKey(e => e.TemplateResultItemId);
                entity.Property(p => p.TemplateResultItemId)
                .ValueGeneratedOnAdd();

                entity.HasOne(d => d.TemplateResult)
                    .WithMany(p => p.TemplateResultItem)
                    .HasForeignKey(d => d.TemplateResultId);
            });

            modelBuilder.Seed();
        }

     }

    
}