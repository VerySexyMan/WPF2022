using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.FormatTheButton 
{ 
    public class FormatTheButton : Window 
    { 
        Run runButton;
        [STAThread] 
        public static void Main()
        { 
            Application app = new Application();
            app.Run(new FormatTheButton());
        } 
        public FormatTheButton()
        { 
            Title = "Format the Button";
            // Создайте кнопку и установите в качестве содержимого окна.
            Button btn = new Button();//создание кнопки             
            btn.HorizontalAlignment =  HorizontalAlignment.Center;
            btn.VerticalAlignment =  VerticalAlignment.Center; 
            btn.MouseEnter += ButtonOnMouseEnter;  
            btn.MouseLeave += ButtonOnMouseLeave;   
            Content = btn;
            // Создайте текстовый блок и установите в качестве содержимого кнопки.
            TextBlock txtblk = new TextBlock(); // создание текстовой облати   
            txtblk.FontSize = 24;     // размер шрифта    
            txtblk.TextAlignment = TextAlignment .Center;     
            btn.Content = txtblk;
            // Добавьте форматированный текст в текстовый блок.
            txtblk.Inlines.Add(new Italic(new Run ("Click")));   
            txtblk.Inlines.Add(" the ");       
            txtblk.Inlines.Add(runButton = new Run ("button"));  
            txtblk.Inlines.Add(new LineBreak());        
            txtblk.Inlines.Add("to launch the ");        
            txtblk.Inlines.Add(new Bold(new Run ("rocket")));    
        }      
        void ButtonOnMouseEnter(object sender,  MouseEventArgs args)   
        {    
            runButton.Foreground = Brushes.Red;  // цвет подсвечивания сдова
        }      
        void ButtonOnMouseLeave(object sender,  MouseEventArgs args)      
        {    
            runButton.Foreground = SystemColors .ControlTextBrush;  //цвет подсвечивания области     
        }   
    }
}