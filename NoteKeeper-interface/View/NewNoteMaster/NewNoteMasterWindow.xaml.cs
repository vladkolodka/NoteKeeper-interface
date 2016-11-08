using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using NoteKeeper_interface.View.NewNoteMaster.Pages;

namespace NoteKeeper_interface.View.NewNoteMaster {
    /// <summary>
    ///     Interaction logic for NewNoteMasterWindow.xaml
    /// </summary>
    public partial class NewNoteMasterWindow {
        // защита от навигационных кнопок мыши
        private bool _allowNavigation = true;

        private readonly Page[] _pages = {
            new Step1(), new Step2(), new Step3(), new Step4(), new Step5()
        };

        private readonly string[] _nextButtonValues;

        private int _currentPage;

        public NewNoteMasterWindow() {
            InitializeComponent();

            _nextButtonValues = NextButton.Tag.ToString().Split(';');
            UpdatePage();

            EndStepNumber.Text = _pages.Length.ToString();
        }

        public Page CurrentPage => _pages[_currentPage];

        private void UpdatePage() {
            if (_currentPage != 0)
                CommandBindings[0].CanExecute -= ((IMasterStepPage) _pages[_currentPage - 1]).NextPage_OnCanExecute;

            _allowNavigation = true;
            MasterPage.NavigationService.Navigate(CurrentPage);

            CommandBindings[0].CanExecute += ((IMasterStepPage) CurrentPage).NextPage_OnCanExecute;
            StepNumber.Text = (_currentPage + 1).ToString();

            NextButton.Content = _currentPage == _pages.Length - 1 ? _nextButtonValues[1] : _nextButtonValues[0];
        }

        private void NextPage_OnExecuted(object sender, ExecutedRoutedEventArgs e) {
            _currentPage++;
            if (_currentPage == _pages.Length) {

                MessageBox.Show("Note created!");
                Close();

                return;
            }

            UpdatePage();
        }

        private void CancalButton_OnClick(object sender, RoutedEventArgs e) {
            Close();
        }

        private void PrevPageCommand_OnExecuted(object sender, ExecutedRoutedEventArgs e) {
            _currentPage--;
            UpdatePage();
        }

        private void PrevPageCommand_OnCanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = _currentPage != 0;
        }

        private void MasterPage_OnNavigating(object sender, NavigatingCancelEventArgs e) {
            if (_allowNavigation) _allowNavigation = false;
            else e.Cancel = true;
        }
    }
}