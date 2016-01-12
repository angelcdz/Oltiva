using Microsoft.Xrm.Sdk.Samples;
using System;

namespace AppInsurance.Base
{
    public abstract class DAOBase<RequestType, ResponseType>
        where ResponseType : ResponseBase, new()
        where RequestType : RequestBase
    {
        public OrganizationDataWebServiceProxy service { get; set; }
        
        public ResponseType Execute(RequestType request)
        {
            try
            {
                if (service == null)
                {
                    service = new OrganizationDataWebServiceProxy();
                    service.ServiceUrl = String.Concat(Constants.CRMUrl, Constants.CRMOrganization);
                }

                return GetData(request);
            }
            catch (System.Exception e)
            {
                var response = new ResponseType();
                response.Status = ExecutionStatus.TechnicalError;
                response.ErrorMessage = e.Message;
                return response;
            }
        }

        protected abstract ResponseType GetData(RequestType requestData);
    }
}
