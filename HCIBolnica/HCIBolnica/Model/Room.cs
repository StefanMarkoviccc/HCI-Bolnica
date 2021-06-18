using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Model
{
    public class Room : Entity
    {
        private RoomType roomType;
        private string roomNumber;
        private bool busy;
        public Room(RoomType roomType, string roomId)
        {
            this.roomType = roomType;
            this.roomNumber = roomId;
        }
        public Room() { }

        public override string Validate(string columName)
        {
            return "";
        }

        public override void InitExportList()
        {
        }

        public RoomType RoomType
        {
            get { return roomType; }
            set
            {
                roomType = value;
                OnPropertyChanged(nameof(RoomType));
            }
        }

        public string RoomNumber
        {
            get { return roomNumber; }
            set
            {
                roomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }

        public bool Busy
        {
            get { return busy; }
            set
            {
                busy = value;
                OnPropertyChanged(nameof(Busy));
            }
        }
    }
}
