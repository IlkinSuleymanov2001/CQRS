using Core.Persistence.Paging;
using Kodlama.io.Application.Features.UserSocialMedias.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.UserSocialMedias.Models
{
    public class UserSocialMediaListModel:BasePageableModel
    {

        public IList<GetListUserSocialMediaDto> Items {  get; set; }
    }
}
