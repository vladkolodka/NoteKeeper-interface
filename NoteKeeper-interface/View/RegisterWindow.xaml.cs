using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace NoteKeeper_interface.View {
    /// <summary>
    ///     Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow {
        private readonly Regex _passwordTemplate = new Regex(@"(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}");
        private string _avatarImagePath;

        public RegisterWindow() {
            InitializeComponent();
            LoginText.Focus();
        }

        private void ChooseAvatarButton_OnClick(object sender, RoutedEventArgs e) {
            _avatarImagePath = Utils.MainUtils.LoadImageFile();
        }

        private void UploadCommand_OnExecuted(object sender, ExecutedRoutedEventArgs e) {
            AvatarImage.Source = new BitmapImage(new Uri(_avatarImagePath));
        }

        private void UploadCommand_OnCanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = !string.IsNullOrEmpty(_avatarImagePath);
        }

        private void NewCommand_OnExecuted(object sender, ExecutedRoutedEventArgs e) {
            if (LoginText.Text == "User") {
                ShowError(Properties.Resources.loginInUse);
                return;
            }
            if (PasswordText.Password != RepeatPasswordText.Password) {
                ShowError(Properties.Resources.diffPasswords);
                return;
            }
            if (_passwordTemplate.Match(PasswordText.Password).Length == 0) {
                ShowError(Properties.Resources.badPassword);
                return;
            }
            // TODO replace with custom dialog window
            MessageBox.Show(this, Properties.Resources.accountCreated); // Temp
        }

        private void ShowError(string errorMessage) {
            ErrorText.Text = errorMessage;
            ErrorText.Visibility = Visibility.Visible;
        }

        private void NewCommand_OnCanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = !(string.IsNullOrEmpty(LoginText.Text) ||
                             string.IsNullOrEmpty(PasswordText.Password) ||
                             string.IsNullOrEmpty(RepeatPasswordText.Password) ||
                             QuestionBox.SelectedIndex == 0 ||
                             string.IsNullOrEmpty(QuestionText.Text)
                );
        }

        private void TextBox_OnGotFocus(object sender, RoutedEventArgs e) {
            (sender as TextBox)?.SelectAll();
            (sender as PasswordBox)?.SelectAll();
        }
    }
}