using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.IO;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;

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
        String ChannelFilePath = "";
        static string allHistory = "";
        List<string> channelsList = new List<string>();
        string[] channelNames;

        public MainWindow() { 
            InitializeComponent();
            try
            {
                readFromFile("history.txt");
                history.Text = allHistory;
            }catch (Exception e) { }
        }
        
        // Select File using Btn
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            selectId0.Items.Clear();
            selectId1.Items.Clear();
            selectId2.Items.Clear();
            selectId3.Items.Clear();
         

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
                    selectId0.Items.Add(el);
                    selectId1.Items.Add(el);
                    selectId2.Items.Add(el);
                    selectId3.Items.Add(el);
                    txtEditor.Text += $"{el}, \n";
                }
            }
        }

        //Fetching Data
        private void Fetch_Data(object sender, RoutedEventArgs e)
        {
            StringBuilder allData = new StringBuilder();
            allData.Append("");

            if (filePath != "")
            {
                String value = text0.Text;
                String value1 = text1.Text;
                String value2 = text2.Text;
                String value3 = text3.Text;
                String value4 = text4.Text;
                String value5 = text5.Text;
                String value6 = text6.Text;
                String value7 = text7.Text;
                String value8 = text8.Text;
                String value9 = text9.Text;

                String value10 = text10.Text;
                String value11 = text11.Text;
                String value12 = text12.Text;
                String value13 = text13.Text;
                String value14 = text14.Text;
                String value15 = text15.Text;
                String value16 = text16.Text;
                String value17 = text17.Text;
                String value18 = text18.Text;

                String value19 = text19.Text;
                String value20 = text20.Text;
                String value21 = text21.Text;
                String value22 = text22.Text;
                String value23 = text23.Text;
                String value24 = text24.Text;
                String value25 = text25.Text;
                String value26 = text26.Text;
                String value27 = text27.Text;
                String value28 = text28.Text;
                String value29 = text29.Text;

                try
                {
                    if(channelNames != null)
                        if (channelNames.Length != 0)
                            foreach (string line in channelNames)
                                allData.Append(fullNameMethod(line));

                    if (value != "")
                    {
                        allData.Append(fullNameMethod(value));
                        appendTextInFile($"{value}","history.txt");
                    }
                    if (value1 != "")
                    {
                        allData.Append(fullNameMethod(value1));
                        appendTextInFile($"{value1}", "history.txt");
                    }
                    if (value2 != "") {
                        allData.Append(fullNameMethod(value2));
                        appendTextInFile($"{value2}", "history.txt");
                    }
                    if (value3 != "")
                    {
                        allData.Append(fullNameMethod(value3));
                        appendTextInFile($"{value3}", "history.txt");
                    }
                    if (value4 != "")
                    {
                        allData.Append(fullNameMethod(value4));
                        appendTextInFile($"{value4}", "history.txt");
                    }
                    if (value5 != "")
                    {
                        allData.Append(fullNameMethod(value5));
                        appendTextInFile($"{value5}", "history.txt");
                    }
                    if (value6 != "")
                    {
                        allData.Append(fullNameMethod(value6));
                        appendTextInFile($"{value6}", "history.txt");
                    }
                    if (value7 != "")
                    {
                        allData.Append(fullNameMethod(value7));
                        appendTextInFile($"{value7}", "history.txt");
                    }
                    if (value8 != "")
                    {
                        allData.Append(fullNameMethod(value8));
                        appendTextInFile($"{value8}", "history.txt");
                    }
                    if (value9 != "")
                    {
                        allData.Append(fullNameMethod(value9));
                        appendTextInFile($"{value9}", "history.txt");
                    }
                    if (value10 != "")
                    {
                        allData.Append(fullNameMethod(value10));
                        appendTextInFile($"{value10}", "history.txt");
                    }
                    if (value11 != "")
                    {
                        allData.Append(fullNameMethod(value11));
                        appendTextInFile($"{value11}", "history.txt");
                    }
                    if (value12 != "")
                    {
                        allData.Append(fullNameMethod(value12));
                        appendTextInFile($"{value12}", "history.txt");
                    }
                    if (value13 != "")
                    {
                        allData.Append(fullNameMethod(value13));
                        appendTextInFile($"{value13}", "history.txt");
                    }
                    if (value14 != "")
                    {
                        allData.Append(fullNameMethod(value14));
                        appendTextInFile($"{value14}", "history.txt");
                    }
                    if (value15 != "")
                    {
                        allData.Append(fullNameMethod(value15));
                        appendTextInFile($"{value15}", "history.txt");
                    }
                    if (value16 != "")
                    {
                        allData.Append(fullNameMethod(value16));
                        appendTextInFile($"{value16}", "history.txt");
                    }
                    if (value17 != "")
                    {
                        allData.Append(fullNameMethod(value17));
                        appendTextInFile($"{value17}", "history.txt");
                    }
                    if (value18 != "")
                    {
                        allData.Append(fullNameMethod(value18));
                        appendTextInFile($"{value18}", "history.txt");
                    }
                    if (value19 != "")
                    {
                        allData.Append(fullNameMethod(value19));
                        appendTextInFile($"{value19}", "history.txt");
                     }
                    if (value20 != "")
                    {
                        allData.Append(fullNameMethod(value20));
                        appendTextInFile($"{value20}", "history.txt");
                    }
                    if (value21 != "")
                    {
                        allData.Append(fullNameMethod(value21));
                        appendTextInFile($"{value21}", "history.txt");
                    }
                    if (value22 != "")
                    {
                        allData.Append(fullNameMethod(value22));
                        appendTextInFile($"{value22}", "history.txt");
                    }
                    if (value23 != "")
                    {
                        allData.Append(fullNameMethod(value23));
                        appendTextInFile($"{value23}", "history.txt");
                    }
                    if (value24 != "")
                    {
                        allData.Append(fullNameMethod(value24));
                        appendTextInFile($"{value24}", "history.txt");
                    }
                    if (value25 != "")
                    {
                        allData.Append(fullNameMethod(value25));
                        appendTextInFile($"{value25}", "history.txt");
                    }
                    if (value26 != "")
                    {
                        allData.Append(fullNameMethod(value26));
                        appendTextInFile($"{value26}", "history.txt");
                    }
                    if (value27 != "")
                    {
                        allData.Append(fullNameMethod(value27));
                        appendTextInFile($"{value27}", "history.txt");
                    }
                    if (value28 != "")
                    {
                        allData.Append(fullNameMethod(value28));
                        appendTextInFile($"{value28}", "history.txt");
                    }
                    if (value29 != "")
                    {
                        allData.Append(fullNameMethod(value29));
                        appendTextInFile($"{value29}", "history.txt");
                    }
                        // ComboBoxs
                    if (selectId0.Text != "" || selectId0.Text != "--Select Channel ID--")
                    {
                        allData.Append(fullNameMethod(selectId0.Text));
                        appendTextInFile($"{selectId0.Text}", "history.txt");
                    }
                    if (selectId1.Text != "" || selectId1.Text != "--Select Channel ID--")
                    {
                        allData.Append(fullNameMethod(selectId1.Text));
                        appendTextInFile($"{selectId1.Text}", "history.txt");
                    }
                    if (selectId2.Text != "" || selectId2.Text != "--Select Channel ID--")
                    {
                        allData.Append(fullNameMethod(selectId2.Text));
                        appendTextInFile($"{selectId2.Text}", "history.txt");
                    }
                    if (selectId3.Text != "" || selectId3.Text != "--Select Channel ID--")
                    {
                        allData.Append(fullNameMethod(selectId3.Text));
                        appendTextInFile($"{selectId3.Text}", "history.txt");
                    }
                }
                catch
                {
                    MessageBox.Show("Selected File not XML type...");
                }

                txtEditor.Text = $"{allData}\r\n";
                if (exportFile.IsChecked == true)
                    writeTextInFile(allData.ToString(), "channel.xml");
            }
            else
                MessageBox.Show("Please Select File...", "Checking...");
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

        private void GetChannelFromFile(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    ChannelFilePath = openFileDialog.FileName;
                    channelNames = File.ReadAllLines(ChannelFilePath);
                }
            }
            catch (Exception err) { }
        }
    }
}
