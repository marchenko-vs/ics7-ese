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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double cocomo2pow = CountCocomo2Power();
            double archLaborCost = ArchLaborCost();
            double archTime = ArchTime(archLaborCost, cocomo2pow);
            double archBudget = archLaborCost * Convert.ToDouble(WageTextBox.Text) * 1000;
            Int32 archStaff = Convert.ToInt32(archLaborCost / archTime);

            ArchLaborCostTextBox.Text = Math.Round(archLaborCost, 2).ToString();
            ArchTimeTextBox.Text = Math.Round(archTime, 2).ToString();
            ArchBudgetTextBox.Text = Math.Round(archBudget, 2).ToString();
            ArchStaffTextBox.Text = archStaff.ToString();

            double nop = CountNop() * ((100.0 - Convert.ToDouble(RuseTextBox.Text)) / 100.0);
            double compositionLaborCost = CompositionLaborCost(nop);
            double compositionTime = ArchTime(compositionLaborCost, cocomo2pow);
            double compositionBudget = compositionLaborCost * Convert.ToDouble(WageTextBox.Text) * 1000;
            Int32 compositionStaff = Convert.ToInt32(compositionLaborCost / compositionTime);

            CompositionLaborCostTextBox.Text = Math.Round(compositionLaborCost, 2).ToString();
            CompositionTimeTextBox.Text = Math.Round(compositionTime, 2).ToString();
            CompositionBudgetTextBox.Text = Math.Round(compositionBudget, 2).ToString();
            CompositionStaffTextBox.Text = compositionStaff.ToString();
        }

        private double CountCocomo2Power()
        {
            return (Convert.ToDouble(PrecOption.SelectedValue) +
                    Convert.ToDouble(FlexOption.SelectedValue) +
                    Convert.ToDouble(ReslOption.SelectedValue) +
                    Convert.ToDouble(TeamOption.SelectedValue) +
                    Convert.ToDouble(PmatOption.SelectedValue)) / 100.0 + 1.01;
        }

        private double CountEArch()
        {
            return (Convert.ToDouble(PersOption.SelectedValue) *
                    Convert.ToDouble(RcpxOption.SelectedValue) *
                    Convert.ToDouble(RuseOption.SelectedValue) *
                    Convert.ToDouble(PdifOption.SelectedValue) *
                    Convert.ToDouble(PrexOption.SelectedValue) *
                    Convert.ToDouble(FcilOption.SelectedValue) *
                    Convert.ToDouble(ScedOption.SelectedValue));
        }

        private double CountNop()
        {
            return Convert.ToDouble(SimpleFormsTextBox.Text) * 1 +
                   Convert.ToDouble(MiddleFormsTextBox.Text) * 2 +
                   Convert.ToDouble(HardFormsTextBox.Text) * 3 +
                   Convert.ToDouble(SimpleReportsTextBox.Text) * 2 +
                   Convert.ToDouble(MiddleReportsTextBox.Text) * 5 +
                   Convert.ToDouble(HardReportsTextBox.Text) * 8 +
                   Convert.ToDouble(ThirdGenLangTextBox.Text) * 10;
        }

        private double ArchLaborCost()
        {
            return 2.45 * CountEArch() * Math.Pow(Convert.ToDouble(KlocTextBox.Text), CountCocomo2Power());
        }

        private double ArchTime(double laborCost, double cocomo2Power)
        {
            return 3.0 * Math.Pow(laborCost, 0.33 + 0.2 * (cocomo2Power - 1.01));
        }

        private double CompositionLaborCost(double nop)
        {
            return nop / Convert.ToDouble(ExperienceOption.SelectedValue);
        }

        private double CompositionTime(double laborCost, double cocomo2Power)
        {
            return 3.0 * Math.Pow(laborCost, 0.33 + 0.2 * (cocomo2Power - 1.01));
        }

        private void FunctionalPoints(object sender, RoutedEventArgs e)
        {
            var fpWindow = new FPWindow();
            fpWindow.Show();
        }
    }
}
