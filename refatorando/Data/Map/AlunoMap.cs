using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using refatorando.Model;

namespace refatorando.Data.Map
{
    public class AlunoMap : IEntityTypeConfiguration<AlunoModel>
    {
        public void Configure(EntityTypeBuilder<AlunoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Segmento).IsRequired();
            builder.Property(x => x.Serie).IsRequired();
            builder.Property(x => x.TipoEnderec).IsRequired();
            builder.Property(x => x.DataNascimento).IsRequired();
            builder.Property(x => x.NomeMae).IsRequired().HasMaxLength(200);
            builder.Property(x => x.NomePai).IsRequired().HasMaxLength(200);
            builder.Property(x => x.EnderecoId);

            builder.HasOne(x => x.Endereco);
        }
    }
}
