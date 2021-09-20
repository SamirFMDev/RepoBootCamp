using MicroKernelContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MicroKernelSolution
{
    public class PluginFactory
    {        
        private const string UriPlugins = "plugins.xml";

        public static ICollection<IPlugin> GetPlugins() {

            var plugins = new List<IPlugin>();
            XmlTextReader reader = new XmlTextReader(UriPlugins);

            while (reader.Read())
            {
                if( reader.NodeType == XmlNodeType.Text)
                {                                        
                    var type = Type.GetType(reader.Value);

                    if (type == null) continue;                    
                    var pluginInstance = Activator.CreateInstance(type) as IPlugin;

                    if (pluginInstance == null)  continue; 
                    plugins.Add(pluginInstance);
                }                
            }

            return plugins;
        }

    }
}
