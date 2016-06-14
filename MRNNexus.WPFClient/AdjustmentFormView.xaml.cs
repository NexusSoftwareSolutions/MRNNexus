using MRNNexus.WPFClient.ViewModels;
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

namespace MRNNexus.WPFClient
{
    /// <summary>
    /// Interaction logic for AdjustmentFormView.xaml
    /// </summary>
    public partial class AdjustmentFormView : Window
    {
        private AdjustmentFormViewModel _vm;
        public AdjustmentFormView()
        {
            InitializeComponent();
            _vm = (this.DataContext as AdjustmentFormViewModel);
            _vm.OnRequestClose += (s, e) => this.Close();
        }
    }
}
