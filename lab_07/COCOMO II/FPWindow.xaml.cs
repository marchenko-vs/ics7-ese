using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace COCOMO
{
    public partial class FPWindow : Window
    {
        public FPWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double fp = CountFP();
            double correctedFP = CountFP() * (0.65 + 0.01 * CountRegulizer());
            double kloc = fp * Convert.ToDouble(ProgLang.SelectedValue) / 1000;
            double correctedKloc = correctedFP * Convert.ToDouble(ProgLang.SelectedValue) / 1000;

            FPTextBox.Text = Math.Round(fp, 3).ToString();
            CorrectedFPTextBox.Text = Math.Round(correctedFP, 3).ToString();
            KlocTextBox.Text = Math.Round(kloc, 3).ToString();
            CorrectedKlocTextBox.Text = Math.Round(correctedKloc, 3).ToString();
        }

        private double CountRegulizer()
        {
            return Convert.ToDouble(Option1.SelectedValue) +
                Convert.ToDouble(Option2.SelectedValue) +
                Convert.ToDouble(Option3.SelectedValue) +
                Convert.ToDouble(Option4.SelectedValue) +
                Convert.ToDouble(Option5.SelectedValue) +
                Convert.ToDouble(Option6.SelectedValue) +
                Convert.ToDouble(Option7.SelectedValue) +
                Convert.ToDouble(Option8.SelectedValue) +
                Convert.ToDouble(Option9.SelectedValue) +
                Convert.ToDouble(Option10.SelectedValue) +
                Convert.ToDouble(Option11.SelectedValue) +
                Convert.ToDouble(Option12.SelectedValue) +
                Convert.ToDouble(Option13.SelectedValue) +
                Convert.ToDouble(Option14.SelectedValue);
        }

        private double CountFP()
        {
            return Convert.ToDouble(LowEITextBox.Text) * 3 +
                    Convert.ToDouble(MiddleEITextBox.Text) * 4 +
                    Convert.ToDouble(HighEITextBox.Text) * 6 +
                    Convert.ToDouble(LowEOTextBox.Text) * 4 +
                    Convert.ToDouble(MiddleEOTextBox.Text) * 5 +
                    Convert.ToDouble(HighEOTextBox.Text) * 7 +
                    Convert.ToDouble(LowEQTextBox.Text) * 3 +
                    Convert.ToDouble(MiddleEQTextBox.Text) * 4 +
                    Convert.ToDouble(HighEQTextBox.Text) * 6 +
                    Convert.ToDouble(LowIFTextBox.Text) * 7 +
                    Convert.ToDouble(MiddleIFTextBox.Text) * 1 +
                    Convert.ToDouble(HighIFTextBox.Text) * 15 +
                    Convert.ToDouble(LowEIFTextBox.Text) * 5 +
                    Convert.ToDouble(MiddleEIFTextBox.Text) * 7 +
                    Convert.ToDouble(HighEIFTextBox.Text) * 1;
        }

        private void MiddleEITextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
