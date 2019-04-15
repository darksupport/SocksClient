using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestTypeApp.Client;

namespace TestTypeApp
{
    public class ModelManufacture : IBaseModel<CManufacture>
    {
        ManufactureRef.ManufactureServiceClient service;
        BindingList<CManufacture> types;
        List<CManufacture> toSave;
        List<int> toDelete;
        TestTypeApp.Client.Converter<ManufactureRef.manufacture, CManufacture> converter;

        public ModelManufacture(ManufactureRef.ManufactureServiceClient service)
        {
            this.service = service;

            types = new BindingList<CManufacture>();
            toSave = new List<CManufacture>();
            toDelete = new List<int>();
            converter = new TestTypeApp.Client.Converter<ManufactureRef.manufacture, CManufacture>();
            types.ListChanged += types_ListChanged;
        }

        private void types_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged ||
                e.ListChangedType == ListChangedType.ItemAdded)
            {
                //toSave.Clear();
                if (e.OldIndex != -1)
                {
                    toSave.Add(types[e.OldIndex]);
                    toSave = toSave.Distinct().ToList();
                    //  toDelete.Add(types[e.OldIndex].Id);
                }
                //  toSave.Add(types[e.NewIndex]);
                //    
                //  MessageBox.Show(types.Count.ToString());

            }
            //if (e.ListChangedType == ListChangedType.ItemDeleted)
            //{

            //}

        }

        public void Reload()
        {
            try
            {
                types.ListChanged -= types_ListChanged;

                toDelete.Clear();
                toSave.Clear();
                types.Clear();
                converter.toClientType(this.service.readAll())
                    .ForEach(n => types.Add(n));
                types.ListChanged += types_ListChanged;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void Save()
        {
            try
            {
                service.save(new TestTypeApp.Client.Converter<ManufactureRef.manufacture, CManufacture>().toDto(toSave));

                toDelete.ForEach(n => service.delete(n));
                Reload();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Delete(CManufacture c)
        {
            try
            {
                toDelete.Add(c.Id);
                // service.delete(toDelete.FirstOrDefault());
                // Reload();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Add()
        {
            try
            {
                CManufacture t = new CManufacture();
                // t.Id = 100;
                t.Name = "some text";
                //MessageBox.Show(t.Name);
                //toSave.Add(t);
                //toSave = toSave.Distinct().ToList();
                types.Add(t);
                //Reload();
                // MessageBox.Show("Ok!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public BindingList<CManufacture> ItemList
        {
            get
            {
                return types;
            }
            set
            {
                types = value;
            }
        }

        public List<CManufacture> SaveList
        {
            get
            {
                return toSave;
            }
            set
            {
                toSave = value;
            }
        }

        public List<int> DeleteList
        {
            get
            {
                return toDelete;
            }
            set
            {
                toDelete = value;
            }
        }

    }
}
