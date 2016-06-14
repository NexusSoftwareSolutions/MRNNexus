using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNNexus.WPFClient.Services
{
    public interface IMessageBoxService
    {
        void ShowError(string message);
        bool AskForConfirmation(string message);
    }
}
