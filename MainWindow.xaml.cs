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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lift.Properties;
using System.Threading;

namespace Lift
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int currentEtage { get { return Int32.Parse(CurrentEtage.Text); } set
            {
                CurrentEtage.Text = value.ToString();
            } }
        bool liftStatus = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn1Etage_Click(object sender, RoutedEventArgs e)
        {
            Button activeButton = (Button)sender;
            int endEtage = Int32.Parse(activeButton.Content.ToString());
            while (currentEtage != endEtage)
            {
                if (currentEtage < endEtage) currentEtage++;
                if (currentEtage > endEtage) currentEtage--;
            }
            ChangeLift();
        }
        private void ChangeLift()
        {
            if (liftStatus)
            {
                liftStatus = false;
                ImgLift.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/liftClosed.png"));
            } else
            {
                liftStatus = true;
                ImgLift.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/liftOpen.png"));
            }
        }
    }
}
