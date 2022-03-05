
using System.Globalization;

namespace SharedKernal.Common
{



    /// <summary>
    /// Enum message used to adding a description to the enum value.
    /// </summary>
    public sealed class EnumMessage : System.Attribute
    {
        /// <summary>
        /// Enum value message.
        /// </summary>
        public string MessageAr { get; }

        /// <summary>
        /// Enum value message.
        /// </summary>
        public string MessageEn { get; }

        /// <summary>
        /// EnumMessage constructor to add the description to the enum value.
        /// </summary>
        /// <param name="messageAr"></param>
        public EnumMessage(string messageAr) => MessageAr = messageAr;

        /// <summary>
        /// EnumMessage constructor to add the description to the enum value.
        /// </summary>
        /// <param name="messageAr"></param>
        /// <param name="messageEn"></param>
        public EnumMessage(string messageAr, string messageEn)
        {
            MessageAr = messageAr;
            MessageEn = messageEn;
        }
    }

   
}
