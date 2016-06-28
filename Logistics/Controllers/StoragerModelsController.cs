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
        // GET: Users/Complaint
        public ActionResult Stocking()
        {
            return View();
        }

        // POST: Users/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Stocking([Bind(Include = "PackNo")] Storage sto)
        {
            if (ModelState.IsValid)
            {
                DateTime date=System .DateTime .Now ;
                //创建仓储信息单
                sto.Storage1 = (int)Session["Account"];
                sto.StorageTime = date;
                sto.StorageType = 0;
                db.Storage.Add(sto);
                db.SaveChanges();

                //更改库存信息
                Stock stock=db.Stock .Find (sto.PackNo );
                if (stock != null)
                {
                    stock.StockStatus = 1;
                    db.SaveChanges();
                }
                else
                {
                    stock.PackNo = (int)sto.PackNo;
                    stock.Storage = (int)Session["Account"];
                    stock.StockTime = date;
                    stock.StockStatus = 1;
                    db.Stock.Add(stock);
                    db.SaveChanges();

                }

                //更改流程单信息
                Process pro = db.Process.Find(sto.PackNo);
                if (pro != null)
                {
                    Storage  storage =(Storage ) from b in db.Storage
                                      where b.PackNo == sto.PackNo && b.StorageTime==date
                                      select b;
                    pro.StorageNo = storage.StorageNo;
                    pro.Storage = (String)Session["UserName"];
                    pro.StorageTime = date;
                    pro.Location =(String)Session["UserName"];
                    pro.UpdateTime =date;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View(sto);
        }



        //查询库存、出库
        // GET: Users/Complaint
        public ActionResult StockInfo()
        {
            var stock = from b in db.Stock
                          where b.StockStatus == 1
                          select b;
            return View(stock .ToList());
        }

        // POST: Users/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult StockInfo(int? id)
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
            if (pro != null)
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