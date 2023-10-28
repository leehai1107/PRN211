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
    public partial class frmMembers : Form
    {
        IMemberRepository memberRepository = new MemberRepository();
        
        public frmMembers()
        {
            InitializeComponent();
        }

        private void frmMembers_Load(object sender, EventArgs e)
        {
            loadMember();
        }

        public void loadMember()
        {
            dvgMember.DataSource= memberRepository.GetMembers().Select(x => new
            {
                MemberId = x.MemberId,
                Email = x.Email,
                Password = x.Password,
                CompanyName= x.CompanyName,
                City =x.City,
                Country=x.Country
            }).ToList();
        }

        private void dvgMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>= 0)
            {
                int memberId = int.Parse(dvgMember.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                Member member = memberRepository.GetMember(memberId);
                txtId.Text = member.MemberId.ToString();
                txtEmail.Text = member.Email;
                txtPassword.Text = member.Password;
                txtCompany.Text = member.CompanyName;
                txtCity.Text = member.City;
                txtCountry.Text = member.Country;
            }
        }

        private void clearText()
        {
            txtId.Text= string.Empty;
            txtEmail.Text= string.Empty;
            txtPassword.Text= string.Empty;
            txtCompany.Text= string.Empty;
            txtCity.Text= string.Empty;
            txtCountry.Text= string.Empty;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearText();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtId.Text != null && txtEmail.Text !=null 
                && txtCompany.Text !=null && txtCity.Text !=null 
                && txtPassword.Text != null && txtCountry.Text != null)
            {
                int id;
                if(int.TryParse(txtId.Text, out id))
                {
                    Member member = memberRepository.GetMember(id);
                    member.MemberId = id;
                    member.Email = txtEmail.Text;
                    member.Password = txtPassword.Text;
                    member.CompanyName = txtCompany.Text;
                    member.City = txtCity.Text;
                    member.Country = txtCountry.Text;
                    memberRepository.updateMember(member);
                    loadMember();
                }
                else
                {
                    MessageBox.Show("Wrong format!");
                }
            }
            else
            {
                MessageBox.Show("Data can not be empty!");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtId.Text != null && txtEmail.Text != null
                && txtCompany.Text != null && txtCity.Text != null
                && txtPassword.Text != null && txtCountry.Text != null)
            {
                int id;
                if (int.TryParse(txtId.Text, out id))
                {
                    Member member = new Member
                    {
                        MemberId = id,
                        Email = txtEmail.Text,
                        Password = txtPassword.Text,
                        CompanyName = txtCompany.Text,
                        City = txtCity.Text,
                        Country = txtCountry.Text
                    };

                    memberRepository.addMember(member);
                    loadMember();
                }
                else
                {
                    MessageBox.Show("Wrong format!");
                }
                
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtId.Text != null)
            {
                int id;
                if (int.TryParse(txtId.Text, out id))
                {
                    memberRepository.deleteMember(id);
                    loadMember();
                }
                else
                {
                    MessageBox.Show("Wrong format!");
                }
            }
        }
    }
}
