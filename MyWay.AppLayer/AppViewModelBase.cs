using Common.DataAdapter.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWay.AppLayer
{
    public class AppViewModelBase : ViewModelBase
    {
        #region Properties
        private string _ResultText;

        public string ResultText
        {
            get { return _ResultText; }
            set
            {
                _ResultText = value;
                RaisePropertyChanged("ResultText");
            }
        }

        public string EventAction { get; set; }
        public string EventValue { get; set; }
        #endregion

        #region Init Method
        public override void Init()
        {
            base.Init();

            ResultText = string.Empty;
        }
        #endregion
    }
}
