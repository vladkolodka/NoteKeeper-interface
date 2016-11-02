using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace NoteKeeper_interface.View {
    /// <summary>
    ///     Interaction logic for NewNoteWindow.xaml
    /// </summary>
    public partial class NewNoteWindow {
        public NewNoteWindow() {
            InitializeComponent();
        }

        public NewNoteWindow(string title, string imagePath, string tegs, string text)
        {
            InitializeComponent();
            Avatar.Source = new BitmapImage(new Uri(imagePath));
            TitleBox.Text = title;
            TegsBox.Text = tegs;
            NoteText.Text = text;
        }

        private void ColorRectangle_OnMouseDown(object sender, MouseButtonEventArgs e) {
            var target = sender as Rectangle;
            if (target == null) return;

            var colorSelector = new ColorDialog {AllowFullOpen = true};
            if (colorSelector.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            target.Fill = new SolidColorBrush(new Color {
                A = colorSelector.Color.A,
                B = colorSelector.Color.B,
                G = colorSelector.Color.G,
                R = colorSelector.Color.R
            });
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
            var path = Utils.MainUtils.LoadImageFile();
            if(path == null) return;

            Avatar.Source = new BitmapImage(new Uri(path));
        }
    }
}