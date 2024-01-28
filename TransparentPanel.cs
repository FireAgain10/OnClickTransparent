using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnClickTransparent
{
    internal class TransparentPanel : Panel

    {
        private bool hide = false;
        public TransparentPanel()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            hide = !hide;
            if (hide)
            {
                this.BackColor = Color.Transparent;
            }
            else
            {
                this.BackColor = Color.DeepSkyBlue;
            }
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            this.BackColor = Color.Transparent;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = Color.DeepSkyBlue;
        }
    }
}
