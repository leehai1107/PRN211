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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyStoreWinApp
{
    public partial class frmMemberManagements : Form
    {
        IMemberRepository memberRepository= new MemberRepository();
        BindingSource source;
        public frmMemberManagements()
        {
            InitializeComponent();
        }


        private void loadMembers()
        {
            var members = memberRepository.GetMembers();

            try
            {
                source = new BindingSource();
                source.DataSource = members;


                dgvMembers.DataSource = null;
                dgvMembers.DataSource = members;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load members");
            }
        }

        private void dgvMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var members = (List<MemberObject>)memberRepository.GetMembers();
   
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
           loadMembers();
        }

        private void frmMemberManagements_Load(object sender, EventArgs e)
        {
            dgvMembers.CellDoubleClick += dgvMembers_CellDoubleClick;
        }

        private void dgvMembers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle the update click
            int selectedRow = dgvMembers.SelectedCells[0].RowIndex;
            MemberObject selectedMember = (MemberObject)dgvMembers.Rows[selectedRow].DataBoundItem;

            frmMemberDetail frmMemberDetail = new frmMemberDetail
            {
                Text = "Update member",
                insertOrUpdate = true,
                memberInfo = selectedMember,
                memberRepository= memberRepository
            };
            if(frmMemberDetail.ShowDialog() == DialogResult.OK)
            {
                loadMembers();
                source.Position = source.Count - 1;
            }
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            frmMemberDetail frmMemberDetail = new frmMemberDetail 
            { 
                Text= "Add member",
                insertOrUpdate = false,
                memberRepository= memberRepository
            };
            if(frmMemberDetail.ShowDialog() == DialogResult.OK )
            {
                loadMembers();
                source.Position = source.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRow = dgvMembers.SelectedCells[0].RowIndex;
                MemberObject selectedMember = (MemberObject)dgvMembers.Rows[selectedRow].DataBoundItem;

                memberRepository.DeleteMember(selectedMember.id);
                loadMembers();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Delete a member!");
            }


        }

        private void txtSearchId_TextChanged(object sender, EventArgs e)
        {
                // Check if TextBox A is filled
                if (!string.IsNullOrEmpty(txtSearchId.Text))
                {
                    // Disable TextBox B
                    txtSearchName.Enabled = false;
                }
                else
                {
                    // Enable TextBox B
                    txtSearchName.Enabled = true;
                }
            }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            // Check if TextBox A is filled
            if (!string.IsNullOrEmpty(txtSearchName.Text))
            {
                // Disable TextBox B
                txtSearchId.Enabled = false;
            }
            else
            {
                // Enable TextBox B
                txtSearchId.Enabled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchId.Text))
            {
                var result = memberRepository.findMembersByName(txtSearchName.Text);
                dgvMembers.DataSource = null;
                dgvMembers.DataSource = result;
            }
            else
            {
                var result = memberRepository.GetMemberById(int.Parse(txtSearchId.Text));
                List<MemberObject> list = new List<MemberObject>();
                list.Add(result);
                dgvMembers.DataSource = null;
                dgvMembers.DataSource = list;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvMembers.DataSource = null;
            dgvMembers.DataSource = memberRepository.GetMembersSortedByNameDescending();

        }
    }
 }

