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
    /// Interaction logic for AccountSelect.xaml
    /// </summary>
    public partial class AccountSelectView : Page
    {
        private AccountSelectViewModel _vm;

        public AccountSelectView()
        {
            setUp(0);
        }

        public AccountSelectView(int code)
        {
            setUp(code);
        }

        public AccountSelectView(object context)
        {
            _vm = context as AccountSelectViewModel;
            
            this.DataContext = _vm;
            InitializeComponent();
        }

        async private void setUp(int code)
        {
            _vm = await AccountSelectViewModel.CreateAsync(code);
            //_vm.OnRequestClose += (s, e) => this.Close();
            InitializeComponent();
            this.DataContext = _vm;
        }
    }
}
