using Chess_GUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
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
using Chess_GUI.Models;

namespace Chess_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            //DataContext = new BoardViewModel();
        }

        private string move = "";

        private void SelectCell(string s)
        {
            if (move.Length == 4)
            {
                // Somehow notify the viewmodel of move & set up databinding
                return;
            }
            else
            {
                move += s;
                return;
            }
        }

        #region On_Click Event Region
        private void A8_OnClick(object sender, RoutedEventArgs e)
        {
            SelectCell("A8");
        }

        private void B8_OnClick(object sender, RoutedEventArgs e)
        {
            SelectCell("B8");
        }

        private void C8_OnClick(object sender, RoutedEventArgs e)
        {
            SelectCell("C8");
        }

        private void D8_OnClick(object sender, RoutedEventArgs e)
        {
            SelectCell("D8");
        }

        private void E8_OnClick(object sender, RoutedEventArgs e)
        {
            SelectCell("E8");
        }

        private void F8_OnClick(object sender, RoutedEventArgs e)
        {
            SelectCell("F8");
        }

        private void G8_OnClick(object sender, RoutedEventArgs e)
        {
            SelectCell("G8");
        }

        private void H8_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("H8");
        }



        private void A7_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("A7");
        }

        private void B7_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("B7");
        }

        private void C7_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("C7");
        }

        private void D7_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("D7");
        }

        private void E7_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("E7");
        }

        private void F7_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("F7");
        }

        private void G7_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("G7");
        }

        private void H7_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("H7");
        }



        private void A6_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("A6");
        }

        private void B6_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("B6");
        }

        private void C6_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("C6");
        }

        private void D6_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("D6");
        }

        private void E6_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("E6");
        }

        private void F6_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("F6");
        }

        private void G6_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("G6");
        }

        private void H6_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("H6");
        }



        private void A5_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("A5");
        }

        private void B5_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("B5");
        }

        private void C5_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("C5");
        }

        private void D5_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("D5");
        }

        private void E5_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("E5");
        }

        private void F5_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("F5");
        }

        private void G5_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("G5");
        }

        private void H5_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("H5");
        }



        private void A4_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("A4");
        }

        private void B4_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("B4");
        }

        private void C4_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("C4");
        }

        private void D4_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("D4");
        }

        private void E4_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("E4");
        }

        private void F4_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("F4");
        }

        private void G4_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("G4");
        }

        private void H4_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("H4");
        }



        private void A3_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("A3");
        }

        private void B3_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("B3");
        }

        private void C3_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("C3");
        }

        private void D3_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("D3");
        }

        private void E3_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("E3");
        }

        private void F3_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("F3");
        }

        private void G3_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("G3");
        }

        private void H3_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("H3");
        }



        private void A2_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("A2");
        }

        private void B2_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("B2");
        }

        private void C2_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("C2");
        }

        private void D2_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("D2");
        }

        private void E2_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("E2");
        }

        private void F2_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("F2");
        }

        private void G2_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("G2");
        }

        private void H2_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("H2");
        }



        private void A1_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("A1");
        }

        private void B1_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("B1");
        }

        private void C1_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("C1");
        }

        private void D1_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("D1");
        }

        private void E1_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("E1");
        }

        private void F1_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("F1");
        }

        private void G1_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("G1");
        }

        private void H1_OnClick(object sender, RoutedEventArgs e)
        {

            SelectCell("H1");
        }
        #endregion

    }
}
