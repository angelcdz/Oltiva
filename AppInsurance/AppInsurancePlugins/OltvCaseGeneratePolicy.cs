using Microsoft.Xrm.Sdk;
using System;

namespace AppInsurancePlugins
{
    public class OltvInsuranceGeneratePolicy : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            var executionContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var policy = string.Empty;

            for (int i = 0; i < 14; i++)
            {
                policy = String.Concat(policy, i == 10 ? '-' : chars[random.Next(chars.Length)]);
            }

            ((Entity)executionContext.InputParameters["Target"]).Attributes.Add("oltv_policy", policy);
        }
    }
}
