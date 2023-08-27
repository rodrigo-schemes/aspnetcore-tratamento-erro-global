namespace Exemplo.API;

public record PrevisaoTempo(DateOnly Data, string? Condicao, int Celcius)
{
    public int Fahrenheit => 32 + (int)(Celcius / 0.5556);
}