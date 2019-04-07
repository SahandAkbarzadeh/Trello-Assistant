﻿using Manatee.Trello;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskbarHook;
using TrelloAssistant.Utils;
using System.Linq;

namespace TrelloAsistant
{
    public partial class Bar : Form
    {
        public Bar()
        {
            InitializeComponent();
            Setup();
        }

        #region Setup Taskbar and Appearance

        private async void Setup()
        {
            await SetupTaskbar();
            SetupFormAppearance();
            SetupTrelloClient();
        }

        TrelloPresenter presenter;

        private async void SetupTrelloClient()
        {
            var appKey = Config.Get(ConfigKeys.TrelloAppKey);
            var userToken = Config.Get(ConfigKeys.TrelloUserToken);

            if (appKey == string.Empty || userToken == string.Empty) {
                MessageBox.Show("Trello.AppKey or Trello.UserToken must be provided in the config file");
                Environment.Exit(1);
            }

            TrelloAuthorization.Default.AppKey = appKey;
            TrelloAuthorization.Default.UserToken = userToken;

            ITrelloFactory factory = new TrelloFactory();

            presenter = new TrelloPresenter();
            presenter.OnLoadingChanged += LoadingChanged;
            await presenter.Init();
        }

        TaskbarElement process;
        Taskbar taskbar;
        private async Task SetupTaskbar()
        {
            taskbar = TaskBarFactory.GetTaskbar();
            process = await taskbar.AddToTaskbar();
            Size = new Size(452, 30);
            var (X, Y) = ConfigUtils.StringToPosition(Config.Get(ConfigKeys.BarPosition));
            process.SetPosition(X, Y);
        }

        private void SetupFormAppearance()
        {
            var color = TaskbarColor.GetColourAt(TaskbarColor.GetTaskbarPosition().Location);
            color = Color.FromArgb(255, color.R, color.G, color.B);
            // Set form background color to TaskBar color
            BackColor = color;

            ToDoneButton.FlatAppearance.BorderColor = color;
            ToTestingButton.FlatAppearance.BorderColor = color;
            ToPoolButton.FlatAppearance.BorderColor = color;
            SyncButton.FlatAppearance.BorderColor = color;

            ToDoneButton.BackColor = color;
            ToTestingButton.BackColor = color;
            ToPoolButton.BackColor = color;
            SyncButton.BackColor = color;

            DragIcon.BackColor = color;

        }

        #region Drag
        bool IsDragging = false;
        private void Drag_MouseDown(object sender, MouseEventArgs e)
        {
            IsDragging = true;
        }

        private void Drag_MouseUp(object sender, MouseEventArgs e)
        {
            IsDragging = false;
        }

        private void Drag_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDragging)
            {
                var position = ConfigUtils.StringToPosition(Config.Get(ConfigKeys.BarPosition));
                int X = this.Location.X - taskbar.Rectangle.Left + e.X;
                process.SetPosition(NumberUtils.Clamp(X, position.Y, taskbar.Rectangle.Right - 300), 0);
                Config.Set(ConfigKeys.BarPosition, ConfigUtils.PositionToString(X, position.Y));
            }
        }
        #endregion

        #endregion

        #region Events

        void LoadingChanged(bool loading)
        {
            Enabled = !loading;
            CurrentTaskLabel.Visible = !loading;
            StatusLabel.Visible = loading;
            StatusLabel.Text = "Please wait...";
        }

        #endregion
    }
}
