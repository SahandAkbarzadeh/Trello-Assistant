using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloAssistant.Utils
{
    public class ConfigUtils
    {
       
        public static string PositionToString(int X, int Y)
        {
            return X.ToString() + "," + Y.ToString();
        }

        public static (int X, int Y) StringToPosition(string val)
        {
            if (val == null || val == string.Empty) return (0, 0);
            var parts = val.Trim().Split(',');
            // TODO: validate parts
            return (int.Parse(parts[0]), int.Parse(parts[1]));
        }

    }
}
