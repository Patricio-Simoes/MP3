using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Extra_3.Models;
using Extra_3.Views;

namespace Extra_3
{
    public partial class App : Application
    {
        // Views
        public AdicionarMovimento _AdicionarMovimento { get; private set; }

        // Models
        public ModelMovimento _ModelMovimento { get; private set; }

        public App()
        {
            // Views

            _AdicionarMovimento = new AdicionarMovimento();

            // Models

            _ModelMovimento = new ModelMovimento();
        }
    }
}
