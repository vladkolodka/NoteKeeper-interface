using System.Windows.Controls;
using System.Windows.Input;

namespace NoteKeeper_interface.View.NewNoteMaster.Pages {
    /// <summary>
    ///     Interaction logic for Step5.xaml
    /// </summary>
    public partial class Step5 : Page, IMasterStepPage {
        public Step5() {
            InitializeComponent();
        }

        public void NextPage_OnCanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = true;
        }
    }
}