using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlDrag
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private Transform originTransform = null;
        public MainWindow()
        {
            InitializeComponent();
            originTransform = SeolhyunImageBorder.RenderTransform;
        }

        private Point beforePoint = new Point();
        private Vector relativeVector = new Vector();

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point p = e.GetPosition(null);
                
                if (beforePoint.X != 0 || beforePoint.Y != 0)
                {
                    // Get vector while mouse drag move
                    relativeVector += p - beforePoint;
                }
                beforePoint = p;

                SeolhyunImageBorder.RenderTransform = new TranslateTransform(relativeVector.X, relativeVector.Y);

                Debug.WriteLine("relativeVector: " + relativeVector);
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SeolhyunImageBorder.RenderTransform = originTransform;
            beforePoint = new Point();
            relativeVector = new Vector();
        }
    }
}
