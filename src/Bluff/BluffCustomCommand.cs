using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Forms;
using Sony.Vegas;

namespace Bluff
{
    public class BluffCustomCommand : CustomCommand
    {
        public BluffCustomCommand(CommandCategory category, string name) : base(category, name)
        {
            IconFile = WriteResourceToFile(name);
        }

        public BluffCustomCommand(CommandCategory category, string name, string displayName) : base(category, name)
        {
            DisplayName = displayName;
            IconFile = WriteResourceToFile(name);
        }

        protected override void OnInvoked(EventArgs args)
        {
            try
            {
                base.OnInvoked(args);
            }
            catch (BluffException be)
            {
                MessageBox.Show(be.Message, "Bluff Vegas Extensions", MessageBoxButtons.OK);
            }
        }

        private static string WriteResourceToFile(string imageResourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var tempPath = Path.Combine(Path.GetTempPath(),
                string.Format("VegasBluff-{0}", assembly.GetName().Version.Major));
            var fileName = Path.Combine(tempPath, string.Format("{0}.png", imageResourceName));
            var resourceName = string.Format("Bluff.Images.{0}.png", imageResourceName);

            if (File.Exists(fileName)) return fileName;

            using (var resource = assembly.GetManifestResourceStream(resourceName))
            {
                if (resource == null) return string.Empty;

                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }

                using (var file = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    while (true)
                    {
                        var buffer = new byte[1024];
                        var byteCount = resource.Read(buffer, 0, buffer.Length);
                        if (byteCount > 0)
                        {
                            file.Write(buffer, 0, byteCount);
                        }
                        else
                        {
                            return fileName;
                        }
                    }
                }
            }
        }
    }
}