using AppInsurance.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace AppInsurance.DTO.GetChallenges
{
    public class GetChallengesRequest : RequestBase
    {
    }
    public class GetChallengesResponse : ResponseBase
    {
        public List<GetChallengesDTO> Challenges { get; set; }
    }

    public class GetChallengesDTO : DTOBase
    {
        public string Slogan { get; set; }
        public string Title { get; set; }
        public BitmapImage Background { get; set; }
    }
}
