using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace angular_api.Models.Configuration
{
    public class AnimalConfiguration : EntityTypeConfiguration<Animal>
    {
        public AnimalConfiguration()
        {
            ToTable("Animals");
            HasKey(x => x.AnimalId)
                .Property(x => x.AnimalId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
