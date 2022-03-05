using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernal.Common.Configuration
{
    public class SwaggerSettings
    {
        public SwaggerSettings()
        {
            Version = new List<SwaggerVersion>();
        }
        public static string Name { get; set; }
        public static string Title { get; set; }
        public static string Description { get; set; }
        public static List<SwaggerVersion> Version { get; set; }
    }

    public class SwaggerVersion
    {
        public string URL { get; set; }
        public string Version { get; set; }
    }
}
