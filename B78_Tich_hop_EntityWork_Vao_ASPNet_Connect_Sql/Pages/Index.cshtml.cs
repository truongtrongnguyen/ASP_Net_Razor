using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorweb.modles;

namespace Tich_hop_EntityWork_Vao_ASPNet_Connect_Sql.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private readonly MyBlogContext _myBlogContext;

    public IndexModel(ILogger<IndexModel> logger, MyBlogContext myBlogContext)
    {
        _logger = logger;
        _myBlogContext = myBlogContext;
    }

    public void OnGet()
    {
        var post = (from a in _myBlogContext.articles orderby a.Title select a).ToList();
        ViewData["post"] = post;
    }
}
