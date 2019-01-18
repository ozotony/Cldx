using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for WaterMarks
    /// </summary>
    public class WaterMarks : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            byte[] myPic = null;
string id = "Test"; 
myPic = createImg(id, 22, 20, 300, 180);
context.Response.ContentType = "image/png";
context.Response.OutputStream.Write(myPic, 0, myPic.Length);
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


  private byte[] createImg(string strWaterMark, float f1, float f2, int w, int h)
{
Bitmap newBitmap = null;
Graphics g = null;
MemoryStream ms = new MemoryStream();
try
{
Font fontCounter = new Font("Lucida Sans Unicode", f1);
Font fontCounter2 = new Font("Lucida Sans Unicode", f2);
// calculate size of the string.
newBitmap = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
g = Graphics.FromImage(newBitmap);
SizeF stringSize = g.MeasureString(strWaterMark, fontCounter);
int nWidth = (int)stringSize.Width;
int nHeight = (int)stringSize.Height;
g.Dispose();
newBitmap.Dispose();
newBitmap = new Bitmap(w, h, PixelFormat.Format32bppArgb);
g = Graphics.FromImage(newBitmap);
g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, w, h));
g.RotateTransform(23.0F);
g.DrawString("Confidential", fontCounter2, new SolidBrush(Color.Black), 40, 0 - 20);
g.DrawString("Printed by " + strWaterMark, fontCounter, new SolidBrush(Color.Black), 40, nHeight * 0.5f - 20);
g.DrawString(DateTime.Now.ToString("yyyy-MM-dd HH:mm"), fontCounter2, new SolidBrush(Color.Black), 40, nHeight * 1.2f - 20);
newBitmap.Save(ms, ImageFormat.Png);
}
catch (Exception e) {}
finally
{
if (null != g) g.Dispose();
if (null != newBitmap) newBitmap.Dispose();
}
return ms.ToArray();
}
}
    }
