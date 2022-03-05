using Newtonsoft.Json;
using SharedKernal.Common;
using SharedKernal.Common.Enum;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SharedKernal.Middlewares.ResourcesReader.Message
{
    public abstract class FileReader
    {
        #region Vars
        private Dictionary<string, string> ResourceData { get; set; }
        private Dictionary<string, string> ValidationResourceData { get; set; }
        #endregion

        public FileReader()
        {
            LoadData(ResourceEnum.LocalizationType.Message);
        }
        #region Load Data
        private void LoadData(ResourceEnum.LocalizationType localizationType)
        {
            string fileName = string.Format(localizationType.GetDescription().MessageAr, System.Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName);
            var rootDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            ResourceData = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(Path.Combine(rootDir, "ResourceFiles", $"{fileName}.json")));
        }

        private void LoadValidationData(ResourceEnum.LocalizationType localizationType)
        {
            string fileName = string.Format(localizationType.GetDescription().MessageAr, System.Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName);
            var rootDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            ValidationResourceData = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(Path.Combine(rootDir, "ResourceFiles", $"{fileName}.json")));
        }
        #endregion

        #region Get Data
        protected string GetKeyValue(string key) => ResourceData[key];
        protected string GetValidationKeyValue(string key)
        {
            LoadValidationData(ResourceEnum.LocalizationType.ValidationMessage);
            return ValidationResourceData[key];
        }
        #endregion
    }
}
