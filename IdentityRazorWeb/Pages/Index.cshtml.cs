using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorweb.models;

namespace IdentityRazorWeb.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly MyBlogContext _context;

    public IndexModel(ILogger<IndexModel> logger, MyBlogContext context)
    {
        _logger = logger;
        _context = context;
    }

    public void OnGet()
    {
        var qr = from a in _context.articles
                orderby a.Created descending
                select a;
        ViewData["post"] = qr.ToList();
    }
}
