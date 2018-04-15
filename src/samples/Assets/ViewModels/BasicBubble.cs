﻿using LiveCharts.Core.Abstractions.DataSeries;
using LiveCharts.Core.Collections;
using LiveCharts.Core.DataSeries;
using LiveCharts.Core.Defaults;
using LiveCharts.Core.Drawing.Svg;

namespace Assets.ViewModels
{
    public class BasicBubble
    {
        public BasicBubble()
        {
            var bubbleSeries = new BubbleSeries<WeightedModel>();

            // add some values to the series...
            //                                 x, y, weight
            bubbleSeries.Add(new WeightedModel(0, 4, 23));
            bubbleSeries.Add(new WeightedModel(3, 2, 55));
            bubbleSeries.Add(new WeightedModel(2, 0, 17));
            bubbleSeries.Add(new WeightedModel(1, 3, 46));

            // we added 4 points
            // the first point has an X eq to 0, a Y eq to 4 and
            // a weight eq to 23
            // every bubble size will be scaled according to its weight
            // in our case 55 will be the bigger bubble, and 17 the smaller
            // now lets set the max and min size for our bubbles

            bubbleSeries.MaxGeometrySize = 400; // when w = 55, our geometry size will be 400
            bubbleSeries.MinGeometrySize = 150;  // when w = 17 our geometry size will be 150

            // lets set a custom geometry, a square
            bubbleSeries.Geometry = Geometry.Square;

            // create a collection to store our series.
            // you can use any IEnumerable, it is recommended to use
            // the ChartingCollection<T> class, it inherits from
            // ObservableCollection and adds the AddRange/RemoveRange methods
            SeriesCollection = new ChartingCollection<ISeries>();
            // finally lets add the series to our series collection,
            // we can add as many series as we need, in this case we will
            // only display one series.
            SeriesCollection.Add(bubbleSeries);
            // we bind the SeriesCollection property to the CartesianChart.Series property in XAML
        }

        public ChartingCollection<ISeries> SeriesCollection { get; set; }
    }
}