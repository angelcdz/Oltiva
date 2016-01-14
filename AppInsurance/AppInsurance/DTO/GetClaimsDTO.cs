using AppInsurance.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInsurance.DTO.GetClaims
{
    public class GetClaimsRequest : RequestBase
    {
    }
    public class GetClaimsResponse : ResponseBase
    {
        public List<GetClaimsDTO> Claims { get; set; }
    }

    public class GetClaimsDTO : DTOBase
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
    }
}
