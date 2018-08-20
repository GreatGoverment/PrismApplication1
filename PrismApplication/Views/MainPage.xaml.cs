﻿using PrismApplication.Entity;
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

namespace PrismApplication.Views
{
    /// <summary>
    /// MainPage.xaml の相互作用ロジック
    /// </summary>
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
                ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password;
        }

        private void RunInternetLink(object sender, SelectionChangedEventArgs e)
        {
            HyperLinkItem item = InternetLinkListBox.SelectedItem as HyperLinkItem;
            System.Diagnostics.Process.Start(item.LinkURL);
        }

        private void DialogHost_DialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
            if (!Equals(eventArgs.Parameter, true)) return;

            System.Console.WriteLine("Title : " + TitleTextBox.Text + ", URL : " + URLTextBox.Text);
        }
    }
}
