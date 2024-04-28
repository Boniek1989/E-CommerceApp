using E_CommerceApp.CustomValidations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace E_CommerceApp.Models
{
    public class Products
    {
        [RequiredListInt(ErrorMessage = "Product code can't be blank")]
        [ValidateProductCode(ErrorMessage = "{0} value can't be less than 1")]
        public List<int> ProductCode { get; set; } = new List<int>();

        [RequiredListDouble(ErrorMessage = "Price can't be blank")]
        [ValidateProductCode(ErrorMessage = "{0} value can't be less than 1")]
        public List<double> Price { get; set; } = new List<double>();

        [ValidateProductCode(ErrorMessage = "{0} value can't be less than 1")]
        [RequiredListInt(ErrorMessage = "Quantity can't be blank")]
        public List<int> Quantity { get; set; } = new List<int>();

        [BindNever]        
        public double ProductList { get { return Quantity.Zip(Price, (quantity, price) => quantity * price).Sum(); } }

        [RequiredDouble(ErrorMessage = "Invoice price can't be blank")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} must be higher than 0")]
        [Compare("ProductList", ErrorMessage = "{0} and {1} does not match")]
        public double InvoicePrice { get; set; }

    }
}