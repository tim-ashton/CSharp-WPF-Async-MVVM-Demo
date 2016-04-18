using AsyncDemo.Veiw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncDemo.Services
{
    class ProgressDialogService : IDialogService
    {
        private Window progressDialog;

        public ProgressDialogService()
        { }

        public void CloseDialog()
        {
            if (progressDialog != null)
            {
                progressDialog.Close();
            }
        }

        public void ShowDialog()
        {
            progressDialog = new ProgressDialog();
            progressDialog.ShowDialog();
        }
    }
}
