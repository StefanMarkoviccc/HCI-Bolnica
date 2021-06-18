using HCIBolnica.Dialogues.ViewModel;
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
using System.Windows.Shapes;

namespace HCIBolnica.Dialogues.View
{
    /// <summary>
    /// Interaction logic for HospitalMainWindow.xaml
    /// </summary>
    public partial class HospitalMainWindow : Window
    {
        Frame mainFrame;

        private static HospitalMainWindow instance;


        public HospitalMainWindow()
        {
            InitializeComponent();
            mainFrame = MainFrame;
            DataContext = new HospitalMainWindowViewModel(this,mainFrame);

            instance = this;
        }

        public Frame MainFramee 
        {
            get { return mainFrame; }
        }

        public static HospitalMainWindow Instance 
        {
            get 
            {
                if (instance == null) 
                {
                    instance = new HospitalMainWindow();
                    
                }

                return instance;
            }
        }
    }
}
