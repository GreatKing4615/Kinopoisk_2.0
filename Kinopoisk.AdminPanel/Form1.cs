using Kinopoisk.Infrastructure.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinopoisk.AdminPanel
{
    public partial class Form1 : Form
    {
        UnitOfWork unitOfWork;
        public Form1()
        {
            IKernel ninjectKernel = new StandardKernel();
            //ninjectKernel.Bind<UnitOfWork>().To.SQL;
            //unitOfWork = new UnitOfWork(dbContext);
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var actors = unitOfWork.SQLActor.GetAllObjects();
            listView1.Items.AddRange((ListView.ListViewItemCollection)actors);
        }
    }
}
