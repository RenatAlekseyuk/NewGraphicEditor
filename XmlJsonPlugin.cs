using System;
using System.IO;
using System.Xml;
using System.Windows;
using NewGraphicEditor.PluginInterfaces;
using Newtonsoft.Json;

namespace XmlJsonPlugin
{
    public class XmlJsonPlugin : IProcessingPlugin
    {
        private bool _prettyPrint = true;

        public string PluginName => "XML ↔ JSON Converter";
        public bool HasSettings => true;

        public string ProcessBeforeSave(string data)
        {
            if (string.IsNullOrEmpty(data)) return data;

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(data);

                string json = JsonConvert.SerializeXmlNode(doc,
                    _prettyPrint ? Newtonsoft.Json.Formatting.Indented : Newtonsoft.Json.Formatting.None);

                return json;
            }
            catch (Exception ex)
            {
                MessageBox.Show("XML to JSON error: " + ex.Message);
                return data;
            }
        }

        public string ProcessAfterLoad(string data)
        {
            if (string.IsNullOrEmpty(data)) return data;

            try
            {
                XmlDocument doc = JsonConvert.DeserializeXmlNode(data, "Root");

                using (var stringWriter = new StringWriter())
                using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                {
                    doc.WriteTo(xmlTextWriter);
                    xmlTextWriter.Flush();
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("JSON to XML error: " + ex.Message);
                return data;
            }
        }

        public void ShowSettings()
        {
            var result = MessageBox.Show(
                "Pretty print JSON?\nYes = Pretty print\nNo = Minified",
                "Plugin Settings",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            _prettyPrint = (result == MessageBoxResult.Yes);

            MessageBox.Show($"Settings saved!\nPretty print: {_prettyPrint}", "Settings",
                           MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}