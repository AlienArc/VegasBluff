using System;
using System.Windows.Forms;
using Sony.Vegas;

namespace Bluff
{
    public class BluffCustomCommand : CustomCommand
    {
        public BluffCustomCommand(CommandCategory category, string name) : base(category, name)
        {
        }

        protected override void OnInvoked(EventArgs args)
        {
            try
            {
                base.OnInvoked(args);
            }
            catch (BluffException be)
            {
                MessageBox.Show(be.Message, "Bluff Vegas Extennsions", MessageBoxButtons.OK);
            }
        }
    }
}