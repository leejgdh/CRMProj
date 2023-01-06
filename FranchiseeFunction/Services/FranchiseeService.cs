using FranchiseeFunction.Interfaces;
using FranchiseeFunction.Models.DAO;
using FranchiseeFunction.Models.DTO.Franchisee;
using SharedProject.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseeFunction.Services
{
    public class FranchiseeService : IFranchiseeService
    {
        private readonly FranchiseeContext _context;

        public FranchiseeService(
            FranchiseeContext context
            )
        {
            _context = context;
        }

        public async Task<TaskBase<Franchisee>> CreateAsync(RequestCreateFranchisee req)
        {
            TaskBase<Franchisee> result = new TaskBase<Franchisee>(false);


            Franchisee customer = new Franchisee()
            {
                BizNum= req.BizNum,
                Name = req.Name,
                Owner= req.Owner,
                Addr= req.Addr,
                Addr2= req.Addr2,
                Tel = req.Tel,
            };

            try
            {
                _context.Franchisees.Add(customer);

                await _context.SaveChangesAsync();

                result.IsSuccess = true;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
