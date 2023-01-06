using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseeFunction.Models.DTO.Class
{
    public class RequestCreateClass
    {
        public string BizNum { get; set; }  

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }


    }
}
