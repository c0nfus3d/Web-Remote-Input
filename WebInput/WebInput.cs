/**
 * Web Input Remote
 * @package Web-Remote-Input
 * @desc Remote control your computer from the web.
 * @author Josh Richard <josh.richard@gmail.com>
 * @see http://theyconfuse.me/code/Web-Remote-Input
 * @license Apache License, Version 2.0
 * @license http://theyconfuse.me/license/apache2
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace WebInput
{
    public partial class frmWebInput : Form
    {
        public static HttpListener listener;
        Thread t;
        private static int static_connectedUsers = 0;
        private static frmWebInput MyForm { get; set; }
        private static QRCode QRForm { get; set; }

        /**
         * Set the current user list count
         * @type int Total connected users.
         * @return void The total connected users.
         */
        public static int connectedUsers {
            get { return static_connectedUsers; }
            set
            {
                static_connectedUsers = value;
                MyForm.ConnectedUserCount.Text = String.Format("Connected Users: {0}", value);
            }
        }

        /**
         * @type bool Exits the application when true; minimizes the application when false.
         * @see void frmWebInput_FormClosing
         */
        bool _exit = false;

        /**
         * @type string The current status of the service.
         * @see void btnSwitch_Click
         */
        string status = "Off";

        /**
         * @type string The port to use for the service.
         * @see void btnSwitch_Click
         */
        string port = "61337";

        public frmWebInput()
        {
            InitializeComponent();
            this.Resize += new EventHandler(frmWebInput_Resize);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWebInput_FormClosing);

            MyForm = this;
            QRForm = new QRCode();
        }
        
        /**
         * Turns the service on/off
         * @return void
         */
        private void btnSwitch_Click(object sender, EventArgs e)
        {
            if (status == "Off")
            {
                try
                {
                    listener = new HttpListener();
                    listener.Start();
                    listener.Prefixes.Add("http://+:" + port + "/");
                    t = new Thread(new ThreadStart(clientListener));
                    t.Start();

                    status = lblServerStatus.Text = "On";
                    btnSwitch.Text = "Turn Off";
                    MenuToggle.Text = "Turn Off";

                    lblIP.Text = "http://" + LocalIPAddress() + ":" + port;
                    lblIP.Visible = true;

                    ConnectedUserCount.Visible = true;
                    connectedUsers = 0;
                }
                catch (HttpListenerException Ex)
                {
                    lblIP.Text = "Could not start service.";
                    lblIP.Visible = true;
                }
            }

            else
            {
                listener.Abort();
                t.Abort();
                status = lblServerStatus.Text = "Off";
                btnSwitch.Text = "Turn On";
                MenuToggle.Text = "Turn On";

                connectedUsers = 0;
                lblIP.Visible = false;
                ConnectedUserCount.Visible = false;
            }
        }

        /**
         * Listen for Web Server Requests
         * @return void
         */
        public static void clientListener()
        {
            while (true)
            {
                try
                {
                    HttpListenerContext request = listener.GetContext();
                    ThreadPool.QueueUserWorkItem(processRequest, request);
                }
                catch (Exception e) {
                    
                }
            }
        }

        /**
         * Process the Web Server Requests
         * @param string filename The name of the requested file which will denote the desired action.
         * @return void
         */
        public static void processRequest(object listenerContext)
        {
            try
            {
                string _output = "";
                var context = (HttpListenerContext)listenerContext;
                string filename = Path.GetFileName(context.Request.RawUrl);

                /**
                 * Output the Remote HTML Web page
                 */
                if ( filename == "" )
                {
                    _output = htmlRemote();
                    connectedUsers = connectedUsers + 1;
                }

                /**
                 * The QR Code was scanned. Output the Remote HTML Web page; minimize the application.
                 */
                else if (filename == "qrscan")
                {
                    /**
                     * @todo Finish this section to autohide the QR code when it's scanned
                     */
                    /*
                    if (QRForm.WindowState == FormWindowState.Normal)
                    {
                        QRForm.Close();
                    }

                    if (MyForm.WindowState == FormWindowState.Normal)
                    {
                        MyForm.WindowState = FormWindowState.Minimized;
                    }
                    */

                    _output = "<html><head><title>Remote</title><meta http-equiv='refresh' content='1; url=/' /></head><body>Redirecting to <a href='/'>the remote</a>...</body></html>";
                }

                /**
                 * A remote session has ended.
                 */
                else if (filename == "remote-ended")
                {
                    connectedUsers = connectedUsers - 1;
                }

                /**
                 * Process Touchpad movement.
                 * @param int x The number of pixels to move along the x-axis.
                 * @param int y The number of pixels to move along the y-axis.
                 */
                else if (filename.Contains("remote-touch"))
                {
                    string[] xPieces = filename.Split(new string[] { "x=" }, StringSplitOptions.None);
                    string[] yPieces = xPieces[1].Split(new string[] { "&y=" }, StringSplitOptions.None);

                    int x = (Convert.ToInt32(yPieces[0]) * -1) / 3;
                    int y = (Convert.ToInt32(yPieces[1]) * -1) / 3;

                    /**
                     * Process Left Mouse Click.
                     */
                    if (x == 0 && y == 0)
                    {
                        VirtualMouse.LeftClick();
                    }

                    /**
                     * Move the mouse curser x, y pixels from the current position.
                     */
                    else
                    {
                        VirtualMouse.Move(x, y);
                    }
                }

                /**
                 * Process Mouse Click
                 * @param string clickButton The mouse button to click.
                 */
                else if (filename.Contains("process-click"))
                {
                    string[] clickPieces = filename.Split(new string[] { "button=" }, StringSplitOptions.None);
                    string clickButton = clickPieces[1];

                    if (clickButton == "left")
                    {
                        VirtualMouse.LeftClick();
                    }

                    else if (clickButton == "right")
                    {
                        VirtualMouse.RightClick();
                    }

                    else
                    {
                        // Unknown
                    }
                }

                /**
                 * Send Keystrokes
                 * @param string text The text to output.
                 */
                else if (filename.Contains("process-text"))
                {
                    // Get the text from the POST data
                    string textData;
                    using (var reader = new StreamReader(context.Request.InputStream,
                                                         context.Request.ContentEncoding))
                    {
                        textData = reader.ReadToEnd();
                    }

                    // In the form of text=encoded+data
                    string[] PostPieces = textData.Split(new string[] { "text=" }, StringSplitOptions.None);
                    string text = PostPieces[1];

                    text = text.Replace("%0A", System.Environment.NewLine);
                    text = System.Uri.UnescapeDataString(text);
                    text = System.Uri.UnescapeDataString(text);

                    SendKeys.SendWait(text);
                }

                /**
                 * Press Arrow Key
                 * @param string ArrowKey The arrow key to press.
                 */
                else if (filename.Contains("process-button"))
                {
                    string[] arrowPieces = filename.Split(new string[] { "button=" }, StringSplitOptions.None);
                    string ArrowKey = arrowPieces[1];

                    switch (ArrowKey)
                    {
                        case "up":
                            SendKeys.SendWait("{UP}");
                            break;

                        case "right":
                            SendKeys.SendWait("{RIGHT}");
                            break;

                        case "down":
                            SendKeys.SendWait("{DOWN}");
                            break;

                        case "left":
                            SendKeys.SendWait("{LEFT}");
                            break;

                        default:
                            break;
                    }
                }

                /**
                 * Unknown Web Server Request
                 */
                else
                {
                    _output = "<html><head><meta http-equiv='refresh' content='0; url=http://theyconfuse.me/code/Web-Remote-Input' /></head><body>Redirecting to <a href='http://theyconfuse.me/code/Web-Remote-Input'>http://theyconfuse.me/code/Web-Remote-Input</a>...</body></html>";
                }

                
                byte[] array = Encoding.ASCII.GetBytes(_output);
                context.Response.ContentLength64 = array.Length;
                using (Stream s = context.Response.OutputStream)
                    s.Write(array, 0, array.Length);
            }
            catch (Exception e)
            {
                
            }
        }

        /**
         * Get the local IP
         * @author Mrchief
         * @see http://stackoverflow.com/questions/6803073/get-local-ip-address-c-sharp
         * @return void
         */
        public string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        /**
         * Exit the Application
         * @return void
         */
        private void btnExit_Click(object sender, EventArgs e)
        {
            _exit = true;
            Application.Exit();
        }

        /**
         * frmWebInput Form Resize Handler
         * @return void
         */
        private void frmWebInput_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                TaskbarIcon.Visible = true;
                this.Hide();
                TaskbarIcon.ShowBalloonTip(5000, "Web Input", "The input server is now running minimized.", ToolTipIcon.Info); 
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                TaskbarIcon.Visible = false;
            }
        }

        /**
         * Open the application if the icon is clicked from the system tray
         * @return void
         */
        private void TaskbarIconMenu_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        /**
         * Form closing Handler
         * * Close if the "Exit" button is clicked
         * * Minimize if the "X" is clicked
         * @param bool _exit Exits the application when true; minimizes the application when false.
         * @return void
         */
        private void frmWebInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_exit == true)
            {
                if (status == "On")
                {
                    listener.Abort();
                    t.Abort();
                }

                Application.Exit();
            }
            else
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
            }

        }

        /**
         * Starting the Application
         * @return void
         */
        private void frmWebInput_Load(object sender, EventArgs e)
        {
            this.Text += " -- Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        /**
         * Show the web based remote control HTML web page
         * @param string RemoteHTML The HTML data for the Web page remote.
         * @return string The HTML data for the Web page remote gui.
         */
        public static string htmlRemote()
        {
            return WebInput.Properties.Resources.htmlRemote;
        }

        /**
         * Show a scannable QRCode
         */
        private void lblIP_Click(object sender, EventArgs e)
        {
            if (!QRForm.Visible)
            {
                try
                {
                    QRForm.Show(this);
                }
                catch {
                    QRForm = new QRCode();
                    QRForm.Show(this);
                }
            }
        }

        /**
         * What to draw on the QR Code
         * @param string QRData The text to draw in the QRCode.
         * @return string The text to draw in the QRCode.
         */
        public string QRText()
        {
            string QRData = this.lblIP.Text;
            return QRData;
        }

        /**
         * Open Author Website
         */
        private void TCMCredit_Click(object sender, EventArgs e)
        {
            Process.Start("http://theyconfuse.me");
        }

        /**
         * Turns the service on/off
         * @return void
         */
        private void MenuToggle_Click(object sender, EventArgs e)
        {
            if (status == "Off")
            {
                try
                {
                    listener = new HttpListener();
                    listener.Start();
                    listener.Prefixes.Add("http://+:" + port + "/");
                    t = new Thread(new ThreadStart(clientListener));
                    t.Start();

                    status = lblServerStatus.Text = "On";
                    btnSwitch.Text = "Turn Off";
                    MenuToggle.Text = "Turn Off";

                    lblIP.Text = "http://" + LocalIPAddress() + ":" + port;
                    lblIP.Visible = true;

                    ConnectedUserCount.Visible = true;
                    connectedUsers = 0;
                }
                catch (HttpListenerException Ex)
                {
                    lblIP.Text = "Could not start service.";
                    lblIP.Visible = true;
                }
            }

            else
            {
                listener.Abort();
                t.Abort();
                status = lblServerStatus.Text = "Off";
                btnSwitch.Text = "Turn On";
                MenuToggle.Text = "Turn On";

                connectedUsers = 0;
                lblIP.Visible = false;
                ConnectedUserCount.Visible = false;
            }
        }

        /**
         * Exit the Application
         * @return void
         */
        private void MenuExit_Click(object sender, EventArgs e)
        {
            _exit = true;
            Application.Exit();
        }
    }
}
