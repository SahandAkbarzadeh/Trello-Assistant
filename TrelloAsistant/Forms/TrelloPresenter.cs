using Manatee.Trello;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloAssistant.Utils
{
    public class TrelloPresenter
    {
        public delegate void StatusChangedDelegate(string status);
        public event StatusChangedDelegate OnStatusChanged;
        public delegate void CurrentTaskChangedDelegate(string name);
        public event CurrentTaskChangedDelegate OnCurrentTaskChanged;
        public delegate void TaskListChangedDelegate();
        public event TaskListChangedDelegate OnTaskListChanged;
        public delegate void LoadingStatusChangedDelegate(bool loading);
        public event LoadingStatusChangedDelegate OnLoadingChanged;

        private IMe Me;

        public TrelloPresenter() { }

        public async Task Init()
        {
            Loading(true);
            Me = await new TrelloFactory().Me();
            Loading(false);
        }

        #region Events

        void Loading(bool loading)
        {
            if (OnLoadingChanged == null) return;
            OnLoadingChanged(loading);
        }

        void Status(string text)
        {
            if (OnStatusChanged == null) return;
            OnStatusChanged(text);
        }

        #endregion
    }
}
