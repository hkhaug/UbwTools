using System;
using System.Windows.Forms;

namespace UbwTools.Common.Gui
{
    public class WaitingCursor : IDisposable
    {
        private readonly Control _control;

        public WaitingCursor()
        {
            _control = null;
            Cursor.Current = Cursors.WaitCursor;
            Application.UseWaitCursor = true;
            Application.DoEvents();
        }

        public WaitingCursor(Control control)
        {
            _control = control;
            Cursor.Current = Cursors.WaitCursor;
            control.UseWaitCursor = true;
            Application.DoEvents();
        }

        public void StopWaiting()
        {
            if (null == _control)
            {
                Application.UseWaitCursor = false;
            }
            else
            {
                _control.UseWaitCursor = false;
            }
            Cursor.Current = Cursors.Default;
        }

        public void Dispose()
        {
            StopWaiting();
        }
    }
}
