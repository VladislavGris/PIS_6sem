using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformsClient
{
    public partial class Form1 : Form
    {
        private static string URI = "https://localhost:44388/sum";
        private HttpClient _client;

        public Form1()
        {
            InitializeComponent();
            _client = new HttpClient();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            Task t = new Task(() => GetResult());
            t.Start();
        }

        private async Task GetResult()
        {
            if (XParam.Value != 0 && YParam.Value != 0)
            {
                var values = new Dictionary<string, string>
                {
                    { "X", XParam.Value.ToString() },
                    { "Y", YParam.Value.ToString() }
                };
                var content = new FormUrlEncodedContent(values);
                var response = await _client.PostAsync(URI, content);
                var responseString = await response.Content.ReadAsStringAsync();
                Result.Text = responseString;
            }
            else
            {
                MessageBox.Show("Set X and Y parameters");
            }
        }
    }
}
