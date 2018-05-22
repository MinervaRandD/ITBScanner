using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Asi.Itb.Utilities
{
    /// <summary>
    /// Represent class of objects used to allow setting WebRequest.CertificatePolicy to 
    /// not fail on Cert errors
    /// </summary>
    public class AcceptAllCertificatePolicy : ICertificatePolicy
    {
        public AcceptAllCertificatePolicy() { }

        #region ICertificatePolicy Members

        public bool CheckValidationResult(ServicePoint srvPoint, System.Security.Cryptography.X509Certificates.X509Certificate certificate, WebRequest request, int certificateProblem)
        {
            return true;
        }

        #endregion
    }
}
