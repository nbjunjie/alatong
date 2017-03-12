using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xinyi.Common
{
    public class DataColumn
    {
        /// <summary>
        /// 头文字
        /// </summary>
        public string HeaderText
        { get; set; }

        /// <summary>
        /// 列宽
        /// </summary>
        public int HeaderWidth
        { get; set; }

        /// <summary>
        /// 对其方式
        /// </summary>
        public string Align
        { get; set; }

        /// <summary>
        /// 参数列表
        /// </summary>
        public string[] FieldNames
        { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public string FieldName
        { get; set; }

        /// <summary>
        /// 显示字段
        /// </summary>
        public string FieldFormat
        { get; set; }
    }
}
