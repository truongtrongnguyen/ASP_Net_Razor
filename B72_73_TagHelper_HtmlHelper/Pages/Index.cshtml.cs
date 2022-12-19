using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace B72_73_TagHelper_HtmlHelper.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [DisplayName("Ten nguoi dung")]
    public string UserName {get; set;} = "Trương Trọng Nguyễn";

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
