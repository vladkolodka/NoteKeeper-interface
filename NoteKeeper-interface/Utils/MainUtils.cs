using Microsoft.Win32;

namespace NoteKeeper_interface.Utils {
    public static class MainUtils {
        public static string LoadImageFile() {
            var openFileDialog = new OpenFileDialog {
                Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*"
            };

            return openFileDialog.ShowDialog() == true ? openFileDialog.FileName : null;
        }
    }
}