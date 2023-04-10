namespace CodingChallenges.Strings
{
    /// <summary>
    /// Related   : String
    /// Title     : 468. Validate IP Address
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/validate-ip-address/
    /// Companies : Cisco 8, Oracle 2 (2022-03-30)
    /// </summary>
    public class ValidateIPAddress
    {
        public string validIPAddress(string queryIP)
        {
            if (IsValidIpV4(queryIP))
                return "IPv4";

            if (IsValidIpV6(queryIP))
                return "IPv6";

            return "Neither";
        }

        private bool IsValidIpV4(string queryIP)
        {
            var ipV4 = queryIP.Split('.');
            if (ipV4.Length != 4)
                return false;

            foreach (var block in ipV4)
            {
                int value = -1;
                if (!int.TryParse(block, out value) // not a valid integer
                   || (block[0] == '0' && block.Length > 1) // has leading zeros
                   || value > 255 || value < 0) // out of the range for IPv4
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsValidIpV6(string queryIP)
        {
            var ipV6 = queryIP.Split(':');
            if (ipV6.Length != 8)
                return false;

            foreach (var block in ipV6)
            {
                if (block.Length == 0 || block.Length > 4)
                    return false;
                foreach (var c in block)
                {
                    if (!((c >= '0' && c <= '9')
                        || (c >= 'a' && c <= 'f')
                        || (c >= 'A' && c <= 'F')))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
