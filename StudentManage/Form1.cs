using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using StudentManage.DAL;
using Model;

namespace StudentManage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bt_Insert_Click(object sender, EventArgs e)
        {
            StudentInfo _StudentInfo = new StudentInfo();
            _StudentInfo.ID = txt_ID.Text;
            _StudentInfo.Name = txt_Name.Text;
            _StudentInfo.Address = txt_Address.Text;
            _StudentInfo.Sex = txt_Sex.Text;
            _StudentInfo.Age = Convert.ToInt32(txt_Age.Text);
            if (gaStudentInfo.InsertStudent(_StudentInfo))
                MessageBox.Show("插入成功！");
            else
                MessageBox.Show("插入失败！");
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            StudentInfo _StudentInfo = new StudentInfo();
            _StudentInfo.ID = txt_ID.Text;
            if (gaStudentInfo.DeleteStudent(_StudentInfo))
                MessageBox.Show("删除成功！");
            else
                MessageBox.Show("删除失败！");
        }

        private void bt_Update_Click(object sender, EventArgs e)
        {
            StudentInfo _StudentInfo = new StudentInfo();
            _StudentInfo.ID = txt_ID.Text;
            _StudentInfo.Name = txt_Name.Text;
            _StudentInfo.Address = txt_Address.Text;
            _StudentInfo.Sex = txt_Sex.Text;
            _StudentInfo.Age = Convert.ToInt32(txt_Age.Text);
            if (gaStudentInfo.UpdateStudent(_StudentInfo))
                MessageBox.Show("插入成功！");
            else
                MessageBox.Show("插入失败！");
        }

        private void bt_Select_Click(object sender, EventArgs e)
        {
            //StudentInfo _StudentInfo = new StudentInfo();
            //_StudentInfo.ID = txt_ID.Text;

            //StudentInfo _NewStudentInfo = gaStudentInfo.GetStudentInfoByID(_StudentInfo);
            //txt_ID.Text = _NewStudentInfo.ID;
            //txt_Address.Text = _NewStudentInfo.Address;
            //txt_Age.Text = _NewStudentInfo.Age.ToString();
            //txt_Name.Text = _NewStudentInfo.Name;
            //txt_Sex.Text = _NewStudentInfo.Sex;
            dt_Data.DataSource = gaStudentInfo.GetAllData();
            if (dt_Data.DataSource != null)
            {
                dt_Data.Columns["ID"].HeaderText = "学号";
                dt_Data.Columns["Name"].HeaderText = "名字";
                dt_Data.Columns["Address"].HeaderText = "地址";
                dt_Data.Columns["Sex"].HeaderText = "性别";
                dt_Data.Columns["Age"].HeaderText = "年龄";
                dt_Data.Columns["Address"].Width = 200;
            }
        }
    }
}
