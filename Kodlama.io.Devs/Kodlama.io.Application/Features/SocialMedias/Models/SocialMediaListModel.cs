using Core.Persistence.Paging;
using Kodlama.io.Application.Features.SocialMedias.Dtos;
using Kodlama.io.Application.Features.SocialMedias.Queries.GetList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.SocialMedias.Models
{
    public class SocialMediaListModel:BasePageableModel
    {
        public IList<GetListSocialMediaDto> Items { get; set; }
    }
}
