using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XTL;

namespace B70_71_PartialView_ViewComponent.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }


// Nó có thể trả về trực tiếp thông qua kiểu IActionresult
    // public IActionResult OnGet()
    // {
    //     // PageModel: Partial , ViewComponent
    //     // Controller: PartialView, ViewComponent

    //     //return Partial("_Message");
    //    // return ViewComponent("ProductBox", false);
    // }



    public IActionResult OnPost()
{
    var message = new MessagePage.Message();
    message.title = "Thông báo";
    message.htmlcontent = "Cảm ơn bạn đã gởi thông tin";
    message.secondwait = 5;
    message.urlredirect = Url.Page("Privacy");
    
    return ViewComponent("MessagePage", message);
}
}

