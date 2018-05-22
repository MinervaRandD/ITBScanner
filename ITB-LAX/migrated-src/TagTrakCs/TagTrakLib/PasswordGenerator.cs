using System.Collections;
using System;

using System.Windows.Forms;

namespace TagTrak.TagTrakLib
{
	public class PasswordGenerator
	{
		private static int[] randList = {5019786, 1780964, 12536989, 1321388, 12108916, 8306623, 
									  12064202, 5376355, 6825432, 11139068, 12882681, 7367920,
									  3752069, 9845324, 7376743, 6522420, 4821565, 10831578, 
									  12925342, 6915176, 3315065, 13003012, 14739668, 8005981, 
									  12251579, 113849, 14358596, 6812327, 16650060, 13036577, 
									  8829481, 13226242, 9259046, 4125247, 619502, 14323360, 
									  13086751, 15055319, 4226018, 436013, 7437583, 48369, 
									  8814416, 16265610, 12227133, 11680297, 9915022, 4015560,
									  13905794, 5806672, 5113623, 10229578, 6257414, 2668271,
									  2625005, 13915373, 15999693, 1123549, 15289563, 6258959, 
									  1062289, 857002, 14779803, 16294646, 12174816, 1194763, 
									  10042038, 9929737, 14315016, 15022117, 13696036, 9376133, 
									  13186596, 5771312, 10168293, 8361191, 11108915, 1966843, 
									  9333826, 340195, 5929864, 7025978, 985809, 4723986, 8811521,
									  4612413, 3572979, 12616662, 12039904, 1619904, 7822780,
									  8195476, 11007819, 15729945, 2732947, 276935, 5415655, 
									  6921142, 11575985, 8879750, 3598572, 12305712, 11660530, 
									  334414, 16269261, 14534080, 2194519, 13973027, 11790253,
									  16048326, 8983373, 14648568, 2505063, 10369201, 1771591, 
									  4368017, 2501661, 10511069, 2542332, 7292002, 13139238, 
									  10430482, 16409472, 15809832, 15553455, 14248005, 11225469,
									  5789258, 1861243, 12422870, 4637352, 13617432, 9156197, 
									  673705, 9780913, 12326358, 13089695, 10414931, 14678507, 
									  11323981, 200897, 13624751, 13931079, 2472871, 12983024, 
									  2982127, 14772675, 13397433, 12809487, 9950939, 4432342, 
									  13473836, 8182982, 5746655, 2892288, 4881986, 250198, 
									  11269440, 1421268, 3176263, 8776274, 10774358, 4610572, 
									  2270566, 5858986, 15572536, 321157, 3516086, 7520131, 
									  5446287, 5766465, 12890918, 4380261, 5308982, 16250735, 
									  357746, 10528656, 7489371, 5339866, 789020, 1435841, 
									  12076858, 12224968, 7194129, 8227702, 8734785, 5961976, 
									  3623259, 3097443, 6443158, 14923561, 2080688, 3330876, 
									  503266, 13615807, 9970894, 15861402, 1922771, 12711333, 
									  2284627, 9733547, 131685, 4974490, 2757343, 4980632, 
									  12747864, 8734051, 15529719, 16020117, 380082, 11789954, 
									  13120467, 10628745, 610994, 14648195, 15617135, 2116774, 
									  5408582, 4559698, 5950666, 9990349, 5605582, 9922021, 
									  5645658, 854344, 5445201, 11873776, 14251530, 12285366, 
									  13163936, 1338504, 12430448, 11947843, 3458396, 11366831, 
									  1598171, 12484189, 2873761, 7472814, 10509010, 15872327, 
									  8557607, 10731978, 7826794, 14058237, 9784047, 9559207, 
									  15995861, 13826750, 1272231, 15878645, 3491693, 2830033, 
									  14232906, 13926063, 3541786};
		private static char[] seedCharList = {'D', 'B', 'J', '3', 'V', 'L', 'U', '7', 'W', 'E', '9', 'R', 'P', 'F', 'N', 'G', '4', 'T', 'Y', 'C', '6', 'M', 'H', 'X', 'K', 'A', '8'};
		private static char[] passwordCharList = {'4', '1', '3', '9', '2', '8', '7', '0', '6', '5'};

		private static int getPasswordStringValue(string inputString)
		{
			if (inputString.Length != 4) 
			{
				MessageBox.Show("System Error");
				return 0;
			}

			int returnValue = 0;

			int mod_base = (int) Math.Pow(2, 24);
			int c0 = (int) inputString.ToCharArray()[0];
			int c1 = (int) inputString.ToCharArray()[1];
			int c2 = (int) inputString.ToCharArray()[2];
			int c3 = (int) inputString.ToCharArray()[3];

			returnValue = ((returnValue << 3) + randList[c0]) % mod_base;
			returnValue = ((returnValue << 3) + randList[c1]) % mod_base;
			returnValue = ((returnValue << 3) + randList[c2]) % mod_base;
			returnValue = ((returnValue << 3) + randList[c3]) % mod_base;

			return returnValue;
		}


		public static string GenerateSeed()
		{
			int randSeed;
			DateTime dateAndTimeUTC = DateTime.UtcNow;
			randSeed = dateAndTimeUTC.Millisecond + 1000 * (dateAndTimeUTC.Second + 60 * dateAndTimeUTC.Minute);
			Random randSeedValue = new Random(randSeed);
			string returnString = "";
			double x;
			int r;
			int seedCharListSize = seedCharList.Length;
			for (int i = 0; i <= 7; i++) 
			{
				x = randSeedValue.NextDouble() * seedCharListSize;
				r = ((int)(Math.Floor(x)));
				if (r == seedCharListSize) 
				{
					r--;
				}
				returnString += seedCharList[r];
			}
			return returnString;
		}

		public static string GeneratePassword(string passwordSeed, PasswordType type)
		{
			string seed = passwordSeed.ToUpper();
			string returnString = "";
			seed += seed + seed;

			int s;

			switch (type)
			{
				case PasswordType.ADMIN:
					s = 0;
					break;
				case PasswordType.DATETIME:
					s = 1;
					break;
				case PasswordType.EXIT:
					s = 2;
					break;
				case PasswordType.LOCATION:
					s = 3;
					break;
				default:
					return null;
			}

			for (int i = 0; i <= 9; i++) 
			{
				int offset = getPasswordStringValue(seed.Substring(i + s, 4));
				returnString += passwordCharList[offset % 10];
			}

			return returnString;
		}

		public static PasswordType CheckPasswordType(string testPassword, string seed)
		{
			PasswordType[] types = new PasswordType[]{PasswordType.ADMIN, 
														 PasswordType.DATETIME,
														 PasswordType.EXIT,
														 PasswordType.LOCATION};
			foreach (PasswordType t in types)
			{
				if (isValidPassword(testPassword, seed, t))
				{
					return t;
				}
			}

			return PasswordType.INVALID;
		}


		private static bool isValidPassword(string inputTestPassword, string seed, PasswordType targetType)
		{
			string testPassword = inputTestPassword.ToUpper();
			string targetPassword = GeneratePassword(seed, targetType);

			if (targetPassword == testPassword) 
			{
				return true;
			}

			return false;
		}
    }

	public enum PasswordType { ADMIN, DATETIME, EXIT, LOCATION, INVALID }
}
