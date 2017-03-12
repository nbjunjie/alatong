using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using Xinyi.Common;
using System.Web;

namespace Xinyi.Common
{
    public class Thumbnail
    {
        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMessage { get; set; }

        public Thumbnail(string strUrl, string strH, string strW)
        {
            int intW = 0;
            int intH = 0;

            if (strUrl == null || strUrl == "")
            {
                ErrorMessage = "图片路径错误！";
                return;
            }
            if (strUrl.ToLower().IndexOf(".jpg") == -1)
            {
                ErrorMessage = "只支持JPG文件缩小！";
                return;
            }

            //判断参数是否数字
            if (FunctionClass.CheckStr(strW, 1))
            {
                intW = Convert.ToInt32(strW);
                if (FunctionClass.CheckStr(strH, 1))
                    intH = Convert.ToInt32(strH);
            }
            else
            {
                if (FunctionClass.CheckStr(strH, 1))
                    intH = Convert.ToInt32(strH);
                else
                {
                    //ErrorMessage = "缩小的尺寸输入不正确！";
                    return;
                }
            }

            string strPath=HttpContext.Current.Server.MapPath(strUrl);

            //判断文件是否存在
            if (!File.Exists(strPath))
            {
                ErrorMessage = "文件不存在！";
                return;
            }

            //读取图片文件路径
            Bitmap source = new Bitmap(strPath);

            //创建缩略图
            System.Drawing.Image myThumbnail = null;
            //判断正比例缩略
            if (intW > 0 && intH > 0)
                myThumbnail = CreateThumbnail(source, intW, intH, false);
            else
                myThumbnail = CreateThumbnail(source, intW, intH, true);

            //配置 JPEG 编码
            System.Drawing.Imaging.EncoderParameters encoderParams = new System.Drawing.Imaging.EncoderParameters();
            long[] quality = new long[1];
            quality[0] = 95;
            System.Drawing.Imaging.EncoderParameter encoderParam = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            encoderParams.Param[0] = encoderParam;

            System.Drawing.Imaging.ImageCodecInfo[] arrayICI = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
            System.Drawing.Imaging.ImageCodecInfo jpegICI = null;
            for (int x = 0; x < arrayICI.Length; x++)
            {
                if (arrayICI[x].FormatDescription.Equals("JPEG"))
                {
                    jpegICI = arrayICI[x];
                    break;
                }
            }
            //JPGE压缩质量配置结束

            // 显示到客户端
            //Response.ContentType = "image/jpeg";
            MemoryStream MemStream = new MemoryStream();
            myThumbnail.Save(MemStream, jpegICI, encoderParams);
            //Response.Flush();

            myThumbnail.Dispose();
            source.Dispose();
            File.WriteAllBytes(strPath, MemStream.GetBuffer());
            MemStream.Dispose();
        }

        /// <summary>
        /// 创建缩略图
        /// </summary>
        /// <param name="source">图像源</param>
        /// <param name="thumbWi">缩略宽度</param>
        /// <param name="thumbHi">缩略高度</param>
        /// <param name="maintainAspect">是否正比例缩放</param>
        /// <returns>返回缩略图</returns>
        public Bitmap CreateThumbnail(Bitmap source, int thumbWi, int thumbHi, bool maintainAspect)
        {
            // return the source image if it's smaller than the designated thumbnail
            if (source.Width < thumbWi && source.Height < thumbHi) return source;

            System.Drawing.Bitmap ret = null;
            try
            {
                int wi, hi;

                wi = thumbWi;
                hi = thumbHi;

                if (maintainAspect)
                {
                    // maintain the aspect ratio despite the thumbnail size parameters
                    //if (source.Width > source.Height)
                    if (thumbWi>0)
                    {
                        wi = thumbWi;
                        hi = (int)(source.Height * ((decimal)thumbWi / source.Width));
                    }
                    else
                    {
                        hi = thumbHi;
                        wi = (int)(source.Width * ((decimal)thumbHi / source.Height));
                    }
                }

                // original code that creates lousy thumbnails
                // System.Drawing.Image ret = source.GetThumbnailImage(wi,hi,null,IntPtr.Zero);
                ret = new Bitmap(wi, hi);
                using (Graphics g = Graphics.FromImage(ret))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.FillRectangle(Brushes.White, 0, 0, wi, hi);
                    g.DrawImage(source, 0, 0, wi, hi);
                }
            }
            catch
            {
                ret = null;
            }

            return ret;
        }
    }
}
