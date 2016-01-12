using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace AppInsurancePlugins
{
    public class OltvActionGetInsurances : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            System.Diagnostics.Debugger.Launch();
            var localContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            var organizationContext = (IOrganizationService)serviceProvider.GetService(typeof(IOrganizationService));

            var cases = string.Empty;

            var query = new QueryExpression() { EntityName = "oltv_insurance" };
            query.ColumnSet = new ColumnSet("oltv_insuranceid", "oltv_name", "oltv_policy");
            query.Criteria.AddCondition("ownerid", ConditionOperator.Equal, new EntityReference("user", localContext.UserId));

            var insurances = organizationContext.RetrieveMultiple(query);
            
            query = new QueryExpression() { EntityName = "case" };

            foreach (var item in insurances.Entities)
            {
                query.Criteria = new FilterExpression();
                query.Criteria.AddCondition("oltv_insurance",
                                            ConditionOperator.Equal,
                                            new EntityReference("oltv_insurance", (Guid) item["oltv_insuranceid"]));

                cases = String.Concat(
                                cases,
                                organizationContext.RetrieveMultiple(query).TotalRecordCount,
                                ";");
            }

            localContext.OutputParameters["Insurances"] = insurances;
            localContext.OutputParameters["Cases"] = cases;
        }
    }
}
