using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTypeApp.Client;

namespace TestTypeApp
{
    interface IBaseModel<ClietType> 
    {
        void Save();
        void Reload();
        void Delete(ClietType c);
        void Add();
        BindingList<ClietType> ItemList { get; set; }
        List<ClietType> SaveList { get; set; }
        List<int> DeleteList { get; set; }
    }
}
