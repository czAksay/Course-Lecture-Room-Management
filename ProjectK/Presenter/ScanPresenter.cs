using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectK.Models;
using ProjectK.View;

namespace ProjectK.Presenter
{
    class ScanPresenter : IScanPresenter
    {
        ScanModel model;
        IScanView view;

        public ScanPresenter(IScanView view)
        {
            model = new ScanModel();
            this.view = view;
        }
    }
}
