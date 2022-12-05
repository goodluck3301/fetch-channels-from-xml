using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.IO;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace FetchFromXML
{
    public partial class MainWindow : Window
    {
        public MainWindow() { InitializeComponent(); }
        String filePath = "";

        // Select File using Btn
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                txtEditor.Text = File.ReadAllText(openFileDialog.FileName);
                filePath = openFileDialog.FileName;
            }
        }

        //Fetching Data
        private void Fetch_Data(object sender, RoutedEventArgs e)
        {
            String allData = "";
            if (filePath != "")
            {
                String value  = text0.Text;
                String value1 = text1.Text;
                String value2 = text2.Text;
                String value3 = text3.Text;
                String value4 = text4.Text;

                try {
                    if (value != "")
                        allData += fullNameMethod(value);
                    if (value1 != "")
                        allData += fullNameMethod(value1);
                    if (value2 != "")
                        allData += fullNameMethod(value2);
                    if (value3 != "")
                        allData += fullNameMethod(value3);
                    if (value4 != "")
                        allData += fullNameMethod(value4);
                }
                catch {
                    MessageBox.Show("Selected File not XML type...");
                }
                

                txtEditor.Text = $"{allData}\r\n";
                if (exportFile.IsChecked == true)
                    writeTextInFile(allData);
            }
            else
                MessageBox.Show("Please Select File...");
        }

        public string fullNameMethod(string value)
        {
            string allData = "";
            XElement root = XElement.Load(filePath);
            IEnumerable<XElement> programme =
                from el in root.Elements("programme")
                where (string)el.Attribute("channel") == $"{value}"
                select el;

            foreach (XElement el in programme)
                allData += el;
            
            return allData;
        }

        public static async Task writeTextInFile(string data)
        {
            try {
                await File.WriteAllTextAsync("channel.xml", data);
                MessageBox.Show("Write in to File Sucsessfuly ;)");
            }
            catch (Exception){
                MessageBox.Show("Error Can't Write in to File (");
            }
        }

    }
}
