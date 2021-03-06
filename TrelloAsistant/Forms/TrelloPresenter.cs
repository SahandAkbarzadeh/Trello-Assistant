﻿using Manatee.Trello;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrelloAssistant.Utils
{
    public class TrelloPresenter
    {

        #region Tags

        private readonly string DoneTag = Config.Get(ConfigKeys.DoneTag);
        private readonly string DoingTag = Config.Get(ConfigKeys.DoingTag);
        private readonly string TestingTag = Config.Get(ConfigKeys.TestingTag);
        private readonly string ScrumTag = Config.Get(ConfigKeys.ScrumTag);
        private readonly string PoolTag = Config.Get(ConfigKeys.PoolTag);
        private readonly string MainPoolTag = Config.Get(ConfigKeys.MainPoolTag);


        #endregion

        private IMe Me;
        private IEnumerable<IBoard> ScrumBoards;

        private List<ICard> Tasks = new List<ICard>();
        private ICard CurrentTask;

        public TrelloPresenter() { }

        public async Task Init()
        {
            await Sync();
        }

        public async Task Sync()
        {
            ITrelloFactory factory = new TrelloFactory();
            Loading(true);
            Me = await new TrelloFactory().Me();
            // Get Scrum Boards
            ScrumBoards = Me.Boards.Where((board) => board.Name.Contains(ScrumTag));
            // Get Related Cards and Lists
            Tasks = new List<ICard>();
            foreach (var board in ScrumBoards)
            {
                await board.Refresh();
                var lists = board.Lists.Where((list) =>
                    list.Name.Contains(PoolTag) ||
                    list.Name.Contains(MainPoolTag) ||
                    list.Name.Contains(DoingTag)
                );
                foreach (var list in lists)
                {
                    await list.Refresh();
                    foreach (var card in list.Cards)
                    {
                        await card.Refresh();
                    }
                    Tasks.AddRange(list.Cards.Where((card) => card.Members.Contains(Me)));
                }
            }
            // Get Current Doing Task
            var doingTasks = Tasks.Where((task) => task.List.Name.Contains(DoingTag));
            if (doingTasks.ToArray().Length > 1)
            {
                // TODO: auto move all cards to main pool
                MessageBox.Show("You have more than one card in doing. please fix this manually then rerun the app");
                Environment.Exit(1);
            } else
            {
                CurrentTask = doingTasks.FirstOrDefault();
                OnCurrentTaskChanged(CurrentTask?.Name);
            }

            UpdateTaskList();

            Loading(false);
        }

        void UpdateTaskList()
        {
            var result = new Dictionary<string, List<ICard>>();
            foreach(var task in Tasks)
            {
                if (CurrentTask != null && task.Id == CurrentTask.Id)
                    continue;
                if (!result.ContainsKey(task.Board.Name))
                    result[task.Board.Name] = new List<ICard>();
                result[task.Board.Name].Add(task);
            }
            OnTaskListChanged(result);
        }

        public void SetCurrentTask(ICard card)
        {
            Loading(true);
            card.List = ScrumBoards.Where((b) => b.Id == card.Board.Id).First().Lists.Where((list) => list.Name.Contains(DoingTag)).First();
            if (CurrentTask != null)
                CurrentTask.List = ScrumBoards.Where((b) => b.Id == CurrentTask.Board.Id).First().Lists.Where((list) => list.Name.Contains(MainPoolTag)).First();
            CurrentTask = card;

            OnCurrentTaskChanged(CurrentTask?.Name);
            UpdateTaskList();

            Loading(false);
        }

        public void DoneCurrentTask()
        {
            if (CurrentTask == null)
                return;
            Loading(true);
            CurrentTask.List = ScrumBoards.Where((b) => b.Id == CurrentTask.Board.Id).First().Lists.Where((list) => list.Name.Contains(DoneTag)).First();
            Tasks = Tasks.Where((item) => item.Id != CurrentTask.Id).ToList();
            CurrentTask = null;

            OnCurrentTaskChanged(null);
            UpdateTaskList();

            Loading(false);
        }

        public void ToPoolCurrentTask()
        {
            if (CurrentTask == null)
                return;
            Loading(true);
            CurrentTask.List = ScrumBoards.Where((b) => b.Id == CurrentTask.Board.Id).First().Lists.Where((list) => list.Name.Contains(MainPoolTag)).First();
            CurrentTask = null;

            OnCurrentTaskChanged(null);
            UpdateTaskList();

            Loading(false);
        }

        public void TestCurrentTask()
        {
            if (CurrentTask == null)
                return;
            Loading(true);
            CurrentTask.List = ScrumBoards.Where((b) => b.Id == CurrentTask.Board.Id).First().Lists.Where((list) => list.Name.Contains(TestingTag)).First();
            Tasks = Tasks.Where((item) => item.Id != CurrentTask.Id).ToList();
            CurrentTask = null;

            OnCurrentTaskChanged(null);
            UpdateTaskList();

            Loading(false);
        }

        public void OpenCurrentCard()
        {
            if (CurrentTask == null)
                return;
            System.Diagnostics.Process.Start(CurrentTask.ShortUrl);
        }

        #region Events
        public delegate void StatusChangedDelegate(string status);
        public event StatusChangedDelegate OnStatusChanged;
        public delegate void CurrentTaskChangedDelegate(string name);
        public event CurrentTaskChangedDelegate OnCurrentTaskChanged;
        public delegate void TaskListChangedDelegate(Dictionary<string, List<ICard>> tasks);
        public event TaskListChangedDelegate OnTaskListChanged;
        public delegate void LoadingStatusChangedDelegate(bool loading);
        public event LoadingStatusChangedDelegate OnLoadingChanged;
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
