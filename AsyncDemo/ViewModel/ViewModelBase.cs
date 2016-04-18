using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDemo.ViewModel
{
    class ViewModelBase
    {

        /// <summary>
        /// Sets the title of the view for the viewmodel
        /// </summary>
        public virtual string ViewTitle { get; protected set; }
    }
}
