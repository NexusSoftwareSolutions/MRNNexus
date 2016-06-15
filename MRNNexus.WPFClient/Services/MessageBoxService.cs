using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MRNNexus.WPFClient.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        public bool AskForConfirmation(string message)
        {
            MessageBoxResult result = MessageBox.Show(message, "Are you sure?", MessageBoxButton.OKCancel);
            return result.HasFlag(MessageBoxResult.OK);
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
