using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Bluff.Wpf
{
    public class SimpleGrid : Grid
    {
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        private void ArrangeChildren()
        {
            var isHorizontal = this.Orientation == Orientation.Horizontal;
            var rowCount = this.RowDefinitions.Count;
            var columnCount = this.ColumnDefinitions.Count;

            if (isHorizontal && rowCount == 0 || !isHorizontal && columnCount == 0)
                return;

            var position = 0;
            foreach (UIElement child in Children)
            {
                if (isHorizontal)
                {
                    var row = Math.Min(position % rowCount, rowCount - 1);
                    var col = position / rowCount;

                    Grid.SetRow(child, row);
                    Grid.SetColumn(child, col);
                    position++;
                }
                else
                {
                    var row = position / columnCount;
                    var col = Math.Min(position % columnCount, columnCount - 1);

                    if (row >= rowCount)
                    {
                        RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                    }

                    Grid.SetRow(child, row);
                    Grid.SetColumn(child, col);
                    position++;
                }

            }

            if (isHorizontal)
            {
                var totalCols = (position / rowCount) + 1;
                if (totalCols < columnCount)
                {
                    ColumnDefinitions.RemoveRange(totalCols - 1, columnCount - totalCols);
                }
            }
            else
            {
                var totalRows = (position / columnCount) + 1;
                if (totalRows < rowCount)
                {
                    RowDefinitions.RemoveRange(totalRows, rowCount - totalRows);
                }
            }
        }

        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", typeof(Orientation), typeof(SimpleGrid),
                new FrameworkPropertyMetadata(Orientation.Horizontal, FrameworkPropertyMetadataOptions.AffectsMeasure));

        #region Overrides

        protected override Size MeasureOverride(Size constraint)
        {
            this.ArrangeChildren();
            return base.MeasureOverride(constraint);
        }

        #endregion Overrides
    }
}