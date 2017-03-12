using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xinyi.Common
{
    public class CustomTag
    {
        public CustomTag() { }

        /// <summary>
        /// 标签类型
        /// </summary>
        public string TagType { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        public int TypeID { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string TypeCalled { get; set; }
        /// <summary>
        /// 分类显示PID
        /// </summary>
        public int TypePID { get; set; }
        /// <summary>
        /// 是否显示子分类，默认显示
        /// </summary>
        public bool SubType { get; set; }
        /// <summary>
        /// 循环，-1表示无限循环
        /// </summary>
        public int Cycle { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsShow { get; set; }
        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool IsRecommend { get; set; }
        /// <summary>
        /// where条件语句，支持sql
        /// </summary>
        public string Where { get; set; }
        /// <summary>
        /// 排序，1（手动排序+倒序，默认）、2（手动排序+顺序）、3（倒序）、4（顺序）
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// 是否显示循环空行，默认显示1，0不显示
        /// </summary>
        public bool ShowSpace { get; set; }
        /// <summary>
        /// 输出sql条件语句
        /// </summary>
        public string OutputWhere { get; set; }
        /// <summary>
        /// 输出sql排序语句
        /// </summary>
        public string OutputOrder { get; set; }
        /// <summary>
        /// 输出循环内容
        /// </summary>
        public string OutputTag { get; set; }
        /// <summary>
        /// 原始标签
        /// </summary>
        public string OriginalTag { get; set; }
        /// <summary>
        /// 分页ID
        /// </summary>
        public int PageID { get; set; }
        /// <summary>
        /// 分页类型
        /// </summary>
        public int PageType { get; set; }
        /// <summary>
        /// 分页总数
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 第一页，文字
        /// </summary>
        public string PageNameFirst { get; set; }
        /// <summary>
        /// 上一页文字
        /// </summary>
        public string PageNamePrev { get; set; }
        /// <summary>
        /// 下一页文字
        /// </summary>
        public string PageNameNext { get; set; }
        /// <summary>
        /// 最后页文字
        /// </summary>
        public string PageNameLast { get; set; }
        /// <summary>
        /// 是否显示下拉菜单跳转
        /// </summary>
        public bool PageDropDownList { get; set; }
        /// <summary>
        /// 是否显示数字输入跳转
        /// </summary>
        public bool PageNumTextBox { get; set; }
        /// <summary>
        /// 日期列名，用“|”分割
        /// </summary>
        public string DateTimeStr { get; set; }
        /// <summary>
        /// 日期格式，用“|”分割
        /// </summary>
        public string DateTimeFormat { get; set; }
        /// <summary>
        /// 换行数字，0表示不换行
        /// </summary>
        public int RowWarp { get; set; }
        /// <summary>
        /// 换行开始标签
        /// </summary>
        public string RowWarpStart { get; set; }
        /// <summary>
        /// 换行结束标签
        /// </summary>
        public string RowWarpEnd { get; set; }
        /// <summary>
        /// 是否写入原有文件名（分页名）
        /// </summary>
        public bool WriteOldFile { get; set; }
        /// <summary>
        /// 是否新产品格式字段名，用“|”分割
        /// </summary>
        public string StringCellNames { get; set; }
        /// <summary>
        /// 是否新产品格式，用“|”分割
        /// </summary>
        public string StringFormat { get; set; }
        /// <summary>
        /// 换行替换部分字符
        /// </summary>
        public string RowWarpReplace { get; set; }
    }
}
