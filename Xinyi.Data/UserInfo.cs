using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xinyi.Data
{
    public class UserInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int ID
        {
            set;
            get;
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            set;
            get;
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord
        {
            set;
            get;
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            set;
            get;
        }

        /// <summary>
        /// 性别，0女性，1男性
        /// </summary>
        public int Sex
        {
            set;
            get;
        }

        /// <summary>
        /// 性别名称
        /// </summary>
        public string SexCalled
        {
            set;
            get;
        }

        /// <summary>
        /// 电话
        /// </summary>
        public string Tel
        {
            set;
            get;
        }

        /// <summary>
        /// 内线电话
        /// </summary>
        public string Tel1
        {
            set;
            get;
        }

        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile
        {
            set;
            get;
        }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Mail
        {
            set;
            get;
        }
        
        /// <summary>
        /// QQ号码
        /// </summary>
        public string QQ
        {
            set;
            get;
        }

        /// <summary>
        /// 学位学历
        /// </summary>
        public int Degree
        {
            set;
            get;
        }

        /// <summary>
        /// 学位学历称呼
        /// </summary>
        public string DegreeCalled
        {
            set;
            get;
        }

        /// <summary>
        /// MSN号码
        /// </summary>
        public string MSN
        {
            set;
            get;
        }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            set;
            get;
        }

        /// <summary>
        /// 学习专业
        /// </summary>
        public string Specialty
        {
            set;
            get;
        }

        /// <summary>
        /// 进公司时间
        /// </summary>
        public string Enter_Date
        {
            set;
            get;
        }

        /// <summary>
        /// 离开公司时间
        /// </summary>
        public string Leave_Date
        {
            set;
            get;
        }

        /// <summary>
        /// 生日
        /// </summary>
        public string Birth_Date
        {
            set;
            get;
        }

        /// <summary>
        /// 所属区域，对应区域表
        /// </summary>
        public int Local_Company
        {
            set;
            get;
        }

        /// <summary>
        /// 所属区域，对应区域表
        /// </summary>
        public string Local_CompanyCalled
        {
            set;
            get;
        }

        /// <summary>
        /// 区域权限
        /// </summary>
        public string AreaRole
        {
            set;
            get;
        }

        /// <summary>
        /// 用户权限
        /// </summary>
        public string UserRole
        {
            set;
            get;
        }

        /// <summary>
        /// 用户职位；角色
        /// </summary>
        public string UserRoleCalled
        {
            set;
            get;
        }

        /// <summary>
        /// 上级领导ID
        /// </summary>
        public int UpperID
        {
            set;
            get;
        }

        /// <summary>
        /// 上级领导姓名
        /// </summary>
        public string UpperName
        {
            set;
            get;
        }

        /// <summary>
        /// 团队名称
        /// </summary>
        public string GroupName
        {
            set;
            get;
        }

        /// <summary>
        /// 是否锁定
        /// </summary>
        public int isLock
        {
            set;
            get;
        }

        /// <summary>
        /// 是否锁定
        /// </summary>
        public string isLockCalled
        {
            set;
            get;
        }

        /// <summary>
        /// 录入时间
        /// </summary>
        public string NoteTime
        {
            set;
            get;
        }

        /// <summary>
        /// 照片地址
        /// </summary>
        public string Pic
        {
            set;
            get;
        }

        /// <summary>
        /// 自我介绍
        /// </summary>
        public string Intro
        {
            set;
            get;
        }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IdentityCard
        {
            set;
            get;
        }

        /// <summary>
        /// 学校
        /// </summary>
        public string School
        {
            set;
            get;
        }

        /// <summary>
        /// 所属部门
        /// </summary>
        public string Department
        {
            set;
            get;
        }

        /// <summary>
        /// 籍贯
        /// </summary>
        public string NativePlace
        {
            set;
            get;
        }

        /// <summary>
        /// 备注信息
        /// </summary>
        public string Memo
        {
            set;
            get;
        }
    }
}
