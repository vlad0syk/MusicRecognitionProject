using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicRecognitionProject.Views
{
    /// <summary>
    /// Interaction logic for RecognitionView.xaml
    /// </summary>
    public partial class RecognitionView : UserControl
    {
        private bool _isSpinning;
        public RecognitionView()
        {
            InitializeComponent();
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (!_isSpinning)
            {
                var rotateTransform = new RotateTransform();
                button.RenderTransform = rotateTransform;
                button.RenderTransformOrigin = new Point(0.5, 0.5);

                var animation = new DoubleAnimation
                {
                    To = 360,
                    Duration = new Duration(TimeSpan.FromSeconds(3)),
                    RepeatBehavior = RepeatBehavior.Forever
                };

                rotateTransform.BeginAnimation(RotateTransform.AngleProperty, animation);
                _isSpinning = true;
            }
            else
            {
                if (button.RenderTransform is RotateTransform rotateTransform)
                {
                    rotateTransform.BeginAnimation(RotateTransform.AngleProperty, null);
                }
                _isSpinning = false;
            }
        }
    }
}
