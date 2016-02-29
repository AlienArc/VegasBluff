using System;
using System.Text;
using Sony.Vegas;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

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
            
            var menu = new CustomCommand(CommandCategory.Tools, "NewmanVegasTools");
            menu.DisplayName = "Duane's Vegas Tools";

            menu.AddChild(GetCreateVideoWallCommand());
            menu.AddChild(GetOrderEventsByNameAndTimeCommand());

            return new CustomCommand[] { menu };
        }

        private CustomCommand GetOrderEventsByNameAndTimeCommand()
        {
            var cmd = new CustomCommand(CommandCategory.Tools, "NewmanOrderEventsByNameTime");
            cmd.DisplayName = "Order Events By Name and In Time";
            cmd.Invoked += this.OrderEventsByNameAndTimeInvoked;
            return cmd;
        }

        private void OrderEventsByNameAndTimeInvoked(object sender, EventArgs e)
        {
            OrderEventsByNameAndTimeCommand.Execute(CurrentVegas);
        }

        private CustomCommand GetCreateVideoWallCommand()
        {
            var cmd = new CustomCommand(CommandCategory.Tools, "NewmanCreateVideoWall");
            cmd.DisplayName = "Create Video Wall";
            cmd.Invoked += this.VideoWallInvoked;
            return cmd;
        }

        void VideoWallInvoked(Object sender, EventArgs args)
        {
            InsertVideoWallCommand.Execute(CurrentVegas);
        }

    }
}