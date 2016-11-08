using System.Windows.Controls;
using System.Windows.Input;

namespace NoteKeeper_interface.View.NewNoteMaster.Pages {
    /// <summary>
    ///     Interaction logic for Step1.xaml
    /// </summary>
    public partial class Step1 : Page, IMasterStepPage {
        public Step1() {
            InitializeComponent();
        }

        public void NextPage_OnCanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = !(string.IsNullOrEmpty(TitleBox.Text) ||
                           string.IsNullOrEmpty(DescriptionBox.Text));
        }
    }
}