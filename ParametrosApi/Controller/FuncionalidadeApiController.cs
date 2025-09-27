using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParametrosApi.Data;
using ParametrosApi.Models;

namespace ParametrosApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FuncionalidadesController(ParametrosDbContext db) : ControllerBase
{
    /// <summary>
    /// Busca por "contém" em sDsFuncionalidade.
    /// </summary>
    /// <param name="funcionalidade">Texto para procurar na descrição</param>
    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<FuncionalidadeDto>>> Search(
        [FromQuery] string funcionalidade,
        CancellationToken ct = default)
    {
        var like = $"%{funcionalidade}%";

        var query = db.Funcionalidades
            .AsNoTracking()
            .Where(f => f.sDsFuncionalidade != null && EF.Functions.Like(f.sDsFuncionalidade, like))
            .OrderBy(f => f.sDsFuncionalidade);

        var itens = await query
            .Select(f => new FuncionalidadeDto(
                f.nCdFuncionalidade,
                f.bFlBloquear,
                f.bFlCritico,
                f.sDsFuncionalidade,
                f.nCdModulo
            ))
            .ToListAsync(ct);

        return Ok(itens);
    }
}
