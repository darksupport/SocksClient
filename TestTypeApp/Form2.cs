using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTypeApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void typesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypeRef.TypeServiceClient service = new TypeRef.TypeServiceClient();
            ModelType model = new ModelType(service);
            Form1 form1 = new Form1(service, model);
            form1.MdiParent = this;
            form1.Controls[0].Show();
            form1.Show();
        }

        private void manufactureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManufactureRef.ManufactureServiceClient service = new ManufactureRef.ManufactureServiceClient();
            ModelManufacture model = new ModelManufacture(service);
            Form1 form1 = new Form1(service, model);
            form1.MdiParent = this;
            form1.Controls[1].Show();
            form1.Show();
        }

        private void materialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaterialRef.MaterialServiceClient service = new MaterialRef.MaterialServiceClient();
            ModelMaterial model = new ModelMaterial(service);
            Form1 form1 = new Form1(service, model);
            form1.MdiParent = this;
            form1.Controls[2].Show();
            form1.Show();
        }
    }
}
