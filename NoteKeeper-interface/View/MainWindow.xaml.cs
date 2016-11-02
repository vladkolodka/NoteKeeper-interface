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
using NoteKeeper_interface.Resources;

namespace NoteKeeper_interface.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            TextSearch.Clear();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow temp = new SettingsWindow();
            temp.Owner = this;
            temp.Show();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            NewNoteWindow temp = new NewNoteWindow(
                "Lore ipsum",
                @"/Resources/LoremIpsum.jpg",
                "fish, text, picture, test", "Lorem ipsum dolor sit amet,\n" 
                                + "consectetur adipiscing elit,\n"
                                + "sed do eiusmod tempor incididunt\n"
                                + "ut labore et dolore magna aliqua.\n"
                                + "Ut enim ad minim veniam, quis nostrud\n"
                                + "exercitation ullamco laboris nisi ut\n"
                                + "aliquip ex ea commodo consequat.\n"
                                + "Duis aute irure dolor in reprehenderit\n"
                                + "in voluptate velit esse cillum dolore\n"
                                + "eu fugiat nulla pariatur.Excepteur sint\n"
                                + "occaecat cupidatat non proident, sunt\n"
                                + "in culpa qui officia deserunt mollit anim\n"
                                + "id est laborum.\n");
            temp.Title = "Edit note";
            temp.PublishButton.Content = "Edit";
            temp.Owner = this;
            temp.Show();
        }

        // Ny a sho?
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Current note will be deleted! Do you want to delete it?",
                "Deleting", MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show(
                "Current note has be deleted!",
                "Deleting", MessageBoxButton.OK,
                MessageBoxImage.Information);
            }
        }

        private void ShowNotifyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "This note was created: 10 OCT 2015, by User.\nLast changes was yesterday.",
                "Notifications", MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void PrivacyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Do you want to save privacy settings?",
                "Privacy settings", MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show(
                "Privacy settings has been successfully saved",
                "Privacy settings", MessageBoxButton.OK,
                MessageBoxImage.Information);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            new NewNoteWindow().Show();            
        }

        private void SyncButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult result;
            do
            {
                result = System.Windows.Forms.MessageBox.Show(
                    "Synchronization process is failed. check your internet connection and try again.",
                    "Synchronization", System.Windows.Forms.MessageBoxButtons.RetryCancel,
                    System.Windows.Forms.MessageBoxIcon.Error);
            } while (result == System.Windows.Forms.DialogResult.Retry);
            
        }
    }
}
