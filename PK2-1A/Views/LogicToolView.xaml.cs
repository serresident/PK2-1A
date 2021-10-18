using belofor.ViewModels;
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

namespace belofor.Views
{
    /// <summary>
    /// Interaction logic for LogicToolView.xaml
    /// </summary>
    public partial class LogicToolView : UserControl
    {
        public LogicToolView()
        {
            InitializeComponent();
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            (this.DataContext as LogicViewModel).Subscribe();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            (this.DataContext as LogicViewModel).Unsubscribe();
        }
    }


}
