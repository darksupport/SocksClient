using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestTypeApp.Presenter;
using TestTypeApp.REST;

namespace TestTypeApp
{
    public partial class Form1 : Form
    {
        public Form1(TypeRef.TypeServiceClient service, ModelType model)
        {
            InitializeComponent();

            TypePresenter presenter = new TypePresenter(model, typeSetupControl1);

            //TestRestClient client = new TestRestClient();
           // MessageBox.Show(client.DbTest("some text"));
            
        }
        public Form1(ManufactureRef.ManufactureServiceClient service, ModelManufacture model)
        {
            InitializeComponent();

            ManufacturePresenter presenter = new ManufacturePresenter(model, manufactureSetupControl1);

        }
        public Form1(MaterialRef.MaterialServiceClient service, ModelMaterial model)
        {
            InitializeComponent();

            MaterialPresenter presenter = new MaterialPresenter(model,materialSetupControl1);

        }
        private void typeSetupControl1_Load(object sender, EventArgs e)
        {
            //ReportForm form = new ReportForm();
           // form.Show();
        }
    }
}
