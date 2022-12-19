using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace B76_77_Validation_HtmlForm_UploadFile.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IWebHostEnvironment _env;
        public ContactModel(IWebHostEnvironment env)
        {
            _env = env;
        }
        [BindProperty]  
        public CustomerInfo customerInfo {get; set;}

        [BindProperty]
        [DataType(DataType.Upload)]
        //[Required(ErrorMessage ="Chọn file Upload")]
        [DisplayName("File Upload")]
        // [FileExtensions(Extensions ="jpg, png, git, bmp ")]  --> Lỗi do nó chỉ thao tác đối với chuỗi
        [CheckFileExtension(Extensions = "jpg, png, git")]
        public IFormFile FileUpload {get; set;}

        // Upload nhiều file
        [BindProperty]
        [DataType(DataType.Upload)]
        //[Required(ErrorMessage ="Chọn file Upload")]
        [DisplayName("Upload Nhều file")]
        public IFormFile[] FileUploads {get; set;}

        public string thongbao {get; set;}
        public void OnGet()
        {
        }
        public void OnPost()
        {   
            // Kiểm tra xem dữ liệu gởi đến có phù hợp hay không
            if(ModelState.IsValid)
            {
                thongbao = "Dữ liệu gởi đến phù hợp";
                
                if(FileUpload != null)
                {
                    // _env.WebRootPath  -- Đường dẫn thư mục Root
                    // FileUpload.Name      -- Tên file
                    var filepath = Path.Combine(_env.WebRootPath, "uploads", FileUpload.FileName);   // tạo đường dẫn để lưu ảnh
                    using var fileStream = new FileStream(filepath, FileMode.Create);
                    FileUpload.CopyTo(fileStream);
                }


                    foreach(var i in FileUploads)
                    {
                        var filepath = Path.Combine(_env.WebRootPath, "uploads", i.FileName);
                        using var fileStream = new FileStream(filepath, FileMode.Create);
                        i.CopyTo(fileStream);
                    }
            }
            else
            {
                thongbao = "Dữ liệu gởi đến không phù hợp";
            }
        }
    }
}
