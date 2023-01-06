using SharedProject.Models.Base;
using System.Linq;
using System.Threading.Tasks;
using UserFunction.Models.DAO;
using UserFunction.Models.DTO.Customer;

namespace UserFunction.Interfaces
{
    public interface ICustomerService
    {
        IQueryable<Customer> GetAll();

        Task<TaskBase<Customer>> CreateAsync(RequestCreateCustomer req);
    }
}
