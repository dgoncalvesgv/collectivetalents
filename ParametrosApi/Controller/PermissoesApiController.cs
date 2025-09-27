using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParametrosApi.Data;
using ParametrosApi.Models;

namespace ParametrosApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissoesController(ParametrosDbContext db) : ControllerBase
{
    /// <summary>
    /// Busca permissao por sDsPermissao
    /// </summary>
    /// <param name="permissao">permissao</param>
    /// <param name="ct">context</param>
    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<PermissaoDto>>> Search(
        [FromQuery] string permissao,
        CancellationToken ct = default)
    {
        var like = $"%{permissao}%";

        var query = db.Permissoes
            .AsNoTracking()
            .Where(p => p.sNmPermissao != null && EF.Functions.Like(p.sNmPermissao, like))
            .OrderBy(p => p.sNmPermissao);

        var itens = await query
            .Select(p => new PermissaoDto(
                p.nCdPermissao,
                p.sNmPermissao,
                p.sDsPermissao,
                p.sDsLocalImagem,
                p.nCdModulo
            ))
            .ToListAsync(ct);

        return Ok(itens);
    }
}
