namespace ParametrosApi.Models;

public class WbcConfig
{
    public decimal? nCdParametro  { get; set; }  // numeric(5,0)
    public decimal? nIdAplicacao  { get; set; }  // numeric(1,0)
    public string   sVlParametro  { get; set; } = "";
    public string   sDsParametro  { get; set; } = "";
    public string   sNmParametro  { get; set; } = "";
    public string?  sVlTexto      { get; set; }  // text
    public decimal? nCdModulo     { get; set; }  // numeric(2,0)
    public decimal? nCdEmpresa    { get; set; }  // numeric(10,0)
    public string?  sDsCategoria  { get; set; }  // varchar(20)
}

public record WbcConfigDto(
    decimal?    nCdParametro,
    string  sNmParametro,
    string  sDsParametro,
    string  sVlParametro
);
