using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demoLocalStorage1.Models;

namespace demoLocalStorage1.Controllers
{
    public class MDController : Controller
    {
        // GET: MD
        QLBHEntities data = new QLBHEntities();
        public ActionResult Index() 
        {
            return View(data.PHIEUNHAPKHOes.ToList());
        }
        // Hiển thị form tạo mới
        [Route("Create")]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.NhaCungCapList = new SelectList(data.NHACUNGCAPs, "MANCC", "TENNCC");
            ViewBag.NguyenLieuList1 = new SelectList(data.NGUYENLIEUx, "MANL", "TENNL");
            ViewBag.NguyenLieuList2 = new SelectList(data.NGUYENLIEUx, "MANL", "COST");
            return View();
        }

        // Xử lý khi submit form tạo mới
        [HttpPost]
        public ActionResult Create(PhieuNhap_ChiTietPN model, List<string> MANLs, List<int> SOLUONGs)
        {
            if (MANLs == null || SOLUONGs == null || MANLs.Count != SOLUONGs.Count)
            {
                // Xử lý trường hợp dữ liệu gửi lên không hợp lệ
                ModelState.AddModelError("", "Dữ liệu không hợp lệ.");
                ViewBag.NhaCungCapList = new SelectList(data.NHACUNGCAPs, "MANCC", "TENNCC");
                // Lấy danh sách nguyên liệu từ cơ sở dữ liệu
                var nguyenLieuList = data.NGUYENLIEUx.ToList();

                // Truyền danh sách nguyên liệu và giá vào ViewBag hoặc ViewModel
                ViewBag.NguyenLieuList1 = new SelectList(nguyenLieuList, "MANL", "TENNL");
                ViewBag.NguyenLieuList2 = new SelectList(data.NGUYENLIEUx, "MANL", "COST");
                return View(model);
            }

            // Tiếp tục xử lý khi dữ liệu hợp lệ
            // Tạo mới phiếu nhập kho
            PHIEUNHAPKHO pn = new PHIEUNHAPKHO();
            pn.MAPHIEU = model.MAPHIEU;
            pn.NGAYNHAP = model.NGAYNHAP;
            pn.MANCC = model.MANCC;
            pn.GHICHU = model.GHICHU;
            data.PHIEUNHAPKHOes.Add(pn);
            data.SaveChanges();

            // Thêm từng nguyên liệu vào chi tiết phiếu nhập
            for (int i = 0; i < MANLs.Count; i++)
            {
                CHITIETPHIEUNHAP ctpn = new CHITIETPHIEUNHAP();
                ctpn.MAPHIEU = model.MAPHIEU;
                ctpn.MANL = MANLs[i];
                ctpn.SOLUONG = SOLUONGs[i].ToString(); // Chuyển đổi SOLUONG từ int sang string để phù hợp với kiểu dữ liệu trong model
                data.CHITIETPHIEUNHAPs.Add(ctpn);
            }
            data.SaveChanges();
            return RedirectToAction("Index"); // Chuyển hướng sau khi thêm thành công
        }
        [HttpGet]
        public ActionResult Edit(string id) 
        {
            
            return View(); 
        }
      

    }
}