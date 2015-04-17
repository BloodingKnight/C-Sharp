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

namespace PrimitiveDataTypes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem selectedtype = (type.SelectedItem as ListBoxItem);
            switch (selectedtype.Content.ToString())
            {
                case "float":
                    showFloatValue();
                    break;
                case "int":
                    showIntValue();
                    break;
                case "double":
                    showDoubleValue();
                    break;
                case "bool":
                    showBoolValue();
                    break;
            }
        }

        private void showBoolValue()
        {
            bool boolVar;
            boolVar = false;
            value.Text = boolVar.ToString();
        }

        private void showDoubleValue()
        {
            double doubleVar;
            doubleVar = (0.0 / 0.0) * (0.42 / 0.0);
            value.Text = doubleVar.ToString();
        }

        private void showIntValue()
        {
            int intVar;
            intVar = 42;
            value.Text = intVar.ToString();
        }

        private void showFloatValue()
        {
            float floatVar;
            floatVar = 0.42F;
            value.Text = floatVar.ToString();
        }
    }
}
