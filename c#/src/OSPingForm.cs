using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSPing
{
    public partial class OSPingForm : Form
    {
        private DataGridViewAdapter<PingResult> adapter;

        private const int HIGHEST_WORLD = 94;

        public OSPingForm()
        {
            InitializeComponent();
        }

        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            List<PingResult> results = await RefreshAsync();

            adapter.AddRange(results);
            adapter.ResizeColumns();
        }

        private async Task<List<PingResult>> RefreshAsync()
        {
            Ping ping = new Ping();
            PingReply pingReply;

            List<PingResult> results = new List<PingResult>();

            await Task.Run(() =>
            {
                for (int i = 1; i < HIGHEST_WORLD; i++)
                {
                    try
                    {
                        pingReply = ping.Send("oldschool" + i + ".runescape.com", 1000);

                        if (pingReply.Status == IPStatus.Success)
                        {
                            results.Add(new PingResult(i, pingReply.RoundtripTime));
                        }
                    }
                    catch (Exception e)
                    {
                        // continue - world doesn't exist
                    }
                }
            });

            return results;
        }

        private void OSPingForm_Load(object sender, EventArgs e)
        {
            adapter = new DataGridViewAdapter<PingResult>(pingResultView);
            adapter.ResizeColumns();
        }

        private void pingResultView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            adapter.Sort(e.ColumnIndex);
        }
    }
}
