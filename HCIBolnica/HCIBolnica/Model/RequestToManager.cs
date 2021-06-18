using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Model
{
    public class RequestToManager : Entity
    {
        private Doctor doctor;
        private string requestDescription;
        private DateTime beginningOfHoliday = DateTime.Now;
        private DateTime endOfHoliday = DateTime.Now;
        private string requestId;
        private RequestStatus status;
       
        public RequestToManager()
        {

        }
        public RequestToManager(Doctor doctor, string requestDescription, DateTime beginningOfHoliday, DateTime endOfHoliday, string requestId, RequestStatus status = RequestStatus.New)
        {
            this.doctor = doctor;
            this.requestDescription = requestDescription;
            this.beginningOfHoliday = beginningOfHoliday;
            this.endOfHoliday = endOfHoliday;
            this.requestId = requestId;
            this.status = status;
        }

        public override string Validate(string columName)
        {
            return "";
        }

        public override void InitExportList()
        {
        }

        public Doctor Doctor
        {
            get { return doctor; }
            set
            {
                doctor = value;
                OnPropertyChanged(nameof(Doctor));
            }
        }

        public string RequestDescription
        {
            get { return requestDescription; }
            set
            {
                requestDescription = value;
                OnPropertyChanged(nameof(RequestDescription));
            }
        }

        public DateTime BeginningOfHoliday
        {
            get { return beginningOfHoliday; }
            set
            {
                beginningOfHoliday = value;
                OnPropertyChanged(nameof(BeginningOfHoliday));
            }
        }
        public DateTime EndOfHoliday
        {
            get { return endOfHoliday; }
            set
            {
                endOfHoliday = value;
                OnPropertyChanged(nameof(EndOfHoliday));
            }
        }

        public string RequestId
        {
            get { return requestId; }
            set
            {
                requestId = value;
                OnPropertyChanged(nameof(RequestId));
            }
        }

        public RequestStatus Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
    }
}
