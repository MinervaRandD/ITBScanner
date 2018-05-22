using System.Text.RegularExpressions;
using OpenNETCF.Security.Cryptography;
using System.IO;
using System.Text;

namespace TagTrak.TagTrakLib
{
	public struct Utilities
	{

		public static bool isTextCharacter(byte inputChar)
		{
			if (inputChar == 13) 
			{
				return true;
			}
			if (inputChar == 10) 
			{
				return true;
			}
			if (inputChar == 9) 
			{
				return true;
			}
			if (inputChar >= 32 & inputChar <= 126) 
			{
				return true;
			}
			return false;
		}

		public static bool isValidFlightNumber(string input)
		{
			return Regex.IsMatch(input, "^[a-zA-Z0-9]{2}\\d{1,4}$");
		}

		public static bool isValidACBinID(string input)
		{
			return Regex.IsMatch(input, "^[0-9a-zA-Z]{1,10}$");
		}

		public static bool isValidLocation(string input)
		{
			return Regex.IsMatch(input, "^[a-zA-Z]{3}$");
		}

		public static string getSha1Hash(string input)
		{
			SHA1CryptoServiceProvider sha1Hasher = new SHA1CryptoServiceProvider();

			byte[] data = sha1Hasher.ComputeHash(Encoding.Default.GetBytes(input));

			StringBuilder sBuilder = new StringBuilder();

			for (int i = 0; i < data.Length; i++)
			{
				sBuilder.Append(data[i].ToString("x2"));
			}

			return sBuilder.ToString();
		}

        public static string SerialNo
        {
            get
            {
#if INTERMEC
                return Hardware.Device.GetUniqueID();
#else
                return "HENRY-MC75";
#endif
            }
        }

	}
}
