using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernal.Middlewares.JWTSettings
{
    public class JwtSettings
    {
        /// <summary>
        /// 
        /// </summary>
        public static string SecurityKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static string ExpirationType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static int ExpirationTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static string ValidIssuer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static string ValidAudience { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static bool RequireExpirationTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static bool ValidateIssuer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static bool ValidateAudience { get; set; }
    }
}
