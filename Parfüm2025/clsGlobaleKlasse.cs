using Busnisse_Layer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parfüm2025
{
    public class clsGlobaleKlasse
    {
        private static readonly object _userLock = new object();
        private static clsUser _currentUser;
        public static clsUser currentUser
        {
            get { lock (_userLock) { return _currentUser; } }
            set { lock (_userLock) { _currentUser = value; } }
        }
    }
}
