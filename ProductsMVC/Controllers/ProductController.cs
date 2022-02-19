using ProductsMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            SqlConnection connection = new SqlConnection();
            List<ProductsModel> list = new List<ProductsModel>();
            try
            {
                connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductsMVCDB;Integrated Security=True";
                connection.Open();

                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = connection;
                //cmdSelect.CommandType = System.Data.CommandType.StoredProcedure;
                //cmdSelect.CommandText = "ShowProducts";
                cmdSelect.CommandType = System.Data.CommandType.Text;
                cmdSelect.CommandText = "select * from Products";

                SqlDataReader read = cmdSelect.ExecuteReader();
                while (read.Read())
                {
                    list.Add(new ProductsModel { ProductId = (int)read["ProductId"], ProductName = read["ProductName"].ToString(), Rate = (decimal)read["Rate"], Description = read["Description"].ToString(), CategoryName = read["CategoryName"].ToString() });
                }
                read.Close();
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex;
            }
            finally
            {
                connection.Close();
            }
            return View(list);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            SqlConnection connection = new SqlConnection();
            ProductsModel obj = new ProductsModel();
            try
            {
                connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductsMVCDB;Integrated Security=True";
                connection.Open();

                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = connection;
                //cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
                //cmdUpdate.CommandText = "SelectProduct";
                cmdUpdate.CommandType = System.Data.CommandType.Text;
                cmdUpdate.CommandText = "select * from Products where ProductId = @ProductId";

                cmdUpdate.Parameters.AddWithValue("@ProductId", id);

                SqlDataReader read = cmdUpdate.ExecuteReader();
               
                while (read.Read())
                {
                    obj = new ProductsModel { ProductId = (int)read["ProductId"], ProductName = read["ProductName"].ToString(), Rate = (decimal)read["Rate"], Description = read["Description"].ToString(), CategoryName = read["CategoryName"].ToString() };
                }
                read.Close();
            }
            catch
            {
                return View();
            }
            finally
            {
                connection.Close();
            }
            return View(obj);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductsModel  obj)
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductsMVCDB;Integrated Security=True";
                connection.Open();

                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = connection;
                //cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
                //cmdUpdate.CommandText = "UpdateProduct";
                cmdUpdate.CommandType = System.Data.CommandType.Text;
                cmdUpdate.CommandText = "UPDATE Products SET ProductName = @ProductName, Rate = @Rate, Description = @Description, CategoryName = @CategoryName where ProductId = @ProductId ";

                cmdUpdate.Parameters.AddWithValue("@ProductId", obj.ProductId);
                cmdUpdate.Parameters.AddWithValue("@ProductName", obj.ProductName);
                cmdUpdate.Parameters.AddWithValue("@Rate", obj.Rate);
                cmdUpdate.Parameters.AddWithValue("@Description", obj.Description);
                cmdUpdate.Parameters.AddWithValue("@CategoryName", obj.CategoryName);

                cmdUpdate.ExecuteNonQuery();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            finally
            {
                connection.Close();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ShowPartial()
        {
            return View();
        }
    }
}
