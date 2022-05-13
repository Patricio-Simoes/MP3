using Extra_5.Models;
using Extra_5.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Extra_5
{
    public partial class App : Application
    {
        // Model

        public ModelFile Model_File { get; set; }

        // Views

        public ViewReplaceWord View_ReplaceWord { get; set; }

        public App()
        {
            Model_File = new ModelFile();
            View_ReplaceWord = new ViewReplaceWord();
        }
    }
}
