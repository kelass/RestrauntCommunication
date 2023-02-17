
﻿using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

using Restraunt.Core.Dto;

namespace Restraunt.WebUI.Controllers
{
    public class TableController : Controller
    {
        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult QrLink(Guid Id)
        {
            QRCodeGenerator qrcodeGenerator = new QRCodeGenerator();
            var qr = qrcodeGenerator.CreateQrCode("https://localhost:45591/Table/Menu/" + Id.ToString(), QRCodeGenerator.ECCLevel.Q);
            QRCode qrcode = new QRCode(qr);
            using (MemoryStream ms = new MemoryStream())
            {
                using (Bitmap bitmap = qrcode.GetGraphic(20))
                {
                    bitmap.Save(ms, ImageFormat.Jpeg);
                    ViewBag.QR = "data:image/jpeg;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }
    
        


        public IActionResult Tables()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Guid id)
        {
            return View();
        }
        public IActionResult Delete(Guid id)
        {
            return RedirectToAction("Tables", "Table");
        }
        [Authorize(Roles = "Waiter, Admin")]
        public IActionResult WaiterTables()
        {
            return View();
        }
        
        public IActionResult Menu(Guid id) => View();
        //public IActionResult Menu() => View();

    }
}
