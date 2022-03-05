using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SharedKernal.Common
{
    public static class GeneralUtilities
    {


        public static string ToXML<TObject>(this TObject body, string methodName, string nameSpace, bool isIgnoreHeader = true)
        {
            var overrides = new XmlAttributeOverrides();
            var bodyRequestData = new XmlAttributes();
            var headerRequestData = new XmlAttributes { XmlIgnore = isIgnoreHeader };
            bodyRequestData.XmlElements.Add(new XmlElementAttribute()
            {
                ElementName = methodName,
                Namespace = nameSpace,
            });

            headerRequestData.XmlElements.Add(new XmlElementAttribute()
            {
                ElementName = "Header",
                Namespace = nameSpace,
            });

            if (isIgnoreHeader)
                overrides.Add(body.GetType(), "Header", headerRequestData);

            overrides.Add(body.GetType().GetProperty("Body").PropertyType, "Data", bodyRequestData);

            var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(body.GetType(), overrides);
            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true,
            };

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, body, emptyNamespaces);
                return stream.ToString();
            }
        }

        public static TObject LoadFromXMLString<TObject>(this string xmlText, string methodName, string nameSpace)
        {
            bool isIgnoreHeader = true;
            var overrides = new XmlAttributeOverrides();
            var bodyRequestData = new XmlAttributes();
            var headerRequestData = new XmlAttributes { XmlIgnore = isIgnoreHeader };
            bodyRequestData.XmlElements.Add(new XmlElementAttribute()
            {
                ElementName = methodName,
                Namespace = nameSpace,
            });

            headerRequestData.XmlElements.Add(new XmlElementAttribute()
            {
                ElementName = "Header",
                Namespace = nameSpace,
            });

            if (isIgnoreHeader)
                overrides.Add(typeof(TObject).GetType(), "Header", headerRequestData);

            overrides.Add(typeof(TObject).GetProperty("Body").PropertyType, "Data", bodyRequestData);

            using (var stringReader = new StringReader(xmlText))
            {
                var serializer = new XmlSerializer(typeof(TObject), overrides);
                return (TObject)serializer.Deserialize(stringReader);
            }
        }

        #region Encrypt & Decrypt
        private static string EncryptionKey = "MIIBVQIBADANBgkqhkiG9w0BAQEFAASCAT8wggE7AgEAAkEAnv5pAZZRTu/sBD439eecRhE2w3ADgz/Xpz6MN4boxy2JDmK74BfEgb7PqPTG6Eusf08NMNWnnQl4ldQ9vCMsnwIDAQABAkB8FVtIJNNCAta0nQY5gM+ik06lCmeDaDDa0mLF9yD2SB609PRsJb7Sl8bosZScnmGuSjV6vq/sSAJVLMTwPhMhAiEA+BUlIEP8sMSmQGPnf6QJwQnbO9l1JsmIMSGFv5Wa8tECIQCkEWcA+WWBGaTMHECPWGIkQRVw8l8fmw/ZP9OnsYakbwIhAItjnhuV96n+pAbz20PdkFl1R0hGc8uaWrp4QmUWExyxAiAcvU+lxAobyzoq5ugINBs87omq90niZ28nRx70SQyk0QIhALx8puuto03gHYdXIWW8Dr30KWET+u8uvFA8V6uxFoCS";

        public static string Encrypt(string clearText)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey,
                    new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
        #endregion

        public static string GetLastException(System.Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex.Message;
        }
    }
}
