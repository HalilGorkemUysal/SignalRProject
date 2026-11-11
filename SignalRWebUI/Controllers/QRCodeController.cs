using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace SignalRWebUI.Controllers
{
    public class QRCodeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(
                    value, QRCodeGenerator.ECCLevel.Q))
                {
                    PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);

                    byte[] qrCodeBytes = qrCode.GetGraphic(10);

                    ViewBag.QRCodeImage = "data:image/png;base64,"
                        + Convert.ToBase64String(qrCodeBytes);
                }
            }

            return View();
        }

    }
}
