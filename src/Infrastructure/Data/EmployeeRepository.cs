using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace FAIS.Infrastructure.Data
{
    public class EmployeeRepository : EFRepository<Employee, string>, IEmployeeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepository"/> class.
        /// </summary>
        public EmployeeRepository(FAISContext context) : base(context) { }

        public IReadOnlyCollection<EmployeeModel> Get()
        {
            var employees = (from t in _dbContext.Employees
                               select new EmployeeModel()
                               {
                                   EmployeeNumber = t.EmployeeNumber,
                                   FirstName = t.FirstName,
                                   MiddleName = t.MiddleName,
                                   LastName = t.LastName
                               }).ToList();

            return employees;
        }
    }
}
