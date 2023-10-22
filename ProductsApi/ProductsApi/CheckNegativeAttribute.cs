using System.ComponentModel.DataAnnotations;

namespace ProductsApi
{
    public class CheckNegativeAttribute : ValidationAttribute
    {
        public CheckNegativeAttribute()
        {

        }

        public override bool IsValid(object? value)
        {
            if ((decimal)value < 0)
                return false;
            return true;
        }
    }
}
