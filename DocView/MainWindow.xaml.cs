using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BusinessLogic.Logic;

namespace DocView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        private void AddFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "docx|*.docx";

            if ((bool)dialog.ShowDialog())
            {
                try
                {
                    SaveLogic.AddFile(dialog.FileName);
                    MessageBox.Show("В грядку попал новый овощ", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            Load();
        }
        private void Load()
        {
            Listbox.ItemsSource = LoadLogic.GetListDocs();
        }

        private void Listbox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(Listbox.SelectedIndex == -1)
            {
                MessageBox.Show("Овощей пока еще не завезли", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            try
            {
                var dialog = new SaveFileDialog();
                dialog.Filter = "docx|*.docx";
                dialog.FileName = Listbox.SelectedValue.ToString();
                if ((bool)dialog.ShowDialog())
                {
                    TakeLogic.TakeFile(dialog.FileName, Listbox.SelectedValue.ToString());
                    MessageBox.Show("Сделано", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteFile_Click(object sender, RoutedEventArgs e)
        {
            if (Listbox.SelectedIndex == -1)
            {
                MessageBox.Show("Овощей пока еще не завезли", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            SaveLogic.DeleteFile(Listbox.SelectedValue.ToString());
            Load();
        }
    }
}
