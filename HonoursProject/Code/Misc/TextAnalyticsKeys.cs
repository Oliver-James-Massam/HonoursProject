using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HonoursProject.Code.Misc
{
    public class TextAnalyticsKeys
    {
        private readonly static String text_analytics_key1 = "34a2419468b64d5187367628ef50fdda";
        private readonly static String text_analytics_key2 = "518c99eaf91c43a696e9b40e044dbb6d";

        public static String getTextAnalyticsKey1()
        {
            return text_analytics_key1;
        }

        public static String getTextAnalyticsKey2()
        {
            return text_analytics_key2;
        }
    }
}