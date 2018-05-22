using System;
using System.Data;
using System.Reflection;
using System.Drawing;

namespace TagTrak
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Resources
	{
		public Resources()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static Bitmap Logo(string carrierCode)
		{
			Bitmap img = null;

			Assembly asm = Assembly.GetExecutingAssembly();
			System.IO.Stream s = asm.GetManifestResourceStream("TagTrak.Logos." + carrierCode + ".gif");
			if (s != null)
			{
				img = new Bitmap(s);
			}
			else
			{
				s = asm.GetManifestResourceStream("TagTrak.Logos.AS.gif");
				if (s != null)
				{
					img = new Bitmap(s);
				}
			}
			return img;
		}
	}
}
