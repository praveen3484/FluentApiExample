using FluentApi4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FluentApi4.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
    


        #region <==Trial Get JSON==>
        public JsonResult GetCustomers(string sidx, string sort, int page, int rows)
        {
            MCustomerContext context = new MCustomerContext();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            //var StudentList = context.MCustomers.Select(
            //        t => new
            //        {
            //            t.CustomerId,
            //            t.CustomerName
            //        });


            var customer = context.MCustomers.ToList();
            var order = context.MOrders.ToList();
            var product = context.MProducts.ToList();

            var viewModel = new CustomerViewModel
            {
                customers = new MCustomer(),
                orders = order,
                products = product
            };



            var innerJoinQuery =
                from category in categories
                join prod in products on category.ID equals prod.CategoryID
                select new { ProductName = prod.Name, Category = category.Name }; //produces flat sequence







            int totalRecords = StudentList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                StudentList = StudentList.OrderByDescending(t => t.CustomerName);
                StudentList = StudentList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                StudentList = StudentList.OrderBy(t => t.CustomerName);
                StudentList = StudentList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = StudentList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        #endregion




    }
}