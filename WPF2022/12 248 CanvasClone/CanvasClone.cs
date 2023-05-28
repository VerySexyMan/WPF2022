using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.PaintOnCanvasClone
{
    public class CanvasClone : Panel
    {
        // определение двух зависимых свойств 
        public static readonly DependencyProperty LeftProperty;
        public static readonly DependencyProperty TopProperty;
        static CanvasClone()
        {
            //Регистрация зависимых свойств как присоединенных    
            // Значение по умолчанию равно 0. при любом изменении размещение родителя становистя недействительным
            LeftProperty = DependencyProperty.RegisterAttached("Left",
                typeof(double), typeof(CanvasClone),
                new FrameworkPropertyMetadata(0.0,
                FrameworkPropertyMetadataOptions.AffectsParentArrange));
            TopProperty = DependencyProperty.RegisterAttached("Top",
                typeof(double), typeof(CanvasClone),
                new FrameworkPropertyMetadata(0.0,
                FrameworkPropertyMetadataOptions.AffectsParentArrange));
        }
        //Статические методы для чтения и записи присоединенных свойств 
        public static void SetLeft(DependencyObject obj, double value)
        {
            obj.SetValue(LeftProperty, value);
        }
        public static double GetLeft(DependencyObject obj)
        {
            return (double)obj.GetValue(LeftProperty);
        }
        public static void SetTop(DependencyObject obj, double value)
        {
            obj.SetValue(TopProperty, value);
        }
        public static double GetTop(DependencyObject obj)
        {
            return (double)obj.GetValue(TopProperty);
        }
        // Переопределение MeasureOverride просто вызывает  Measure для дочерних объектов
        protected override Size MeasureOverride(Size sizeAvailable)
        {
            foreach (UIElement child in InternalChildren)
                child.Measure(new Size(Double.PositiveInfinity,
                    Double.PositiveInfinity));
            // По умолчанию возврощает (0, 0).
            return base.MeasureOverride(sizeAvailable);
        }
        //Переопределение ArrangeOverride размещает дочерние объекты.
        protected override Size ArrangeOverride(Size sizeFinal)
        {
            foreach (UIElement child in InternalChildren)
                child.Arrange(new Rect(new Point(GetLeft(child), GetTop(child)), child.DesiredSize));
            return sizeFinal;
        }
    }
}


