using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSOFT.Infrastructure.Context
{
    public class DBConnection : IDbContext
    {
        public string AccountURL { get; set; } = string.Empty;
        public string AuthKey { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string ContainerName { get; set; }= string.Empty;
    }
}
