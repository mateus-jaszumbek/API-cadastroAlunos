using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using refatorando.Model;

namespace refatorando.Data.Map
{
    public class EnderecoMap : IEntityTypeConfiguration<EnderecoModel>
    {
        public void Configure(EntityTypeBuilder<EnderecoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Rua).IsRequired();
            builder.Property(x => x.Cidade).IsRequired();
            builder.Property(x => x.Estado).IsRequired();
            builder.Property(x => x.CEP).IsRequired();

        }
    }
}
