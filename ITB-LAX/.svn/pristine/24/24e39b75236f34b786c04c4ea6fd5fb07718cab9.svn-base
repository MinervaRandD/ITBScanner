using System;
using System.Net;


namespace TagTrak.TagTrakLib
{
	using com.asiscan.baggage;


	/// <summary>
	/// wrapper class around auto-generated TagTrakSyncService proxy class to provide customization in one place
	/// </summary>
	public class WebSyncService : TagTrakSyncService
	{
        private DateTime _CredentialsLastUpdate = DateTime.MinValue;

		public WebSyncService()
		{
            SetCredentials();

			this.PreAuthenticate = true;
#if !DEBUG
			this.Url = "http://baggage.asiscan.com/index.php?soap=tagtraksync";
#endif		
		}

        protected override WebRequest GetWebRequest(Uri uri)
        {
            if (DateTime.Now.Date != _CredentialsLastUpdate.Date)
            {
                SetCredentials();
            }

            return base.GetWebRequest(uri);
        }

        private void SetCredentials()
        {
            string uid = Utilities.SerialNo;
            ulong pwdSeed = ulong.Parse(PasswordGenerator.GeneratePassword(uid, PasswordType.ADMIN))
                * (ulong)DateTime.UtcNow.DayOfYear / (ulong)DateTime.UtcNow.Year;
            string pwd = Utilities.getSha1Hash(pwdSeed.ToString());
            this.Credentials = new NetworkCredential(uid, pwd);
            _CredentialsLastUpdate = DateTime.Now;
        }

	}
}
