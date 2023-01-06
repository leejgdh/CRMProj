using SharedProject.Models.Base;
using System.Threading.Tasks;
using UserFunction.Models.DAO;
using UserFunction.Models.DTO.Customer;

namespace UserFunction.Interfaces
{
    public interface ICustomerService
    {
        Task<TaskBase<Customer>> CreateAsync(RequestCreateCustomer req);
    }
}
