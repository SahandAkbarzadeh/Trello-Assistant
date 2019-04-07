using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloAssistant.Utils
{
    class Config
    {

        private static IniFile File = new IniFile("config.ini");

        public static String Get(ConfigKeys key)
        {
            return File.KeyExists(key.GetName(), key.GetSection()) ? File.Read(key.GetName() ?? string.Empty , key.GetSection()) : string.Empty;
        }

        public static void Set(ConfigKeys key, String value)
        {
            File.Write(key.GetName(), value, key.GetSection());
        }

    }

    public enum ConfigKeys
    {
        [Section("General")]
        [Description("BarPosition")]
        BarPosition,

        [Section("Trello")]
        [Description("AppKey")]
        TrelloAppKey,

        [Section("Trello")]
        [Description("UserToken")]
        TrelloUserToken,
    }

    public static class MyEnumExtensions
    {
        public static string GetName(this ConfigKeys val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }

        public static string GetSection(this ConfigKeys val)
        {
            Section[] attributes = (Section[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(Section), false);
            return attributes.Length > 0 ? attributes[0].Name : null;
        }

    }

    public class Section: Attribute
    {
        public string Name { get; set; }
        public Section(string name) { this.Name = name;  }
    }
}
