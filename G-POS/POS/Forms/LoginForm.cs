using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using G_POS.POS.Controllers;
using G_POS.POS.Models;
using G_POS.POS.Helpers;
using GKM;


namespace G_POS.POS.Forms
{
    public partial class LoginForm : Form
    {
        private UserController userController;
        private CustomPathHelper pathHelper;

        public LoginForm()
        {
            InitializeComponent();
            userController = new UserController();
            pathHelper = new CustomPathHelper();

            //MessageBox.Show("" + userController.getAppConfigs().APP_COLOR);

            //theming
            linePanel.BackColor = System.Drawing.ColorTranslator.FromHtml(userController.getAppConfigs().APP_COLOR);
            appNameLbl.Text = userController.getAppConfigs().APP_NAME;

            //logo
            Image image = Image.FromFile(pathHelper.get_app_images_path() +"logo.png");
            this.loginPictureBox.Image = image;

            string partialEncRes = GKI.DecryptString("/+FZz97af/uxtjeRHDTG/RXj/6jp3Z3ZmIB4rspiSFfZ+hZkRDnlj/iB0U8O3mne", "duka.plus.gmtech");
           
            if (GKI.getRemainDays() < 15 && GKI.getRemainDays() > 0)
            {
                expiryReminderLbl.Text = GKI.getRemainDays() + " days remained!"; 
                expiryReminderLbl.Visible = true;
            }
            else if (GKI.getRemainDays() == 0)
            {
                expiryReminderLbl.Text = "TODAY IS THE END-DATE!!"; 
                expiryReminderLbl.Visible = true;
            }
            else if (GKI.getRemainDays() < -15)
            {
                expiryReminderLbl.Text = "EXPIRED SINCE " + GKI.getEndDate();
                expiryReminderLbl.Visible = true;
                //hide login btn
                loginBtn.Visible = false;
            }
            else if (GKI.getRemainDays() < 0 && GKI.getRemainDays() >= -15)
            {
                expiryReminderLbl.Text = "EXPIRED SINCE " + GKI.getEndDate() + " - CLOSE ANYTIME";
                expiryReminderLbl.Visible = true;
            }
            else{
                expiryReminderLbl.Text = GKI.getRemainDays() + " days remained!";
                expiryReminderLbl.Visible = false;
            }


        }

        

        private void backBtn_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginBtn_Click_1(object sender, EventArgs e)
        {
            loadingLbl.Text = "signing in ...";
            loadingLbl.Visible = true;
            if (usernameTxt.Text == null || usernameTxt.Text == "" || passwordTxt.Text == null || passwordTxt.Text == "")
            {
                MessageBox.Show("Username and password are required!!");
            }
            //MessageBox.Show(usernameTxt.Text + ":" + passwordTxt.Text);
            MDB_UserModel res = userController.login_user(new MDB_UserModel()
            {
                username = usernameTxt.Text,
                password = passwordTxt.Text
            });
            
            if (res != null)
            {
                int r = userController.saveCurrentUser(res);
                if (r == 0)
                {
                    loadingLbl.Text = "OK";
                    //System.Threading.Thread.Sleep(2000);

                    var f = new POSForm();
                    f.ShowDialog();
                    this.Close();
                }
                else
                {
                    loadingLbl.Text = "Cant Save current user!!";
                }

            }
            else
            {
                loadingLbl.Text = "Sorry invalid credentials!!";
            }
        }

    }
}
