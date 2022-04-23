using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WpfWcfClient.Calculator;

namespace WpfWcfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        CalculatorClient client;
        public double Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Result"));
            }
        }
        double _result;


        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            client = new CalculatorClient();
        }

        private bool TxbToDouble(ref double xout, ref double yout)
        {
            double x, y;
            if (!double.TryParse(txbX.Text, out x))
                return false;
            if (!double.TryParse(txbY.Text, out y))
                return false;
            xout = x;
            yout = y;
            return true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            double x = 0, y = 0;
            if(TxbToDouble(ref x, ref y))
            {
                Result = client.Add(x, y);
            }
        }

        private void btnSubstract_Click(object sender, RoutedEventArgs e)
        {
            double x = 0, y = 0;
            if (TxbToDouble(ref x, ref y))
            {
                Result = client.Substract(x, y);
            }
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            double x = 0, y = 0;
            if (TxbToDouble(ref x, ref y))
            {
                Result = client.Multiply(x, y);
            }
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            double x = 0, y = 0;
            if (TxbToDouble(ref x, ref y))
            {
                Result = client.Divide(x, y);
            }
        }
    }
}
