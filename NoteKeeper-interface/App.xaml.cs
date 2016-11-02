using System.Windows;
using System.Windows.Input;

namespace NoteKeeper_interface {
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        public static RoutedCommand RandomColors { get; private set; }

        static App() {
            RandomColors = new RoutedCommand("RandomColors", typeof(App), new InputGestureCollection {
                new KeyGesture(Key.R, ModifierKeys.Control | ModifierKeys.Shift)
            });
        }
    }
}