using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using E_CommerceApp.CustomValidations;
using System.Runtime.CompilerServices;


namespace E_CommerceApp.Models
{
    public class Order
    {
        private Random random = new Random();
        private int? orderNo;
        
        [BindNever]
        public int? OrderNo { get; set; }
        
        [MinimumYearValidator(2000-01-01)]
        public DateTime OrderDate { get; set; }
           
    }
    
}
