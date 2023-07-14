using System;
using System.Windows.Forms;

namespace SimpleWebBrowser
{
    public partial class MainForm : Form
    {
        private WebBrowser webBrowser;

        public MainForm()
        {
            InitializeComponent();
            InitializeWebBrowser();
        }

        private void InitializeWebBrowser()
        {
            webBrowser = new WebBrowser();
            webBrowser.Dock = DockStyle.Fill;
            webBrowser.ScriptErrorsSuppressed = true;
            webBrowser.Navigated += WebBrowser_Navigated;
            webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;

            // Set your default homepage
            webBrowser.Navigate("https://www.example.com");

            // Add the web browser control to the form
            Controls.Add(webBrowser);
        }

        private void WebBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            // Update the address bar with the current URL
            txtAddress.Text = webBrowser.Url.ToString();
        }

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Web page has finished loading, do any additional processing here
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            // Load the URL entered in the address bar
            webBrowser.Navigate(txtAddress.Text);
        }
    }
}