using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParametrosApi.Data;
using ParametrosApi.Models;

namespace ParametrosApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParametrosController(ParametrosDbContext db) : ControllerBase
{
    /// <summary>
    /// Busca por Parâmetros.
    /// </summary>
    /// <param name="parametro">Nome do Parametro a procurar</param>
    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<WbcConfigDto>>> Search(
    [FromQuery] string parametro,
    CancellationToken ct = default)
    {
        var like = $"%{parametro}%";

        var itens = await db.Parametros
            .AsNoTracking()
            .Where(p => p.sNmParametro != null && EF.Functions.Like(p.sNmParametro, like))
            .OrderBy(p => p.sNmParametro)
            .Select(p => new WbcConfigDto(
                p.nCdParametro,
                p.sNmParametro,
                p.sDsParametro,
                p.sVlParametro
            ))
            .ToListAsync(ct);

        return Ok(itens);
    }
}
