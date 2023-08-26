using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Exemplo.API.Middleware;

public class TratamentoErroGlobal : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception)
        {
            var detalheErro = new ProblemDetails
            {
                Status = (int) HttpStatusCode.InternalServerError,
                Type = "Erro",
                Title = "Erro no servidor",
                Detail = "Ocorreu um erro interno."
            };

            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(detalheErro);
        }
    }
}