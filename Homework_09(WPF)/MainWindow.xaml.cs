using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Homework_09_WPF_
{
    /*Задание:
     
          Создать оконный интерфейс с использованием WPF для приложения из практической работы 5го модуля.

          В приложении реализовать следующую функциональность:

          1. Разделение строки на слова. Пользователь вводит предложение в компонент TextBox. 
             Каждое слово в этом предложении отделено пробелом. После нажатия на кнопку приложение 
             выводит каждое слово в отдельной строке в компоненте ListBox.

          2. Перестановка слов в предложении. Пользователь вводит в программе длинное предложение в TextBox. 
             Каждое слово в этом предложении отделено пробелом. После ввода текста пользователь нажимает на 
             вторую кнопку, и предложение выводится в компонент Label в обратном порядке. 
      
          Что оценивается:
             В работе используется WPF.
             В главном окне программы содержатся:
                - два компонента TextBox для ввода данных на каждую операцию;
                - два компонента Button для выполнения операций;
                - компонент ListBox для результата первого метода;
                - компонент Label для результата второго метода.*/

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Получает текст из Textbox и выводит каждое слово в отдельной строке в ListBox.
        /// </summary>
        /// <param name="TextBoxTxt"></param>
        private void GetWordsToListBox(string TextBoxTxt) 
        {
            string[] wordsArray = TextBoxTxt.Split(' ');

            foreach (string word in wordsArray)
            { 
                ListBox.Items.Add(word);          
            }
        }
        /// <summary>
        /// Получает текст из Textbox и выводит в Label предложение со словами в обратном порядке. 
        /// </summary>
        /// <param name="TextBoxTxt"></param>
        private void ReverseText(string TextBoxTxt) 
        {
            string[] wordsArray = TextBoxTxt.Split(' ');

            string reverseText = null;

            for (int i = wordsArray.Length - 1; i >= 0; i--)
            {
                reverseText += wordsArray[i] + " ";
            }

            TextBlockInLabel.Text = reverseText;
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (RadioBttn1.IsChecked == true)
            {
                ListBox.Items.Clear();

                GetWordsToListBox(TextBoxTxt.Text);
            }
            else if (RadioBttn2.IsChecked == true)
            {
                Label.Content = null;

                ReverseText(TextBoxTxt.Text);
            }
            else 
            {
                MessageBox.Show($"Не выбрано действие!", this.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
