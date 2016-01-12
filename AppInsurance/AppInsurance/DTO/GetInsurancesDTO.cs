using AppInsurance.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInsurance.DTO.GetInsurances
{
    public class GetInsurancesRequest : RequestBase
    {
    }
    public class GetInsurancesResponse : ResponseBase
    {
        public List<GetInsurancesDTO> Insurances { get; set; }
    }

    public class GetInsurancesDTO
    {
        public string Title { get; set; }
        public string Policy { get; set; }
        public int Claims { get; set; }
    }
}
