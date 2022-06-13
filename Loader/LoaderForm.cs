using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loader
{
    public partial class LoaderForm : Form
    {
        private BackgroundWorker backgroundWorker = new BackgroundWorker();
        public string Message { get; set; } = string.Empty;

        public LoaderForm(BackgroundWorker worker, ProgressBarStyle pStyle = ProgressBarStyle.Blocks)
        {
            InitializeComponent();
            progressBar.Style = pStyle;
            backgroundWorker = worker;
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
        }

        private void ProgressDialog_Load(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            Text = $"Loader - {e.ProgressPercentage}%";
            if (e.UserState != null)
                lblLoadContent.Text = e.UserState.ToString();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                progressBar.Value = 100;
                if (progressBar.Style == ProgressBarStyle.Blocks)
                    Text = $"Loader - 100%";
            }
            Task t = new Task(() =>
            {
                Thread.Sleep(1000);
                DialogResult = DialogResult.OK;
            });
            t.Start();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
        }
    }
}
