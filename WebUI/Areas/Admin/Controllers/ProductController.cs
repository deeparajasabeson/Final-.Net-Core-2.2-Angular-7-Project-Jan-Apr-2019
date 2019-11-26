using DomainModels.Entities;
using DomainModels.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.IO;

namespace WebUI.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        IHostingEnvironment env;
        public ProductController(IUnitOfWork _uow, IHostingEnvironment _env) : base(_uow)
        {
            env = _env;
        }

        void BindCategory()
        {
            ViewBag.CategoryList = uow.CategoryRepo.GetAll();
        }
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View(uow.ProductRepo.GetAll());
        }

        public ActionResult Create()
        {
            BindCategory();
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(ProductModel model)
        {
            try
            {
                string uploads = Path.Combine(env.WebRootPath, "Uploads");

                bool exists = Directory.Exists(uploads);
                if (!exists)
                {
                    Directory.CreateDirectory(uploads);
                }

                //saving file
                string fileName = Path.GetFileName(model.file.FileName);
                FileStream fileStream = new FileStream(Path.Combine(uploads, model.file.FileName), FileMode.Create);
                model.file.CopyToAsync(fileStream);

                model.ImageName = fileName;
                model.ImagePath = "/Uploads/" + fileName;

                Product data = new Product
                {
                    ProductId = model.ProductId,
                    Name = model.Name,
                    UnitPrice = model.UnitPrice,
                    CategoryId = model.CategoryId,
                    Description = model.Description,
                    ImagePath = model.ImagePath,
                    ImageName = model.ImageName
                };

                uow.ProductRepo.Add(data);
                uow.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

            }
            BindCategory();
            return View();
        }

        public ActionResult Edit(int id)
        {
            BindCategory();
            Product data = uow.ProductRepo.GetById(id);
            ProductModel model = new ProductModel();
            if (data != null)
            {
                model.ProductId = data.ProductId;
                model.Name = data.Name;
                model.UnitPrice = data.UnitPrice;
                model.CategoryId = data.CategoryId;
                model.Description = data.Description;
                model.ImagePath = data.ImagePath;
            }
            return View(model);
        }

        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public ActionResult Edit(ProductModel model)
        //{
        //    try
        //    {
        //        if (model.file != null)
        //        {
        //            //deleting previous one
        //            var filePath = IServer.MapPath(model.ImagePath);
        //            if (System.IO.File.Exists(filePath))
        //            {
        //                System.IO.File.Delete(filePath);
        //            }

        //            //uploading new one
        //            var fileName = Path.GetFileName(model.file.FileName);
        //            var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
        //            model.file.SaveAs(path);

        //            model.ImageName = fileName;
        //            model.ImagePath = "/Uploads/" + fileName;
        //        }
        //        Product data = new Product();
        //        data.ProductId = model.ProductId;
        //        data.Name = model.Name;
        //        data.UnitPrice = model.UnitPrice;
        //        data.CategoryId = model.CategoryId;
        //        data.Description = model.Description;
        //        data.ImagePath = model.ImagePath;
        //        if (model.ImageName != null)
        //            data.ImageName = model.ImageName;

        //        uow.ProductRepo.Modify(data);
        //        uow.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    BindCategory();
        //    return View();
        //}

        //public ActionResult Delete(int id, string file)
        //{
        //    uow.ProductRepo.DeleteById(id);
        //    var filePath = Server.MapPath(file);
        //    if (System.IO.File.Exists(filePath))
        //    {
        //        System.IO.File.Delete(filePath);
        //    }

        //    uow.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}