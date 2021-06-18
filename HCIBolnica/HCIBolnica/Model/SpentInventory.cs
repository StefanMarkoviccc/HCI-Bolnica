using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Model
{
    public class SpentInventory : Entity
    {
        private string inventoryName;
        private string inventoryQuantity;

        public SpentInventory(string inventoryName, string inventoryQuantity)
        {
            this.inventoryName = inventoryName;
            this.inventoryQuantity = inventoryQuantity;
        }

        public SpentInventory()
        {
        }

        public string InventoryName
        {
            get { return inventoryName; }
            set
            {
                inventoryName = value;
                OnPropertyChanged(nameof(InventoryName));
            }
        }

        public string InventoryQuantity
        {
            get { return inventoryQuantity; }
            set
            {
                inventoryQuantity = value;
                OnPropertyChanged(nameof(InventoryQuantity));
            }
        }

        public override void InitExportList()
        {
        }

        public override string Validate(string columName)
        {
            return "";
         }
    }
}
