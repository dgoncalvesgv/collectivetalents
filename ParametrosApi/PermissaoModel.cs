namespace ParametrosApi.Models;

public class Permissao
{
    public decimal   nCdPermissao   { get; set; }   
    public string    sNmPermissao   { get; set; } = "";
    public string?   sDsPermissao   { get; set; }      
    public string?   sDsLocalImagem { get; set; }
    public decimal?  nCdModulo      { get; set; }      
}

public record PermissaoDto(
    decimal  nCdPermissao,
    string   sNmPermissao,
    string?  sDsPermissao,
    string?  sDsLocalImagem,
    decimal? nCdModulo
);
