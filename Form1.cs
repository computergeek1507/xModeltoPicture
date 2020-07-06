using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public Bitmap Save_Nodes_As_Image(string[,] NodeName, Dictionary<string ,Tuple<List<int>, Color>> overRide = null)
        {
            overRide = overRide ?? new Dictionary<string, Tuple<List<int>, Color>>();
            //creating bitmap image
            Bitmap bmp = new Bitmap(1, 1);

            //FromImage method creates a new Graphics from the specified Image.
            Graphics graphics = Graphics.FromImage(bmp);
            // Create the Font object for the image text drawing.
            // Font font = new Font(fontname, fontsize);
            // Instantiating object of Bitmap image again with the correct size for the text and font.

            bmp = new Bitmap(bmp, NodeName.GetUpperBound(0), NodeName.GetUpperBound(1));
            graphics = Graphics.FromImage(bmp);

            //Brush brush = (Brush)Brushes.White;

            //Color col = Color.Black;

            //System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(col);

            Brush brush = (Brush)Brushes.Black;
            //Graphics g = this.CreateGraphics();

            for (int i = 0; i < NodeName.GetUpperBound(0); i++)
            {
                for (int j = 0; j < NodeName.GetUpperBound(1); j++)
                {
                    if (!string.IsNullOrEmpty(NodeName[i, j]))
                    {
                        if (overRide.Count == 0)
                            graphics.FillRectangle(brush, i, j, 1, 1);
                        else 
                        {
                            foreach(string key in overRide.Keys)
                            {
                                List<int> nodes = overRide[key].Item1;
                                Brush myBrush = new System.Drawing.SolidBrush(overRide[key].Item2);

                                if (nodes.Contains(int.Parse(NodeName[i, j])))
                                {
                                    graphics.FillRectangle(myBrush, i, j, 1, 1);
                                }
                            }
                        }
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
                if (!string.IsNullOrEmpty(textBoxFile.Text) && File.Exists(textBoxFile.Text))
                {
                    string filename = textBoxFile.Text;

                    FileInfo file = new FileInfo(filename);

                    string basename = Path.GetFileNameWithoutExtension(file.Name);
                    string folder = file.Directory.FullName + Path.DirectorySeparatorChar + basename + Path.DirectorySeparatorChar;
                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);

                    LogLine("Converting: " + filename);
                    ModelData model = GetXModelData(filename);

                    string pngfilename = folder + basename + ".png";
                    //string pngfilename = Path.ChangeExtension(filename, ".png");
                    Bitmap img = Save_Nodes_As_Image(model.NodeName);                    
                    img.Save(pngfilename, ImageFormat.Png);
                    LogLine("Saved: " + pngfilename);

                    if (checkBoxFaces.Checked)
                    {
                        foreach (string face in model.Faceinfo.Keys)
                        {
                            Dictionary<string, Tuple<List<int>, Color>> faceInfo = model.Faceinfo[face];

                            for (int i = 0; i <= 2; i++)
                            {
                                string name = "Eyes-Open";
                                //string name2 = "Eyes-Closed";
                                if (i == 1)
                                {
                                    name = "Eyes-Closed";
                                   // name2 = "Eyes-Open";
                                }

                                //Dictionary<string, Tuple<List<int>, Color>> newFaceInfo = new Dictionary<string, Tuple<List<int>, Color>>();

                                foreach(string line in faceInfo.Keys)
                                {
                                    if (line.ToUpper().StartsWith("Mouth".ToUpper()))
                                    {
                                        Dictionary<string, Tuple<List<int>, Color>> newFaceInfo = new Dictionary<string, Tuple<List<int>, Color>>();

                                        if (faceInfo.Keys.Contains(name))
                                            newFaceInfo.Add(name, faceInfo[name]);
                                        else
                                            continue;

                                        if (faceInfo.Keys.Contains(line))
                                            newFaceInfo.Add(line, faceInfo[line]);

                                        if (faceInfo.Keys.Contains("FaceOutline"))
                                            newFaceInfo.Add("FaceOutline", faceInfo["FaceOutline"]);

                                        if (faceInfo.Keys.Contains("FaceOutline2"))
                                            newFaceInfo.Add("FaceOutline2", faceInfo["FaceOutline2"]);

                                        string facefilename = folder + basename + "_" + line + "_" + name + ".png";
                                        Bitmap faceimg = Save_Nodes_As_Image(model.NodeName, newFaceInfo);
                                        faceimg.Save(facefilename, ImageFormat.Png);
                                        LogLine("Saved: " + facefilename);
                                    }
                                }
                            }                        
                        }
                    }

                    if (checkBoxStates.Checked)
                    {
                        foreach (string state in model.Stateinfo.Keys)
                        {
                            Dictionary<string, Tuple<List<int>, Color>> stateInfo = model.Stateinfo[state];

                            string statefilename = folder + basename + "_" + state + ".png";
                            Bitmap stateimg = Save_Nodes_As_Image(model.NodeName, stateInfo);
                            stateimg.Save(statefilename, ImageFormat.Png);
                            LogLine("Saved: " + statefilename);
                        }
                    }

                    if (checkBoxSubmodels.Checked)
                    {
                        foreach (string sub in model.SubModels.Keys)
                        {
                            Dictionary<string, Tuple<List<int>, Color>> subInfo = model.SubModels[sub];

                            string subfilename = folder + basename + "_" + sub + ".png";
                            Bitmap subimg = Save_Nodes_As_Image(model.NodeName, subInfo);
                            subimg.Save(subfilename, ImageFormat.Png);
                            LogLine("Saved: " + subfilename);
                        }
                    }
                    LogLine("Done");
                }
            }
            catch (Exception ex)
            {
                LogLine("Error: " + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private ModelData GetXModelData(string filename)
        {
            ModelData returnData = new ModelData();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filename);
            XmlNodeList custommodel = xDoc.GetElementsByTagName("custommodel");

            string swidth = custommodel[0].Attributes["parm1"].Value;
            string sheight = custommodel[0].Attributes["parm2"].Value;

            int iwidth = int.Parse(swidth);
            int iheight = int.Parse(sheight);

            returnData.NodeName = new string[iwidth, iheight];
            string line = custommodel[0].Attributes["CustomModel"].Value;
            string[] rows = line.Split(';');
            
            for (int i = 0; i < rows.Length; i++)
            {
                string[] elements = rows[i].Split(',');
                for (int j = 0; j < elements.Length; j++)
                {
                    returnData.NodeName[j, i] = elements[j];
                }
            }
            try
            {
                foreach (XmlNode child in custommodel[0].SelectNodes("faceInfo"))
                {
                    string type = child.Attributes["Type"].Value;
                    if (type.ToUpper() != "NodeRange".ToUpper())
                        continue;
                    string name = child.Attributes["Name"].Value;
                    Color forceColor = Color.Black;
                    Dictionary < string, Tuple<List<int>, Color>> lines = new Dictionary < string, Tuple<List<int>, Color>>();
                    foreach (XmlAttribute attr in child.Attributes)
                    {
                        if (attr.Name.ToUpper().StartsWith("FaceOutline".ToUpper()) ||
                            attr.Name.ToUpper().StartsWith("Eyes".ToUpper()) ||
                            attr.Name.ToUpper().StartsWith("Mouth".ToUpper()))
                        {
                            if (attr.Name.ToUpper().EndsWith("-Color".ToUpper()))
                            {
                                if (!string.IsNullOrEmpty(attr.Value))
                                {
                                    forceColor = System.Drawing.ColorTranslator.FromHtml(attr.Value);
                                }
                            }
                            else
                            {
                                List<int> nodes = parseNodeInfo(attr.Value);
                                lines.Add(attr.Name, new Tuple<List<int>, Color>(nodes, forceColor));
                            }
                        }
                    }
                    returnData.Faceinfo.Add(name, lines);
                }
            }
            catch (Exception ex)
            {
                LogLine("Error: " + custommodel[0].OuterXml + ex.Message);
            }
            try
            {
                foreach (XmlNode child in custommodel[0].SelectNodes("stateInfo"))
                {
                    string type = child.Attributes["Type"].Value;
                    if (type.ToUpper() != "NodeRange".ToUpper())
                        continue;
                    string name = child.Attributes["Name"].Value;
                    Color forceColor = Color.Black;
                    Dictionary<string, Tuple<List<int>, Color>> lines = new Dictionary<string, Tuple<List<int>, Color>>();

                    List<int> nodes = new List<int>();
                    foreach (XmlAttribute attr in child.Attributes)
                    {
                        if (Regex.IsMatch(attr.Name, "^s\\d+"))
                        {
                            if (attr.Name.ToUpper().EndsWith("-Color".ToUpper()))
                            {
                                if (!string.IsNullOrEmpty(attr.Value))
                                {
                                    forceColor = System.Drawing.ColorTranslator.FromHtml(attr.Value);
                                }
                            }
                            else if (attr.Name.ToUpper().EndsWith("-Name".ToUpper()))
                            {
                                if(!string.IsNullOrEmpty(attr.Value))
                                    lines.Add(attr.Value, new Tuple<List<int>, Color>(nodes, forceColor));
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(attr.Value))
                                    nodes = parseNodeInfo(attr.Value);
                            }
                        }
                    }
                    returnData.Stateinfo.Add(name, lines);
                }
            }
            catch (Exception ex)
            {
                LogLine("Error: " + custommodel[0].OuterXml + ex.Message);
            }
            try
            {

                foreach (XmlNode child in custommodel[0].SelectNodes("subModel"))
                {
                    string type = child.Attributes["type"].Value;
                    if (type.ToUpper() != "ranges".ToUpper())
                        continue;
                    string name = child.Attributes["name"].Value;
                    Color forceColor = Color.Black;
                    Dictionary<string, Tuple<List<int>, Color>> lines = new Dictionary<string, Tuple<List<int>, Color>>();

                    foreach (XmlAttribute attr in child.Attributes)
                    {
                        if (attr.Name.ToUpper().StartsWith("line".ToUpper()))
                        {
                            List<int> nodes = parseNodeInfo(attr.Value);
                            lines.Add(attr.Name, new Tuple<List<int>, Color>(nodes, forceColor));
                        }
                    }
                    returnData.SubModels.Add(name, lines);
                }
            }
            catch (Exception ex)
            {
                LogLine("Error: " + custommodel[0].OuterXml + ex.Message);
            }

            return returnData;
        }

        private List<int> parseNodeInfo(string line)
        {
            List<int> nodes = new List<int>();
            string[] elements = line.Split(',');
            foreach (string element in elements)
            {
                int start, end;
                if (element.Contains("-"))
                {
                    int idx = element.IndexOf('-');
                    start = int.Parse(element.Substring(0,idx));
                    end = int.Parse(element.Substring(idx + 1, element.Length - idx - 1));
                    if (end < start)
                    {
                        int temp = start;
                        start = end; 
                        end = temp;
                    } 
                }
                else
                {
                    int num;
                    bool worked = int.TryParse(element, out num);
                    if (!worked)
                    {
                        LogLine("Invalid Line "+ element);
                        return nodes;
                    }
                        
                    start = end = int.Parse(element);
                }
                if (start > end)
                {
                    start = end;
                }
                //start--;
                //end--;
                for (int n = start; n <= end; n++)
                {
                    nodes.Add(n);
                }
            }
            return nodes;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (openXmodelFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFile.Text = openXmodelFileDialog.FileName;
            }
        }

        private void LogLine(string line)
        {
            listBox1.Items.Add(line);
        }
    }
}
