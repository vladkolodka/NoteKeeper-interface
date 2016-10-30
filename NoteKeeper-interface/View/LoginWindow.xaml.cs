using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace NoteKeeper_interface.View {
    /// <summary>
    ///     Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window {
        private int _counter;

        public LoginWindow() {
            InitializeComponent();
            LoginText.Focus();
        }

        private void SignUpButton_OnClick(object sender, RoutedEventArgs e) {
            var registerWindow = new RegisterWindow {Owner = this};
            registerWindow.ShowDialog();
        }

        private void TextBox_OnGotFocus(object sender, RoutedEventArgs e) {
            (sender as TextBox)?.SelectAll();
            (sender as PasswordBox)?.SelectAll();
        }

        private void GoCommand_OnExecuted(object sender, ExecutedRoutedEventArgs e) {
            if (LoginText.Text != "User" || PasswordText.Password != "12345") {
                _counter++;
                ErrorText.Visibility = Visibility.Visible;

                if (_counter == 3) {
                    MessageBox.Show(this, "Reset password?"); // Temp
                    // TODO show dialog
                    _counter = 0;
                }
                return;
            }
            new MainWindow().Show();
            Close();
        }

        private void GoCommand_OnCanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = !(
                string.IsNullOrEmpty(LoginText.Text) ||
                string.IsNullOrEmpty(PasswordText.Password)
                );
        }
    }
}