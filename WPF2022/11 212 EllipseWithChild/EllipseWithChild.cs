using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.EncloseElementInEllipse
{
    public class EllipseWithChild : Petzold.RenderTheBetterEllipse.BetterEllipse
    {
        UIElement child;
        //открытое свойство Child
         public UIElement Child
        {
            set //  вызов переопределенных методов 
            {
                if (child != null)
                {
                    RemoveVisualChild(child);
                    RemoveLogicalChild(child);
                }
                if ((child = value) != null) 
                { 
                    AddVisualChild(child); 
                    AddLogicalChild(child); 
                }
            }
            get
            {
                return child;
            }
        }
        // переопределение VisualChildrenCount возращает  1 если свойство Child отлично от null.
        protected override int VisualChildrenCount
        {
            get
            {
                return Child != null ? 1 : 0;
            }
        }
        // переопределение GetVisualChildren возращает Child.
        protected override Visual GetVisualChild(int index)
        {
            if (index > 0 || Child == null)
                throw new ArgumentOutOfRangeException("index");
            return Child;
        }
        // переопределение MeasureOverride вызывает Measure дочернего объекта
        protected override Size MeasureOverride(Size sizeAvailable)
        {
            Size sizeDesired = new Size(0, 0); // изменяем длину 
            if (Stroke != null)
            {
                sizeDesired.Width += 2 * Stroke.Thickness;
                sizeDesired.Height += 2 * Stroke.Thickness;
                sizeAvailable.Width = Math.Max(0, sizeAvailable.Width - 2 * Stroke.Thickness);
                sizeAvailable.Height =Math.Max(0, sizeAvailable.Height - 2 * Stroke.Thickness);
            }
            if (Child != null)
            {
                Child.Measure(sizeAvailable);
                sizeDesired.Width += Child.DesiredSize.Width;
                sizeDesired.Height += Child.DesiredSize.Height;
            }
            return sizeDesired;
        }
        // переопределение ArrangeOverride вызывает Arrange дочернего объекта
        protected override Size ArrangeOverride(Size sizeFinal)
        {
            if (Child != null)
            {
                Rect rect = new Rect(
                    new Point((sizeFinal.Width - Child.DesiredSize.Width) / 2,
                    (sizeFinal.Height - Child.DesiredSize.Height) / 2),
                    Child.DesiredSize); Child.Arrange(rect);
            }
            return sizeFinal;
        }
    }
}





