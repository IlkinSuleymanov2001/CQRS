using Core.Persistence.Paging;
using Kodlama.io.Application.Features.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.Users.Models
{
    public  class UserListModel:BasePageableModel
    {
        public IList<GetListUserDto> Items { get; set; }
    }
}
