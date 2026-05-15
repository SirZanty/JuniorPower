using Microsoft.AspNetCore.Mvc;

namespace JuniorPower.Features.Resources;

public class ResourcesController : Controller
{
    public IActionResult AiGuide() => View();
    public IActionResult Architecture() => View();
}
