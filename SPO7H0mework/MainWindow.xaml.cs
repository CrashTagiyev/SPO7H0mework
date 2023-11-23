using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SPO7Homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {


        string jsonPath = @"C:\Users\Crash\source\repos\SPO7H0mework\SPO7H0mework\WordsJson.json";

        Task timerTask = new Task(() => { });

        CancellationTokenSource cts = new CancellationTokenSource();
        string currentLetter;

        int timerSecond = 0;
        int timerDuration = 4;
        string currentNumberTask = "";

        private string currentSearchedText;

        public string CurrentSearchedText
        {
            get { return currentSearchedText; }
            set { currentSearchedText = value; OnPropertyChanged(nameof(currentSearchedText)); }
        }
        Task clickKeysTask = new(() => { });
        bool isTextSelected = true;
        bool isLetterSelected = false;
        int removableIndex = -1;
        int selectedIndex = -1;
        int selectedLenght = -1;
        public MainWindow()
        {
            InitializeComponent();
            FillButtons();
            DataContext = this;
            clickKeysTask = new(ClickNumPad);
            MessageBox.Show("Muellim salam,jsonpath fieldini oz kompuvuza gore deyiwin json file ele projektin ichindedi");
        }
        private void ClickNumPad()
        {
            var key = Console.ReadKey();
            MessageBox.Show(key.Key.ToString());
        }
        private string? JsonSerializingToList(char letter)
        {
            string jsonString = File.ReadAllText(jsonPath);

            dynamic jsn = JsonConvert.DeserializeObject(jsonString);
            List<string> wordsList = jsn.words.ToObject<List<string>>();

            for (int i = 0; i < wordsList.Count; i++)
            {
                if (wordsList[i][0] == letter)
                {
                    string wordWithoutFirstLetter = "";
                    for (int j = 1; j < wordsList[i].Length; j++)
                    {
                        wordWithoutFirstLetter += wordsList[i][j];

                    }
                    return wordWithoutFirstLetter;
                }
            }
            return null;
        }

        private void Num_Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Content.ToString().Contains("1"))
            {
                WriteLetter("1");
            }
            else if (btn.Content.ToString().Contains("2"))
            {
                if (currentNumberTask != "2" && timerTask.Status == TaskStatus.Running)
                {
                    cts.Cancel();
                    timerTask.Wait(TimeSpan.FromMicroseconds(1));
                }
                WriteLetter("2");

            }
            else if (btn.Content.ToString().Contains("3"))
            {
                if (currentNumberTask != "3" && timerTask.Status == TaskStatus.Running)
                {
                    cts.Cancel();
                    timerTask.Wait(TimeSpan.FromMicroseconds(1));
                }
                WriteLetter("3");
            }
            else if (btn.Content.ToString().Contains("4"))
            {
                if (currentNumberTask != "4" && timerTask.Status == TaskStatus.Running)
                {
                    cts.Cancel();
                    timerTask.Wait(TimeSpan.FromMicroseconds(1));
                }
                WriteLetter("4");
            }
            else if (btn.Content.ToString().Contains("5"))
            {
                if (currentNumberTask != "5" && timerTask.Status == TaskStatus.Running)
                {
                    cts.Cancel();
                    timerTask.Wait(TimeSpan.FromMicroseconds(1));
                }
                WriteLetter("5");
            }
            else if (btn.Content.ToString().Contains("6"))
            {
                if (currentNumberTask != "6" && timerTask.Status == TaskStatus.Running)
                {
                    cts.Cancel();
                    timerTask.Wait(TimeSpan.FromMicroseconds(1));
                }
                WriteLetter("6");
            }
            else if (btn.Content.ToString().Contains("7"))
            {
                if (currentNumberTask != "7" && timerTask.Status == TaskStatus.Running)
                {
                    cts.Cancel();
                    timerTask.Wait(TimeSpan.FromMicroseconds(1));
                }
                WriteLetter("7");
            }
            else if (btn.Content.ToString().Contains("8"))
            {
                if (currentNumberTask != "8" && timerTask.Status == TaskStatus.Running)
                {
                    cts.Cancel();
                    timerTask.Wait(TimeSpan.FromMicroseconds(1));
                }
                WriteLetter("8");
            }
            else if (btn.Content.ToString().Contains("8"))
            {
                if (currentNumberTask != "8" && timerTask.Status == TaskStatus.Running)
                {
                    cts.Cancel();
                    timerTask.Wait(TimeSpan.FromMicroseconds(1));
                }
                WriteLetter("8");
            }
            else if (btn.Content.ToString().Contains("9"))
            {
                if (currentNumberTask != "9" && timerTask.Status == TaskStatus.Running)
                {
                    cts.Cancel();
                    timerTask.Wait(TimeSpan.FromMicroseconds(1));
                }
                WriteLetter("9");
            }
            else if (btn.Content.ToString().Contains("*"))
            {
                if (currentNumberTask != "10" && timerTask.Status == TaskStatus.Running)
                {
                    cts.Cancel();
                    timerTask.Wait(TimeSpan.FromMicroseconds(1));
                }
                WriteLetter("10");
            }
            else if (btn.Content.ToString().Contains("0"))
            {
                if (currentNumberTask != "11" && timerTask.Status == TaskStatus.Running)
                {
                    cts.Cancel();
                    timerTask.Wait(TimeSpan.FromMicroseconds(1));
                }
                WriteLetter("11");
            }
            else if (btn.Content.ToString().Contains("#"))
            {
                if (currentNumberTask != "12" && timerTask.Status == TaskStatus.Running)
                {
                    cts.Cancel();
                    timerTask.Wait(TimeSpan.FromMicroseconds(1));
                }
                WriteLetter("12");
            }

        }
        string RemoveSelectedText()
        {
            string removedString = "";
            for (int i = 0; i < removableIndex; i++)
            {
                removedString += Search_TB.Text[i];
            }
            for (int i = Search_TB.SelectionLength; i < Search_TB.Text.Length - 1; i++)
            {
                removedString += Search_TB.Text[i];
            }
            return removedString;
        }
        void WriteLetter(string buttonNumber)
        {
            StringBuilder sb = new(Search_TB.Text);
            if (buttonNumber == "1")
            {
                Search_TB.Text += "1";
                if (timerTask.Status == TaskStatus.Running)
                {
                    cts.Cancel();
                }
                timerSecond = 0;
            }
            else if (buttonNumber == "2")
            {
                if (timerSecond == 0)
                {
                    Search_TB.Text += "a";
                    currentLetter = "a";
                    currentNumberTask = "2";
                    timerTask = new(CallTimer);
                    timerTask.Start();
                }
                else if (currentLetter == "a")
                {
                    sb[sb.Length - 1] = 'b';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "b";
                    timerSecond = 1;
                }
                else if (currentLetter == "b")
                {
                    sb[sb.Length - 1] = 'c';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "c";
                    timerSecond = 1;
                }
                else if (currentLetter == "c")
                {
                    sb[sb.Length - 1] = 'a';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "a";
                    timerSecond = 1;
                }

            }
            else if (buttonNumber == "3")
            {
                if (timerSecond == 0)
                {
                    Search_TB.Text += "d";
                    currentLetter = "d";
                    currentNumberTask = "3";
                    timerTask = new(CallTimer);
                    timerTask.Start();
                }
                else if (currentLetter == "d")
                {
                    sb[sb.Length - 1] = 'e';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "e";
                    timerSecond = 1;
                }
                else if (currentLetter == "e")
                {
                    sb[sb.Length - 1] = 'f';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "f";
                    timerSecond = 1;
                }
                else if (currentLetter == "f")
                {
                    sb[sb.Length - 1] = 'd';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "d";
                    timerSecond = 1;
                }

            }
            else if (buttonNumber == "4")
            {
                if (timerSecond == 0)
                {
                    Search_TB.Text += "g";
                    currentLetter = "g";
                    currentNumberTask = "4";
                    timerTask = new(CallTimer);
                    timerTask.Start();
                }
                else if (currentLetter == "g")
                {
                    sb[sb.Length - 1] = 'h';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "h";
                    timerSecond = 1;
                }
                else if (currentLetter == "h")
                {
                    sb[sb.Length - 1] = 'i';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "i";
                    timerSecond = 1;
                }
                else if (currentLetter == "i")
                {
                    sb[sb.Length - 1] = 'g';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "g";
                    timerSecond = 1;
                }

            }
            else if (buttonNumber == "5")
            {
                if (timerSecond == 0)
                {
                    Search_TB.Text += "j";
                    currentLetter = "j";
                    currentNumberTask = "5";
                    timerTask = new(CallTimer);
                    timerTask.Start();
                }
                else if (currentLetter == "j")
                {
                    sb[sb.Length - 1] = 'k';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "k";
                    timerSecond = 1;
                }
                else if (currentLetter == "k")
                {
                    sb[sb.Length - 1] = 'l';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "l";
                    timerSecond = 1;
                }
                else if (currentLetter == "l")
                {
                    sb[sb.Length - 1] = 'j';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "j";
                    timerSecond = 1;
                }

            }
            else if (buttonNumber == "6")
            {
                if (timerSecond == 0)
                {
                    Search_TB.Text += "m";
                    currentLetter = "m";
                    currentNumberTask = "6";
                    timerTask = new(CallTimer);
                    timerTask.Start();
                }
                else if (currentLetter == "m")
                {
                    sb[sb.Length - 1] = 'n';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "n";
                    timerSecond = 1;
                }
                else if (currentLetter == "n")
                {
                    sb[sb.Length - 1] = 'o';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "o";
                    timerSecond = 1;
                }
                else if (currentLetter == "o")
                {
                    sb[sb.Length - 1] = 'm';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "m";
                    timerSecond = 1;
                }

            }
            else if (buttonNumber == "7")
            {
                if (timerSecond == 0)
                {
                    Search_TB.Text += "p";
                    currentLetter = "p";
                    currentNumberTask = "7";
                    timerTask = new(CallTimer);
                    timerTask.Start();
                }
                else if (currentLetter == "p")
                {
                    sb[sb.Length - 1] = 'q';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "q";
                    timerSecond = 1;
                }
                else if (currentLetter == "q")
                {
                    sb[sb.Length - 1] = 'r';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "r";
                    timerSecond = 1;
                }
                else if (currentLetter == "r")
                {
                    sb[sb.Length - 1] = 's';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "s";
                    timerSecond = 1;
                }
                else if (currentLetter == "s")
                {
                    sb[sb.Length - 1] = 'p';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "p";
                    timerSecond = 1;
                }

            }
            else if (buttonNumber == "8")
            {
                if (timerSecond == 0)
                {
                    Search_TB.Text += "t";
                    currentLetter = "t";
                    currentNumberTask = "8";
                    timerTask = new(CallTimer);
                    timerTask.Start();
                }
                else if (currentLetter == "t")
                {
                    sb[sb.Length - 1] = 'u';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "u";
                    timerSecond = 1;
                }
                else if (currentLetter == "u")
                {
                    sb[sb.Length - 1] = 'v';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "v";
                    timerSecond = 1;
                }
                else if (currentLetter == "v")
                {
                    sb[sb.Length - 1] = 't';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "t";
                    timerSecond = 1;
                }

            }
            else if (buttonNumber == "9")
            {
                if (timerSecond == 0)
                {
                    Search_TB.Text += "w";
                    currentLetter = "w";
                    currentNumberTask = "9";
                    timerTask = new(CallTimer);
                    timerTask.Start();
                }
                else if (currentLetter == "w")
                {
                    sb[sb.Length - 1] = 'x';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "x";
                    timerSecond = 1;
                }
                else if (currentLetter == "x")
                {
                    sb[sb.Length - 1] = 'y';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "y";
                    timerSecond = 1;
                }
                else if (currentLetter == "y")
                {
                    sb[sb.Length - 1] = 'z';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "z";
                    timerSecond = 1;
                }
                else if (currentLetter == "z")
                {
                    sb[sb.Length - 1] = 'w';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "w";
                    timerSecond = 1;
                }

            }
            else if (buttonNumber == "10")
            {
                if (timerSecond == 0)
                {
                    Search_TB.Text += "*";
                    currentLetter = "*";
                    currentNumberTask = "10";
                    timerTask = new(CallTimer);
                    timerTask.Start();
                }

            }
            else if (buttonNumber == "11")
            {
                if (timerSecond == 0)
                {
                    Search_TB.Text += "0";
                    currentLetter = "0";
                    currentNumberTask = "11";
                    timerTask = new(CallTimer);
                    timerTask.Start();
                }
                else if (currentLetter == "0")
                {
                    sb[sb.Length - 1] = '+';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "+";
                    timerSecond = 1;
                }
                else if (currentLetter == "+")
                {
                    sb[sb.Length - 1] = '0';
                    Search_TB.Text = sb.ToString();
                    currentLetter = "0";
                    timerSecond = 1;
                }

            }
            else if (buttonNumber == "12")
            {
                if (timerSecond == 0)
                {
                    Search_TB.Text += "#";
                    currentLetter = "#";
                    currentNumberTask = "12";
                    timerTask = new(CallTimer);
                    timerTask.Start();
                }

            }

        }
        void CallTimer()
        {
            if (timerSecond == 0)
            {

                while (timerSecond != timerDuration)
                {
                    if (cts.IsCancellationRequested)
                    {
                        timerSecond = 0;
                        isLetterSelected = true;
                        cts = new();
                        return;
                    }
                    else
                    {
                        ++timerSecond;
                        Thread.Sleep(55);
                    }

                }
                timerSecond = 0;


            }
            Dispatcher.Invoke(FindCorrectWords);
        }
        public void Button_C_Click(object sender, RoutedEventArgs e)
        {
            if (Search_TB.Text != null && Search_TB.Text.Length >= 0)
            {
                string removedText = StringLastLetterRemover(Search_TB.Text);
                Search_TB.Text = removedText;
            }
        }
        private string StringLastLetterRemover(string txt)
        {
            string temp = "";
            if (txt != null)
            {
                for (int i = 0; i < txt.Length - 1; i++)
                {
                    temp += txt[i];
                }
            }
            return temp;

        }
        private void FillButtons()
        {
            Left_Button.Content = "<";
            Right_Button.Content = ">";
            Up_Button.Content = "^";
            Down_Button.Content = "v";
            Search_TB.Text = "";
            string[][] btnContents =
            [
                ["1", "  2\nABC", "  3\nDEF"],
                ["  4\nGHI", "  5\nJKL", "   6\nMNO"],
                ["   7\nPQRS", "  8\nTUV", "   9\nWXYZ"],
                ["*", "0\n+", "#"],
            ];
            int num = 1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ++num;
                    Button btn = new Button()
                    {
                        Margin = new Thickness(3),
                        FontSize = 20,
                        FontWeight = FontWeights.Bold,
                        Content = btnContents[i][j]
                    };
                    btn.Click += Num_Button_Click;
                    Numbers_Grid.Children.Add(btn);
                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);
                }
            }
        }

        private void FindCorrectWords()
        {
            string resultword = JsonSerializingToList(Search_TB.Text[Search_TB.Text.Length - 1]);
            CurrentSearchedText += resultword;
            removableIndex = Search_TB.Text.Length - resultword.Length;
            Search_TB.Focus();
            Search_TB.SelectionStart = Search_TB.Text.Length - resultword.Length;
            Search_TB.SelectionLength = Search_TB.Text.Length;
            selectedIndex = Search_TB.SelectionStart;
            selectedLenght = Search_TB.SelectionLength;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        private void Left_Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void NumPad_Key_Down(object sender, KeyEventArgs e)
        {
            Left_Button.Focus();
            switch (e.Key)
            {
                case Key.NumPad7: Num_Button_Click(new Button() { Content = "1" }, new RoutedEventArgs()); break;
                case Key.NumPad8: Num_Button_Click(new Button() { Content = "2" }, new RoutedEventArgs()); break;
                case Key.NumPad9: Num_Button_Click(new Button() { Content = "3" }, new RoutedEventArgs()); break;
                case Key.NumPad4: Num_Button_Click(new Button() { Content = "4" }, new RoutedEventArgs()); break;
                case Key.NumPad5: Num_Button_Click(new Button() { Content = "5" }, new RoutedEventArgs()); break;
                case Key.NumPad6: Num_Button_Click(new Button() { Content = "6" }, new RoutedEventArgs()); break;
                case Key.NumPad1: Num_Button_Click(new Button() { Content = "7" }, new RoutedEventArgs()); break;
                case Key.NumPad2: Num_Button_Click(new Button() { Content = "8" }, new RoutedEventArgs()); break;
                case Key.NumPad3: Num_Button_Click(new Button() { Content = "9" }, new RoutedEventArgs()); break;
                case Key.Right: Num_Button_Click(new Button() { Content = "*" }, new RoutedEventArgs()); break;
                case Key.NumPad0: Num_Button_Click(new Button() { Content = "0" }, new RoutedEventArgs()); break;
                case Key.Decimal: Num_Button_Click(new Button() { Content = "#" }, new RoutedEventArgs()); break;
            }
        }

        private void Add_Word_Button_Click(object sender, RoutedEventArgs e)
        {
            string jsonString = File.ReadAllText(jsonPath);

            dynamic jsn = JsonConvert.DeserializeObject(jsonString);
            List<string> wordsList = jsn.words.ToObject<List<string>>();
            wordsList.Add(Search_TB.Text);
            Words words = new Words() { words = wordsList };
            var jsonSeri = JsonConvert.SerializeObject(words, Formatting.Indented);
            File.WriteAllText(jsonPath, jsonSeri);

        }
        class Words
        {
            public List<string> words { get; set; }
        }
    }

}