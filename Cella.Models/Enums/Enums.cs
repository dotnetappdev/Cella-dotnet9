using System;
using System.Collections.Generic;
using System.Text;

namespace Cella.Models{
    public class Enums {
        public enum RoundingType
        {
            /// <summary>
            /// Default rounding (Match.Round(num, 2))
            /// </summary>
            Rounding001 = 0,

            /// <summary>
            /// <![CDATA[Prices are rounded up to the nearest multiple of 5 cents for sales ending in: 3¢ & 4¢ round to 5¢; and, 8¢ & 9¢ round to 10¢]]>
            /// </summary>
            Rounding005Up = 10,

            /// <summary>
            /// <![CDATA[Prices are rounded down to the nearest multiple of 5 cents for sales ending in: 1¢ & 2¢ to 0¢; and, 6¢ & 7¢ to 5¢]]>
            /// </summary>
            Rounding005Down = 20,

            /// <summary>
            /// <![CDATA[Round up to the nearest 10 cent value for sales ending in 5¢]]>
            /// </summary>
            Rounding01Up = 30,

            /// <summary>
            /// <![CDATA[Round down to the nearest 10 cent value for sales ending in 5¢]]>
            /// </summary>
            Rounding01Down = 40,

            /// <summary>
            /// <![CDATA[Sales ending in 1–24 cents round down to 0¢
            /// Sales ending in 25–49 cents round up to 50¢
            /// Sales ending in 51–74 cents round down to 50¢
            /// Sales ending in 75–99 cents round up to the next whole dollar]]>
            /// </summary>
            Rounding05 = 50,

            /// <summary>
            /// Sales ending in 1–49 cents round down to 0
            /// Sales ending in 50–99 cents round up to the next whole dollar
            /// For example, Swedish Krona
            /// </summary>
            Rounding1 = 60,

            /// <summary>
            /// Sales ending in 1–99 cents round up to the next whole dollar
            /// </summary>
            Rounding1Up = 70
        }
        /// <summary>
        /// Represents an attribute control type
        /// </summary>
        public enum ControlTypeEnum
        {
            /// <summary>
            /// Dropdown list
            /// </summary>
            DropdownList = 1,

            /// <summary>
            /// Radio list
            /// </summary>
            RadioList = 2,

            /// <summary>
            /// Checkboxes
            /// </summary>
            Checkboxes = 3,

            /// <summary>
            /// TextBox
            /// </summary>
            TextBox = 4,

            /// <summary>
            /// Multiline textbox
            /// </summary>
            MultilineTextbox = 10,

            /// <summary>
            /// Datepicker
            /// </summary>
            Datepicker = 20,

            /// <summary>
            /// File upload control
            /// </summary>
            FileUpload = 30,

            /// <summary>
            /// Color squares
            /// </summary>
            ColorSquares = 40,

            /// <summary>
            /// Image squares
            /// </summary>
            ImageSquares = 45,

            /// <summary>
            /// Read-only checkboxes
            /// </summary>
            ReadonlyCheckboxes = 50
        }
    }
}
