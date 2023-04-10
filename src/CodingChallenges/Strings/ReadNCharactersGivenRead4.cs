using System.Collections.Generic;

namespace CodingChallenges.Strings
{
    /// <summary>
    /// Related   : String, Simulation, Interactive
    /// Title     : 158. Read N Characters Given read4 II - Call Multiple Times
    /// Difficult : Hard
    /// Link      : https://leetcode.com/problems/read-n-characters-given-read4-ii-call-multiple-times/
    /// Approachs : -
    /// </summary>
    public class ReadNCharactersGivenRead4_II : Reader4
    {

        private Queue<char> remainChars = new Queue<char>(4);

        public ReadNCharactersGivenRead4_II(string fileContent) : base(fileContent) { }

        /**
         * @param buf Destination buffer
         * @param n   Number of characters to read
         * @return    The number of actual characters read
         */
        public int Read(char[] buf, int n)
        {
            int readCharsCount = 0;

            while (remainChars.Count > 0 && readCharsCount < n)
            {
                buf[readCharsCount] = remainChars.Dequeue();
                readCharsCount++;
            }

            var buf4 = new char[4];
            int readChars = 4;

            while (readCharsCount < n && readChars == 4)
            {
                readChars = Read4(buf4);

                for (int i = 0; i < readChars; i++)
                {
                    if (readCharsCount < n)
                    {
                        buf[readCharsCount] = buf4[i];
                        readCharsCount++;
                    }
                    else
                    {
                        remainChars.Enqueue(buf4[i]);
                    }
                }
            }

            return readCharsCount;
        }
    }

    /// <summary>
    /// Related   : String, Simulation, Interactive
    /// Title     : 157. Read N Characters Given Read4
    /// Difficult : Easy
    /// Link      : https://leetcode.com/problems/read-n-characters-given-read4/
    /// Approachs : -
    /// </summary>
    public class ReadNCharactersGivenRead4 : Reader4
    {
    /**
     * The Read4 API is defined in the parent class Reader4.
     *     int Read4(char[] buf4);
     */
        public ReadNCharactersGivenRead4(string fileContent) : base(fileContent) { }

        /**
         * @param buf Destination buffer
         * @param n   Number of characters to read
         * @return    The number of actual characters read
         */
        public int Read(char[] buf, int n)
        {
            int readCharsCount = 0;
            var buf4 = new char[4];

            int readChars = 0;
            do
            {
                readChars = Read4(buf4);

                for (int i = 0; i < readChars && readCharsCount < n; i++)
                {
                    buf[readCharsCount] = buf4[i];
                    readCharsCount++;
                }
            } while (readCharsCount < n && readChars == 4);

            return readCharsCount;
        }
    }

    // Simulator for the Leetcode Reader4 file reader
    public class Reader4
    {
        private readonly string _fileContent;
        private int _filePointer = 0;

        public Reader4(string fileContent)
            => _fileContent = fileContent;

        public int Read4(char[] buf4)
        {
            for(int i = 0; i < 4 && _filePointer < buf4.Length; i++)
            {
                buf4[i] = _fileContent[i];
                _filePointer++;
            }
            return 0;
        }
    }
}
