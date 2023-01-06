using FranchiseeFunction.Models.DAO;
using FranchiseeFunction.Models.DTO.Class;
using SharedProject.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseeFunction.Interfaces
{
    public interface IClassService
    {
        Task<TaskBase<Class>> CreateAsync(RequestCreateClass req);

        Task<TaskBase<Class>> InAssignmentCustomerAsync(Guid classId, Class._Customer customer);
    }
}
