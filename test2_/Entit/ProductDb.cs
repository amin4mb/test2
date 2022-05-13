using test2.Models;
using System.Globalization;
using HW9.DataAcses;
using Microsoft.EntityFrameworkCore;

namespace test2_.Entit
{
    public partial class ProductDb
    {

        private readonly AppDbContext _dbContext;

        public ProductDb()
        {
            _dbContext = new AppDbContext();

        }
        public List<Category> GetCategori()
        {
            var x = _dbContext.categories.ToList();

            return x;

        }

        public List<User> GetUsers()
        {

            return _dbContext.users.ToList();

        }
        public User GetUsers(int id)
        {
            var x = _dbContext.products.Where(x => x.Id == id).Include(x => x.User).Select(x => new User { Id = x.User.Id, Name = x.User.Name }).FirstOrDefault();

            return x;

        }

        public uc GetUC(int id)
        {
            var x = (uc)_dbContext.products.Where(x => x.Id == id).Include(x => x.User).Include(x => x.Category).Select(x => new uc { cat = x.Category, us = x.User }).FirstOrDefault();

            return x;

        }

        public List<Product> GetProducts()
        {
            return _dbContext.products.ToList();
        }

        public void Edit(Product pro)
        {
            _dbContext.Update(pro);
            _dbContext.SaveChanges();

        }
        public bool Add(Product pro)
        {
            if (pro == null)
                return false;
            else
            {
                var x = _dbContext.users.ToList()[0];
                pro.User = x;
                _dbContext.products.Add(pro);
                _dbContext.SaveChanges();
                return true;
            }
        }

        public List<Category> cat()
        {

            List<Category> cl = new List<Category>();
            cl = (from c in _dbContext.categories select c).ToList();
            cl.Insert(0, new Category
            {
                Id = 0,
                Name = "یکی را انتخاب کنید"

            });

            return cl;

        }


      


        public Product Get(int id)
        {
            return _dbContext.products.FirstOrDefault(x => x.Id == id);
        }
        public bool Delete(int id)
        {
            var p = Get(id);
            _dbContext.products.Remove(p);
            _dbContext.SaveChanges();
            return true;
        }









        public string ToShamsiFormat(int data)
        {
            var x = data % 100;
            var y = (data / 100) % 100;
            var j = data / 10000;
            string result = j + "/" + y + "/" + x;
            return result;
        }



        public DateTime ToGregorianDate(string date)
        {
            PersianCalendar pr = new PersianCalendar();
            var dets = date.Split('/');
            var day = int.Parse(dets[2]);
            var month = int.Parse(dets[1]);
            var year = int.Parse(dets[0]);
            var data = new DateTime(year, month, day, pr);
            return data;
        }


    }
}
