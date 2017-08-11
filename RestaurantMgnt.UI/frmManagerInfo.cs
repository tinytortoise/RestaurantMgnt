using System;
using System.Windows.Forms;
using RestaurantMgnt.BLL;
using RestaurantMgnt.Model;

namespace RestaurantMgnt.UI
{
    public partial class frmManagerInfo : Form
    {
        ManagerInfoBLL managerInfoBLL = new ManagerInfoBLL();
       public frmManagerInfo()
        {
            InitializeComponent();
        }

      private void LoadList()
        {
            
            dgvList.AutoGenerateColumns = false;//禁用自动生成
            dgvList.DataSource = managerInfoBLL.GetList();


        }

        private void frmManagerInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ManagerInfo managerInfo = new ManagerInfo()
            {
                ManagerName = txtName.Text,
                ManagerPassword = txtPwd.Text,
            };
            if (managerInfoBLL.AddManagerInfo(managerInfo))
            {
                LoadList();
                CleanText();
            }
            else
            {
                MessageBox.Show("添加失败,请重新输入!");
                CleanText();
            }
        

        }
        /// <summary>
        /// 清除输入文本框的值
        /// </summary>
        private void CleanText()
        {
            txtName.Text = "";
            txtPwd.Text = "";
            rbClerk.Checked = true;
        }
    }
}
