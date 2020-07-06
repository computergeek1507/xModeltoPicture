using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xModeltoPicture
{
    public class ModelData
    {
        public string[,] NodeName;
        public Dictionary<string, Dictionary<string, Tuple<List<int>, Color>>> Faceinfo = new Dictionary<string, Dictionary<string, Tuple<List<int>, Color>>>();
        public Dictionary<string, Dictionary<string, Tuple<List<int>, Color>>> SubModels = new Dictionary<string, Dictionary<string, Tuple<List<int>, Color>>>();
        public Dictionary<string, Dictionary<string, Tuple<List<int>, Color>>> Stateinfo = new Dictionary<string, Dictionary<string, Tuple<List<int>, Color>>>();
    }
}
