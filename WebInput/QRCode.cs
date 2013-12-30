/**
 * Web Input Remote
 * @package VirtualWebInput
 * @desc Remote control your computer from the web.
 * @author Josh Richard <josh.richard@gmail.com>
 * @see http://theyconfuse.me/code/Web-Remote-Input
 * @license GPL
 * @license http://theyconfuse.me/license/gpl
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebInput
{
    public partial class QRCode : Form
    {
        public QRCode()
        {
            InitializeComponent();
        }

        private void QRCode_Load(object sender, EventArgs e)
        {
            frmWebInput owningForm = (frmWebInput)this.Owner;

            /**
             * @type string The data to draw on the QR Code
             */
            string QRText = owningForm.QRText();

            /**
             * @type int The pixel size of each block in the QR Code
             */
            int blockSize = 5;

            QRCode4CS.QRCode QRCoded = new QRCode4CS.QRCode(new QRCode4CS.Options(QRText + "/qrscan"));
            QRCoded.Make();

            Bitmap DrawArea = new Bitmap((QRCoded.GetModuleCount() * blockSize), (QRCoded.GetModuleCount() * blockSize));

            /**
             * Show an error message if the service is unavailabe.
             */
            if (QRText == "Could not start service.")
            {
                this.UnavailableNotice.Visible = true;
            }

            /**
             * Draw the QR Code Image
             */
            else {
                for (int row = 0; row < QRCoded.GetModuleCount(); row++)
                {
                    for (int col = 0; col < QRCoded.GetModuleCount(); col++)
                    {
                        bool isDark = QRCoded.IsDark(row, col);
                        if (isDark)
                        {
                            for (int y = 0; y < blockSize; y++)
                            {
                                int myCol = (blockSize * (col - 1)) + (y + blockSize);
                                for (int x = 0; x < blockSize; x++)
                                {
                                    DrawArea.SetPixel((blockSize * (row - 1)) + (x + blockSize), myCol, Color.Black);
                                }
                            }
                        }
                        else
                        {
                            for (int y = 0; y < blockSize; y++)
                            {
                                int myCol = (blockSize * (col - 1)) + (y + blockSize);
                                for (int x = 0; x < blockSize; x++)
                                {
                                    DrawArea.SetPixel((blockSize * (row - 1)) + (x + blockSize), myCol, Color.White);
                                }
                            }
                        }
                    }
                }
                QRPic.Image = DrawArea;
                QRPic.Visible = true;
            }
        }
    }
}
