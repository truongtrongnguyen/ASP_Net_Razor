using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Syntax_ASP_Net_Razor.Pages;

public class IndexModel : PageModel
{
    public string abc {get; set;}
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        abc = "Day la noi dung trong abc";
    }
}
