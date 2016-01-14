using AppInsurance.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace AppInsurance.DTO.GetInsurances
{
    public class GetInsurancesRequest : RequestBase
    {
    }
    public class GetInsurancesResponse : ResponseBase
    {
        public List<GetInsurancesDTO> Insurances { get; set; }
    }

    public class GetInsurancesDTO : DTOBase
    {
        public string Title { get; set; }
        public string Policy { get; set; }
        public int Claims { get; set; }
        public BitmapImage Background { get; set; }
    }
}
