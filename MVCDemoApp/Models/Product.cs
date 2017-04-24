using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDemoApp.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required !!!")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Display(Name = "Product Category")]
        [Required(ErrorMessage = "Product category is required !!! ")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Price is required !!!")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
    public class RadioButton
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Isselected { get; set; }
    }
    public class DropDown
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}