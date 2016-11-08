using System.Windows.Controls;
using System.Windows.Input;

namespace NoteKeeper_interface.View.NewNoteMaster.Pages {
    /// <summary>
    ///     Interaction logic for Step2.xaml
    /// </summary>
    public partial class Step2 : Page, IMasterStepPage {
        public Step2() {
            InitializeComponent();
        }

        public void NextPage_OnCanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = !(string.IsNullOrEmpty(TagsBox.Text) || 
                Group.SelectedIndex == -1);
        }
    }
}