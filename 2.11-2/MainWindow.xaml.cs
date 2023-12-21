using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace _2._11_2
{
    public partial class MainWindow : Window
    {
        private string _userKey = "pro";
        TextBox tb; 
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _userKey == "pro" || _userKey == "trial";
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, "Новый файл создан");
            }
        }

        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _userKey == "pro" || _userKey == "trial";
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string fileContent = File.ReadAllText(openFileDialog.FileName);
                tb.Text = fileContent;
            }
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _userKey == "pro" || _userKey == "trial";
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, tb.Text);
            }
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CutCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _userKey == "pro";
        }

        private void CutCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (tb != null)
            {
                Clipboard.SetText(tb.SelectedText);
                tb.Text = tb.Text.Remove(tb.SelectionStart, tb.SelectionLength);
            }
        }

        private void CopyCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _userKey == "pro";
        }

        private void CopyCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Clipboard.SetText(tb.Text);
        }

        private void PasteCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _userKey == "pro";
        }

        private void PasteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                tb.Text = Clipboard.GetText();
            }
        }

    }
}