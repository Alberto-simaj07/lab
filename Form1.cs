using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Resize += new System.EventHandler(this.Form_Resize);

            webView.NavigationStarting += EnsureHttps;
        }

        void EnsureHttps(object sender, CoreWebView2NavigationStartingEventArgs args)
        {
            String uri = args.Uri;
            if (!uri.StartsWith("https://"))
            {
                args.Cancel = true;
            }
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            webView.Size = ClientSize - new Size(webView.Location);
            goButton.Left = ClientSize.Width - goButton.Width;
            addressBar.Width = goButton.Left - addressBar.Left;
        }
            
        private void button1_Click(object sender, EventArgs e)  
        {
                if (webView != null && webView.CoreWebView2 != null)
                {
                    webView.CoreWebView2.Navigate(addressBar.Text);
                }
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }
    }
}
