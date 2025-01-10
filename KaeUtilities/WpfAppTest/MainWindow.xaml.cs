﻿using Kae.Utility.Logging;
using Kae.Utility.Logging.WPF;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            string selectedLevel = (string)((ComboBoxItem)cbLevel.SelectedItem).Content;
            if (selectedLevel == "Info")
            {
                logger.LogInfo(tbText.Text);
            }
            else if (selectedLevel == "Warn")
            {
                logger.LogWarning(tbText.Text);
            }
            else
            {
                Exception ex = null;
                if (cbWithException.IsChecked.Value)
                {
                    var buf = new int[10];
                    try
                    {
                        int x = buf[buf.Length];
                    }
                    catch(Exception exx)
                    {
                        ex = exx;
                    }
                }
                logger.LogError(tbText.Text, ex);
            }
        }

        Logger logger;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            logger = WPFLogger.CreateLogger(tbLog);
        }
    }
}