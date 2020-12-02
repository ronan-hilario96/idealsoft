﻿using System.Windows;
using Edialsoft.UI.HttpClient;
using Edialsoft.UI.ViewModel;

namespace Edialsoft.UI.Layout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            StartGrid();
        }

        public async void StartGrid()
        {
            Grid.ItemsSource = await PersonHttpClient.Get();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new PersonWindow().ShowDialog();

            StartGrid();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var item = (PersonViewModel)Grid.SelectedItem;

            new PersonWindow(item).ShowDialog();

            StartGrid();
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string msg = "Tem certeza ?";

            var action = MessageBox.Show(msg, msg, MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (action == MessageBoxResult.Yes)
            {
                var item = (PersonViewModel)Grid.SelectedItem;

                await PersonHttpClient.Delete(item.Id);

                StartGrid();
            }
        }

        private void btnUpdateList_Click(object sender, RoutedEventArgs e)
        {
            StartGrid();
        }
    }
}
