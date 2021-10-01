using BeautySolutions.View.ViewModel;
using MaterialDesignThemes.Wpf;
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

namespace DropDownMenu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var menuRegister = new List<SubItem>();
            menuRegister.Add(new SubItem("hogrings", new UserControlCustomers()));
            menuRegister.Add(new SubItem("Jigy", new UserControlProviders()));
            menuRegister.Add(new SubItem("FPL"));
            menuRegister.Add(new SubItem("ASRS"));
            var item6 = new ItemMenu("Front Line", menuRegister, PackIconKind.Register);

            var menuSchedule = new List<SubItem>();
            menuSchedule.Add(new SubItem("Žehlicky"));
            menuSchedule.Add(new SubItem("testtest"));
            var item1 = new ItemMenu("Rearline", menuSchedule, PackIconKind.Schedule);

            

            Menu.Children.Add(new UserControlMenuItem(item6, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            
        }

        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);

            if(screen!=null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
