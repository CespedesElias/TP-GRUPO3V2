using Microsoft.AspNetCore.Mvc.Filters;
using TP_GRUPO3.Models;

namespace TP_GRUPO3.Utils
{
    public class UsuarioAction : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var usuario = context.HttpContext.Session.GetObject<Usuario>("Usuario");
            context.HttpContext.Items["Usuario"] = usuario;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // No se requiere ninguna acción después de la ejecución de la acción
        }
    }
}
