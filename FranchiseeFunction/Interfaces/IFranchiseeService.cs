using FranchiseeFunction.Models.DAO;
using FranchiseeFunction.Models.DTO.Franchisee;
using SharedProject.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseeFunction.Interfaces
{
    public interface IFranchiseeService
    {
        Task<TaskBase<Franchisee>> CreateFranchisee(RequestCreateFranchisee req);
    }
}
