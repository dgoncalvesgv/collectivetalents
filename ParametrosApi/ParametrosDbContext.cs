using Microsoft.EntityFrameworkCore;
using ParametrosApi.Models;

namespace ParametrosApi.Data;

public class ParametrosDbContext(DbContextOptions<ParametrosDbContext> opts) : DbContext(opts)
{
    public DbSet<WbcConfig> Parametros => Set<WbcConfig>();
    public DbSet<Permissao> Permissoes => Set<Permissao>();
    public DbSet<Funcionalidade> Funcionalidades => Set<Funcionalidade>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        var p = modelBuilder.Entity<Permissao>();
        p.ToTable("PERMISSAO", "dbo");
        p.HasKey(x => x.nCdPermissao);
        p.Property(x => x.nCdPermissao).HasColumnName("nCdPermissao");
        p.Property(x => x.sNmPermissao).HasColumnName("sNmPermissao").HasMaxLength(255);
        p.Property(x => x.sDsPermissao).HasColumnName("sDsPermissao");
        p.Property(x => x.sDsLocalImagem).HasColumnName("sDsLocalImagem").HasMaxLength(255);
        p.Property(x => x.nCdModulo).HasColumnName("nCdModulo");

        var e = modelBuilder.Entity<WbcConfig>();
        e.HasNoKey();
        e.ToTable("WBC_CONFIG", "dbo");

        e.Property(p => p.nCdParametro).HasColumnName("nCdParametro").HasColumnType("numeric(5,0)");
        e.Property(p => p.nIdAplicacao).HasColumnName("nIdAplicacao").HasColumnType("numeric(1,0)");
        e.Property(p => p.sVlParametro).HasColumnName("sVlParametro").HasMaxLength(4000);
        e.Property(p => p.sDsParametro).HasColumnName("sDsParametro").HasMaxLength(1000);
        e.Property(p => p.sNmParametro).HasColumnName("sNmParametro").HasMaxLength(50);
        e.Property(p => p.sVlTexto).HasColumnName("sVlTexto");
        e.Property(p => p.nCdModulo).HasColumnName("nCdModulo").HasColumnType("numeric(2,0)");
        e.Property(p => p.nCdEmpresa).HasColumnName("nCdEmpresa").HasColumnType("numeric(10,0)");
        e.Property(p => p.sDsCategoria).HasColumnName("sDsCategoria").HasMaxLength(20);
        
        var f = modelBuilder.Entity<Funcionalidade>();
        f.ToTable("FUNCIONALIDADE", "dbo");
        f.HasKey(x => x.nCdFuncionalidade);

        f.Property(x => x.nCdFuncionalidade ).HasColumnName("nCdFuncionalidade"); 
        f.Property(x => x.bFlBloquear       ).HasColumnName("bFlBloquear");
        f.Property(x => x.bFlCritico        ).HasColumnName("bFlCritico");
        f.Property(x => x.sDsFuncionalidade ).HasColumnName("sDsFuncionalidade");
        f.Property(x => x.nCdModulo         ).HasColumnName("nCdModulo"); 
    }
}
