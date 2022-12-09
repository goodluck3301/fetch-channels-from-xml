using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.IO;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FetchFromXML
{
    public class NameAndNumber
    {
        public NameAndNumber(string s)
        {
            OriginalString = s;
            Match match = Regex.Match(s, @"^(.*?)(\d*)$");
            Name = match.Groups[1].Value;
            int number;
            int.TryParse(match.Groups[2].Value, out number);
            Number = number; //will get default value when blank
        }

        public string OriginalString { get; private set; }
        public string Name { get; private set; }
        public int Number { get; private set; }
    }

    public partial class MainWindow : Window
    {
        String filePath = "";
        static string allHistory = "";
        List<string> channelsList = new List<string>();

        public MainWindow() { 
            InitializeComponent();
            readFromFile("history.txt");
            history.Text = allHistory;
        }
        
        // Select File using Btn
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            selectId.Items.Clear();
            selectId1.Items.Clear();
            selectId2.Items.Clear();
            selectId3.Items.Clear();
            selectId4.Items.Clear();

            progressBar.IsIndeterminate = true;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                /*txtEditor.Text = File.ReadAllText(openFileDialog.FileName);*/
                filePath = openFileDialog.FileName;

                XElement root = XElement.Load(filePath);
                IEnumerable<XAttribute> listOfAttributes =
                    from att in root.Elements("channel").Attributes("id")
                    select att;
                foreach (XAttribute a in listOfAttributes)
                    channelsList.Add(a.Value);

                channelsList.Sort((x, y) =>
                {
                    int ix, iy;
                    return int.TryParse(x, out ix) && int.TryParse(y, out iy)
                          ? ix.CompareTo(iy) : string.Compare(x, y);
                });

                foreach (string el in channelsList){
                    selectId.Items.Add(el);
                    selectId1.Items.Add(el);
                    selectId2.Items.Add(el);
                    selectId3.Items.Add(el);
                    selectId4.Items.Add(el);
                    txtEditor.Text += $"{el}, \n";
                }
            }
            progressBar.IsIndeterminate = false;
        }

        //Fetching Data
        private void Fetch_Data(object sender, RoutedEventArgs e)
        {
            String allData = "";
            progressBar.IsIndeterminate = true;

            if (filePath != "")
            {
                String value = text0.Text;
                String value1 = text1.Text;
                String value2 = text2.Text;
                String value3 = text3.Text;
                String value4 = text4.Text;

                try
                {
                    if (value != "")
                    {
                        allData += fullNameMethod(value);
                        appendTextInFile($"{value}","history.txt");
                    }
                    if (value1 != "")
                    {
                        allData += fullNameMethod(value1);
                        appendTextInFile($"{value1}", "history.txt");
                    }
                    if (value2 != "") {
                        allData += fullNameMethod(value2);
                        appendTextInFile($"{value2}", "history.txt");
                    }
                    if (value3 != "")
                    {
                        allData += fullNameMethod(value3);
                        appendTextInFile($"{value3}", "history.txt");
                    }
                    if (value4 != "")
                    {
                        allData += fullNameMethod(value4);
                        appendTextInFile($"{value4}", "history.txt");
                    }
                    if (selectId.Text != "" || selectId.Text != "--Select Channel ID--")
                    {
                        allData += fullNameMethod(selectId.Text);
                        appendTextInFile($"{selectId.Text}", "history.txt");
                    }
                    if (selectId1.Text != "" || selectId1.Text != "--Select Channel ID--")
                    {
                        allData += fullNameMethod(selectId1.Text);
                        appendTextInFile($"{selectId1.Text}", "history.txt");
                    }
                    if (selectId2.Text != "" || selectId2.Text != "--Select Channel ID--")
                    {
                        allData += fullNameMethod(selectId2.Text);
                        appendTextInFile($"{selectId2.Text}", "history.txt");
                    }
                    if (selectId3.Text != "" || selectId3.Text != "--Select Channel ID--")
                    { 
                        allData += fullNameMethod(selectId3.Text);
                        appendTextInFile($"{selectId3.Text}", "history.txt");
                    }
                    if (selectId4.Text != "" || selectId4.Text != "--Select Channel ID--")
                    {
                        allData += fullNameMethod(selectId4.Text);
                        appendTextInFile($"{selectId4.Text}", "history.txt");
                    }
                }
                catch
                {
                    MessageBox.Show("Selected File not XML type...");
                }

                txtEditor.Text = $"{allData}\r\n";
                if (exportFile.IsChecked == true)
                    writeTextInFile(allData, "channel.xml");
            }
            else
                MessageBox.Show("Please Select File...", "Checking...");
            progressBar.IsIndeterminate = false;
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
            { allData += el; }

            allHistory = "";
            readFromFile("history.txt");
            history.Text = allHistory;

            return allData;
        }

        public static async Task writeTextInFile(string data, string channelName)
        {
            try {
                await File.WriteAllTextAsync($"{channelName}", data);
                MessageBox.Show("Write in to File Sucsessfuly ;)");
            }
            catch (Exception){
                MessageBox.Show("Error Can't Write in to File (");
            }
        }

        public static async Task appendTextInFile(string data, string channelName) {
            try
            {
                await using (StreamWriter sw = File.AppendText(channelName))
                    sw.WriteLine($"{data}");
            }
            catch
            {
              /*MessageBox.Show("Error Can't Append text in to File (");*/
            }
        }

        public static async Task clearTextFromFile(string channelName)
        {
            try
            {
                await File.WriteAllTextAsync($"{channelName}", "");
                /*MessageBox.Show("History was cleaned Sucsessfuly ;)");*/
            }
            catch
            {
                MessageBox.Show("Error Can't clear history (");
            }

        }

        private static async Task readFromFile(string fileName) {
            string[] lines = File.ReadAllLines($"{fileName}");

            Array.Reverse(lines);
            foreach (string line in lines)
                if(String.Concat(line.Where(c => !Char.IsWhiteSpace(c)))!="")
                    allHistory += ($"{line}\n");     
        }

        private void Clear_history(object sender, RoutedEventArgs e)
        {
            clearTextFromFile("history.txt");
            history.Text = "";
        }
    }
}
