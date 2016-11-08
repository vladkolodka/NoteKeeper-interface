using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;

namespace NoteKeeper_interface.View.NewNoteMaster.Pages {
    internal interface IMasterStepPage {
        void NextPage_OnCanExecute(object sender, CanExecuteRoutedEventArgs e);
    }
}