using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NoteKeeper_interface.Utils;

namespace NoteKeeper_interface.View {
    /// <summary>
    ///     Interaction logic for NewNoteWindow.xaml
    /// </summary>
    public partial class NewNoteWindow {
        public NewNoteWindow() {
            InitializeComponent();
        }

        public NewNoteWindow(string title, string imagePath, string tegs, string text) {
            InitializeComponent();
            Avatar.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            TitleBox.Text = title;
            TegsBox.Text = tegs;
            NoteText.Text = text;
        }

        private void ColorRectangle_OnMouseDown(object sender, MouseButtonEventArgs e) {
            var target = sender as Rectangle;
            if (target == null) return;

            var color = MainUtils.GetColor();
            if (color != null) target.Fill = color;
        }

        private void PublishButton_OnClick(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(TitleBox.Text)) {
                MessageBox.Show(this, Properties.Resources.newNoteNoTitle); // temp
                return;
            }

            Close();
            // TODO replace with custom dialog window
            MessageBox.Show(this, Properties.Resources.noteSaved);
        }

        private void ImageButton_OnClick(object sender, RoutedEventArgs e) {
            var path = MainUtils.LoadImageFile();
            if (path == null) return;

            Avatar.Source = new BitmapImage(new Uri(path));
        }

        private void RandomColorsCommand_OnExecuted(object sender, ExecutedRoutedEventArgs e) {
            FunUtils.SetRandomColorsForContols(this);
        }
    }
}