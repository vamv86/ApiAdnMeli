using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Common
{
    public static class AdnCommon
    {
        public static readonly int matrizLength = 6;
        public static readonly char[] charValid =  { 'A', 'T', 'G', 'C' };
        public static readonly string[] genMutant = { "AAAA", "TTTT", "GGGG", "CCCC" };      
    }
}
