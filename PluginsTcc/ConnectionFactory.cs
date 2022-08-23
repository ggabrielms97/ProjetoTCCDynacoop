using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsTcc
{
    public class ConnectionFactory
    {
        public static IOrganizationService Dynamics01()
        {
            string connectionString =
                "AuthType=OAuth;" +
                "Username=admin@dynacoop498.onmicrosoft.com;" +
                "Password=Dyp@tcc01;" +
                "Url=https://org6c69dd47.crm2.dynamics.com;" +
                "AppId=e9e38886-943b-4162-8323-9ad625c50f12;" +
                "RedirectUri=app://58145B91-0C36-4500-8554-080854F2AC97;";

            CrmServiceClient crmServiceClient = new CrmServiceClient(connectionString);

            return crmServiceClient.OrganizationWebProxyClient;
        }

        public static IOrganizationService Dynamics02()
        {
            string connectionString =
                "AuthType=OAuth;" +
                "Username=admin@dynacoop02.onmicrosoft.com;" +
                "Password=Dyp@tcc01;" +
                "Url=https://org9e541c0d.crm2.dynamics.com/;" +
                "AppId=83dacd97-f2f0-4e9d-8581-150ee46dc920;" +
                "RedirectUri=app://58145B91-0C36-4500-8554-080854F2AC97;";

            CrmServiceClient crmServiceClient = new CrmServiceClient(connectionString);

            return crmServiceClient.OrganizationWebProxyClient;
        }
    }
}
