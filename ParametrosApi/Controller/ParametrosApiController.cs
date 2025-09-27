using Microsoft.AspNetCore.Mvc;

namespace ParametrosApi.Controllers;

public sealed class Parametro
{
    public int nCdParametro { get; init; }
    public int nIdAplicacao { get; init; }
    public string sVlParametro { get; init; } = "";
    public string sDsParametro { get; init; } = "";
    public string sNmParametro { get; init; } = "";
}

[ApiController]
[Route("api/[controller]")]
public class ParametrosController : ControllerBase
{
    private static readonly List<Parametro> _parametros = new()
    {
    new() { nCdParametro = -300, nIdAplicacao = 0, sNmParametro = "TrustedDataSources",
            sVlParametro = "<?xml version=\"1.0\" encoding=\"utf-16\"?><DataModelList ...>",
            sDsParametro = "Contém a configuração dos modelos de dados reconhecidos pelo sistema." },

    new() { nCdParametro = -100, nIdAplicacao = 0, sNmParametro = "Infra.Menu",
            sVlParametro = "4DA34428E89B91D1E72FA87E1EC023F1F1D20675",
            sDsParametro = "Menu padrão do produto" },

    new() { nCdParametro = 100, nIdAplicacao = 0, sNmParametro = "max_items_page",
            sVlParametro = "40",
            sDsParametro = "Quantidade de itens por página (para efeito de paginação)" },

    new() { nCdParametro = 200, nIdAplicacao = 0, sNmParametro = "enable_audit",
            sVlParametro = "1",
            sDsParametro = "Indica se a auditoria está habilitada" },

    new() { nCdParametro = 300, nIdAplicacao = 0, sNmParametro = "nQtTentativaLogin",
            sVlParametro = "5",
            sDsParametro = "Número máximo de tentativas de logon quando senha incorreta" },

    new() { nCdParametro = 400, nIdAplicacao = 0, sNmParametro = "hash_type",
            sVlParametro = "MD5",
            sDsParametro = "Algoritimo utilizado para gravar hash da senha" },

    new() { nCdParametro = 500, nIdAplicacao = 0, sNmParametro = "sNmServidorSmtp",
            sVlParametro = "smtp.office365.com",
            sDsParametro = "Servidor de email" },

    new() { nCdParametro = 600, nIdAplicacao = 0, sNmParametro = "sNmSite",
            sVlParametro = "https://localhost:44317/etrm-dev",
            sDsParametro = "Endereço do Portal" },

    new() { nCdParametro = 700, nIdAplicacao = 0, sNmParametro = "sDsFormataValor",
            sVlParametro = "#,###,##0.00",
            sDsParametro = "Formatação para valor." },

    new() { nCdParametro = 800, nIdAplicacao = 0, sNmParametro = "sDsFormataQuantidade",
            sVlParametro = "#,###,##0.000",
            sDsParametro = "Formatação para quantidade." },

    new() { nCdParametro = 900, nIdAplicacao = 0, sNmParametro = "nQtDiasValidadeSenha",
            sVlParametro = "60",
            sDsParametro = "Número de dias em que a senha dos usuários expira. Em caso do número 0 (zero), senha nunca expira." },

    new() { nCdParametro = 1000, nIdAplicacao = 0, sNmParametro = "nNrMinimoSenha",
            sVlParametro = "8",
            sDsParametro = "Número mínimo de caracteres para senha do usuário." },

    new() { nCdParametro = 1100, nIdAplicacao = 0, sNmParametro = "nCdIndiceDolarItaipu",
            sVlParametro = "19",
            sDsParametro = "Texto do relatório de negócios fechados na bolsa ." },

    new() { nCdParametro = 1200, nIdAplicacao = 0, sNmParametro = "sDsEmailPortal",
            sVlParametro = "wbc@paradigmabs.com.br",
            sDsParametro = "Endereço de e-mail do Portal" },

    new() { nCdParametro = 1300, nIdAplicacao = 0, sNmParametro = "sCaminhoUpload",
            sVlParametro = "\\upload\\",
            sDsParametro = "Caminho do diretório de upload" },

    new() { nCdParametro = 1500, nIdAplicacao = 0, sNmParametro = "sFlDesativarEMAIL",
            sVlParametro = "DESATIVAR_EMAIL",
            sDsParametro = "Para desativar o envio de email em funcionalidades como a minuta. Para..." },

    new() { nCdParametro = 1700, nIdAplicacao = 0, sNmParametro = "sNmProxyURL",
            sVlParametro = "http://pta0004:8080",
            sDsParametro = "URL completa do proxy" },

    new() { nCdParametro = 1800, nIdAplicacao = 0, sNmParametro = "sNmProxyUsuario",
            sVlParametro = "PARADIGMA\\pedroFAKE",
            sDsParametro = "Usuário do proxy" },

    new() { nCdParametro = 1900, nIdAplicacao = 0, sNmParametro = "sNmProxySenha",
            sVlParametro = "SENHA",
            sDsParametro = "Senha do usuário do proxy" },

    new() { nCdParametro = 2000, nIdAplicacao = 0, sNmParametro = "sDsTituloPagina",
            sVlParametro = "QA - WBC Energy",
            sDsParametro = "Descrição do título do portal" },
    };


    // GET api/parametros?snmparametro=API_TIMEOUT
    [HttpGet]
    public ActionResult<IEnumerable<Parametro>> Get([FromQuery] string? sNmParametro)
    {
        var query = _parametros.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(sNmParametro))
            query = query.Where(p => string.Equals(p.sNmParametro, sNmParametro, StringComparison.OrdinalIgnoreCase));

        return Ok(query);
    }

    // GET api/parametros/search?q=jwt
    [HttpGet("search")]
    public ActionResult<IEnumerable<Parametro>> Search([FromQuery] string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            return BadRequest(new { message = "Parâmetro de busca 'q' é obrigatório." });

        var comp = StringComparison.OrdinalIgnoreCase;
        var hits = _parametros.Where(p => p.sNmParametro.Contains(valor, comp));
        return Ok(hits);
    }
}
