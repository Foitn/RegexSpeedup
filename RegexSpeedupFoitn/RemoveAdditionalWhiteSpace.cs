using System.Linq;
using System.Runtime.InteropServices;

namespace RegexSpeedupFoitn
{
    public static class RemoveAdditionalWhiteSpace
    {
        public static string ReplaceWhiteSpacesLINQ(string text)
        {
            return string.Join(" ", text.Trim().Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)));
        }

        public static string ReplaceWhiteSpacesFor(string text)
        {
            char[] chars = text.Trim().ToCharArray();
            char[] result = new char[chars.Length];
            bool gotFirst = false;
            int numberOfChars = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];
                if ((c == ' ' || c == '\t') && gotFirst)
                {
                    continue;
                }
                else if (c == ' ')
                {
                    gotFirst = true;
                }
                else
                {
                    gotFirst = false;
                }
                result[numberOfChars++] = c;
            }
            return new string(result, 0, numberOfChars);
        }

        public static string ReplaceWhiteSpacesCpp(string text)
        {
            char[] chars = new char[text.Length];
            int length = ReplaceWhiteSpacesInCppFor(text, ref chars[0], text.Length);
            return new string(chars, 0, length);
        }

        private const string DllFilePath = @"RegexSpeedupFoitn_cpp.dll";
        [DllImport(DllFilePath, CallingConvention = CallingConvention.Cdecl)]
        private extern static int ReplaceWhiteSpacesInCppFor(string input, ref char output, int inputLength);
        [DllImport(DllFilePath, CallingConvention = CallingConvention.Cdecl)]
        private extern static int test(ref char input, ref char output, int amount);

    }
}