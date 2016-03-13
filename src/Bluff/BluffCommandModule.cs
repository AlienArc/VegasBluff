using System;
using System.Text;
using Sony.Vegas;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using Bluff.Commands;

namespace Bluff
{
    public delegate void VegasCommandDelegate(Vegas vegas);

    public class BluffCommandModule : ICustomCommandModule
    {
        private Vegas CurrentVegas { get; set; }

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

            menu.AddChild(CreateToolMenuItem("BluffZZZHelpAbout", "About Bluff", ShowAboutBluff));
            return new[] { menu };
        }

        private CustomCommand BuildTrackMotionMenu()
        {
            var subMenu = new CustomCommand(CommandCategory.Tools, "BluffMotion")
            {
                DisplayName = "Motion"
            };

            subMenu.AddChild(CreateToolMenuItem("BluffCreateVideoWall", "Create Video Wall", InsertVideoWall.Execute));
#if DEBUG
            subMenu.AddChild(CreateToolMenuItem("BluffTrackAlongBezier", "Track Along Bezier", TrackAlongBezier.Execute));
#endif
            return subMenu;
        }

        private CustomCommand BuildEventMenu()
        {
            var subMenu = new CustomCommand(CommandCategory.Tools, "BluffEvent")
            {
                DisplayName = "Events"
            };

            subMenu.AddChild(CreateToolMenuItem("BluffArrangeEventsByCreatedTimestamp", "Arrange Events By Created Timestamp", ArrangeEventsByCreatedTimestamp.Execute));
            subMenu.AddChild(CreateToolMenuItem("BluffOrderEventsByNameTime", "Order Events By Name and In Time", OrderEventsByNameAndTime.Execute));
            subMenu.AddChild(CreateToolMenuItem("BluffRandomizeEvents", "Randomize Events", OrderEventsByRandom.Execute));

            return subMenu;
        }

        private CustomCommand BuildMarkerAndRegionMenu()
        {
            var subMenu = new CustomCommand(CommandCategory.Tools, "BluffMarkerAndRegion")
            {
                DisplayName = "Marker And Regions"
            };

            subMenu.AddChild(CreateToolMenuItem("BluffConvertMarkersToRegions", "Convert Markers To Regions", ConvertMarkersToRegions.Execute));
            subMenu.AddChild(CreateToolMenuItem("BluffReorderMarkers", "Reorder Markers and Regions", ReorderMarkers.Execute));
            subMenu.AddChild(CreateToolMenuItem("BluffSplitRegion", "Split Region", SplitRegion.Execute));
            
            return subMenu;
        }
        private void ShowAboutBluff(Vegas vegas)
        {
            var aboutBluff = new AboutBluff();
            aboutBluff.ShowDialog();
        }

        private BluffCustomCommand CreateToolMenuItem(string menuName, string display, VegasCommandDelegate command)
        {
            var cmd = new BluffCustomCommand(CommandCategory.Tools, menuName);
            cmd.DisplayName = display;
            cmd.Invoked += (sender, args) => { command(CurrentVegas); };
            return cmd;
        }

    }
}