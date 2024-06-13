using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isAltPressed = false;
        
        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += MainWindow_KeyDown;
            this.KeyUp += MainWindow_KeyUp;
        }

        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyUp(Key.LeftAlt) && e.KeyboardDevice.IsKeyUp(Key.RightAlt))
            {
                _isAltPressed = false;
                spTitle.Background = new SolidColorBrush( Colors.White);
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyDown(Key.LeftAlt) || e.KeyboardDevice.IsKeyDown(Key.RightAlt))
            {
                _isAltPressed = true;
                spTitle.Background = new SolidColorBrush(Colors.Orange);
            }
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt)
            {
                // 如果按下，则开始拖动窗口
                DragMove();
                // 保存窗口的当前位置到设置
                Properties.Settings.Default.LastWindowPosX = this.Left;
                Properties.Settings.Default.LastWindowPosY = this.Top;

                // 提交设置更改
                Properties.Settings.Default.Save();
            }

            if(e.ClickCount == 2)
            {
                this.Close();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double posX = Properties.Settings.Default.LastWindowPosX;
            double posY = Properties.Settings.Default.LastWindowPosY;

            // 确保设置了合理的默认值，防止无效值导致的异常
            if (double.IsNaN(posX) || double.IsNaN(posY))
            {
                posX = 100; // 或者其他默认位置
                posY = 100;
            }

            // 应用到窗口
            this.Left = posX;
            this.Top = posY;
        }

        private void spTitle_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //首先验证密码

            //尝试输入写入数据
        }
    }
}