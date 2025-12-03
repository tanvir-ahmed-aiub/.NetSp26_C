using AutoMapper;
using PMS.DTOs;
using PMS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class RegistrationController : Controller
    {
        PMS_Fall25_CEntities db = new PMS_Fall25_CEntities();
        // GET: Registration
        public static Mapper GetMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CustomerDTO,Customer>().ReverseMap();
                
            });
            return new Mapper(config);
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View(new CustomerDTO());
        }
        [HttpPost]
        public ActionResult Index(CustomerDTO c) {
            if (ModelState.IsValid) {
                var customer = GetMapper().Map<Customer>(c);
                customer.Password = CreateMD5(customer.Password);
                db.Customers.Add(customer);
                db.SaveChanges();
            }
            return View(c);
        }

        public static string CreateMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2")); // "x2" ensures lowercase hex format
                }
                return sb.ToString();
            }
        }
    }
}