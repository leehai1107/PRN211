using BusinessObject;
using System.IO;
using System.Windows.Forms;
using System.Text.Json;
using DataAccess.Repository;
using System.Diagnostics.Metrics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MyStoreWinApp
{
    public partial class frmLogin : Form
    {
        private MemberObject defaultAccount;
        private IMemberRepository memberRepository = new MemberRepository();

        public frmLogin()
        {
            defaultAccount = new MemberObject();
            InitializeComponent();
            LoadDefaultAccount();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void LoadDefaultAccount()
        {
            string appSettingsPath = @"appsettings.json";

            if (File.Exists(appSettingsPath))
            {
                string json = File.ReadAllText(appSettingsPath);
                var appSettings = JsonSerializer.Deserialize<JsonElement>(json);

                var defaultAccountElement = appSettings.GetProperty("DefaultAccount");
                defaultAccount.email = defaultAccountElement.GetProperty("Email").GetString();
                defaultAccount.password = defaultAccountElement.GetProperty("Password").GetString();
            }
            else
            {
                MessageBox.Show("Default account is not initialized!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            // Check if the defaultAccount object is null
            if (defaultAccount != null)
            {
                // Get the entered email and password from the textboxes
                string enteredEmail = txtEmail.Text.Trim();
                string enteredPassword = txtPassword.Text;

                if(loginWithAdmin(enteredEmail, enteredPassword)) 
                {
                    // Create an instance of frmMemberManagement form
                    frmMemberManagements memberManagementForm = new frmMemberManagements();

                    // Subscribe to the FormClosed event of memberManagementForm
                    memberManagementForm.FormClosed += MemberManagementForm_FormClosed;

                    // Show the frmMemberManagement form
                    memberManagementForm.Show();

                    // Hide the login form
                    this.Hide();
                }
                else if(logiWithUser(enteredEmail, enteredPassword))
                {
                    frmMemberDetail memberDetail = new frmMemberDetail();

                    // Set the memberRepository property of memberDetailForm
                    memberDetail.memberRepository = memberRepository;

                    // Set the insertOrUpdate property of memberDetailForm
                    memberDetail.insertOrUpdate = true;

                    // Set the memberInfo property of memberDetailForm
                    memberDetail.memberInfo = memberRepository.GetMemberByEmail(enteredEmail) ;

                    memberDetail.FormClosed += MemberManagementForm_FormClosed;

                    memberDetail.Show();
                    this.Hide();
                }
                else
                {
                    // Display an error message if the entered email or password is incorrect
                    MessageBox.Show("Email or Password is incorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
            }
            else
            {
                this.Close();
            }
        }

        private void MemberManagementForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Show the login form when memberManagementForm is closed
            this.Show();
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private bool loginWithAdmin(string username, string password)
        {
            // Check if the entered email and password match the default account
            if (username == defaultAccount.email.Trim() && password == defaultAccount.password)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        private bool logiWithUser(string username, string password)
        {
            MemberObject member = memberRepository.GetMemberByEmail(username);
            if(member != null)
            {
                if (username == member.email && password == member.password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }
    }
}