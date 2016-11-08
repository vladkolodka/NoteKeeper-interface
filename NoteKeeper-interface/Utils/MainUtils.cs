using System.Windows.Forms;
using System.Windows.Media;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace NoteKeeper_interface.Utils {
    public static class MainUtils {
        public static string LoadImageFile() {
            var openFileDialog = new OpenFileDialog {
                Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*"
            };

            return openFileDialog.ShowDialog() == true ? openFileDialog.FileName : null;
        }

        public static SolidColorBrush GetColor() {
            var colorSelector = new ColorDialog {AllowFullOpen = true};
            if (colorSelector.ShowDialog() != DialogResult.OK) return null;

            return new SolidColorBrush(new Color {
                A = colorSelector.Color.A,
                B = colorSelector.Color.B,
                G = colorSelector.Color.G,
                R = colorSelector.Color.R
            });
        }
    }
}