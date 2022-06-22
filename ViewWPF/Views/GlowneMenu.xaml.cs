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

namespace ViewWPF.Views
{
    /// <summary>
    /// Interaction logic for GlowneMenu.xaml
    /// </summary>
    public partial class GlowneMenu : Window
    {
        public GlowneMenu()
        {
            InitializeComponent();
        }

        private void Wyjdz_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void zarejestrujPacjenta_Click(object sender, RoutedEventArgs e)
        {
            CadastrarPaciente cp = new CadastrarPaciente();
            cp.Show();
        }

        private void zarejestrujLekarza_Click(object sender, RoutedEventArgs e)
        {
            CadastrarMedico cm = new CadastrarMedico();
            cm.Show();
        }

        private void zarejestrujUzytkownika_Click(object sender, RoutedEventArgs e)
        {
            rejstracjaUzytkownika cu = new rejstracjaUzytkownika();
            cu.Show();
        }

        private void ListaLekarzy_Click(object sender, RoutedEventArgs e)
        {
            MedicosCadastrados mc = new MedicosCadastrados();
            mc.Show();
        }

        private void ListaPacjentow_Click(object sender, RoutedEventArgs e)
        {
            PacientesCadastrados pc = new PacientesCadastrados();
            pc.Show();
        }
    }
}