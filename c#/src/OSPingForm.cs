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

        private static int[] EXCLUDE_WORLDS = new int[] { 7, 15, 23, 24, 31, 32, 39, 40, 47, 48, 55, 56, 63, 64, 71, 72, 79, 80, 87, 88, 89, 90, 91, 92 };
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
                    if (!EXCLUDE_WORLDS.Contains(i))
                    {
                        pingReply = ping.Send("oldschool" + i + ".runescape.com", 500);

                        if (pingReply.Status == IPStatus.Success)
                        {
                            results.Add(new PingResult(i, pingReply.RoundtripTime));
                        }
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
