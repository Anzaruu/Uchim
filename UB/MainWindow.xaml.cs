using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Budzhet> budets;
        DS files = new DS();
        List<string> items = new List<string>();
        Budzhet bude = new Budzhet();

        public MainWindow()
        {
            InitializeComponent();
            Dat.Text = DateTime.Now.ToString();
        }

        public void Appd()
        {
            var budzh = DS.Des<List<Budzhet>>();
            int sum = 0;
            foreach (var bud in budets)
            {
                if (bud.GetDate() == Dat.DisplayDate) 
                {
                    budets.Add(bud);
                }
                sum += bud.Money;
            }
            DatPic.ItemsSource = null;
            Itog.Text = "Итог: " + Convert.ToString(sum);
            DatPic.ItemsSource = budets;
        }

        public void AddType(string item)
        {
            items.Add(item);
            Types.ItemsSource = items;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var budzh = DS.Des<List<Budzhet>>();
            bude.Date = Dat.DisplayDate;
            bude.Name = NameOf.Text;
            bude.Money = Convert.ToInt32(Summ.Text);
            if ((sender as Button).Name == "CreateType")
            {
                AddType window = new AddType();
                window.ShowDialog();
            }
            else if ((sender as Button).Name == "CreateZap")
            {
                budzh.Add(bude);
            }
            else if ((sender as Button).Name == "SaveZap")
            {
                foreach (var bud in budets)
                {
                    if ((bud.GetDate() == Dat.DisplayDate) || (bud.Name == bude.Name) || (bud.Type == bude.Type))
                    {
                        bude.Date = Dat.DisplayDate;
                        bude.Name = bud.Name;
                        bude.Money = bud.Money;
                        bude.Type = bud.Type;
                    }
                }
            }
            else if ((sender as Button).Name == "DeleteZap")
            {
                foreach (var bud in budets)
                {
                    if ((bud.GetDate() == Dat.DisplayDate) && (bud.Name == bude.Name) && (bud.Money == bude.Money) && (bud.Type == bude.Type))
                    {
                        budets.Remove(bud);
                    }
                }
            }
            files.Ser(budzh);
            Appd();
        }

        private void DatPic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var budzh = DS.Des<List<Budzhet>>();
            Budzhet selected = DatPic.SelectedItem as Budzhet;
            foreach (var bud in budets)
            {
                if ((bud.GetDate() == Dat.DisplayDate) && (bud.Name == selected.Name))
                {
                    NameOf.Text = bud.Name;
                    Types.Text = bud.Type;
                    Summ.Text = Convert.ToString(bud.Money);
                }
            }
        }

        private void Types_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = Types.SelectedItem as string;
            bude.Type = selected;
        }
    }
}
