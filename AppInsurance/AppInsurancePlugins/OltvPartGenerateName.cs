using Microsoft.Xrm.Sdk;
using System;

namespace AppInsurancePlugins
{
    public class OltvPartGenerateName : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            var executionContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            string firstName, lastName;
            firstName = (string)((Entity)executionContext.InputParameters["Target"])["oltv_firstname"];
            lastName = (string)((Entity)executionContext.InputParameters["Target"])["oltv_lastname"];

            if (((Entity)executionContext.InputParameters["Target"]).Attributes.Contains("oltv_name"))
                ((Entity)executionContext.InputParameters["Target"])["oltv_name"] = String.Concat(firstName, " ", lastName);
            else
                ((Entity)executionContext.InputParameters["Target"]).Attributes.Add("oltv_name", String.Concat(firstName, " ", lastName));
        }
    }
}
