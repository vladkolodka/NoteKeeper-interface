using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using NoteKeeper_interface.Utils;

namespace NoteKeeper_interface.View.NewNoteMaster.Pages {
    /// <summary>
    ///     Interaction logic for Step4.xaml
    /// </summary>
    public partial class Step4 : Page, IMasterStepPage {
        public Step4() {
            InitializeComponent();
        }

        public void NextPage_OnCanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = !string.IsNullOrEmpty(NoteText.Text);
        }

        private void ColorRectangle_OnMouseDown(object sender, MouseButtonEventArgs e) {
            var target = sender as Rectangle;
            if (target == null) return;

            var color = MainUtils.GetColor();
            if (color != null) target.Fill = color;
        }
    }
}