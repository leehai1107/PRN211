using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreWinApp
{
    public partial class frmMemberDetail : Form
    {
        public frmMemberDetail()
        {
            InitializeComponent();
        }

        public IMemberRepository memberRepository { get; set; }
        public bool insertOrUpdate { get; set; }
        public MemberObject memberInfo { get; set; }

        private void frmMemberDetail_Load(object sender, EventArgs e)
        {
            txtId.Enabled = !insertOrUpdate;
            if(insertOrUpdate == true)
            {
                txtId.Text = memberInfo.id.ToString();
                txtName.Text = memberInfo.name.ToString();
                txtPassword.Text = memberInfo.password.ToString();
                txtEmail.Text = memberInfo.email.ToString();
                txtCity.Text = memberInfo.city.ToString();
                txtCountry.Text = memberInfo.country.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var member = new MemberObject
                {
                    id = int.Parse(txtId.Text),
                    name = txtName.Text,
                    password = txtPassword.Text,
                    email = txtEmail.Text,
                    city = txtCity.Text,
                    country = txtCountry.Text
                };
                if(insertOrUpdate == false)
                {
                    memberRepository.AddMember(member);
                    List<MemberObject> count = (List<MemberObject>)memberRepository.GetMembers();
                    MessageBox.Show("Add member to system!","Result");
                }
                else
                {
                    memberRepository.UpdateMember(member);
                    MessageBox.Show("Update member to system!", "Result");
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, insertOrUpdate == false ? "Add a new member" : "Update a member");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)=> Close();

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCountry.Text = string.Empty;
        }
    }
}
