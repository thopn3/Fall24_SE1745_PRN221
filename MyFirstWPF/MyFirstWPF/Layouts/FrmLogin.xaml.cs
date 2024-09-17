using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyFirstWPF.Layouts
{
    /// <summary>
    /// Interaction logic for FrmLogin.xaml
    /// </summary>
    public partial class FrmLogin : Window
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (ValidForm())
            {
                // Work DB
                MessageBox.Show("Login success");
            }
        }

        private bool ValidForm()
        {
            bool valid = true;

            if(txtUsername.Text.Trim().Length == 0)
            {
                valid = false;
                lbMsgUser.Content = "Username is required";
            }
            else
            {
                lbMsgUser.Content = string.Empty;
            }

            if (txtPassword.Password.Trim().Length == 0)
            {
                valid = false;
                lbMsgPass.Content = "Password is required";
            }
            else
            {
                lbMsgPass.Content = string.Empty;
            }

            if(valid == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
