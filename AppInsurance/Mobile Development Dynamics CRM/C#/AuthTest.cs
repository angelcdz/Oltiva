using Microsoft.Crm.Sdk.Messages.Samples;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Xrm.Sdk.Messages.Samples;
using Microsoft.Xrm.Sdk.Query.Samples;
using Microsoft.Xrm.Sdk.Samples;
using System;
using System.Globalization;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;

namespace Microsoft.Crm.Sdk.Mobile
{
    public class AuthTest
    {
        const string aadInstance = "https://login.windows.net/{0}/";
        const string tenant = "avanadeoltiva.onmicrosoft.com";
        //const string tenant = "avanadeoltiva.crm2.dynamics.com";
        const string clientId = "6d80ddbc-b327-40ed-9744-c9d7b6c23435";

        private string authority = String.Format(CultureInfo.InvariantCulture, aadInstance, tenant);
        private AuthenticationContext authContext = null;
        private Uri redirectURI = WebAuthenticationBroker.GetCurrentApplicationCallbackUri();
        private string ResourceId = "https://avanadeoltiva.crm2.dynamics.com";

        public AuthTest()
        {
            this.GetAccessToken();
        }

        private async void GetAccessToken()
        {
            authContext = AuthenticationContext.CreateAsync(authority).GetResults();

            // Use ADAL to get an access token. 
            AuthenticationResult result = await authContext.AcquireTokenSilentAsync(ResourceId, clientId);

            if (result.Status == AuthenticationStatus.Success)
            {
                var AccessToken = result.AccessToken;
            }
        }

        private void ContinueToken(AuthenticationResult result)
        {
            if (result.Status == AuthenticationStatus.Success)
            {
                this.ResourceId = result.AccessToken;
            }
        }
    }
}
