using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(string role="user")
        {
            IEnumerable<mvcProductModal> prodList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products").Result;
            prodList = response.Content.ReadAsAsync<IEnumerable<mvcProductModal>>().Result;
            ViewBag.role = role;
            return View(prodList);
            
        }

        public PartialViewResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return PartialView("~/Views/Product/AddProduct.cshtml", new mvcProductModal());
            
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products/" + id.ToString()).Result;
                //return PartialView("~/Views/Product/AddProduct.cshtml.cshtml", new mvcProductModal());
                return PartialView("~/Views/Product/AddProduct.cshtml", response.Content.ReadAsAsync<mvcProductModal>().Result);
            }
        }

      

        [HttpPost]
        public ActionResult AddOrEdit(mvcProductModal prd)
        {
            if (prd.ID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Products", prd).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Products/" + prd.ID, prd).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Products/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }


    }
}