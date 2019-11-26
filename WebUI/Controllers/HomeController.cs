using DomainModels.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using WebUI.Models;


namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        IUnitOfWork uow;
        public HomeController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult PaymentStatus(IFormCollection form)
        {
            try
            {
                string salt = "eCwWELxi";
                string hash_seq = "key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5|udf6|udf7|udf8|udf9|udf10";
                string[] merc_hash_vars_seq;
                string merc_hash_string = string.Empty;
                string merc_hash = string.Empty;
                string order_id = string.Empty;

                if (form["status"].ToString() == "success")
                {
                    merc_hash_vars_seq = hash_seq.Split('|');
                    Array.Reverse(merc_hash_vars_seq);
                    merc_hash_string = salt + "|" + form["status"].ToString();

                    foreach (string merc_hash_var in merc_hash_vars_seq)
                    {
                        merc_hash_string += "|";
                        merc_hash_string += form[merc_hash_var].ToString() != null ? form[merc_hash_var].ToString() : "";
                    }

                    Response.WriteAsync(merc_hash_string);
                    merc_hash = Generatehash512(merc_hash_string).ToLower();

                    if (merc_hash != form["hash"])
                    {
                        ViewData["Message"] = "<br/>Hash value did not match";
                    }
                    else
                    {
                        order_id = Request.Form["txnid"];
                        ViewData["Message"] = "<br/>Status is successful.  Hash value is matched";

                        TransactionModel model = new TransactionModel();
                        model.CartId = Convert.ToInt32(form["udf1"]);
                        model.Amount = Convert.ToDecimal(form["amount"]);
                        model.PaymentType = "PayUMoney";
                        model.Status = form["status"];
                        model.Tran_Id = form["txnid"];
                        model.Name = form["firstname"];

                        model.CreatedDate = DateTime.Now;
                        model.UpdatedDate = DateTime.Now;

                        try
                        {
                            uow.OrderRepo.PlaceOrder(model);
                            uow.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            ViewData["Message"] = "Internal Error! : " + ex;
                        }

                        ReceiptModel obj = new ReceiptModel();
                        obj.Name = model.Name;
                        obj.Email = form["email"];
                        obj.TransactionId = model.Tran_Id;
                        obj.Amount = form["amount"];
                        obj.Status = form["status"];

                        ViewData["Message"] = "Your Order Status!";
                        return View(obj);
                    }
                }
                else
                {
                    ViewData["Message"] = "Hash value did not match";
                }
            }
            catch (Exception ex)
            {
                ViewData["Message"] = "<span style='color:red'>" + ex.Message + "</span>";
            }
            return View();
        }

        public string Generatehash512(string text)
        {
            //UnicodeEncoding UE = new UnicodeEncoding();
            byte[] message = Encoding.UTF8.GetBytes(text);

            //SHA512Managed hashString = new SHA512Managed();  //MVC 5
            SHA512 hashString = SHA512.Create();  //Core

            byte[] hashValue = hashString.ComputeHash(message);

            string hex = string.Empty;
            foreach (byte b in hashValue)
            {
                hex += string.Format("{0:x2}", b);
            }
            return hex;
        }

    }
}

