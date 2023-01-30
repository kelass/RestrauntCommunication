using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using Restraunt.Core.Dto;

namespace Restraunt.WebUI.Controllers
{
    public class TableController : Controller
    {
        
        public IActionResult Create()
        {
            QRCodeGenerator qrcodeGenerator = new QRCodeGenerator();
            var qr = qrcodeGenerator.CreateQrCode("https://localhost:7165/Table/bla".ToString(),QRCodeGenerator.ECCLevel.Q);
            QRCode qrcode = new QRCode(qr);
            using (MemoryStream ms = new MemoryStream())
            {
                using(Bitmap bitmap = qrcode.GetGraphic(20))
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

        public IActionResult Menu(Guid id)
        {
            return View();
        }

    }
}
