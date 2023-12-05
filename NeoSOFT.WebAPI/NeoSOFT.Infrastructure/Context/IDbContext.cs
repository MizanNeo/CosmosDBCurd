
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSOFT.Infrastructure.Context
{
    public interface IDbContext
    {
        public string AccountURL { get; set; }
        public string AuthKey { get; set; }
        public string DatabaseName { get; set; }
        public string ContainerName { get; set; }
       
    }
}
