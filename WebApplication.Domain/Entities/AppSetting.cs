using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Domain.Entities
{
    public class AppSetting
    {
        public string? SecretKey { get; set; }
        public string? issuer { get; set; }
        public string? Audience { get; set; }
    }
}
