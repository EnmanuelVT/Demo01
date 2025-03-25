using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace Demo19WindowsService
{
    [RunInstaller(true)]
    public partial class d: System.Configuration.Install.Installer
    {
        public d()
        {
            InitializeComponent();
        }
    }
}
