using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Runtime.InteropServices;

namespace TaskManagerPC.Pages
{
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private CancellationTokenSource CancellationToken { get; set; } = null;
        private PerformanceCounter CpuCounter { get; set; } = null;
        private PerformanceCounter RamCounter { get; set; } = null;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CancellationToken = new CancellationTokenSource();
            CpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            RamCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");

            CpuUsageProgressBar.Maximum = 100;

            GetPerformanceUsageStatusAsync();
        }

        private async void ChangeValueProgressBarAsync(object sender, float newValue, CancellationToken token)
        {
            ProgressBar progressBar = (ProgressBar)sender;

            int countPart = 20;
            float part = (float)(Math.Abs(newValue - progressBar.Value) / countPart);

            while (progressBar.Value < newValue)
            {
                if (token.IsCancellationRequested) return;

                progressBar.Value += part;
                await Task.Delay(1);
            }

            while (progressBar.Value > newValue)
            {
                if (token.IsCancellationRequested) return;

                progressBar.Value -= part;
                await Task.Delay(1);
            }
        }

        private async void GetPerformanceUsageStatusAsync()
        {
            CancellationTokenSource cancellationToken = new CancellationTokenSource();

            while (true)
            {
                cancellationToken.Cancel();
                cancellationToken = new CancellationTokenSource();

                float cpuUsage = CpuCounter.NextValue();
                float ramUsage = RamCounter.NextValue();

                ChangeValueProgressBarAsync(CpuUsageProgressBar, cpuUsage, cancellationToken.Token);
                CpuUsageTextBlock.Text = $"{cpuUsage:0.00} %";

                ChangeValueProgressBarAsync(RamUsageProgressBar, ramUsage, cancellationToken.Token);
                RamUsageTextBlock.Text = $"{ramUsage:0.00} %";

                await Task.Delay(600);
            }
        }
        //CleanerMetod//
        [DllImport("KERNEL32.DLL", EntryPoint =
       "SetProcessWorkingSetSize", SetLastError = true,
       CallingConvention = CallingConvention.StdCall)]
        internal static extern bool SetProcessWorkingSetSize32Bit
       (IntPtr pProcess, int dwMinimumWorkingSetSize,
       int dwMaximumWorkingSetSize);

        [DllImport("KERNEL32.DLL", EntryPoint =
           "SetProcessWorkingSetSize", SetLastError = true,
           CallingConvention = CallingConvention.StdCall)]
        internal static extern bool SetProcessWorkingSetSize64Bit
           (IntPtr pProcess, long dwMinimumWorkingSetSize,
           long dwMaximumWorkingSetSize);
        public void FlushMem()
        {
            GC.Collect();

            GC.WaitForPendingFinalizers();

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {

                SetProcessWorkingSetSize32Bit(System.Diagnostics
                   .Process.GetCurrentProcess().Handle, -1, -1);

            }


        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            FlushMem();
        }
    }
}
