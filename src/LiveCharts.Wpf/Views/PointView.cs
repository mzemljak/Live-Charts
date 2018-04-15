﻿#region License
// The MIT License (MIT)
// 
// Copyright (c) 2016 Alberto Rodríguez Orozco & LiveCharts contributors
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy 
// of this software and associated documentation files (the "Software"), to deal 
// in the Software without restriction, including without limitation the rights to 
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies 
// of the Software, and to permit persons to whom the Software is furnished to 
// do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all 
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR 
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

#region

using System;
using System.Drawing;
using System.Windows;
using LiveCharts.Core.Abstractions;
using LiveCharts.Core.Abstractions.DataSeries;
using LiveCharts.Core.Events;
using LiveCharts.Core.Interaction;

#endregion

namespace LiveCharts.Wpf.Views
{
    public class PointView<TModel, TCoordinate, TViewModel, TSeries, TShape, TLabel>
        : IPointView<TModel, TCoordinate, TViewModel, TSeries>
        where TCoordinate : ICoordinate
        where TSeries : ISeries
        where TShape : FrameworkElement, new()
        where TLabel : DependencyObject, IDataLabelControl, new()
    {
        /// <summary>
        /// Gets or sets the shape.
        /// </summary>
        /// <value>
        /// The shape.
        /// </value>
        public TShape Shape { get; protected set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public TLabel Label { get; protected set; }

        /// <inheritdoc cref="DrawShape"/>
        protected virtual void OnDraw(Point<TModel, TCoordinate, TViewModel, TSeries> point, Point<TModel, TCoordinate, TViewModel, TSeries> previous)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="DrawLabel"/>
        protected virtual void OnDrawLabel(Point<TModel, TCoordinate, TViewModel, TSeries> point, PointF location)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="Dispose"/>
        protected virtual void OnDispose(IChartView chart)
        {
            throw new NotImplementedException();
        }

        #region ResourceViewImplementation


        /// <inheritdoc />
        object IPointView<TModel, TCoordinate, TViewModel, TSeries>.VisualElement => Shape;

        /// <inheritdoc />
        IDataLabelControl IPointView<TModel, TCoordinate, TViewModel, TSeries>.Label => Label;

        /// <inheritdoc />
        public void DrawShape(Point<TModel, TCoordinate, TViewModel, TSeries> point, Point<TModel, TCoordinate, TViewModel, TSeries> previous)
        {
            OnDraw(point, previous);
        }

        /// <inheritdoc />
        public void DrawLabel(Point<TModel, TCoordinate, TViewModel, TSeries> point, PointF location)
        {
            OnDrawLabel(point, location);
        }

        public event DisposingResourceHandler Disposed;

        object IResource.UpdateId { get; set; }

        /// <inheritdoc />
        public void Dispose(IChartView view)
        {
            OnDispose(view);
            Disposed?.Invoke(view, this);
        }

        #endregion
    }
}