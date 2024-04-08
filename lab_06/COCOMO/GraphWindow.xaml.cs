using LiveCharts.Wpf;
using LiveCharts;
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
using System.Windows.Shapes;
using System.Runtime.Remoting.Metadata;
using System.Security.Cryptography;

namespace COCOMO
{
    public partial class GraphWindow : Window
    {
        public GraphWindow(List<Dictionary<string, double>> dictList)
        {
            InitializeComponent();

            _dictList = dictList;

            List<CartesianChart> charts = new List<CartesianChart>
            {
                Chart1,
                Chart2,
            };
            List<double> laborCosts = new List<double>();
            List<double> times = new List<double>();

            string value = "Номинальный";
            double kloc = 55;

            double modp = _dictList[15]["Очень низкий"];
            double tool = _dictList[16]["Очень низкий"];
            double acap = _dictList[10]["Очень низкий"];
            double pcap = _dictList[12]["Очень низкий"];
            double eaf = GetEaf(value, modp, tool, acap, pcap);
            
            laborCosts.Add(_dictList[0]["Промежуточный"] * eaf * Math.Pow(kloc, _dictList[1]["Промежуточный"]));
            times.Add(2.5 * Math.Pow(laborCosts[0], _dictList[2]["Промежуточный"]));
            
            modp = _dictList[15]["Низкий"];
            eaf = GetEaf(value, modp, tool, acap, pcap);
            laborCosts.Add(_dictList[0]["Промежуточный"] * eaf * Math.Pow(kloc, _dictList[1]["Промежуточный"]));
            times.Add(2.5 * Math.Pow(laborCosts[1], _dictList[2]["Промежуточный"]));

            modp = _dictList[15]["Номинальный"];
            eaf = GetEaf(value, modp, tool, acap, pcap);
            laborCosts.Add(_dictList[0]["Промежуточный"] * eaf * Math.Pow(kloc, _dictList[1]["Промежуточный"]));
            times.Add(2.5 * Math.Pow(laborCosts[2], _dictList[2]["Промежуточный"]));

            modp = _dictList[15]["Высокий"];
            eaf = GetEaf(value, modp, tool, acap, pcap);
            laborCosts.Add(_dictList[0]["Промежуточный"] * eaf * Math.Pow(kloc, _dictList[1]["Промежуточный"]));
            times.Add(2.5 * Math.Pow(laborCosts[3], _dictList[2]["Промежуточный"]));

            modp = _dictList[15]["Очень высокий"];
            eaf = GetEaf(value, modp, tool, acap, pcap);
            laborCosts.Add(_dictList[0]["Промежуточный"] * eaf * Math.Pow(kloc, _dictList[1]["Промежуточный"]));
            times.Add(2.5 * Math.Pow(laborCosts[4], _dictList[2]["Промежуточный"]));

            modp = _dictList[15]["Очень низкий"];
            tool = _dictList[16]["Очень низкий"];
            acap = _dictList[10]["Очень низкий"];
            pcap = _dictList[12]["Очень низкий"];
            eaf = GetEaf(value, modp, tool, acap, pcap);

            laborCosts.Add(_dictList[0]["Промежуточный"] * eaf * Math.Pow(kloc, _dictList[1]["Промежуточный"]));
            times.Add(2.5 * Math.Pow(laborCosts[5], _dictList[2]["Промежуточный"]));

            tool = _dictList[16]["Низкий"];
            eaf = GetEaf(value, modp, tool, acap, pcap);
            laborCosts.Add(_dictList[0]["Промежуточный"] * eaf * Math.Pow(kloc, _dictList[1]["Промежуточный"]));
            times.Add(2.5 * Math.Pow(laborCosts[6], _dictList[2]["Промежуточный"]));

            tool = _dictList[16]["Номинальный"];
            eaf = GetEaf(value, modp, tool, acap, pcap);
            laborCosts.Add(_dictList[0]["Промежуточный"] * eaf * Math.Pow(kloc, _dictList[1]["Промежуточный"]));
            times.Add(2.5 * Math.Pow(laborCosts[7], _dictList[2]["Промежуточный"]));

            tool = _dictList[16]["Высокий"];
            eaf = GetEaf(value, modp, tool, acap, pcap);
            laborCosts.Add(_dictList[0]["Промежуточный"] * eaf * Math.Pow(kloc, _dictList[1]["Промежуточный"]));
            times.Add(2.5 * Math.Pow(laborCosts[8], _dictList[2]["Промежуточный"]));

            tool = _dictList[16]["Очень высокий"];
            eaf = GetEaf(value, modp, tool, acap, pcap);
            laborCosts.Add(_dictList[0]["Промежуточный"] * eaf * Math.Pow(kloc, _dictList[1]["Промежуточный"]));
            times.Add(2.5 * Math.Pow(laborCosts[9], _dictList[2]["Промежуточный"]));

            modp = _dictList[15]["Очень низкий"];
            tool = _dictList[16]["Очень низкий"];
            acap = _dictList[10]["Очень низкий"];
            pcap = _dictList[12]["Очень низкий"];
            eaf = GetEaf(value, modp, tool, acap, pcap);

            laborCosts.Add(_dictList[0]["Промежуточный"] * eaf * Math.Pow(kloc, _dictList[1]["Промежуточный"]));
            times.Add(2.5 * Math.Pow(laborCosts[10], _dictList[2]["Промежуточный"]));

            acap = _dictList[10]["Низкий"];
            eaf = GetEaf(value, modp, tool, acap, pcap);
            laborCosts.Add(_dictList[0]["Промежуточный"] * eaf * Math.Pow(kloc, _dictList[1]["Промежуточный"]));
            times.Add(2.5 * Math.Pow(laborCosts[11], _dictList[2]["Промежуточный"]));

            acap = _dictList[10]["Номинальный"];
            eaf = GetEaf(value, modp, tool, acap, pcap);
            laborCosts.Add(_dictList[0]["Промежуточный"] * eaf * Math.Pow(kloc, _dictList[1]["Промежуточный"]));
            times.Add(2.5 * Math.Pow(laborCosts[12], _dictList[2]["Промежуточный"]));

            acap = _dictList[10]["Высокий"];
            eaf = GetEaf(value, modp, tool, acap, pcap);
            laborCosts.Add(_dictList[0]["Промежуточный"] * eaf * Math.Pow(kloc, _dictList[1]["Промежуточный"]));
            times.Add(2.5 * Math.Pow(laborCosts[13], _dictList[2]["Промежуточный"]));

            acap = _dictList[10]["Очень высокий"];
            eaf = GetEaf(value, modp, tool, acap, pcap);
            laborCosts.Add(_dictList[0]["Промежуточный"] * eaf * Math.Pow(kloc, _dictList[1]["Промежуточный"]));
            times.Add(2.5 * Math.Pow(laborCosts[14], _dictList[2]["Промежуточный"]));

            modp = _dictList[15]["Очень низкий"];
            tool = _dictList[16]["Очень низкий"];
            acap = _dictList[10]["Очень низкий"];
            pcap = _dictList[12]["Очень низкий"];
            eaf = GetEaf(value, modp, tool, acap, pcap);

            laborCosts.Add(_dictList[0]["Промежуточный"] * eaf * Math.Pow(kloc, _dictList[1]["Промежуточный"]));
            times.Add(2.5 * Math.Pow(laborCosts[15], _dictList[2]["Промежуточный"]));

            pcap = _dictList[12]["Низкий"];
            eaf = GetEaf(value, modp, tool, acap, pcap);
            laborCosts.Add(_dictList[0]["Промежуточный"] * eaf * Math.Pow(kloc, _dictList[1]["Промежуточный"]));
            times.Add(2.5 * Math.Pow(laborCosts[16], _dictList[2]["Промежуточный"]));

            pcap = _dictList[12]["Номинальный"];
            eaf = GetEaf(value, modp, tool, acap, pcap);
            laborCosts.Add(_dictList[0]["Промежуточный"] * eaf * Math.Pow(kloc, _dictList[1]["Промежуточный"]));
            times.Add(2.5 * Math.Pow(laborCosts[17], _dictList[2]["Промежуточный"]));

            pcap = _dictList[12]["Высокий"];
            eaf = GetEaf(value, modp, tool, acap, pcap);
            laborCosts.Add(_dictList[0]["Промежуточный"] * eaf * Math.Pow(kloc, _dictList[1]["Промежуточный"]));
            times.Add(2.5 * Math.Pow(laborCosts[18], _dictList[2]["Промежуточный"]));

            pcap = _dictList[12]["Очень высокий"];
            eaf = GetEaf(value, modp, tool, acap, pcap);
            laborCosts.Add(_dictList[0]["Промежуточный"] * eaf * Math.Pow(kloc, _dictList[1]["Промежуточный"]));
            times.Add(2.5 * Math.Pow(laborCosts[19], _dictList[2]["Промежуточный"]));

            charts[0].AxisX.Add(new Axis() { Title="Значения коэффициентов" });
            charts[0].AxisY.Add(new Axis() { Title="Трудозатраты, чел.-мес." });

            charts[0].Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "MODP",
                    Values = new ChartValues<double>
                    {
                        laborCosts[0],
                        laborCosts[1],
                        laborCosts[2],
                        laborCosts[3],
                        laborCosts[4],
                    }
                },
                new LineSeries
                {
                    Title = "TOOL",
                    Values = new ChartValues<double>
                    {
                        laborCosts[5],
                        laborCosts[6],
                        laborCosts[7],
                        laborCosts[8],
                        laborCosts[9],
                    }
                },
                new LineSeries
                {
                    Title = "ACAP",
                    Values = new ChartValues<double>
                    {
                        laborCosts[10],
                        laborCosts[11],
                        laborCosts[12],
                        laborCosts[13],
                        laborCosts[14],
                    }
                },
                new LineSeries
                {
                    Title = "PCAP",
                    Values = new ChartValues<double>
                    {
                        laborCosts[15],
                        laborCosts[16],
                        laborCosts[17],
                        laborCosts[18],
                        laborCosts[19],
                    }
                }
            };

