using System.ComponentModel.DataAnnotations;

namespace test2.Models
{
    public class User
    {

        [Display(Name = "شناسه ")]

        public int Id{ get; set; }
        [Display(Name = "نام ")]

        public string Name{ get; set; }
        [Display(Name = "نام خانوادگی ")]

        public string Family {get; set; }
        [Display(Name = "تاریخ تولد ")]

        public DateTime BrithDate { get; set; }
        [Display(Name = "ایمیل ")]

        public string Email{ get; set; }
        [Display(Name = "شماره تلفن ")]

        public string PhoneNumber { get; set; }


        [Display(Name = " محصولات ثبت شده")]

        public ICollection<Product> products { get; set; }


    }
}
