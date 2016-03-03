﻿using System;
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
            menu.AddChild(GetSplitRegionCommand());
            menu.AddChild(GetConvertMarkersToRegionsCommand());

            return new[] { menu };
        }

        private CustomCommand GetCreateVideoWallCommand()
        {
            var cmd = new CustomCommand(CommandCategory.Tools, "BluffCreateVideoWall");
            cmd.DisplayName = "Create Video Wall";
            cmd.Invoked += (sender, args) => { InsertVideoWall.Execute(CurrentVegas); };
            return cmd;
        }

        private CustomCommand GetOrderEventsByNameAndTimeCommand()
        {
            var cmd = new CustomCommand(CommandCategory.Tools, "BluffOrderEventsByNameTime");
            cmd.DisplayName = "Order Events By Name and In Time";
            cmd.Invoked += (sender, args) => { OrderEventsByNameAndTime.Execute(CurrentVegas); };
            return cmd;
        }

        private CustomCommand GetOrderEventsByRandomCommand()
        {
            var cmd = new CustomCommand(CommandCategory.Tools, "BluffRandomizeEvents");
            cmd.DisplayName = "Randomize Events";
            cmd.Invoked += (sender, args) => { OrderEventsByRandom.Execute(CurrentVegas); };
            return cmd;
        }

        private CustomCommand GetSplitRegionCommand()
        {
            var cmd = new CustomCommand(CommandCategory.Tools, "BluffSplitRegion");
            cmd.DisplayName = "Split Region";
            cmd.Invoked += (sender, args) => { SplitRegion.Execute(CurrentVegas); };
            return cmd;
        }

        private CustomCommand GetConvertMarkersToRegionsCommand()
        {
            var cmd = new CustomCommand(CommandCategory.Tools, "BluffConvertMarkersToRegions");
            cmd.DisplayName = "Convert Markers To Regions";
            cmd.Invoked += (sender, args) => { ConvertMarkersToRegions.Execute(CurrentVegas); };
            return cmd;
        }

    }
}