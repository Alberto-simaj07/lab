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
        List<URL> urls = new List<URL>();
        public Form1()
        {
            InitializeComponent();
            /*this.Resize += new System.EventHandler(this.Form_Resize);

            webView.NavigationStarting += EnsureHttps;*/
        }

        private void Leer()
        {
            string fileName = "historial.txt";

            FileStream stream = new FileStream(fileName, fileMode.Open, fileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.peek()) > -1)
            {
                URL url = new URL();
                url.Pagina = reader.ReadLine();
                url.Veces = Convert.ToInt32(reader.ReadLine());
                url.Fecha = Convert.ToDateTime(reader.ReadLine());

                urls.Add(url);

            }
            reader.Close();

            ComboBox.DisplayMember = "Pagina";
            ComboBox.DataSource = urls;
            ComboBox.Refresh();

        }

        private void Grabar(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAcces);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var u in urls)
            {
                writer.WriteLine(u.PAgina);
                writer.writeLine(u.Veces);
                writer.writeLine(u.Fecha);

            }

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
            string urlIngresada = ComboBox.Text;
            URL urlExiste = urls.Find(uint => u.Pagina == urlIngresada);

                /*if (webView != null && webView.CoreWebView2 != null)
                {
                    webView.CoreWebView2.Navigate(addressBar.Text);
                }*/

            if (urlExistente  == null)
            {
                URL urlNueva = new URL();
                urlNueva.Pagina = urlIngresada;
                urlNueva.Veces = 1;
                urlNueva.Fecha = DateTime.Now;
                urls.Add(urlNueva);
                Grabar("historial.txt");
                webView2.CoreWebView2.Navegador(urlIngresada);
            }

            else
            {
                UrlExistente.Veces++;
                urlExistente.Fecha = DateTime.Now;
                Grabar("Historial.txt");
                webView2.CoreWebView2.Navigate(urlExiste.Pagina);
            }

        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }
    }
}
