using System;

namespace UserFunction.Models.DTO.Customer
{
    public class RequestCreateCustomer
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Tel { get; set; } 

        public Guid? ClassId { get; set; }

    }
}