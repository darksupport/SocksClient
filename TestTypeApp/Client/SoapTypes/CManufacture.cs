using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTypeApp.Client
{
    public class CManufacture : Transportable<ManufactureRef.manufacture>, INotifyPropertyChanged
    {
        public CManufacture() : base(new ManufactureRef.manufacture())
        { PropertyChanged += CType_PropertyChanged; }

        private void CType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            dto.name = this.Name;
        }

        public CManufacture(ManufactureRef.manufacture manufacture) : base(manufacture)
        { }

        public int Id
        {
            get { return dto.id; }
            set { dto.id = value; } //???
        }
        public string Name
        {
            get { return dto.name; }
            set { dto.name = value; PropertyChanged(this, new PropertyChangedEventArgs("Name")); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}