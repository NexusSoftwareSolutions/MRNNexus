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


using MRNNexus.WPFClient.ViewModels;

namespace MRNNexus.WPFClient
{
    /// <summary>
    /// Interaction logic for NewInspection.xaml
    /// </summary>
    public partial class InspectionView : Page
    {
        private InspectionViewModel _vm;

        public InspectionView()
        {
            setUp();
        }

        async private void setUp()
        {
            //AccountSelect accts = new AccountSelect();
            //accts.ShowDialog();
            _vm = await InspectionViewModel.CreateAsync();
            
            this.DataContext = _vm;
            InitializeComponent();

        }
    }
}
