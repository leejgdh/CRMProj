using FranchiseeFunction.Interfaces;
using FranchiseeFunction.Models.DAO;
using FranchiseeFunction.Models.DTO.Class;
using SharedProject.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseeFunction.Services
{
    public class ClassService : IClassService
    {
        private readonly FranchiseeContext _context;

        public ClassService(
            FranchiseeContext context
            )
        {
            _context = context;
        }

        public async Task<TaskBase<Class>> CreateAsync(RequestCreateClass req)
        {
            TaskBase<Class> result = new TaskBase<Class>(false);

            var franchisee = await _context.Franchisees.FindAsync(req.BizNum);

            if (franchisee != null)
            {
                Class customer = new Class()
                {
                    BizNum = req.BizNum,
                    Name = req.Name,
                    StartDate = req.StartDate,
                    EndDate = req.EndDate,
                };

                try
                {
                    _context.Classes.Add(customer);

                    await _context.SaveChangesAsync();

                    result.IsSuccess = true;

                }
                catch (Exception ex)
                {
                    result.IsSuccess = false;
                    result.Message = ex.Message;
                }

            }
            else
            {
                result.IsSuccess = false;
                result.Message = $"Cannot find Franchisee ({req.BizNum})";
            }

            return result;
        }

        public async Task<TaskBase<Class>> InAssignmentCustomerAsync(Guid classId, Class._Customer customer)
        {

            TaskBase<Class> result = new TaskBase<Class>(false);


            var targetClass = await _context.Classes.FindAsync(classId);

            if (targetClass != null)
            {

                var alreadyCustomer = targetClass.Customers.Any(e => e.Tel == customer.Tel && e.Email == customer.Email);

                if(!alreadyCustomer)
                {
                    targetClass.Customers.Add(customer);
                    await _context.SaveChangesAsync();
                    result.IsSuccess = true;
                }
                else
                {
                    result.IsSuccess = true;
                    result.Message = "Already in class";
                }

            }
            else
            {

                result.IsSuccess = false;
                result.Message = $"Cannot find class";

            }

            return result;
        }
    }
}
