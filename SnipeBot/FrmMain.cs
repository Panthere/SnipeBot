using POGOProtos.Enums;
using SnipeBot.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using SnipeBot.UserLogger;

namespace SnipeBot
{
    public partial class FrmMain : Form
    {
        Bot.PokeAccount acc;
        bool loginMsg;
        public FrmMain()
        {
            InitializeComponent();
            

        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            Logger.SetLogger(new UserLogger.EventLogger(LogLevel.Info));

            Utils.Events.OnMessageReceived += Events_OnMessageReceived;

            LoadSettings();

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            Environment.Exit(0);
        }
        private void LoadSettings()
        {
            try
            {
                UserSettings.GoogleRefreshToken = Properties.Settings.Default.GoogleAuthValue;
                txtUser.Text = Properties.Settings.Default.Username;
                txtPass.Text = Properties.Settings.Default.Password;

                //txtGoogleAuth.Text = UserSettings.GoogleRefreshToken;

                txtLat.Text = Properties.Settings.Default.Lat.ToString();
                txtLng.Text = Properties.Settings.Default.Lng.ToString();
                txtAltitude.Text = Properties.Settings.Default.Altitude.ToString();

                txtProbability.Text = Properties.Settings.Default.BerriesProbability.ToString();

                chkUseBerries.Checked = Properties.Settings.Default.ChkBerries;

                txtRegex.Text = Properties.Settings.Default.CoordRegex;



                cbAuthType.SelectedIndex = Properties.Settings.Default.AuthType == "Ptc" ? 0 : 1;

                Logger.Write($"Google Token: {UserSettings.GoogleRefreshToken}");
            }
            catch (Exception ex)
            {
                Logger.Write($"Failed to load settings: {ex}");
            }
        }

        private void SaveSettings()
        {
            try
            {
                Properties.Settings.Default.GoogleAuthValue = string.IsNullOrEmpty(UserSettings.GoogleRefreshToken) ? "" : UserSettings.GoogleRefreshToken;
                Properties.Settings.Default.Username = txtUser.Text;
                Properties.Settings.Default.Password = txtPass.Text;

                Properties.Settings.Default.Lat = txtLat.Text.ToDouble();
                Properties.Settings.Default.Lng = txtLng.Text.ToDouble();

                Properties.Settings.Default.Altitude = txtAltitude.Text.ToInt();

                Properties.Settings.Default.BerriesProbability = txtProbability.Text.ToInt();

                Properties.Settings.Default.AuthType = cbAuthType.SelectedIndex == 0 ? "Ptc" : "Google";

                Properties.Settings.Default.CoordRegex = txtRegex.Text;
                Properties.Settings.Default.ChkBerries = chkUseBerries.Checked;

                Properties.Settings.Default.Save();

            }
            catch (Exception ex)
            {
                Logger.Write($"Failed to save settings: {ex}");
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (!acc.Logged)
            {
                //
                MessageBox.Show("Cannot snipe when the bot is not logged in!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var listData = GetList(txtCoords.Text, txtRegex.Text);

            UserSettings.UseBerries = chkUseBerries.Checked;
            UserSettings.StartLat = txtLat.Text.ToDouble();
            UserSettings.StartLng = txtLng.Text.ToDouble();
            UserSettings.Altitude = txtAltitude.Text.ToInt();

            UserSettings.BerryProbability = txtProbability.Text.ToInt();

            acc.PokemonToSnipe = listData;
            acc.SnipeEnabled.Set();

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {



            UserSettings.Auth = cbAuthType.SelectedIndex == 0 ? PokemonGo.RocketAPI.Enums.AuthType.Ptc : PokemonGo.RocketAPI.Enums.AuthType.Google;
            UserSettings.Username = txtUser.Text;
            UserSettings.Password = txtPass.Text;

            Settings s = new Settings();

            acc = new Bot.PokeAccount(s);

            acc.Execute();


            
        }

        private Dictionary<Navigation.Location, PokemonId> GetList(string data, string regex)
        {
            Dictionary<Navigation.Location, PokemonId> list = new Dictionary<Navigation.Location, PokemonId>();

            foreach (Match m in Regex.Matches(data, regex, RegexOptions.IgnoreCase))
            {
                try
                {
                    Navigation.Location loc = new Navigation.Location(m.Groups[2].Value.ToDouble(), m.Groups[3].Value.ToDouble());
                    if (!list.ContainsKey(loc))
                    {

                        list.Add(loc, (PokemonId)Enum.Parse(typeof(PokemonId), m.Groups[1].Value));

                    }
                }
                catch (Exception ex)
                {
                    Logger.Write($"Did not add coords successfully on match: {ex}");
                }
            }

            return list;
        }


        private void Events_OnMessageReceived(object sender, Utils.LogReceivedArgs e)
        {
            try
            {
                if (!this.IsHandleCreated)
                    return;

                this.Invoke((MethodInvoker)delegate ()
                {
                    if (e.Message == "Successful Login" && !loginMsg)
                    {
                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loginMsg = true;
                        acc.Logged = true;

                        btnLogin.Enabled = false;

                        btnStart.Enabled = true;
                        btnStart.Scheme = cButton.Schemes.Green;

                    }
                    // clear log
                    if (lvWalkLog.Items.Count > 300)
                        lvWalkLog.Items.Clear();

                    ListViewItem lvi = new ListViewItem($"[{ DateTime.Now.ToString("HH:mm:ss")}]");
                    lvi.UseItemStyleForSubItems = true;

                    lvi.SubItems.Add(e.Message);

                    lvi.ForeColor = e.Color;

                    lvWalkLog.Items.Add(lvi);

                    lvWalkLog.Items[lvWalkLog.Items.Count - 1].EnsureVisible();
                });
            }
            catch (Exception ex)
            {

            }
        }

        private void cbAuthType_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
