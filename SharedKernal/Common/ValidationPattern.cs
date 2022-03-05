using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Common
{
    public static class ValidationPattern
    {

        /// <summary>
        /// Free Text 
        /// </summary>
        /// <returns>FreeText as one word</returns>
        public static string FreeText = "FreeText";

        /// <summary>
        /// ISBN
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string ISBN = "(?:(?=.{17}$)97[89][ -](?:[0-9]+[ -]){2}[0-9]+[ -][0-9]|97[89][0-9]{10}|(?=.{13}$)(?:[0-9]+[ -]){2}[0-9]+[ -][0-9Xx]|[0-9]{9}[0-9Xx])";

        /// <summary>
        /// Alpha and Numeric
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Numeric_Alpha = "[a-zA-Z0-9]+";

        /// <summary>
        /// inches
        /// Format : 1' , 1'2" , 2" or 2 (assumes inches)
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string ScreenInches = "^(([0-9]{1,}\')?([0-9]{1,}\x22)?)+$";

        /// <summary>
        /// Password (UpperCase, LowerCase and Number)
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string NormalPassword = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$";

        /// <summary>
        /// Password (UpperCase, LowerCase, Number/SpecialChar and min 8 Chars)
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string ComplexPassword = @"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$";

        /// <summary>
        /// ICQ UIN
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string ICQ_UIN = @"([1-9])+(?:-?\d){4,}";

        /// <summary>
        /// Username with 2-20 chars
        /// </summary>
        /// <returns>Validation Pattern | Format: string+string|number</returns>
        public static string Username_with_2_20_chars = @"^[a-zA-Z][a-zA-Z0-9-_\.]{1,20}$";

        /// <summary>
        /// New Twitter usernames have a character maximum of 15
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string TwitterUsername_1 = @"^[A-Za-z0-9_]{1,15}$";

        /// <summary>
        /// Backwards compatible Twitter username
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string TwitterUsername_2 = @"^[A-Za-z0-9_]{1,32}$";

        /// <summary>
        /// Facebook Account
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Facebook = @"^[a-z\d\.]{5,}$";

        /// <summary>
        /// Credit Card Number
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Credit_Card_Number = @"[0-9]{13,16}";

        /// <summary>
        /// Email
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Email= @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

        /// <summary>
        /// Hex-Color
        /// </summary>
        /// <returns>Validation Pattern | Format is #CCC or #CCCCCC</returns>
        public static string Hex_Color = @"^#?([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$";

        /// <summary>
        /// IPv4 Address
        /// </summary>
        /// <returns>Validation Pattern </returns>
        public static string IPv4_Address = @"((^|\.)((25[0-5])|(2[0-4]\d)|(1\d\d)|([1-9]?\d))){4}$";

        /// <summary>
        /// IPv6 Address
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string IPv6_Address = @"((^|:)([0-9a-fA-F]{0,4})){1,8}$";

        /// <summary>
        /// Domain Name
        /// </summary>
        /// <returns>Validation Pattern | </returns>
        public static string Domains = @"^([a-zA-Z0-9]([a-zA-Z0-9\-]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z]{2,6}$";

        /// <summary>
        /// Numbers Or decimals
        /// </summary>
        /// <returns>Validation Pattern | Format: 9 or 9.9 or 9,9</returns>
        public static string Numbers_Or_decimals = @"[-+]?[0-9]*[.,]?[0-9]+";

        /// <summary>
        /// UUID
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string UUID = @"^[0-9A-Fa-f]{8}\-[0-9A-Fa-f]{4}\-[0-9A-Fa-f]{4}\-[0-9A-Fa-f]{4}\-[0-9A-Fa-f]{12}$";
        /// <summary>
        /// Latitude or Longitude
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Latitude_Or_Longitude = @"-?\d{1,3}\.\d+";

        /// <summary>
        /// Price (Format: 1.00)
        /// </summary>
        /// <returns>Validation Pattern | Price (Format: 1.00)</returns>
        public static string Price_1 = @"\d+(\.\d{2})?";

        /// <summary>
        /// Price (Format: 1,00)
        /// </summary>
        /// <returns>Validation Pattern | Price (Format: 1,00)</returns>
        public static string Price_2 = @"\d+(,\d{2})?";

        /// <summary>
        /// Md5 Hash
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Md5_Hash = @"[0-9a-fA-F]{32}";

        /// <summary>
        /// Basic date | Format: DD.MM.YYYY
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Basicdate_1 = @"(0[1-9]|1[0-9]|2[0-9]|3[01]).(0[1-9]|1[012]).[0-9]{4}";

        /// <summary>
        /// Basic date | Format: YYYY-MM-DD
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Basicdate_2 = @"[0-9]{4}-(0[1-9]|1[012])-(0[1-9]|1[0-9]|2[0-9]|3[01])";

        /// <summary>
        /// Full Date Validation (YYYY-MM-DD)
        /// Checks that
        ///1) the year is numeric and starts with 19 or 20,
        ///2) the month is numeric and between 01-12, and
        ///3) the day is numeric between 01-29, or
        ///b) 30 if the month value is anything other than 02, or
        ///c) 31 if the month value is one of 01,03,05,07,08,10, or 12.
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Fulldate_1 = @"(?:19|20)[0-9]{2}-(?:(?:0[1-9]|1[0-2])-(?:0[1-9]|1[0-9]|2[0-9])|(?:(?!02)(?:0[1-9]|1[0-2])-(?:30))|(?:(?:0[13578]|1[02])-31))";

        /// <summary>
        /// Date | (Format: MM/DD/YYYY)
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string date = @"(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d";

        /// <summary>
        /// Full date validation (MM/DD/YYYY)
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Fulldate_2 = @"(?:(?:0[1-9]|1[0-2])[\/\\-. ]?(?:0[1-9]|[12][0-9])|(?:(?:0[13-9]|1[0-2])[\/\\-. ]?30)|(?:(?:0[13578]|1[02])[\/\\-. ]?31))[\/\\-. ]?(?:19|20)[0-9]{2}";

        /// <summary>
        /// Date with leapyear-check
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Date_leapyear_check = @"(?:19|20)(?:(?:[13579][26]|[02468][048])-(?:(?:0[1-9]|1[0-2])-(?:0[1-9]|1[0-9]|2[0-9])|(?:(?!02)(?:0[1-9]|1[0-2])-(?:30))|(?:(?:0[13578]|1[02])-31))|(?:[0-9]{2}-(?:0[1-9]|1[0-2])-(?:0[1-9]|1[0-9]|2[0-8])|(?:(?!02)(?:0[1-9]|1[0-2])-(?:29|30))|(?:(?:0[13578]|1[02])-31)))";

        /// <summary>
        /// Time | Format: HH:MM:SS
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Time = @"(0[0-9]|1[0-9]|2[0-3])(:[0-5][0-9]){2}";

        /// <summary>
        /// datetime
        /// Date according to W3C for input type="datetime". Matches the following:
        ///1990-12-31T23:59:60Z
        ///1996-12-19T16:39:57-08:00
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string datetime = @"/([0-2][0-9]{3})\-([0-1][0-9])\-([0-3][0-9])T([0-5][0-9])\:([0-5][0-9])\:([0-5][0-9])(Z|([\-\+]([0-1][0-9])\:00))/";

        /// <summary>
        /// American Postal Code
        /// Format is nnnnn or nnnnn-nnnn
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string American_PostalCode = @"(\d{5}([\-]\d{4})?)";

        /// <summary>
        /// Australian  Postal Code
        /// Format: nnnn
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Australian_PostalCode = @"[0-9]{4}";

        /// <summary>
        /// Austrian Postal Code
        /// Format: nnnn
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Austrian_PostalCode = @"[0-9]{4}";

        /// <summary>
        /// Belgian Postal Code
        /// Format: nnnn
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Belgian_PostalCode = @"[0-9]{4}";

        /// <summary>
        /// Brazilian Postal Code
        /// Format: nnnnn-nnn
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Brazilian_PostalCode = @"[0-9]{5}[\-]?[0-9]{3}";

        /// <summary>
        /// Canadian Postal Code
        /// Format : A0A 0A0
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Canadian_PostalCode = @"[A-Za-z][0-9][A-Za-z] [0-9][A-Za-z][0-9]";

        /// <summary>
        /// Danish and Faroe Island Postal Code
        /// Format : nnn or nnnn
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Danish_and_Faroe_Island_PostalCode = @"[0-9]{3,4}";

        /// <summary>
        /// Dutch Postal Code
        /// Format : 1234 aa
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Dutch_PostalCode = @"[1-9][0-9]{3}\s?[a-zA-Z]{2}";

        /// <summary>
        /// German Postal Code
        /// Format : nnnnn
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string German_PostalCode = @"[0-9]{5}";

        /// <summary>
        /// Hungarian Postal Code
        /// Format : nnnn
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Hungarian_PostalCode = @"[0-9]{4}";

        /// <summary>
        /// Italian Postal Code
        /// Format : nnnnn
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Italian_PostalCode = @"[0-9]{5}";

        /// <summary>
        /// Japanese Postal Code
        /// Format : nnn-nnnn
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Japanese_PostalCode = @"\d{3}-\d{4}";

        /// <summary>
        /// Luxembourg Postal Code
        /// Format : L-nnnn incl. typical variations
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Luxembourg_PostalCode = @"(L\s*(-|—|–))\s*?[\d]{4}";

        /// <summary>
        /// Polish Postal Code
        /// Format : nn-nnn
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Polish_PostalCode = @"[0-9]{2}\-[0-9]{3}";

        /// <summary>
        /// Spanish Postal Code
        /// Format : 01xxx to 50xxx
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Spanish_PostalCode = @"((0[1-9]|5[0-2])|[1-4][0-9])[0-9]{3}";

        /// <summary>
        /// Swedish Postal Code
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Swedish_PostalCode = @"\d{3}\s?\d{2}";

        /// <summary>
        /// UK Postal Code
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string UK_PostalCode = @"[A-Za-z]{1,2}[0-9Rr][0-9A-Za-z]? [0-9][ABD-HJLNP-UW-Zabd-hjlnp-uw-z]{2}";

        /// <summary>
        /// Phone Number
        /// (Format: +99(99)9999-9999)
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string PhoneNumber = @"[\+]\d{2}[\(]\d{2}[\)]\d{4}[\-]\d{4}";

        /// <summary>
        /// UK Phone Number
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string PhoneNumber_UK = @"^\s*\(?(020[7,8]{1}\)?[ ]?[1-9]{1}[0-9{2}[ ]?[0-9]{4})|(0[1-8]{1}[0-9]{3}\)?[ ]?[1-9]{1}[0-9]{2}[ ]?[0-9]{3})\s*$";

        /// <summary>
        /// French Phone Number
        /// A french phone number must begin with one of the following:
        ///- a zero
        ///- +33 (surronding with optional parathensis), all following by optional space
        ///- 0033 following by optional space
        ///Then a number betwen 1 and 7, or 9.
        ///Then four groups of 2 digits, optionaly seperated by one of the following: point(.), dash(-), space(\s)
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string PhoneNumber_French = @"^(?:0|\(?\+33\)?\s?|0033\s?)[1-79](?:[\.\-\s]?\d\d){4}$";

        /// <summary>
        /// USA Phone Number
        /// US based Phone Number in the format of: 123-456-7890
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string PhoneNumber_USA = @"\d{3}[\-]\d{3}[\-]\d{4}";

        /// <summary>
        /// Can use as NationalId
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Number_14digit = "[0-9]{14}";

        /// <summary>
        /// Can use as Mobile Number
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Number_11digit = "[0-9]{11}";

        /// <summary>
        /// Can use as Land Line Phone Number
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Number_8digit = "[0-9]{8}";

        /// <summary>
        /// Number 19 digit
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Number_19digit = "[0-9]{19}";

        /// <summary>
        /// Number 24 digit
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string Number_24digit = "[0-9]{24}";

        /// <summary>
        /// URL http or https or ftp
        /// </summary>
        /// <returns>Validation Pattern</returns>
        public static string URL = @"(?:https?|ftp)://[-a-zA-Z0-9.]+(:(\d{2,4}|[1-9]))?";


        public static Dictionary<string, string> ValidationPatterns()
        {
            Dictionary<string, string> validationList = new()
            {
                { string.Empty, string.Empty },
                { "Free Text", ValidationPattern.FreeText },
                { "ISBN", ValidationPattern.ISBN },
                { "Numeric & Alpha", ValidationPattern.Numeric_Alpha },
                { "Screen Inche", ValidationPattern.ScreenInches },
                { "Password Normal", ValidationPattern.NormalPassword },
                { "Password Complex", ValidationPattern.ComplexPassword },
                { "ICQ UIN", ValidationPattern.ICQ_UIN },
                { "Username from 2-20 Chars", ValidationPattern.Username_with_2_20_chars },
                { "Twitter Old Username", ValidationPattern.TwitterUsername_1 },
                { "Twitter New Username", ValidationPattern.TwitterUsername_2 },
                { "Facebook Account", ValidationPattern.Facebook },
                { "Credit Card Number", ValidationPattern.Credit_Card_Number },
                { "Hex Color", ValidationPattern.Hex_Color },
                { "Email", ValidationPattern.Email },
                { "IPv4 Address", ValidationPattern.IPv4_Address },
                { "IPv6 Address", ValidationPattern.IPv6_Address },
                { "Domain Name", ValidationPattern.Domains },
                { "Numbers Or decimals", ValidationPattern.Numbers_Or_decimals },
                { "UUID", ValidationPattern.UUID },
                { "Latitude Or Longitude", ValidationPattern.Latitude_Or_Longitude },
                { "Price (Format: 1.00)", ValidationPattern.Price_1 },
                { "Price (Format: 1,00)", ValidationPattern.Price_2 },
                { "Md5 Hash", ValidationPattern.Md5_Hash },
                { "Basicdate (Format: DD.MM.YYYY)", ValidationPattern.Basicdate_1 },
                { "Basicdate (Format: YYYY-MM-DD)", ValidationPattern.Basicdate_2 },
                { "Fulldate Validation (Format: YYYY-MM-DD)", ValidationPattern.Fulldate_1 },
                { "Date (Format: MM/DD/YYYY)", ValidationPattern.date },
                { "Fulldate Validation (Format: MM/DD/YYYY)", ValidationPattern.Fulldate_2 },
                { "Date leapyear Check", ValidationPattern.Date_leapyear_check },
                { "Time (Format: HH:MM:SS) ", ValidationPattern.Time },
                { "DateTime", ValidationPattern.datetime },
                { "American PostalCode", ValidationPattern.American_PostalCode },
                { "Australian PostalCode", ValidationPattern.Australian_PostalCode },
                { "Austrian PostalCode", ValidationPattern.Austrian_PostalCode },
                { "Belgian PostalCode", ValidationPattern.Belgian_PostalCode },
                { "Brazilian PostalCode", ValidationPattern.Brazilian_PostalCode },
                { "Canadian PostalCode", ValidationPattern.Canadian_PostalCode },
                { "Danish & Faroe Island PostalCode", ValidationPattern.Danish_and_Faroe_Island_PostalCode },
                { "Dutch PostalCode", ValidationPattern.Dutch_PostalCode },
                { "German PostalCode", ValidationPattern.German_PostalCode },
                { "Hungarian PostalCode", ValidationPattern.Hungarian_PostalCode },
                { "Italian PostalCode", ValidationPattern.Italian_PostalCode },
                { "Japanese PostalCode", ValidationPattern.Japanese_PostalCode },
                { "Luxembourg PostalCode", ValidationPattern.Luxembourg_PostalCode },
                { "Polish PostalCode", ValidationPattern.Polish_PostalCode },
                { "Spanish PostalCode", ValidationPattern.Spanish_PostalCode },
                { "Swedish PostalCode", ValidationPattern.Swedish_PostalCode },
                { "UK PostalCode", ValidationPattern.UK_PostalCode },
                { "Phone Number (Format: +99(99)9999-9999)", ValidationPattern.PhoneNumber },
                { "Phone Number UK", ValidationPattern.PhoneNumber_UK },
                { "Phone Number French", ValidationPattern.PhoneNumber_French },
                { "Phone Number USA", ValidationPattern.PhoneNumber_USA },
                { "Number 14 digit", ValidationPattern.Number_14digit },
                { "Number 11 digit", ValidationPattern.Number_11digit },
                { "Number 08 digit", ValidationPattern.Number_8digit },
                { "Number 19 digit", ValidationPattern.Number_19digit },
                { "Number 24 digit", ValidationPattern.Number_24digit },
                { "URL", ValidationPattern.URL },
            };

            //validationList.OrderBy(x => x.Key).ToDictionary();

            return validationList;
        }

    }

}
