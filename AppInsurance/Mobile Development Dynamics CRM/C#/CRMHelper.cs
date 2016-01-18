// =====================================================================
//  This file is part of the Microsoft Dynamics CRM SDK code samples.
//
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
//
//  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
// =====================================================================

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Xrm.Sdk.Samples;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Windows.Security.Authentication.Web;
using Windows.UI.Popups;

namespace Microsoft.Crm.Sdk.Mobile
{
    public class CRMContext
    {
        // TODO Set these string values as approppriate for your app registration and organization.
        // For more information, see the SDK topic "Walkthrough: Register an app with Active Directory".
        public string ServerUrl = "https://avanadeoltiva.crm2.dynamics.com/";
        public string ResourceName = "https://avanadeoltiva.crm2.dynamics.com/";
        public string RedirectUri = WebAuthenticationBroker.GetCurrentApplicationCallbackUri().ToString();
        public string ClientId = "6d80ddbc-b327-40ed-9744-c9d7b6c23435";

        public string AuthorityUrl;

        public OrganizationDataWebServiceProxy proxy;

        public CRMContext()
        {
            proxy = new OrganizationDataWebServiceProxy();
            proxy.ServiceUrl = ServerUrl;
        }

        /// <summary>
        /// Method to get authority URL from organization’s SOAP endpoint.
        /// http://msdn.microsoft.com/en-us/library/dn531009.aspx#bkmk_oauth_discovery
        /// </summary>
        /// <param name="result">The Authority Url returned from HttpResponseMessage.</param>
        public async System.Threading.Tasks.Task DiscoveryAuthority()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer");
                // need to specify soap endpoint with client version,.
                HttpResponseMessage httpResponse = await httpClient.GetAsync(ServerUrl + "/XRMServices/2011/Organization.svc/web?SdkClientVersion=6.1.0.533");
                // For phone, we dont need oauth2/authorization part.
                AuthorityUrl = System.Net.WebUtility.UrlDecode(httpResponse.Headers.GetValues("WWW-Authenticate").FirstOrDefault().Split('=')[1]);//.Replace("oauth2/authorize", "");
            }
        }

        #region ADAL for Windows Phone 8/8.1

        public AuthenticationContext authContext = null;

        public async System.Threading.Tasks.Task GetTokenSilent()
        {
            if(String.IsNullOrEmpty(this.AuthorityUrl))
                await this.DiscoveryAuthority();

            // If authContext is null, then generate it.
            if (authContext == null)
                //#if WINDOWS_PHONE_APP
                //                // ADAL for Windows Phone 8.1 builds AuthenticationContext instances throuhg a factory, which performs authority validation at creation time
                authContext = AuthenticationContext.CreateAsync(this.AuthorityUrl,false).GetResults();
            AuthenticationResult result = await authContext.AcquireTokenSilentAsync(this.ResourceName, this.ClientId);

            //#else
            //    authContext = AuthenticationContext.CreateAsync(this.AuthorityUrl).GetResults();
            //AuthenticationResult result = await authContext.AcquireTokenSilentAsync(this.ResourceName, this.ClientId);            
            //#endif

            if (result != null && result.Status == AuthenticationStatus.Success)
            {
                // A token was successfully retrieved. Then store it.
                StoreToken(result);
            }
            else
            {
#if WINDOWS_PHONE_APP
                // Clear the AccessToken first so that any Service Calls waits until it's filled.
                proxy.AccessToken = "";
                // In case credential was wrong, clear the token cache first.
                authContext.TokenCache.Clear();
                // Acquiring a token without user interaction was not possible. 
                // Trigger an authentication experience and specify that once a token has been obtained the StoreToken method should be called.
                authContext.AcquireTokenAndContinue(this.ResourceName, this.ClientId, new Uri(this.RedirectUri), StoreToken);
#else
                DisplayErrorWhenAcquireTokenFails(result);
#endif
            }
        }

        public void StoreToken(AuthenticationResult result)
        {
            if (result.Status == AuthenticationStatus.Success)
            {
                this.proxy.AccessToken = result.AccessToken;
            }
            else
            {
                DisplayErrorWhenAcquireTokenFails(result);
            }
        }

        private async void DisplayErrorWhenAcquireTokenFails(AuthenticationResult result)
        {
            MessageDialog dialog;

            switch (result.Error)
            {
                case "authentication_canceled":
                    // User cancelled, so no need to display a message.
                    break;
                case "temporarily_unavailable":
                case "server_error":
                    dialog = new MessageDialog("Please retry the operation. If the error continues, please contact your administrator.", "Sorry, an error has occurred.");
                    await dialog.ShowAsync();
                    break;
                default:
                    // An error occurred when acquiring a token. Show the error description in a MessageDialog. 
                    dialog = new MessageDialog(string.Format("If the error continues, please contact your administrator.\n\nError: {0}\n\nError Description:\n\n{1}", result.Error, result.ErrorDescription), "Sorry, an error has occurred.");
                    await dialog.ShowAsync();
                    break;
            }
        }

        #endregion

    }
}
