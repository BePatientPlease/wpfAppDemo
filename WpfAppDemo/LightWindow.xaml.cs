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
using System.Windows.Shapes;

namespace WpfAppDemo
{
    /// <summary>
    /// LightWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LightWindow : Window
    {
        public LightWindow()
        {
            InitializeComponent();
        }

        private void GlowingLightControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lamp.IsLight = !lamp.IsLight;
        }
    }
}
