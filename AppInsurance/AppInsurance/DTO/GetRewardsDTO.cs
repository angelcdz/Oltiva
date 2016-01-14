using AppInsurance.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace AppInsurance.DTO.GetRewards
{
    public class GetRewardsRequest : RequestBase
    {
    }
    public class GetRewardsResponse : ResponseBase
    {
        public List<GetRewardsDTO> Rewards { get; set; }
    }

    public class GetRewardsDTO : DTOBase
    {
        public string Title { get; set; }
        public string Expiration { get; set; }
        public BitmapImage Icon { get; set; }
    }
}
