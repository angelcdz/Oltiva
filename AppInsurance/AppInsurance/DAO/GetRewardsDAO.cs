using AppInsurance.Base;
using AppInsurance.DTO.GetRewards;
using Microsoft.Crm.Sdk.Messages.Samples;
using Microsoft.Xrm.Sdk.Messages.Samples;
using Microsoft.Xrm.Sdk.Query.Samples;
using Microsoft.Xrm.Sdk.Samples;
using System;
using System.Threading.Tasks;

namespace AppInsurance.DAO
{
    public class GetRewardsDAO : DAOBase<GetRewardsRequest, GetRewardsResponse>
    {
        protected override async Task<GetRewardsResponse> GetData(GetRewardsRequest requestData)
        {
            throw new NotImplementedException();

            //var request = new RetrieveMultipleRequest();
            //var query = new QueryExpression("oltv_insurance", new ColumnSet(true));

            //request.Query = query;

            //var response = await service.Execute(new WhoAmIRequest());
            
            //var response = await service.RestRetrieveMultiple("oltv_insurance", new ColumnSet("oltv_name"));
            
            //return new GetInsurancesResponse()
            //{
            //    Status = ExecutionStatus.Success
            //};
        }
    }
}
