using Main.Controllers.UserManagementControllers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Main
{
    public partial class LoginFrm : Form
    {
        private readonly ILogger<LoginFrm> _logger;
        private readonly IUserController _userController;
        private readonly Sessions _sessions;
        private readonly MainFrm _mainFrm;

        public LoginFrm(ILogger<LoginFrm> logger,
                            IUserController userController,
                            Sessions sessions,
                            MainFrm mainFrm)
        {
            InitializeComponent();
            _logger = logger;
            _userController = userController;
            _sessions = sessions;
            _mainFrm = mainFrm;
        }


        private void Login()
        {
            var signResults = _userController.SignIn(this.TbxUsername.Text, this.TbxPassword.Text);

            if (signResults != null && signResults.IsSuccess)
            {
                _sessions.CurrentLoggedInUser = signResults.Data;

                _mainFrm.Show();
                this.Hide();
            }
            else
            {
                string messages = string.Join(",", signResults.Messages.ToArray());

                MessageBox.Show(messages, "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void TbxPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
                e.Handled = true;
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }
    }
}
