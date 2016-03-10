using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Bluff
{
    public partial class AboutBluff : Form
    {
        public AboutBluff()
        {
            InitializeComponent();

            var assembly = Assembly.GetExecutingAssembly();
            var exAsmVersion = assembly.GetName().Version.ToString();

            using (var rtfSource = assembly.GetManifestResourceStream("Bluff.Content.AboutBluff.rtf"))
            using (var reader = new StreamReader(rtfSource))
            {
                var rawRtf = reader.ReadToEnd();
                AboutInfo.Rtf = rawRtf.Replace("[VERSION]", exAsmVersion);
            }
            
        }
    }
}
