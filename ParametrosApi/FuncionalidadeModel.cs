namespace ParametrosApi.Models;

public class Funcionalidade
{
    public decimal   nCdFuncionalidade  { get; set; }   
    public bool?     bFlBloquear        { get; set; } 
    public bool?     bFlCritico         { get; set; }  
    public string?   sDsFuncionalidade  { get; set; }  
    public decimal?  nCdModulo          { get; set; }  
}

public record FuncionalidadeDto(
    decimal   nCdFuncionalidade,
    bool?     bFlBloquear,
    bool?     bFlCritico,
    string?   sDsFuncionalidade,
    decimal?  nCdModulo
);
