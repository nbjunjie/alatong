using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xinyi.Common
{
    public class IncludeHtml
    {
        public IncludeHtml(){}

        /// <summary>
        /// 网页头部
        /// </summary>
        public string TopHtml { get; set; }

        /// <summary>
        /// 源码头部申明
        /// </summary>
        public string HeadHtml { get; set; }

        /// <summary>
        /// 网页底部
        /// </summary>
        public string BottomHtml { get; set; }

        /// <summary>
        /// 源码底部
        /// </summary>
        public string FootHtml { get; set; }

        /// <summary>
        /// 网页左侧
        /// </summary>
        public string LeftHtml { get; set; }

        /// <summary>
        /// 包含文件1
        /// </summary>
        public string File1Html { get; set; }

        /// <summary>
        /// 包含文件2
        /// </summary>
        public string File2Html { get; set; }
    }
}
