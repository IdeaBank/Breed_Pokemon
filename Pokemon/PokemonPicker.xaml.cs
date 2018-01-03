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

namespace Pokemon
{
    /// <summary>
    /// Interaction logic for PokemonPicker.xaml
    /// </summary>
    public partial class PokemonPicker : Window
    {
        private uint _Current_Exp = 0;
        private byte _Current_Pokemon = 0;

        private readonly string _ResourcePath =
            ((MainWindow)System.Windows.Application.Current.MainWindow).ResourcePath;

        public PokemonPicker()
        {
            InitializeComponent();

            System.Windows.Rect desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = 0;
            this.Top = 0;

            SizeChanged += ((MainWindow)System.Windows.Application.Current.MainWindow).Size_Changed;

            Set_Image();

            _Current_Pokemon = ((MainWindow)System.Windows.Application.Current.MainWindow).CurrentPokemon;
            PokemonName.Content = ((MainWindow)Application.Current.MainWindow).GetCurrentPokemon();

            _Current_Exp = ((MainWindow)System.Windows.Application.Current.MainWindow).CurrentExp;
            Exp.Content = "Exp : " + _Current_Exp.ToString();

            Pikachu_Image.MouseLeftButtonDown += (sender, EventArgs) => { Change_Pokemon(sender, EventArgs, 0); };
            Bulbasaur_Image.MouseLeftButtonDown += (sender, EventArgs) => { Change_Pokemon(sender, EventArgs, 1); };
            Charmander_Image.MouseLeftButtonDown += (sender, EventArgs) => { Change_Pokemon(sender, EventArgs, 2); };
            Squirtle_Image.MouseLeftButtonDown += (sender, EventArgs) => { Change_Pokemon(sender, EventArgs, 3); };
        }

        private void Change_Pokemon(object sender, EventArgs e, byte PokemonNumber)
        {
            _Current_Pokemon = ((MainWindow)System.Windows.Application.Current.MainWindow).CurrentPokemon = PokemonNumber;
            MessageBox.Show("Your pokemon changed into " + ((MainWindow)System.Windows.Application.Current.MainWindow).GetCurrentPokemon() + "!", "Information");
            ((MainWindow)System.Windows.Application.Current.MainWindow).Change_Pokemon_Image(_ResourcePath + ((MainWindow)System.Windows.Application.Current.MainWindow).GetCurrentPokemon() + "_Basic.png");
        }

        private void Set_Image()
        {
            try
            {
                Pikachu_Image.Source = new BitmapImage(new Uri(_ResourcePath + "Pikachu_Basic.png", UriKind.Absolute));
                Bulbasaur_Image.Source = new BitmapImage(new Uri(_ResourcePath + "Bulbasaur_Basic.png", UriKind.Absolute));
                Charmander_Image.Source = new BitmapImage(new Uri(_ResourcePath + "Charmander_Basic.png", UriKind.Absolute));
                Squirtle_Image.Source = new BitmapImage(new Uri(_ResourcePath + "Squirtle_Basic.png", UriKind.Absolute));
                Pokeball_Image.Source = new BitmapImage(new Uri(_ResourcePath + "Pokeball.png", UriKind.Absolute));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}