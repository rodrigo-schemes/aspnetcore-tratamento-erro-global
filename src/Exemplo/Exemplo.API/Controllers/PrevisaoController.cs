using Microsoft.AspNetCore.Mvc;

namespace Exemplo.API.Controllers;

[ApiController]
[Route("api/previsao")]
public class PrevisaoController : ControllerBase
{
    [HttpGet]
    public Task<IActionResult> ObterPrevisao()
    {
        var condicoesClimaticas = new[]
        {
            "Nevoeiro", "Céu claro", "Sol", "Nublado", "Encoberto", "Chuvoso", "Neve", "Trovoadas", "Geada", "Garoa"
        };
        
        var previsoes = Enumerable.Range(1, 5).Select(index =>
                new PrevisaoTempo
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    condicoesClimaticas[Random.Shared.Next(condicoesClimaticas.Length)],
                    Random.Shared.Next(-20, 55)
                ))
            .ToArray();
        
        return Task.FromResult<IActionResult>(Ok(previsoes));
    }
    
    [HttpPost]
    public Task<IActionResult> AdicionarPrevisao()
    {
        throw new Exception("Exceção causada intencionalmente");
    }
}