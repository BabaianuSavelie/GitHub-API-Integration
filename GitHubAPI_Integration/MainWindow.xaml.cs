using GitHubAPI_Integration.Helpers;
using GitHubAPI_Integration.Models;
using GitHubAPI_Integration.Services;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace GitHubAPI_Integration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            APIHelper.InitializeClient();
        }

        private async void submit_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
                string username = input.Text.Replace(" ", "");
                if (String.IsNullOrEmpty(username))
                    throw new ArgumentNullException();

                var repositories = await RepositoryService.GetAllRepositories(username);
                SeedListViewItems(repositories);
                ResetInput();
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex.Message);
            }
        }

        private void DisplayErrorMessage(string message)
        {
            ErrorLbl.Content = message;
            ErrorLbl.Visibility = Visibility.Visible;
            input.BorderBrush = Brushes.Red;
        }
        private void ResetInput()
        {
            ErrorLbl.Visibility = Visibility.Collapsed;
            input.BorderBrush = Brushes.Gray;
        }
        private void SeedListViewItems(IEnumerable<Repository> repositories)
        {
            RepositoriesRecipe.Items.Clear();
            foreach (var repository in repositories)
                RepositoriesRecipe.Items.Add(repository.Name);
        }
    }
}
