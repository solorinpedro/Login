using Login.BLL;
using Login.Entidades;
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

namespace Login.UI.Registros
{
    /// <summary>
    /// Interaction logic for rUsuarios.xaml
    /// </summary>
    public partial class rUsuarios : Window
    {
        public Usuarios usuario = new Usuarios();
        public rUsuarios()
        {
            InitializeComponent();
            this.DataContext = usuario;

        }
        public void Limpiar()
        {
            this.usuario = new Usuarios();
            this.DataContext = usuario;
        }
        private bool Validar()
        {
            bool esValido = true;

            if (FechaDatePicker.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ha ocurrido un error, inserte la fecha", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (NombreTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ha ocurrido un error, inserte el nombre", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (ApellidoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ha ocurrido un error, inserte el apellido", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (NombreUsuarioTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ha ocurrido un error, inserte el Nombre de usuario", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (ClavePaswordBox.Password.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ha ocurrido un error, inserte el Nombre de usuario", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (ClaveNuevamentePasswordBox.Password.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ha ocurrido un error, inserte el Nombre de usuario", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if(ClavePaswordBox.Password != ClaveNuevamentePasswordBox.Password)
            {
                esValido = false;
                MessageBox.Show("Las claves no coinciden,Intente denuevo", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var usuarios = UsuariosBLL.Buscar(Utilidades.ToInt(UsuarioIdTextBox.Text));
            if (usuarios != null)
            {
                this.usuario = usuarios;
            }
            else
            {
                this.usuario = new Usuarios();
                MessageBox.Show("No se ha encontrado", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            this.DataContext = this.usuario;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            var paso = UsuariosBLL.Guardar(this.usuario);
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Se ha guardado exitosamente", "Exito", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar correctamente", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuariosBLL.Eliminar(Utilidades.ToInt(UsuarioIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Se ha eliminado correctamente", "Exito", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se ha eliminado correctamente", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
