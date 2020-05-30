using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class StepMap
    {
        public StepMap(EntityTypeBuilder<Step> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Title);
            entityBuilder.Property(t => t.Text).IsRequired();
            entityBuilder.Property(t => t.Rank).IsRequired();
        }
    }
}
