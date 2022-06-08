using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Extra_7.Models;
using Extra_7.Views;

namespace Extra_7
{
    public partial class App : Application
    {
        public AdicionaVeículoWindow _AdicionaVeículoWindow { get; private set; }

        public App()
        {
            _AdicionaVeículoWindow = new AdicionaVeículoWindow();
        }
    }
}
