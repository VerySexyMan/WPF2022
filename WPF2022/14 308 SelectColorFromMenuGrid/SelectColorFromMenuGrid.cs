using Petzold.SelectColorFromGrid;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.SelectColorFromMenuGrid
{
    public class SelectColorFromMenuGrid : Window
    {
        [STAThread] public static void Main() { Application app = new Application(); app.Run(new SelectColorFromMenuGrid()); }
        public SelectColorFromMenuGrid()
        {
            Title = "Select Color from Menu Grid";

            //Создание объекта DockPanel.
            DockPanel dock = new DockPanel();
            Content = dock;

            // Создание меню. пристыковонного у верхнего края окна 
            Menu menu = new Menu();
            dock.Children.Add(menu);
            DockPanel.SetDock(menu, Dock.Top);

            // создание объекта TextBlock заполняющего оставшуюся площадь
            TextBlock text = new TextBlock();
            text.Text = Title; 
            text.FontSize = 32; 
            text.TextAlignment = TextAlignment.Center;
            dock.Children.Add(text);

            // Включение команд в меню
            MenuItem itemColor = new MenuItem();
            itemColor.Header = "_Color";
            menu.Items.Add(itemColor);
            MenuItem itemForeground = new MenuItem();
            itemForeground.Header = "_Foreground";
            itemColor.Items.Add(itemForeground);

            // Создание объекта ColorGridBox и его привязка к свойству Foreground окна
            ColorGridBox clrbox = new ColorGridBox();
            clrbox.SetBinding(ColorGridBox.SelectedValueProperty, "Foreground");
            clrbox.DataContext = this;
            itemForeground.Items.Add(clrbox);
            MenuItem itemBackground = new MenuItem();
            itemBackground.Header = "_Background";
            itemColor.Items.Add(itemBackground);

            // Создание объекта ColorGridBox и его привязка к свойству Background окна
            / clrbox = new ColorGridBox();
            clrbox.SetBinding(ColorGridBox.SelectedValueProperty, "Background");
            clrbox.DataContext = this;
            itemBackground.Items.Add(clrbox);
        }
    }
}

