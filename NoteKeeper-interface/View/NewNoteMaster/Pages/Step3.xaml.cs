using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace NoteKeeper_interface.View.NewNoteMaster.Pages {
    /// <summary>
    ///     Interaction logic for Step3.xaml
    /// </summary>
    public partial class Step3 : Page, IMasterStepPage {
        private string _imageUri;
        public Step3() {
            InitializeComponent();
        }

        public void NextPage_OnCanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = true;
        }

        private void ChooseAvatarButton_OnClick(object sender, RoutedEventArgs e) {
            _imageUri = Utils.MainUtils.LoadImageFile();
        }

        private void ImageUploadCommand_OnExecuted(object sender, ExecutedRoutedEventArgs e) {
            AvatarImage.Source = new BitmapImage(new Uri(_imageUri, UriKind.Absolute));
        }

        private void ImageUploadCommand_OnCanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = !string.IsNullOrEmpty(_imageUri);
        }
    }
}