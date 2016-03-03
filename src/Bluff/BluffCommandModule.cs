using System;
using System.Text;
using Sony.Vegas;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using Bluff.Commands;

namespace Bluff
{
    public class BluffCommandModule : ICustomCommandModule
    {

        Vegas CurrentVegas;

        public void InitializeModule(Vegas vegas)
        {
            CurrentVegas = vegas;
        }

        public ICollection GetCustomCommands()
        {

            var menu = new CustomCommand(CommandCategory.Tools, "Bluff")
            {
                DisplayName = "Bluff"
            };

            menu.AddChild(GetCreateVideoWallCommand());
            menu.AddChild(GetOrderEventsByNameAndTimeCommand());
            menu.AddChild(GetOrderEventsByRandomCommand());

            return new[] { menu };
        }

        private CustomCommand GetCreateVideoWallCommand()
        {
            var cmd = new CustomCommand(CommandCategory.Tools, "BluffCreateVideoWall");
            cmd.DisplayName = "Create Video Wall";
            cmd.Invoked += (sender, args) => { InsertVideoWallCommand.Execute(CurrentVegas); };
            return cmd;
        }

        private CustomCommand GetOrderEventsByNameAndTimeCommand()
        {
            var cmd = new CustomCommand(CommandCategory.Tools, "BluffOrderEventsByNameTime");
            cmd.DisplayName = "Order Events By Name and In Time";
            cmd.Invoked += (sender, args) => { OrderEventsByNameAndTimeCommand.Execute(CurrentVegas); };
            return cmd;
        }

        private CustomCommand GetOrderEventsByRandomCommand()
        {
            var cmd = new CustomCommand(CommandCategory.Tools, "BluffRandomizeEvents");
            cmd.DisplayName = "Randomize Events";
            cmd.Invoked += (sender, args) => { OrderEventsByRandomCommand.Execute(CurrentVegas); };
            return cmd;
        }


    }
}