using System;

namespace TagTrak.TagTrakLib
{
	/// <summary>
	/// Extended ComboBox capable of remembering previous selection, in order to restore previous selection
	/// when needed.
	/// </summary>
	public class ComboBoxEx : System.Windows.Forms.ComboBox
	{
		private int previousSelectedIndex = 0;

		public ComboBoxEx()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public int PreviousSelectedIndex
		{
			get
			{
				return previousSelectedIndex;
			}
			set
			{
				previousSelectedIndex = value;
			}
		}


	}
}
