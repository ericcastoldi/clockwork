using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clockwork.Presentation.Tray
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var context = new TrayApplicationContext();
            Application.Run(context);
        }
    }

    internal class TrayApplicationContext : ApplicationContext
    {
        protected Container _components;
        protected NotifyIcon _notifyIcon;

        public TrayApplicationContext()
        {
            InitializeContext();    
        }

        private void InitializeContext()
        {
            _components = new System.ComponentModel.Container();
            _notifyIcon = new NotifyIcon(_components)
            {
                ContextMenuStrip = new ContextMenuStrip(),
                Icon = FormResources.ClockworkIcon,
                Text = "Clockwork",
                Visible = true
            };
            _notifyIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
            _notifyIcon.DoubleClick += notifyIcon_DoubleClick;
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
