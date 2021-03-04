using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace _4235
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public class MonthlyData
    {
        public int Count;
        public string Month;
    }



    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            Data = Enumerable.Range(1, 170).Cast<float>();

            Timestamps = new ObservableCollection<DateTime>();

            DateTime timestamp = new DateTime(2011, 5, 17);
            TimeSpan timestep = new TimeSpan(0, 1, 0);

            for (int i = 0; i < 100; ++i)
            {
                Timestamps.Add(timestamp);
                timestamp += timestep;
            }

            MonthlyList = new ObservableCollection<MonthlyData>();

            for (int i = 0; i < 12; ++i)
            {
                MonthlyList.Add(new MonthlyData
                {
                    Count = i * 100,
                    Month = timestamp.Date.Month.ToString()
                });

                timestamp = timestamp.AddMonths(1);
            }

        }

        public ObservableCollection<MonthlyData> MonthlyList { get; set; }

        public ObservableCollection<DateTime> Timestamps { get; set; }


        public IEnumerable<string> Cat => new[] { "Fist", "Second", "Third", "4th" };

        public IEnumerable<float> Data { get; set; }

    }
}
