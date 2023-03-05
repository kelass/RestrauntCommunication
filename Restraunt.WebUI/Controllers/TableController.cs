
﻿using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using QRCoder;

using Restraunt.Core.Dto;

namespace Restraunt.WebUI.Controllers
{
    public class TableController : Controller
    {
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Create()
        {
            var access_token = await HttpContext.GetTokenAsync("access_token");
            ViewBag.access_token = access_token;
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
    
        


        public async Task<IActionResult> Tables()
        {
            var access_token = await HttpContext.GetTokenAsync("access_token");
            ViewBag.access_token = access_token;
            return View();
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var access_token = await HttpContext.GetTokenAsync("access_token");
            ViewBag.access_token = access_token;

            return View(id);

        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var access_token = await HttpContext.GetTokenAsync("access_token");
            ViewBag.access_token = access_token;
            return RedirectToAction("Tables", "Table");
        }



        [Authorize(Roles = "Waiter, Admin")]
        public async Task<IActionResult> WaiterTables()
        {
            
            var access_token = await HttpContext.GetTokenAsync("access_token");
            ViewBag.access_token = access_token;

            var user = HttpContext.User;
            var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.UserId = userId;
            
            
            return View();
        }
        
        public IActionResult Menu(Guid id) => View(id);


        public async Task<IActionResult> Basket(Guid id)
        {
            



            return View(id);
        }

        //public IActionResult Menu() => View();

    }
}
