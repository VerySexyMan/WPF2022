﻿< Window xmlns = "http://schemas.microsoft.com/winfx/ 2006/xaml/presentation"
        Title = "Load Xaml Window"
        SizeToContent = "WidthAndHeight"
        ResizeMode = "CanMinimize" >
    < StackPanel >

        < Button HorizontalAlignment = "Center"
            Margin = "24" >
        Hello, XAML!
    </ Button >

    < Ellipse Width = "200"
        Height = "100"
        Margin = "24"
        Stroke = "Red"
        StrokeThickness = "10" />
    < ListBox Width = "100"
        Height = "100"
        Margin = "24" >
    < ListBoxItem > Sunday </ ListBoxItem >
    < ListBoxItem > Monday </ ListBoxItem >
    < ListBoxItem > Tuesday </ ListBoxItem >
    < ListBoxItem > Wednesday </ ListBoxItem >
    < ListBoxItem > Thursday </ ListBoxItem >
    < ListBoxItem > Friday </ ListBoxItem >
    < ListBoxItem > Saturday </ ListBoxItem >
    </ ListBox >
   </ StackPanel >
</ Window >
