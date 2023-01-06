using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseeFunction.Models.DTO.Franchisee
{
    public class RequestCreateFranchisee
    {
        public string BizNum { get; set; }

        public string Name { get; set; }

        public string Owner { get; set; }

        public string Addr { get; set; }

        public string Addr2 { get; set; }

        public string Tel { get; set; }
    }
}
