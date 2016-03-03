using System;
using System.Collections.Generic;
using System.Text;
using Sony.Vegas;

namespace Bluff.Commands
{
    public class SplitRegion
    {
        public static void Execute(Vegas vegas)
        {
            var currentPosition = vegas.Transport.CursorPosition;

            var proj = vegas.Project;
            foreach (var region in proj.Regions)
            {
                if (region.Position < currentPosition && region.End > currentPosition)
                {
                    using (var undo = new UndoBlock("Split Region"))
                    {
                        var endingPosition = region.End;
                        region.End = currentPosition;
                        proj.Regions.Add(new Region(currentPosition, endingPosition - currentPosition));
                    }
                    break;
                }
            }

        }
    }
}