            charts[1].AxisX.Add(new Axis() { Title = "Значения коэффициентов" });
            charts[1].AxisY.Add(new Axis() { Title = "Время, мес." });

            charts[1].Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "MODP",
                    Values = new ChartValues<double>
                    {
                        times[0],
                        times[1],
                        times[2],
                        times[3],
                        times[4],
                    }
                },
                new LineSeries
                {
                    Title = "TOOL",
                    Values = new ChartValues<double>
                    {
                        times[5],
                        times[6],
                        times[7],
                        times[8],
                        times[9],
                    }
                },
                new LineSeries
                {
                    Title = "ACAP",
                    Values = new ChartValues<double>
                    {
                        times[10],
                        times[11],
                        times[12],
                        times[13],
                        times[14],
                    }
                },
                new LineSeries
                {
                    Title = "PCAP",
                    Values = new ChartValues<double>
                    {
                        times[15],
                        times[16],
                        times[17],
                        times[18],
                        times[19],
                    }
                },
            };
        }

        private double GetEaf(string value, double modp, double tool, double acap, double pcap)
        {
            double rely = _dictList[3][value];
            double data = _dictList[4][value];
            double cplx = _dictList[5][value];
            double time = _dictList[6][value];
            double stor = _dictList[7][value];
            double virt = _dictList[8][value];
            double turn = _dictList[9][value];
            double aexp = _dictList[11][value];
            double vexp = _dictList[13][value];
            double lexp = _dictList[14][value];
            double sced = _dictList[17][value];

            return rely * data * cplx * time * stor * virt * turn * acap *
                aexp * pcap * vexp * lexp * modp * tool * sced;
        }

        private readonly List<Dictionary<string, double>> _dictList;
    }
}
