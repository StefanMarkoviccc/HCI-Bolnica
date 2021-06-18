using HCI_Bolnica.CompositeComon;
using HCIBolnica.CompositeComon;
using HCIBolnica.Model;
using HCIBolnica.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using System.Diagnostics;
using HCIBolnica.Dialogues.View;

namespace HCIBolnica.Dialogues.ViewModel
{
    public class PatientHistoryReportViewModel : ViewModelBase
    {
        private ObservableCollection<Anamneza> anamnezes = new ObservableCollection<Anamneza>();
        private RelayCommand generateReportCommand;
        private RelayCommand searchCommand;
        private RelayCommand cancelCommand;
        private AnamnezaRepository anamnezaRepository = new AnamnezaRepository();
        private DateTime startDate = DateTime.Now;
        private DateTime endDate = DateTime.Now;
        private string search;



        public PatientHistoryReportViewModel()
        {
        }
        public PatientHistoryReportViewModel(Patient patient)
        {
            Anamnezes = new ObservableCollection<Anamneza>(anamnezaRepository.FindPatientHistory(patient));
        }

        public ObservableCollection<Anamneza> Anamnezes
        {
            get { return anamnezes; }
            set
            {
                anamnezes = value;
                OnPropertyChanged(nameof(Anamnezes));
            }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        public string Search
        {
            get{ return search; }
            set
            {
                search = value;
                OnPropertyChanged(nameof(Search));
            }
        }

        public RelayCommand GenerateReportCommand
        {
            get { return generateReportCommand ?? (generateReportCommand = new RelayCommand(param => GenerateReportCommandExecute(), param => CanGenerateReportCommandExecute())); }
        }
        public RelayCommand CancelCommand
        {
            get { return cancelCommand ?? (cancelCommand = new RelayCommand(param => CancelCommandExecute(), param => CanCancelCommandExecute())); }
        }

        public RelayCommand SearchCommand
        {
            get { return searchCommand ?? (searchCommand = new RelayCommand(param => SearchCommandExecute(), param => CanSearchCommandExecute())); }
        }
        public void CancelCommandExecute()
        {
            FirstPage firstPage = new FirstPage();
            HospitalMainWindow.Instance.MainFrame.Content = firstPage;
        }

        public bool CanCancelCommandExecute() { return true; }

        public void GenerateReportCommandExecute()
        {
            // Must have write permissions to the path folder
            PdfWriter writer = new PdfWriter(@"C:\Users\Markoviccc\OneDrive\Desktop\reports\demo.pdf");
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            Paragraph header = new Paragraph("Report")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(20);

            document.Add(header);

            Table table = new Table(4, false);

            table.AddCell(new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("ID")));

            table.AddCell(new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("Pacijent")));

            table.AddCell(new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("Simtomi")));

            table.AddCell(new Cell(1, 1)
               .SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new Paragraph("Izvestaj lekara")));

            foreach (Anamneza anamneza in Anamnezes) 
            {
                table.AddCell(new Cell(1, 1)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph(anamneza.ID)));

                table.AddCell(new Cell(1, 1)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph(anamneza.Patient.FirstName + " " + anamneza.Patient.LastName)));

                table.AddCell(new Cell(1, 1)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph(anamneza.Simptoms)));

                table.AddCell(new Cell(1, 1)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph(anamneza.DoctorReport)));
            }

            document.Add(table);

            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "acroRd32.exe"; //not the full application path
            myProcess.StartInfo.Arguments = "/A \"page=2=OpenActions\" C:\\Users\\Markoviccc\\OneDrive\\Desktop\\reports\\demo.pdf";
            myProcess.Start();

            document.Close();
        }

        public bool CanGenerateReportCommandExecute()
        {
            return true;
        } 

        public void SearchCommandExecute()
        {

            Anamnezes = new ObservableCollection<Anamneza>(anamnezaRepository.SearchByDate(StartDate, EndDate));

        }

        public bool CanSearchCommandExecute()
        {
            return true;
        }
    }
}

