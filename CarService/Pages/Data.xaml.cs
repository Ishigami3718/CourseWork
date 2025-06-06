﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
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

namespace CarService.Pages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Data : Page
    {
        //Requests table
        public ObservableCollection<RequestDTO> Requests { get; set; }
        public RequestDTO SelectedReq => (RequestDTO)DataGrid.SelectedItem;
        
        public Data(ObservableCollection<RequestDTO> requestsDTO)
        {
            InitializeComponent();
            //Requests = requestsDTO.Select(i=>new Request(i)).ToList();
            Requests= requestsDTO;
            DataContext = this;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).Update((RequestDTO)DataGrid.SelectedItem);
        }

        public void Redact(ObservableCollection<RequestDTO> requestsToSer)
        {
            try
            {
                RequestDTO toRedact = (RequestDTO)DataGrid.SelectedItem;
                if (toRedact != null)
                {
                    Window1 redacting = new Window1(toRedact, requestsToSer.IndexOf(toRedact));
                    redacting.ShowDialog();
                }
            }
            catch {  }
        }
    }
}
