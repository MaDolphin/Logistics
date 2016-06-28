using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Logistics.Models;

namespace Logistics.Controllers
{
    public class StoragerModelsController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: StoragerModels
        public ActionResult Index()
        {
            return View();
        }


        //入库
        // GET: Storage/Stocking
        public ActionResult Stocking()
        {
            return View();
        }

        // POST: Storage/Stocking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Stocking([Bind(Include = "PackNo")] Storage sto)
        {
            if (ModelState.IsValid)
            {
                int packno = (int)sto.PackNo;
                var check = db.Stock.Find(packno);
                if (check != null)
                {
                    if (check.StockStatus == 1 && check.Storage == 1)
                        return Content("<script >alert('货物已在库，不能重复输入！');history.go(-1)</script >", "text/html");
                }
                    DateTime date = System.DateTime.Now;
                    //创建仓储信息单
                    sto.Storage1 = (int)Session["Account"];
                    sto.StorageTime = date;
                    sto.StorageType = 0;
                    db.Storage.Add(sto);
                    db.SaveChanges();

                    //更改库存信息
                    Stock stock = db.Stock.Find(sto.PackNo);
                    if (stock != null)
                    {
                        stock.StockStatus = 1;
                        db.SaveChanges();
                    }
                    else
                    {
                        Stock stock1 = new Stock();
                        stock1.PackNo = packno;
                        stock1.Storage = (int)Session["Account"];
                        stock1.StockTime = date;
                        stock1.StockStatus = 1;
                        db.Stock.Add(stock1);
                        db.SaveChanges();

                    }

                    //更改流程单信息
                    Process pro = db.Process.Find(packno);
                    if (pro != null && pro.Status == 0)
                    {
                        Storage storage = (Storage)from b in db.Storage
                                                   where b.PackNo == sto.PackNo && b.StorageTime == date
                                                   select b;
                        pro.StorageNo = storage.StorageNo;
                        pro.Storage = (String)Session["UserName"];
                        pro.StorageTime = date;
                        pro.Location = (String)Session["UserName"];
                        pro.UpdateTime = date;
                        db.SaveChanges();
                    }

                    return RedirectToAction("StockInfo");
                }
              
            

            return View(sto);
        }



        //查询库存、出库
        // GET: Storage/StockInfo
        public ActionResult StockInfo()
        {
            var stock = from b in db.Stock
                          where b.StockStatus == 1 && b.Storage==1
                          select b;
            return View(stock.ToList());
        }

        // POST: Storage/StockInfo
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Outbound(int? id)
        {
            DateTime date = System.DateTime.Now;
            //创建仓储信息单
            Storage sto = new Storage();
            sto.PackNo = id;
            sto.Storage1 = (int)Session["Account"];
            sto.StorageTime = date;
            sto.StorageType = 1;
            db.Storage.Add(sto);
            db.SaveChanges();

            //更改库存信息
            Stock stock = db.Stock.Find(id);
            stock.StockTime = date;
            stock.StockStatus = 0;
            db.SaveChanges();

            //更改流程单信息
            Process pro = db.Process.Find(sto.PackNo);
            if (pro != null&& pro.Status ==0)
            {
                Storage storage = (Storage)from b in db.Storage
                                           where b.PackNo == sto.PackNo && b.StorageTime == date
                                           select b;
                pro.OutboundNo  = storage.StorageNo;
                pro.OutboundStorage  = (String)Session["UserName"];
                pro.OutboundTime = date;
                pro.Location = (String)Session["UserName"];
                pro.UpdateTime = date;
                db.SaveChanges();
            }

            return RedirectToAction("StockInfo");
        }

    }
}