using Login.BLL;
using Login.DAL;
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

namespace Login.UI.Login
{
    /// <summary>
    /// Interaction logic for lLogin.xaml
    /// </summary>
    public partial class lLogin : Window
    {
        MainWindow main = new MainWindow();
        
        public lLogin()
        {
            InitializeComponent();

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

            /*if(LNombreUsuarioTextBox.Text.Length == 0)
            {
                MessageBox.Show("Ha ocurrido un error, inserte el Nombre de usuario", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if(LClavePassWordBox.Password.Length == 0)
            {
                MessageBox.Show("Ha ocurrido un error, inserte la clave", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
           */
            var paso = LoginBLL.Validar(LNombreUsuarioTextBox.Text,LClavePassWordBox.Password);
            if (paso)
            {
                this.Close();
                MessageBox.Show("Welcome" + LNombreUsuarioTextBox);
                main.Show();
            }
            else
            {
                MessageBox.Show("Usuario o clave de acceso incorrectos");
            }
        }
    }
}
