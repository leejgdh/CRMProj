using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseeFunction.Models.DAO
{
    public class Class
    {
        public Class()
        {
            Customers = new List<_Customer>();
        }


        public Guid Id { get; set; }

        public string Name { get; set; }

        public string BizNum { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }  


        public List<_Customer> Customers { get; set; }


        public class _Customer
        {

            public string Name { get; set; }

            public string Email { get; set; }

            public string Tel { get; set; }

            public DateTime StartDate { get; set; }

        }

    }
}
