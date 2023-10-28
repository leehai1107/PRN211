using BusinessObject;
using DataAccess.Repository;

namespace MyStoreWinApp
{
    public partial class frmMain : Form
    {
        IMemberRepository memberRepository;
        frmMembers membersForm;
        frmOrders ordersForm;
        frmProducts productsForm;

        public frmMain()
        {
            InitializeComponent();
            memberRepository = new MemberRepository();
            menuMain.Visible = false; // Hide menu
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Member member = memberRepository.getMemberByEmail(txtEmail.Text);
            if (member != null)
            {
                if (member.Email == txtEmail.Text && member.Password == txtPassword.Text)
                {
                    MessageBox.Show("Login Success!");
                    menuMain.Visible = true; // Show menu
                    gbLogin.Visible = false;
                }
                else
                {
                    MessageBox.Show("Incorrect Email or Password!");
                    menuMain.Visible = false; // Hide menu
                }
            }
        }

        private void memberManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (membersForm == null || membersForm.IsDisposed)
            {
                membersForm = new frmMembers();
                membersForm.FormClosed += (s, args) => menuMain.Visible = true; // Reset menu visibility when the form is closed
            }
            membersForm.Show();
            menuMain.Visible = false; // Hide menu when the form is shown
        }

        private void productManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (productsForm == null || productsForm.IsDisposed)
            {
                productsForm = new frmProducts();
                productsForm.FormClosed += (s, args) => menuMain.Visible = true; // Reset menu visibility when the form is closed
            }
            productsForm.Show();
            menuMain.Visible = false; // Hide menu when the form is shown
        }

        private void orderManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ordersForm == null || ordersForm.IsDisposed)
            {
                ordersForm = new frmOrders();
                ordersForm.FormClosed += (s, args) => menuMain.Visible = true; // Reset menu visibility when the form is closed
            }
            ordersForm.Show();
            menuMain.Visible = false; // Hide menu when the form is shown
        }
    }
}