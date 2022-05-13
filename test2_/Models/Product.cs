using System.ComponentModel.DataAnnotations;

namespace test2.Models
{
    public class Product
    {

        public int Id { get; set; } 

        public string Name { get; set; }    

        public int Price { get; set; }  

        public DateTime Date { get; set; }
        [Display(Name = "دسته بندی ")]
        public int? CategoryID { get; set; }
        public Category? Category { get; set; }  

        public User? User { get; set; }  

    }



}
