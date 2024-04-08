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

        private double GetEaf()
        {
            double rely = _relyDict[RelyOption.SelectedValue as string];
            double data = _dataDict[DataOption.SelectedValue as string];
            double cplx = _cplxDict[CplxOption.SelectedValue as string];
            double time = _timeDict[TimeOption.SelectedValue as string];
            double stor = _storDict[StorOption.SelectedValue as string];
            double virt = _virtDict[VirtOption.SelectedValue as string];
            double turn = _turnDict[TurnOption.SelectedValue as string];
            double acap = _acapDict[AcapOption.SelectedValue as string];
            double aexp = _aexpDict[AexpOption.SelectedValue as string];
            double pcap = _pcapDict[PcapOption.SelectedValue as string];
            double vexp = _vexpDict[VexpOption.SelectedValue as string];
            double lexp = _lexpDict[LexpOption.SelectedValue as string];
            double modp = _modpDict[ModpOption.SelectedValue as string];
            double tool = _toolDict[ToolOption.SelectedValue as string];
            double sced = _scedDict[ScedOption.SelectedValue as string];
        
            return rely * data * cplx * time * stor * virt * turn * acap * 
                aexp * pcap * vexp * lexp * modp * tool * sced;
        }

        private void MakeExperiment(object sender, RoutedEventArgs e)
        {
            GraphWindow graphWindow = new GraphWindow(new List<Dictionary<string, double>>
            {
                _modeCoeffDict,
                _modePowLaborCostDict,
                _modePowTimeDict,
                _relyDict,
                _dataDict,
                _cplxDict,
                _timeDict,
                _storDict,
                _virtDict,
                _turnDict,
                _acapDict,
                _aexpDict,
                _pcapDict,
                _vexpDict,
                _lexpDict,
                _modpDict,
                _toolDict,
                _scedDict
            });
            graphWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mode = ModeOption.SelectedValue as string;
            double kloc = Convert.ToDouble(KlocTextBox.Text);
            double eaf = GetEaf();

            double laborCost = _modeCoeffDict[mode] * eaf * Math.Pow(kloc, _modePowLaborCostDict[mode]);
            double time = 2.5 * Math.Pow(laborCost, _modePowTimeDict[mode]);

            CycleLaborCostStage1.Text = Math.Round(0.08 * laborCost, 2).ToString();
            CycleTimeStage1.Text = Math.Round(0.36 * time, 2).ToString();

            CycleLaborCostStage2.Text = Math.Round(0.18 * laborCost, 2).ToString();
            CycleLaborCostStage3.Text = Math.Round(0.25 * laborCost, 2).ToString();
            CycleLaborCostStage4.Text = Math.Round(0.26 * laborCost, 2).ToString();
            CycleLaborCostStage5.Text = Math.Round(0.31 * laborCost, 2).ToString();

            CycleTimeStage2.Text = Math.Round(0.36 * time, 2).ToString();
            CycleTimeStage3.Text = Math.Round(0.18 * time, 2).ToString();
            CycleTimeStage4.Text = Math.Round(0.18 * time, 2).ToString();
            CycleTimeStage5.Text = Math.Round(0.28 * time, 2).ToString();

            laborCost *= 1.08;
            time *= 1.36;

            WbsLaborCostStage1.Text = Math.Round(0.04 * laborCost, 2).ToString();
            WbsLaborCostStage2.Text = Math.Round(0.12 * laborCost, 2).ToString();
            WbsLaborCostStage3.Text = Math.Round(0.44 * laborCost, 2).ToString();
            WbsLaborCostStage4.Text = Math.Round(0.06 * laborCost, 2).ToString();
            WbsLaborCostStage5.Text = Math.Round(0.14 * laborCost, 2).ToString();
            WbsLaborCostStage6.Text = Math.Round(0.07 * laborCost, 2).ToString();
            WbsLaborCostStage7.Text = Math.Round(0.07 * laborCost, 2).ToString();
            WbsLaborCostStage8.Text = Math.Round(0.06 * laborCost, 2).ToString();

            double budget = Convert.ToDouble(WageTextBox.Text) * laborCost;

            WbsBudgetStage1.Text = Math.Round(0.04 * budget, 2).ToString();
            WbsBudgetStage2.Text = Math.Round(0.12 * budget, 2).ToString();
            WbsBudgetStage3.Text = Math.Round(0.44 * budget, 2).ToString();
            WbsBudgetStage4.Text = Math.Round(0.06 * budget, 2).ToString();
            WbsBudgetStage5.Text = Math.Round(0.14 * budget, 2).ToString();
            WbsBudgetStage6.Text = Math.Round(0.07 * budget, 2).ToString();
            WbsBudgetStage7.Text = Math.Round(0.07 * budget, 2).ToString();
            WbsBudgetStage8.Text = Math.Round(0.06 * budget, 2).ToString();
            
            LaborCostTextBox.Text = Math.Round(laborCost).ToString();
            TimeTextBox.Text = Math.Round(time).ToString();
            BudgetTextBox.Text = Math.Round(budget).ToString();

            BudgetChart.AxisX.Clear();
            BudgetChart.AxisX.Add(new Axis() { Title = "Этап разработки" });
            BudgetChart.AxisY.Clear();
            BudgetChart.AxisY.Add(new Axis() { Title = "Количество работников, чел." });

            BudgetChart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Распределение работников",
                    Values = new ChartValues<double> 
                    {
                        Math.Round(Convert.ToDouble(CycleLaborCostStage1.Text) / Convert.ToDouble(CycleTimeStage1.Text)),
                        Math.Round(Convert.ToDouble(CycleLaborCostStage2.Text) / Convert.ToDouble(CycleTimeStage2.Text)),
                        Math.Round(Convert.ToDouble(CycleLaborCostStage3.Text) / Convert.ToDouble(CycleTimeStage3.Text)),
                        Math.Round(Convert.ToDouble(CycleLaborCostStage4.Text) / Convert.ToDouble(CycleTimeStage4.Text)),
                        Math.Round(Convert.ToDouble(CycleLaborCostStage5.Text) / Convert.ToDouble(CycleTimeStage5.Text))
                    }
                }
            };

            BudgetChart.Visibility = Visibility.Visible;
        }

        private readonly Dictionary<string, double> _modeCoeffDict = new Dictionary<string, double>()
        {
            {"Обычный", 3.2},
            {"Промежуточный", 3.0},
            {"Встроенный", 2.8}
        };
        private readonly Dictionary<string, double> _modePowLaborCostDict = new Dictionary<string, double>()
        {
            {"Обычный", 1.05},
            {"Промежуточный", 1.12},
            {"Встроенный", 1.2}
        };
        private readonly Dictionary<string, double> _modePowTimeDict = new Dictionary<string, double>()
        {
            {"Обычный", 0.38},
            {"Промежуточный", 0.35},
            {"Встроенный", 0.32}
        };
        private readonly Dictionary<string, double> _relyDict = new Dictionary<string, double>()
        {
            {"Очень низкий", 0.75},
            {"Низкий", 0.86},
            {"Номинальный", 1.0},
            {"Высокий", 1.15},
            {"Очень высокий", 1.4}
        };
        private readonly Dictionary<string, double> _dataDict = new Dictionary<string, double>()
        {
            {"Низкий", 0.94},
            {"Номинальный", 1.0},
            {"Высокий", 1.08},
            {"Очень высокий", 1.16}
        };
        private readonly Dictionary<string, double> _cplxDict = new Dictionary<string, double>()
        {
            {"Очень низкий", 0.7},
            {"Низкий", 0.85},
            {"Номинальный", 1.0},
            {"Высокий", 1.15},
            {"Очень высокий", 1.3}
        };
        private readonly Dictionary<string, double> _timeDict = new Dictionary<string, double>()
        {
            {"Номинальный", 1.0},
            {"Высокий", 1.11},
            {"Очень высокий", 1.5}
        };
        private readonly Dictionary<string, double> _storDict = new Dictionary<string, double>()
        {
            {"Номинальный", 1.0},
            {"Высокий", 1.06},
            {"Очень высокий", 1.21}
        };
        private readonly Dictionary<string, double> _virtDict = new Dictionary<string, double>()
        {
            {"Низкий", 0.87},
            {"Номинальный", 1.0},
            {"Высокий", 1.15},
            {"Очень высокий", 1.3}
        };
        private readonly Dictionary<string, double> _turnDict = new Dictionary<string, double>()
        {
            {"Низкий", 0.87},
            {"Номинальный", 1.0},
            {"Высокий", 1.07},
            {"Очень высокий", 1.15}
        };
        private readonly Dictionary<string, double> _acapDict = new Dictionary<string, double>()
        {
            {"Очень низкий", 1.46},
            {"Низкий", 1.19},
            {"Номинальный", 1.0},
            {"Высокий", 0.86},
            {"Очень высокий", 0.71}
        };
        private readonly Dictionary<string, double> _aexpDict = new Dictionary<string, double>()
        {
            {"Очень низкий", 1.29},
            {"Низкий", 1.15},
            {"Номинальный", 1.0},
            {"Высокий", 0.91},
            {"Очень высокий", 0.82}
        };
        private readonly Dictionary<string, double> _pcapDict = new Dictionary<string, double>()
        {
            {"Очень низкий", 1.42},
            {"Низкий", 1.17},
            {"Номинальный", 1.0},
            {"Высокий", 0.86},
            {"Очень высокий", 0.7},
        };
        private readonly Dictionary<string, double> _vexpDict = new Dictionary<string, double>()
        {
            {"Очень низкий", 1.21},
            {"Низкий", 1.1},
            {"Номинальный", 1.0},
            {"Высокий", 0.9},
        };
        private readonly Dictionary<string, double> _lexpDict = new Dictionary<string, double>()
        {
            {"Очень низкий", 1.14},
            {"Низкий", 1.07},
            {"Номинальный", 1.0},
            {"Высокий", 0.95},
        };
        private readonly Dictionary<string, double> _modpDict = new Dictionary<string, double>()
        {
            {"Очень низкий", 1.24},
            {"Низкий", 1.1},
            {"Номинальный", 1.0},
            {"Высокий", 0.91},
            {"Очень высокий", 0.82}
        };
        private readonly Dictionary<string, double> _toolDict = new Dictionary<string, double>()
        {
            {"Очень низкий", 1.24},
            {"Низкий", 1.1},
            {"Номинальный", 1.0},
            {"Высокий", 0.91},
            {"Очень высокий", 0.82}
        };
        private readonly Dictionary<string, double> _scedDict = new Dictionary<string, double>()
        {
            {"Очень низкий", 1.23},
            {"Низкий", 1.08},
            {"Номинальный", 1.0},
            {"Высокий", 1.04},
            {"Очень высокий", 1.1}
        };
    }
}
