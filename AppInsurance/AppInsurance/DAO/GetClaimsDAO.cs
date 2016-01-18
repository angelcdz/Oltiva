using AppInsurance.Base;
using AppInsurance.DTO.GetClaims;
using Microsoft.Crm.Sdk.Messages.Samples;
using Microsoft.Crm.Sdk.Mobile;
using Microsoft.Xrm.Sdk.Messages.Samples;
using Microsoft.Xrm.Sdk.Query.Samples;
using Microsoft.Xrm.Sdk.Samples;
using System;
using System.Threading.Tasks;

namespace AppInsurance.DAO
{
    public class GetClaimsDAO : DAOBase<GetClaimsRequest, GetClaimsResponse>
    {
        protected override async Task<GetClaimsResponse> GetData(GetClaimsRequest requestData)
        {
            //var request = new RetrieveMultipleRequest();
            //var query = new QueryExpression("case", new ColumnSet(true));

            //request.Query = query;

            //var response = await service.Retrieve()

            new AuthTest();

            return new GetClaimsResponse()
            {
                Status = ExecutionStatus.Success
            };
        }
    }
}
