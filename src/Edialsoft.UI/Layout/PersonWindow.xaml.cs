using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Edialsoft.UI.HttpClient;
using Edialsoft.UI.ViewModel;

namespace Edialsoft.UI.Layout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PersonWindow : Window
    {
        private readonly PersonViewModel _viewModel;

        public PersonWindow(PersonViewModel viewModel = null)
        {
            this.Title = "Editar Pessoa";

            InitializeComponent();

            if (viewModel == null)
            {
                this.Title = "Cadastrar Pessoa";

                viewModel = new PersonViewModel();
            }

            _viewModel = viewModel;

            firstName.Text = _viewModel.FirstName;
            lastName.Text = _viewModel.LastName;
            phone.Text = _viewModel.Phone;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var person = new PersonViewModel()
            {
                Id = _viewModel.Id,
                FirstName = firstName.Text.Trim(),
                LastName = lastName.Text.Trim(),
                Phone = phone.Text.Trim()
            };

            await PersonHttpClient.Post(person);

            Close();
        }
    }
}
