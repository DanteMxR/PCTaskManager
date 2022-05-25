using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using System.Management;

namespace TaskManagerPC.Pages
{
    public partial class DiscriptionPage : Page
    {
        public DiscriptionPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            object[] fields = new[]
            {
                new object[] { "Процессор:", "Win32_Processor", "Name" },
                new object[] { "Производитель:", "Win32_Processor", "Manufacturer" },
                new object[] { "Описание:", "Win32_Processor", "Description" },
                new object[] { "Видеокарта:", "Win32_VideoController", "Name" },
                new object[] { "Видеопроцессор:", "Win32_VideoController", "Name" },
                new object[] { "Версия драйвера:","Win32_VideoController", "DriverVersion" },
                new object[] { "Объем памяти (в байтах):","Win32_VideoController", "AdapterRAM" },
                new object[] { "Название дисковода:","Win32_CDROMDrive", "Name" },
                new object[] { "Буква привода:","Win32_CDROMDrive", "Drive" },
                new object[] { "Жесткий диск:","Win32_DiskDrive", "Caption" },
                new object[] { "Объем (в байтах):","Win32_DiskDrive", "Size" },
            };

            ProcessTextBlock.Text = string.Join("\n",
                fields.Select(x => $"{((object[])x)[0]} {string.Join("\n", GetHardwareInfo(((object[])x)[1].ToString(), ((object[])x)[2].ToString()))}"));
        }

        private static List<string> GetHardwareInfo(string WIN32_Class, string ClassItemField)
        {
            List<string> result = new List<string>();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM " + WIN32_Class);

            foreach (ManagementObject obj in searcher.Get())
            {
                if (obj[ClassItemField] != null)
                {
                    result.Add(obj[ClassItemField].ToString());
                }
            }

            return result;
        }
    }
}