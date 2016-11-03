using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReportWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _reportViewer.Load += ReportViewer_Load;
        }

        private bool _isReportViewerLoaded;

        private void ReportViewer_Load(object sender, EventArgs e) 
        {
            if (!_isReportViewerLoaded)
            {
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                testDataSet dataset = new testDataSet();

                dataset.BeginInit();

                reportDataSource1.Name = "DataSet1";
                reportDataSource1.Value = dataset.User;
                this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
                this._reportViewer.LocalReport.ReportEmbeddedResource = "ReportWPF.Report.rdlc";

                dataset.EndInit();

                testDataSetTableAdapters.UserTableAdapter userTableAdapter = new testDataSetTableAdapters.UserTableAdapter();
                userTableAdapter.ClearBeforeFill = true;
                userTableAdapter.Fill(dataset.User);

                _reportViewer.RefreshReport();
                _isReportViewerLoaded = true;
            }
        }
    }
}
