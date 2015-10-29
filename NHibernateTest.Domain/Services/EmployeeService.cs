using NHibernateTest.Domain.Entities;
using NHibernateTest.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace NHibernateTest.Domain.Services
{
    public interface IEmployeeService
    {
        void CreateForStore(Employee employee, int storeId);

        void Delete(int id);

        IList<Employee> GetAll();

        Employee GetById(int id);

        void Update(Employee employee);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Store> _storeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository, IRepository<Store> storeRepository)
        {
            _employeeRepository = employeeRepository;
            _storeRepository = storeRepository;
        }

        public void CreateForStore(Employee employee, int storeId)
        {
            var store = _storeRepository.GetById(storeId);
            store.AddEmployee(employee);
            _storeRepository.Update(store);
        }

        public void Delete(int id)
        {
            _employeeRepository.Delete(id);
        }

        public IList<Employee> GetAll()
        {
            return _employeeRepository.GetAll().ToList();
        }

        public Employee GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public void Update(Employee employee)
        {
            _employeeRepository.Update(employee);
        }
    }
}