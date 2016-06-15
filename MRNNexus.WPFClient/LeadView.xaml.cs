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
using System.Windows.Shapes;

namespace MRNNexus.WPFClient
{
    /// <summary>
    /// Interaction logic for LeadView.xaml
    /// </summary>
    public partial class LeadView : Window
    {
        private LeadViewModel _vm;
        public LeadView()
        {
            InitializeComponent();
            _vm = (this.DataContext as LeadViewModel);
            _vm.OnRequestClose += (s, e) => this.Close();
        }
    }
}
