using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BotGarden.Domain.Models;

public class PlantsConfiguration : IEntityTypeConfiguration<Plants>
{
    public void Configure(EntityTypeBuilder<Plants> builder)
    {
        builder.ToTable("Plants");

        builder.HasKey(p => p.PlantId);

        builder.Property(p => p.InventorNumber)
               .HasMaxLength(50)
               .IsRequired(false);


        builder.Property(p => p.Species)
               .HasMaxLength(50)
               .IsRequired(false);

        builder.Property(p => p.Variety)
               .HasMaxLength(50)
               .IsRequired(false);

        builder.Property(p => p.Form)
               .HasMaxLength(50)
               .IsRequired(false);

        builder.Property(p => p.Determined)
               .HasMaxLength(50)
               .IsRequired(false);

        builder.Property(p => p.DateOfPlanting)
               .HasMaxLength(50)
               .IsRequired(false);

        builder.Property(p => p.ProtectionStatus)
               .HasMaxLength(50)
               .IsRequired(false);

        builder.Property(p => p.FilledOut)
               .HasMaxLength(50)
               .IsRequired(false);

        builder.Property(p => p.HerbariumDuplicate)
               .HasMaxLength(50)
               .IsRequired(false);

        builder.Property(p => p.Synonyms)
               .HasMaxLength(250)
               .IsRequired(false);

        builder.Property(p => p.PlantOrigin)
               .HasMaxLength(250)
               .IsRequired(false);

        builder.Property(p => p.NaturalHabitat)
               .HasMaxLength(250)
               .IsRequired(false);

        builder.Property(p => p.EcologyBiology)
               .HasMaxLength(250)
               .IsRequired(false);

        builder.Property(p => p.EconomicUse)
               .HasMaxLength(250)
               .IsRequired(false);

        builder.Property(p => p.Originator)
               .HasMaxLength(250)
               .IsRequired(false);

        builder.Property(p => p.Date)
               .HasMaxLength(250)
               .IsRequired(false);

        builder.Property(p => p.Country)
               .HasMaxLength(250)
               .IsRequired(false);

        builder.Property(p => p.ImagePath)
               .HasMaxLength(250)
               .IsRequired(false);

        builder.Property(p => p.HerbariumPresence)
               .IsRequired()
               .IsRequired(true);

        builder.Property(p => p.Note)
               .HasColumnType("text")
               .IsRequired(false);

       

        builder.HasOne(p => p.Family)
               .WithMany(f => f.Plants)
               .HasForeignKey(p => p.FamilyId);

        builder.HasOne(p => p.Sector)
               .WithMany(s => s.Plants)
               .HasForeignKey(p => p.SectorId);



    }
}
