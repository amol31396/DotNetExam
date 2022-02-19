using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductsMVC.Models
{
    public class ProductsModel
    {
        [Display(AutoGenerateField = true, Name = "Product ID")]
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Please Enter Product Name")]
        [DataType(DataType.Text)]
        public string ProductName { get; set; }

        [Display(Name = "Rate")]
        [Required(ErrorMessage = "Please Enter Product Rate")]
        [DataType(DataType.Text)]
        public decimal Rate { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please Enter Product Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Please Enter Category Name")]
        [DataType(DataType.Text)]
        public string CategoryName { get; set; }
    }
}