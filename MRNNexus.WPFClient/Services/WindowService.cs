using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MRNNexus.WPFClient.Services
{
    class WindowService : IWindowService
    {
        public void showWindow(object viewModel)
        {
            var win = new Window();
            win.Content = viewModel;
            win.SizeToContent = SizeToContent.WidthAndHeight;
            win.WindowStyle = WindowStyle.ThreeDBorderWindow;
            win.ResizeMode = ResizeMode.NoResize;
            win.ShowDialog();
            
        }
    }
}
