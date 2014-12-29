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
            using (var context = new TrayApplicationContext())
            {
                Application.Run(context);
            }
        }
    }

    internal class TrayApplicationContext : ApplicationContext
    {
        protected ContextMenuStrip _menuStrip;
        protected Container _components;
        protected NotifyIcon _notifyIcon;

        public TrayApplicationContext()
        {
            InitializeContext();    
        }

        private void InitializeContext()
        {
            _menuStrip = new ContextMenuStrip();
            _components = new System.ComponentModel.Container();
            _notifyIcon = new NotifyIcon(_components);

            _notifyIcon.ContextMenuStrip = _menuStrip;
            _notifyIcon.Icon = FormResources.ClockworkIcon;
            _notifyIcon.Text = FormResources.Clockwork;
            _notifyIcon.Visible = true;

            _notifyIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
            _notifyIcon.DoubleClick += notifyIcon_DoubleClick;
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
        }

        private void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
        }

        protected override void Dispose(bool disposing)
        {
            _menuStrip.Dispose();
            _components.Dispose();
            _notifyIcon.Dispose();

            base.Dispose(disposing);
        }
    }
}
