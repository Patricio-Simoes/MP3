using Extra_4.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Extra_4
{
    public partial class App : Application
    {
        // Model

        public ModelFile Model_File { get; set; }

        public App()
        {
            Model_File = new ModelFile();
        }
    }
}
