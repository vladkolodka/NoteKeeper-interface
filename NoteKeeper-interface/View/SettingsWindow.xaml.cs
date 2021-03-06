﻿using System;
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

namespace NoteKeeper_interface.View
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private string _avatarImagePath;

        public SettingsWindow()
        {
            InitializeComponent();
            RBLightTheme.IsChecked = true;
        }

        private void ChooseAvatarButton_OnClick(object sender, RoutedEventArgs e)
        {
            _avatarImagePath = Utils.MainUtils.LoadImageFile();
        }

        private void RBLightTheme_Checked(object sender, RoutedEventArgs e)
        {
            this.Background = Brushes.White;
        }

        private void RBDarkTheme_Checked(object sender, RoutedEventArgs e)
        {
            this.Background = Brushes.Silver;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
        }

        private void Window_Closing(object sender, EventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Do you want to save changes?",
                this.Title, MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show(
                "Changes has been saved.",
                this.Title, MessageBoxButton.OK,
                MessageBoxImage.Information);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Owner.Focus();
        }

        private void ImageUploadCommand_OnExecuted(object sender, ExecutedRoutedEventArgs e) {
            Avatar.Source = new BitmapImage(new Uri(_avatarImagePath, UriKind.Absolute));
        }

        private void ImageUploadCommand_OnCanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = !string.IsNullOrEmpty(_avatarImagePath);
        }
    }
}
