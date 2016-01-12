using AppInsurance.Base;
using AppInsurance.DTO.GetInsurances;
using Microsoft.Xrm.Sdk.Samples;
using System;

namespace AppInsurance.DAO
{
    public class GetInsurancesDAO : DAOBase<GetInsurancesRequest, GetInsurancesResponse>
    {
        protected override GetInsurancesResponse GetData(GetInsurancesRequest requestData)
        {
            var request = new OrganizationRequest();
            request.RequestName = "oltv_OltvActionGetInsurances";

            var response = service.Execute(request);

            throw new NotImplementedException();
        }
    }
}
