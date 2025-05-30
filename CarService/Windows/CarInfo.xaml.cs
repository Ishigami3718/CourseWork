﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace CarService.Windows
{
    /// <summary>
    /// Interaction logic for CarInfo.xaml
    /// </summary>
    public partial class CarInfo : Window
    {
        public ObservableCollection<CarDTO> Car {  get; set; } = new ObservableCollection<CarDTO>();
        public CarInfo(CarDTO car)
        {
            InitializeComponent();
            Car.Add(car);
            DataContext = this;
        }
    }
}
