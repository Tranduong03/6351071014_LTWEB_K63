using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_LTWeb_K63.Models;

namespace Lab_LTWeb_K63.Controllers
{
    public class HomeController : Controller
    {
        QLBANSACHEntities1 data = new QLBANSACHEntities1();
        private List<SACH> LaySachMoi(int count)
        {
            return data.SACHes.OrderByDescending(a => a.Ngaycapnhat)
                .Take(count).ToList();
        }

        // GET: Home
        public ActionResult Index()
        {
            var sachmoi = LaySachMoi(5);
            return View(sachmoi);
        }

        public ActionResult ChuDe()
        {
            var chude = from cd in data.CHUDEs select cd;
            return PartialView(chude);
        }
        public ActionResult Nhaxuatban()
        {
            var chude = from cd in data.NHAXUATBANs select cd;
            return PartialView(chude);
        }

        public ActionResult Details(int id)
        {
            var sach = from s in data.SACHes
                       where s.Masach == id
                       select s;
            return View(sach.Single());
        }

        public ActionResult SPTheochude(int id)
        {
            var sach = from s in data.SACHes where s.MaCD == id select s;
            return View(sach);
        }

        public ActionResult SPTheoNXB(int id)
        {
            var sach = from s in data.SACHes where s.MaNXB == id select s;
            return View(sach);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}