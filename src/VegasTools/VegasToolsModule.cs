using System;
using System.Text;
using Sony.Vegas;
using System.Collections;

namespace VegasTools
{
    public class VegasToolsModule : ICustomCommandModule
    {

        Vegas CurrentVegas;

        public void InitializeModule(Vegas vegas)
        {
            CurrentVegas = vegas;
        }

        public ICollection GetCustomCommands()
        {
            var cmd = new CustomCommand(CommandCategory.Tools, "VideoWall");
            cmd.DisplayName = "Insert Video Wall";
            cmd.Invoked += this.VideoWallInvoked;
            return new CustomCommand[] { cmd };
        }

        void VideoWallInvoked(Object sender, EventArgs args)
        {
            InsertVideoWallCommand.Execute(CurrentVegas);
        }

    }
}