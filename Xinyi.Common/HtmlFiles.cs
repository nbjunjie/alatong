using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Collections;

namespace Xinyi.Common
{
    public class HtmlFiles
    {
        public HtmlFiles() { }

        /// <summary>
        /// 读取模版文件html代码
        /// </summary>
        /// <param name="strFileName">文件名</param>
        /// <returns>返回html代码</returns>
        public static string ReadTemplateFile(string strFileName)
        {
            string strResult = "";

            Encoding code = Encoding.GetEncoding("utf-8");
            // 读取模板文件 
            string temp = HttpContext.Current.Server.MapPath(strFileName);

            //判断文件是否存在
            if (File.Exists(temp))
            {
                StreamReader sr = null;
                try
                {
                    sr = new StreamReader(temp, code);
                    strResult = sr.ReadToEnd(); // 读取文件 
                }
                catch (Exception exp)
                {
                    HttpContext.Current.Response.Write(exp.Message);
                    HttpContext.Current.Response.End();
                }
                finally
                {
                    sr.Close();
                    sr.Dispose();
                }
            }

            return strResult;
        }

        /// <summary>
        /// 读取目录下所有html文件名称
        /// </summary>
        /// <param name="strPath">目录路径（相对路径）</param>
        /// <returns>文件名称数组</returns>
        public static ArrayList ReadTemplateFileNames(string strPath)
        {
            ArrayList arlFiles = new ArrayList();

            string path = HttpContext.Current.Server.MapPath(strPath);

            DirectoryInfo myDr = new DirectoryInfo(path);
            FileInfo[] myFI = myDr.GetFiles();//获取本目录下所有文件
            foreach (FileInfo myFile in myFI)
            {
                //判断是否需要写入数据的文件
                if (myFile.Name.IndexOf(".htm") > -1 || myFile.Name.IndexOf(".xml") > -1)
                {
                    arlFiles.Add(myFile.Name);
                }
                else//不需要写入数据的文件直接复制
                {
                    CopyFiles(myFile.FullName, strPath);
                }
            }

            return arlFiles;
        }

        /// <summary>
        /// 读取目录下所有html文件名称（递归获取子目录）
        /// </summary>
        /// <param name="strPath">目录路径（相对路径）</param>
        /// <param name="strSubDirName">子目录名称</param>
        /// <returns>文件名称数组</returns>
        public static ArrayList ReadTemplateFileNames(string strPath, string strSubDirName)
        {
            ArrayList arlFiles = new ArrayList();

            string path = HttpContext.Current.Server.MapPath(strPath + strSubDirName + "/");

            DirectoryInfo myDr = new DirectoryInfo(path);
            FileInfo[] myFI = myDr.GetFiles();//获取本目录下所有文件
            foreach (FileInfo myFile in myFI)
            {
                //判断是否需要写入数据的文件
                if (myFile.Name.IndexOf(".htm") > -1 || myFile.Name.IndexOf(".xml") > -1)
                {
                    if (strSubDirName == "")
                        arlFiles.Add(myFile.Name);
                    else
                        arlFiles.Add(strSubDirName + "/" + myFile.Name);
                }
                else//不需要写入数据的文件直接复制
                {
                    CopyFiles(myFile.FullName, strPath);
                }
            }

            DirectoryInfo[] myDI = myDr.GetDirectories();//获取本目录下子文件夹
            foreach (DirectoryInfo myDir in myDI)
            {
                if (strSubDirName == "")
                    arlFiles.AddRange(ReadTemplateFileNames(strPath, myDir.Name));
                else
                    arlFiles.AddRange(ReadTemplateFileNames(strPath, strSubDirName + "/" + myDir.Name));
            }

            return arlFiles;
        }

        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="strFileName">文件名（带物理路径）</param>
        /// <param name="strDirName">模板文件夹名称</param>
        /// <returns>是否成功复制</returns>
        public static bool CopyFiles(string strFileName,string strDirName)
        {
            bool boolResult = false;

            strDirName=strDirName.Replace("./","");
            strDirName=strDirName.Replace("/","");

            string strDisFileName = strFileName.Replace("\\" + strDirName + "\\", "\\");//获取目标全路径，带文件名
            string strDirPath = strDisFileName.Replace(Path.GetFileName(strDisFileName), "");//获取路径

            //判断是否有目录存在，没有则新建
            if (!Directory.Exists(strDirPath))
                Directory.CreateDirectory(strDirPath);

            try
            {
                File.Copy(strFileName, strDisFileName, true);
                boolResult = true;
            }
            catch
            {
                boolResult = false;
            }

            return boolResult;
        }

        /// <summary>
        /// 替换html中的标签内容
        /// </summary>
        /// <param name="strHTML">HTML代码</param>
        /// <param name="strTag">标签名</param>
        /// <param name="strTagContent">要替换内容</param>
        /// <returns>替换后结果</returns>
        public static string ReplaceContent(string strHTML,string strTag,string strTagContent)
        {
            string strResult;

            strResult = strHTML.Replace(strTag, strTagContent);

            return strResult;
        }

        /// <summary>
        /// 写入生成html文件
        /// </summary>
        /// <param name="strFileName">文件名</param>
        /// <param name="strHTML">html代码</param>
        /// <returns>是否成功</returns>
        public static bool WriteHtmlFile(string strFileName, string strHTML)
        {
            bool isSuccess = false;

            string path = HttpContext.Current.Server.MapPath("./"+strFileName);
            Encoding code = Encoding.GetEncoding("utf-8");

            string strDirPath = path.Replace(Path.GetFileName(path), "");//获取路径
            //判断是否有目录存在，没有则新建
            if (!Directory.Exists(strDirPath))
                Directory.CreateDirectory(strDirPath);

            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(path , false, code);
                sw.Write(strHTML);
                sw.Flush();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                isSuccess = false;
                HttpContext.Current.Response.Write(ex.Message);
                HttpContext.Current.Response.End();
            }
            finally
            {
                sw.Close();
                sw.Dispose();
            }

            return isSuccess;
        }

        /// <summary>
        /// 删除所有html文件
        /// </summary>
        /// <param name="strPath">文件路径</param>
        public static void DelAllHtmlFiles(string strPath)
        {
            string path = HttpContext.Current.Server.MapPath(strPath);

            DirectoryInfo myDr = new DirectoryInfo(path);
            FileInfo[] myFI = myDr.GetFiles();
            foreach (FileInfo myFile in myFI)
            {
                if (myFile.Name.IndexOf(".htm") > -1)
                {
                    myFile.Delete();
                }
            }
        }

    }
}
