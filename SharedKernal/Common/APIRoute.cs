using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernal.Common
{
    public static class APIRoute
    {
        public const string VersioningTemplate = "api/v{version:apiVersion}/[controller]/[action]";
        public const string VersioningTemplateAdmin = "api/admin/v{version:apiVersion}/[controller]/[action]";
        public const string Template = "api/[controller]/[action]";
        public const string FileTemplate = "api/[controller]";
        public const string ControllerTemplate = "api/{0}";
        public const string ActionTemplate = "/{0}";
    }

    public static class APIVersion
    {
        public const string Version1 = "1.0";
        public const string Version2 = "2.0";

    }
}
