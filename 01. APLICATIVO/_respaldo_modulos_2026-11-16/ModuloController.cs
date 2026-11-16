// SIGH - Hospital General Monster Salud
// Talleres Login y CRUD MVC con ASP.NET Core y SQL Server - Grupo GR07
// Subsistema de Seguridad
using Microsoft.AspNetCore.Mvc;
using SIGH_DOTNET_GR07.Models;
using SIGH_DOTNET_GR07.Services;

namespace SIGH_DOTNET_GR07.Controllers;

/// <summary>
/// Módulos de Admisión, Clínica y Farmacia. Si el perfil tiene la opción se muestra una pantalla de
/// acceso autorizado; su funcionalidad se construye en otros talleres.
/// </summary>
public class ModuloController(MenuServicio menu) : Controller
{
    [HttpGet("/admision/{**resto}")]
    [HttpGet("/clinica/{**resto}")]
    [HttpGet("/farmacia/{**resto}")]
    public async Task<IActionResult> Index()
    {
        Opcion? opcion = await menu.OpcionRequeridaAsync(Request.Path.Value ?? "/");
        if (opcion is null)
        {
            return Redirect("~/inicio");
        }
        ViewData["Titulo"] = opcion.DescripcionOpcion;
        ViewData["Activo"] = opcion.CodigoOpcion;
        return View(opcion);
    }
}
