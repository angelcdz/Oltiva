using Microsoft.Xrm.Sdk.Samples;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Crm.Sdk.Mobile;

namespace AppInsurance.Base
{
    public abstract class DAOBase<RequestType, ResponseType>
        where ResponseType : ResponseBase, new()
        where RequestType : RequestBase
    {
        public CRMContext service { get; set; }
        
        public async Task<ResponseType> Execute(RequestType request)
        {
            try
            {
                //if (service == null)
                //{
                //    service = new CRMContext();
                //    await service.GetTokenSilent();
                //}

                return await GetData(request);
            }
            catch (System.Exception e)
            {
                var response = new ResponseType();
                response.Status = ExecutionStatus.TechnicalError;
                response.ErrorMessage = e.Message;
                return response;
            }
        }

        protected abstract Task<ResponseType> GetData(RequestType requestData);
    }
}
