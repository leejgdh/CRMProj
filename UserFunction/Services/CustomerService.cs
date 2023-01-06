using SharedProject.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserFunction.Interfaces;
using UserFunction.Models.DAO;
using UserFunction.Models.DTO.Customer;

namespace UserFunction.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly UserContext _context;

        public CustomerService(
            UserContext context
            )
        {
            _context = context;
        }

        public async Task<TaskBase<Customer>> CreateAsync(RequestCreateCustomer req)
        {
            TaskBase<Customer> result = new TaskBase<Customer>(false);


            Customer customer = new Customer()
            {
                Name = req.Name,
                Email = req.Email,
                Tel = req.Tel,
                Password = req.Password,
            };

            try
            {
                _context.Customers.Add(customer);

                await _context.SaveChangesAsync();

                result.IsSuccess = true;

            }
            catch (Exception ex)
            {
                result.IsSuccess= false;
                result.Message = ex.Message;
            }

            return result;
        }

        public IQueryable<Customer> GetAll()
        {
            var datas = _context.Customers.AsQueryable();

            return datas;
        }
    }
}
