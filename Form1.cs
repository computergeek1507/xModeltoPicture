using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace xModeltoPicture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Bitmap Save_CSV_As_Image(string[,] csvdata)
        {
            //creating bitmap image
            Bitmap bmp = new Bitmap(1, 1);

            //FromImage method creates a new Graphics from the specified Image.
            Graphics graphics = Graphics.FromImage(bmp);
            // Create the Font object for the image text drawing.
            // Font font = new Font(fontname, fontsize);
            // Instantiating object of Bitmap image again with the correct size for the text and font.

            bmp = new Bitmap(bmp, csvdata.GetUpperBound(0), csvdata.GetUpperBound(1));
            graphics = Graphics.FromImage(bmp);

            //Brush brush = (Brush)Brushes.White;

            Brush brush = (Brush)Brushes.Black;
            //Graphics g = this.CreateGraphics();

            for (int i = 0; i < csvdata.GetUpperBound(0); i++)
            {
                for (int j = 0; j < csvdata.GetUpperBound(1); j++)
                {
                    if (!string.IsNullOrEmpty(csvdata[i, j]))
                    {
                        graphics.FillRectangle(brush, i, j, 1, 1);
                    }
                }
            }
            
            //font.Dispose();
            graphics.Flush();
            graphics.Dispose();
            return bmp;     //return Bitmap Image 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (openXmodelFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = openXmodelFileDialog.FileName;

                    label1.Text = "Converting: " + filename;

                    string[,] csvdata = GetXModelData(filename);

                    Bitmap img = Save_CSV_As_Image(csvdata);

                    string pngfilename = Path.ChangeExtension(filename, ".png");
                    img.Save(pngfilename, ImageFormat.Png);

                    label1.Text = "Saved: " + pngfilename;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string[,] GetXModelData(string filename)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filename);
            XmlNodeList custommodel = xDoc.GetElementsByTagName("custommodel");

            string swidth = custommodel[0].Attributes["parm1"].Value;
            string sheight = custommodel[0].Attributes["parm2"].Value;

            int iwidth = int.Parse(swidth);
            int iheight = int.Parse(sheight);

            string[,] array = new string[iwidth, iheight];
            string line = custommodel[0].Attributes["CustomModel"].Value;
            string[] rows = line.Split(';');
            
            for (int i = 0; i < rows.Length; i++)
            {
                string[] elements = rows[i].Split(',');
                for (int j = 0; j < elements.Length; j++)
                {
                    array[j, i] = elements[j];
                }
            }
            return array;
        }
    }
}
