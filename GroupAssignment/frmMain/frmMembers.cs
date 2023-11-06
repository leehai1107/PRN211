using BussinessObjects.Models;
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

namespace frmWinApp
{
    public partial class frmMembers : Form
    {
        IMemberRepository memberRepository = new MemberRepository();
        IRoleRepository roleRepository = new RoleRepository();
        public frmMembers()
        {
            InitializeComponent();
        }

        private void frmMembers_Load(object sender, EventArgs e)
        {
            LoadMembers();
            LoadRole();
        }

        private void LoadMembers()
        {

            dgvMembers.DataSource = memberRepository.GetMembers().Select(x => new
            {
                MemberId = x.MemberId,
                Email = x.Email,
                Company = x.CompanyName,
                Password = x.Password,
                Role = x.Role.RoleName,
                City = x.City,
                Country = x.Country

            }).ToList();
        }

        private void dgvMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           if(e.RowIndex >= 0)
            {
                int memberId = Int32.Parse(dgvMembers.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                Member member = memberRepository.GetMember(memberId);
                txtMemberId.Text = member.MemberId.ToString();
                txtEmail.Text = member.Email;
                txtPassword.Text = member.Password;
                txtCompanyName.Text = member.CompanyName;
                txtCity.Text = member.City;
                txtCountry.Text = member.Country;
                cbRole.SelectedValue = member.RoleId;
            }
        }

        private void LoadRole()
        {
            cbRole.DataSource = roleRepository.GetRoles();
            cbRole.ValueMember = "RoleId";
            cbRole.DisplayMember = "RoleName";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Member member = new Member
            {
                MemberId = Int32.Parse(txtMemberId.Text),
                City = txtCity.Text,
                Country = txtCountry.Text,
                CompanyName = txtCompanyName.Text,
                Email = txtEmail.Text,
                Password = txtPassword.Text,
                RoleId = Int32.Parse((string)cbRole.SelectedValue.ToString())
            };
            memberRepository.UpdateMember(member);
            LoadMembers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            Member member = new Member
            {
                MemberId = Int32.Parse(txtMemberId.Text),
                City = txtCity.Text,
                Country = txtCountry.Text,
                CompanyName = txtCompanyName.Text,
                Email = txtEmail.Text,
                Password = txtPassword.Text,
                RoleId = Int32.Parse((string)cbRole.SelectedValue.ToString())
            };
            memberRepository.AddMember(member);
            LoadMembers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int MemberId = Int32.Parse(txtMemberId.Text);
            memberRepository.DeleteMember(MemberId);
            LoadMembers();
        }
    }
}
