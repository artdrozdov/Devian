using System;

namespace Devian.DateTime
{
    public static class UnixTime
    {
        private static readonly System.DateTime _epoch = new System.DateTime(1970, 1, 1);

        public static long Now
        {
            get { return Convert.ToInt64((System.DateTime.UtcNow - _epoch).TotalSeconds); }
        }

        public static bool TryParse(long val, out System.DateTime result)
        {
            if (val < 0)
            {
                result = default(System.DateTime);
                return false;
            }
            result = _epoch.AddSeconds(val);
            return true;
        }
    }
}
