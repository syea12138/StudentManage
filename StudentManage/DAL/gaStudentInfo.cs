using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Tool;
using System.Data;


namespace StudentManage.DAL
{
    class gaStudentInfo
    {
        /// <summary>
        /// 增加学生信息
        /// </summary>
        /// <param name="_StudentInfo"></param>
        /// <returns></returns>
        public static bool InsertStudent(StudentInfo _StudentInfo)
        {
            try
            {
                string sql = string.Format("insert into StudentInfo(ID,Name,Age,Sex,Address) values(@ID,@Name,@Age,@Sex,@Address)");
                if (DapperHelper.Execute<StudentInfo>(_StudentInfo, "Local", sql) > 0)
                   return true;
               else
                   return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("=======>插入信息错误" + ex);
                return false;
            }
        }

        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <param name="_StudentInfo"></param>
        /// <returns></returns>
        public static bool DeleteStudent(StudentInfo _StudentInfo)
        {
            try
            {
                string sql = string.Format("delete from StudentInfo where ID=@ID");
                if (DapperHelper.Execute<StudentInfo>(_StudentInfo, "Local", sql) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("=======>插入信息错误" + ex);
                return false;
            }
        }


        /// <summary>
        /// 更新学生信息
        /// </summary>
        /// <param name="_StudentInfo"></param>
        /// <returns></returns>
        public static bool UpdateStudent(StudentInfo _StudentInfo)
        {
            try
            {
                string sql = string.Format("update StudentInfo set Name=@Name,Age=@Age,Sex=@Sex,Address=@Address where ID=@ID");
                if (DapperHelper.Execute<StudentInfo>(_StudentInfo, "Local", sql) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("=======>插入信息错误" + ex);
                return false;
            }
        }

        public static StudentInfo GetStudentInfoByID(StudentInfo _StudentInfo)
        {
            try
            {
                string sql = "select * from StudentInfo where ID=@ID";
                List<StudentInfo> _StudentInfoS = DapperHelper.Query<StudentInfo>(_StudentInfo, "Local", sql);
                if (_StudentInfoS.Count > 0)
                    return _StudentInfoS[0];
                else
                    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("=======>插入信息错误" + ex);
                return null;
            }
        }

        public static DataTable GetAllData()
        {
            try
            {
                string sql = "select * from StudentInfo";
                return DapperHelper.ExecuteReadder("Local", sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("=======>插入信息错误" + ex);
                return null;
            }
        }
    }
}
