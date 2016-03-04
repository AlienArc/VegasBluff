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

            menu.AddChild(BuildTrackMotionMenu());
            menu.AddChild(BuildEventMenu());
            menu.AddChild(BuildMarkerAndRegionMenu());

            return new[] { menu };
        }

        private CustomCommand BuildTrackMotionMenu()
        {
            var subMenu = new CustomCommand(CommandCategory.Tools, "BluffMotion")
            {
                DisplayName = "Motion"
            };

            subMenu.AddChild(GetCreateVideoWallCommand());
            subMenu.AddChild(GetTrackAlongBezierCommand());

            return subMenu;
        }

        private CustomCommand BuildEventMenu()
        {
            var subMenu = new CustomCommand(CommandCategory.Tools, "BluffEvent")
            {
                DisplayName = "Events"
            };

            subMenu.AddChild(GetOrderEventsByNameAndTimeCommand());
            subMenu.AddChild(GetOrderEventsByRandomCommand());

            return subMenu;
        }

        private CustomCommand BuildMarkerAndRegionMenu()
        {
            var subMenu = new CustomCommand(CommandCategory.Tools, "BluffMarkerAndRegion")
            {
                DisplayName = "Marker And Regions"
            };

            subMenu.AddChild(GetConvertMarkersToRegionsCommand());
            subMenu.AddChild(GetReorderMarkersCommand());
            subMenu.AddChild(GetSplitRegionCommand());

            return subMenu;
        }

        private CustomCommand GetCreateVideoWallCommand()
        {
            var cmd = new BluffCustomCommand(CommandCategory.Tools, "BluffCreateVideoWall");
            cmd.DisplayName = "Create Video Wall";
            cmd.Invoked += (sender, args) => { InsertVideoWall.Execute(CurrentVegas); };
            return cmd;
        }

        private CustomCommand GetOrderEventsByNameAndTimeCommand()
        {
            var cmd = new BluffCustomCommand(CommandCategory.Tools, "BluffOrderEventsByNameTime");
            cmd.DisplayName = "Order Events By Name and In Time";
            cmd.Invoked += (sender, args) => { OrderEventsByNameAndTime.Execute(CurrentVegas); };
            return cmd;
        }

        private CustomCommand GetOrderEventsByRandomCommand()
        {
            var cmd = new BluffCustomCommand(CommandCategory.Tools, "BluffRandomizeEvents");
            cmd.DisplayName = "Randomize Events";
            cmd.Invoked += (sender, args) => { OrderEventsByRandom.Execute(CurrentVegas); };
            return cmd;
        }

        private CustomCommand GetSplitRegionCommand()
        {
            var cmd = new BluffCustomCommand(CommandCategory.Tools, "BluffSplitRegion");
            cmd.DisplayName = "Split Region";
            cmd.Invoked += (sender, args) => { SplitRegion.Execute(CurrentVegas); };
            return cmd;
        }

        private CustomCommand GetConvertMarkersToRegionsCommand()
        {
            var cmd = new BluffCustomCommand(CommandCategory.Tools, "BluffConvertMarkersToRegions");
            cmd.DisplayName = "Convert Markers To Regions";
            cmd.Invoked += (sender, args) => { ConvertMarkersToRegions.Execute(CurrentVegas); };
            return cmd;
        }

        private CustomCommand GetTrackAlongBezierCommand()
        {
            var cmd = new BluffCustomCommand(CommandCategory.Tools, "BluffTrackAlongBezier");
            cmd.DisplayName = "Track Along Bezier";
            cmd.Invoked += (sender, args) => { TrackAlongBezier.Execute(CurrentVegas); };
            return cmd;
        }

        private CustomCommand GetReorderMarkersCommand()
        {
            var cmd = new BluffCustomCommand(CommandCategory.Tools, "BluffReorderMarkers");
            cmd.DisplayName = "Reorder Markers";
            cmd.Invoked += (sender, args) => { ReorderMarkers.Execute(CurrentVegas); };
            return cmd;
        }

    }
}