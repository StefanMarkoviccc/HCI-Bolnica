using HCIBolnica.Dialogues.ViewModel;
using HCIBolnica.Model;
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

namespace HCIBolnica.Dialogues.View
{
    public partial class HealthCardPage : Page
    {
        public HealthCardPage(Patient patient)
        {
            InitializeComponent();
            DataContext = new HealthCardViewModel(this,patient);
        }
    }
}
