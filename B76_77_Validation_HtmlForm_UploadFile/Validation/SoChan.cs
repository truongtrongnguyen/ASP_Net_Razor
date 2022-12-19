// xây dựng class dùng để check lỗi nhập vào phải là số chẵn
using System.ComponentModel.DataAnnotations;

public class SoChan :ValidationAttribute
{
    public SoChan(){
         ErrorMessage = "{0} phải là số chẵn";
    }

    public override bool IsValid(object obj)
    {
        if(obj == null) return false;
        int i = Int16.Parse(obj.ToString());
        return i % 2==0;
    }

}
