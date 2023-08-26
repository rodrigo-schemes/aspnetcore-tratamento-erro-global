using Microsoft.AspNetCore.Mvc;

namespace Exemplo.API.Controllers;

[ApiController]
[Route("api/previsao")]
public class PrevisaoController : ControllerBase
{
    [HttpGet]
    public Task<IActionResult> ObterPrevisao()
    {
        var climas = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        
        var previsoes = Enumerable.Range(1, 5).Select(index =>
                new PrevisaoTempo
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    climas[Random.Shared.Next(climas.Length)]
                ))
            .ToArray();
        
        return Task.FromResult<IActionResult>(Ok(previsoes));
    }
    
    [HttpPost]
    public Task<IActionResult> GravarPrevisaoComErro()
    {
        throw new Exception("Exceção causada intencionalmente");
    }
}