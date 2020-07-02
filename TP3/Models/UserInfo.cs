using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP3.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    namespace Identity.Models
    {
        public class UserInfo
        {
            [Key]
            public string Email { get; set; }

            public string Password { get; set; }
        }
    }
}