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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleWpfStyleDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// 定义一个全局rect记录还原状态下窗口的位置和大小。
        /// </summary>
        Rect _rcnormal;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void btn_window_max_Click(object sender, RoutedEventArgs e)
        {
            string str_ = btn_window_max.Content.ToString();

            if (str_ == "最大化")
            {
                //this.WindowState = WindowState.Maximized;

                _rcnormal = new Rect(this.Left, this.Top, this.Width, this.Height);//保存下当前位置与大小
                this.Left = 0;//设置位置
                this.Top = 0;
                Rect rc = SystemParameters.WorkArea;//获取工作区大小
                this.Width = rc.Width;
                this.Height = rc.Height;

                btn_window_max.Content = "恢复";
            }
            else
            {
                //this.WindowState = WindowState.Normal;

                this.Left = _rcnormal.Left;
                this.Top = _rcnormal.Top;
                this.Width = _rcnormal.Width;
                this.Height = _rcnormal.Height;
                btn_window_max.Content = "最大化";
            }
        }

        private void btn_widow_min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btn_window_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void border_window_move_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

    }
}
