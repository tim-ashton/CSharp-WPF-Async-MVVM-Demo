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
        private Window owner;

        public ProgressDialogService(Window owner)
        {
            this.owner = owner;
        }

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

            if (owner != null)
                progressDialog.Owner = owner;

            progressDialog.ShowDialog();
        }
    }
}
