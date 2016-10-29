using System.Windows;

namespace NoteKeeper_interface.View {
    /// <summary>
    ///     Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window {
        public LoginWindow() {
            InitializeComponent();
        }

        private void SignUpButton_OnClick(object sender, RoutedEventArgs e) {
            var registerWindow = new RegisterWindow {Owner = this};
            registerWindow.ShowDialog();
        }
    }
}