using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class StudentInfo
    {
        /// <summary>
        /// 学号
        /// </summary>
        public string ID { set; get; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { set; get; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { set; get; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { set; get; }
    }
}
