using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NoteKeeper_interface.Utils {
    public static class FunUtils {
        public static void SetRandomColorsForContols(DependencyObject parent) {
            var randomizer = new Random();

            var parent1 = parent as Control;
            if (parent1 != null) {
                parent1.Background =RandomColor(randomizer);
            }

            var controls = FindControls<Control>(parent);
            var texts = FindControls<TextBlock>(parent);

            foreach (var control in controls) {
                control.Background = RandomColor(randomizer);
                control.Style = null;
            }

            foreach (var control in texts) {
                control.Foreground = RandomColor(randomizer);
                control.Background = RandomColor(randomizer);
            }            
        }

        private static SolidColorBrush RandomColor(Random randomizer) {
            return new SolidColorBrush(new Color {
                A = (byte) randomizer.Next(0, 255),
                B = (byte) randomizer.Next(0, 255),
                G = (byte) randomizer.Next(0, 255),
                R = (byte) randomizer.Next(0, 255)
            });
        }

        private static IEnumerable<T> FindControls<T>(DependencyObject window) where T : DependencyObject {
            if (window == null) throw new ArgumentNullException();

            var childCount = VisualTreeHelper.GetChildrenCount(window);

            for (var i = 0; i < childCount; i++) {
                var child = VisualTreeHelper.GetChild(window, i);
                var control = child as T;
                if (control != null) yield return control;

                foreach (var childOfChild in FindControls<T>(child))
                    yield return childOfChild;
            }
        }
    }
}