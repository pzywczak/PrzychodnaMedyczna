﻿using System;
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
using System.Windows.Shapes;
using ViewWPF.Class;
using ViewWPF.baza;

namespace ViewWPF.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ListaWizyt.xaml
    /// </summary>
    public partial class ListaWizyt : Window
    {
        public List<Pacjenci> MoiWizyty { get; set; }
        public ListaWizyt()
        {
            InitializeComponent();
         
            DataContext = this;
            dataGrid.Items.Refresh();
        }
    }
}
