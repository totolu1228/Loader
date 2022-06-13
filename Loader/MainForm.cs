using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Loader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            LoaderForm loader = new LoaderForm(worker);
            worker.DoWork += (object obj, DoWorkEventArgs args) =>
            {
                Builder builder = new Builder();
                builder.Step1();
                worker.ReportProgress(40, "Step1");
                if (worker.CancellationPending)
                {
                    args.Cancel = true;
                    return;
                }
                builder.Step2();
                worker.ReportProgress(80, "Step2");
                if (worker.CancellationPending)
                {
                    args.Cancel = true;
                    return;
                }
                builder.Step3();
                worker.ReportProgress(100, "Step3");
                if (worker.CancellationPending)
                {
                    args.Cancel = true;
                    return;
                }
            };
            loader.ShowDialog();
        }
    }
}
