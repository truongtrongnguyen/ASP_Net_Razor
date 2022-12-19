using Microsoft.AspNetCore.Mvc.ModelBinding;

// Tạo ra một Model Binding
// Class này có nhiệm vụ là : chuyển tên thành in hoa, không chứa kí tự XXX, cắt khoảng trắng
public class UserNameBinding : IModelBinder
{
    // Tham số bindingContext là nó chứa dữ liệu được đọc từ form gởi đến 
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if(bindingContext == null)
        {
            throw new ArgumentNullException("bindingContext");
        }
        string modelName = bindingContext.ModelName;    // Lấy tên 
        // Đọc giá trị gởi đến thông qua tên 
        var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName); 

        if(valueProviderResult == ValueProviderResult.None) // Nếu không có dữ liệu thì đánh dấu là đã hoàn thành   
        {
            return Task.CompletedTask;
        }
        string value = valueProviderResult.FirstOrDefault();    // Do dữ liệu từ form có thể nhiều nên ta phải đọc cái đầu tiên

        if(String.IsNullOrEmpty(value))
        {
            return Task.CompletedTask;
        }
        // Binding
        string s = value.ToUpper();

        if(s.Contains("XXX"))
        {
            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);    // Lấy giá trị để xuất ngược ra View
            bindingContext.ModelState.TryAddModelError(modelName, "Lỗi chứa XXX");
            return Task.CompletedTask;
        }
        s = s.Trim();
        // 
        bindingContext.ModelState.SetModelValue(modelName, s, s);
        bindingContext.Result= ModelBindingResult.Success(s);
        return Task.CompletedTask;
    }
}