using LinqPlayground.Models;

namespace LinqPlayground._02ProjectionOperators
{
    internal class SelectOperator
    {
        private readonly List<Employee> _employees;

        public SelectOperator()
        {
            _employees = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Sreejith", Email = "sreejith@gmail.com"},
                new Employee() { Id = 2, Name = "Athulya", Email = "athulya@gmail.com"},
                new Employee() { Id = 3, Name = "Rithul", Email = "rithul@gmail.com"}
            };
        }

        #region Basic
        public List<Employee> BasicQuery()
        {
            return (from emp in _employees
                    select emp).ToList();
        }

        public List<Employee> BasicMethod()
        {
            return _employees.Where(emp => emp.Id == 2).ToList();
        }


        public List<int> BasicQuerySelectingField()
        {
            return (from emp in _employees
                    select emp.Id).ToList();
        }

        public List<string> BasicMethodSelectingField()
        {
            return _employees.Select(emp => emp.Id.ToString()).ToList();
        }
        #endregion

        #region Select Some Fields only
        public List<Employee> BasicQuerySelectingSomeFieldsOnly()
        {
            return (from emp in _employees
                    select new Employee()
                    {
                        Id = emp.Id,
                        Name = emp.Name
                    }).ToList();
        }

        public List<Employee> BasicMethodSelectingSomeFieldsOnly()
        {
            return _employees.Select(emp => new Employee()
            {
                Id = emp.Id,
                Name = emp.Name
            }).ToList();
        }
        #endregion


        #region Select Data To Another Class
        public List<Student> QueryDataToAnotherClass()
        {
            return (from emp in _employees
                    select new Student()
                    {
                        StudentId = emp.Id,
                        StudentName = emp.Name
                    }).ToList();
        }

        public List<Student> MethodDataToAnotherClass()
        {
            return _employees.Select(emp => new Student()
            {
                StudentId = emp.Id,
                StudentName = emp.Name
            }).ToList();
        }
        #endregion

        #region Map Data To Anonymous Type
        public void QueryMapDataToAnonymousType()
        {
            var query = (from emp in _employees
                         select new
                         {
                             StudentId = emp.Id,
                             StudentName = emp.Name
                         }).ToList();
        }

        public void MethodMapDataToAnonymousType()
        {
            var method = _employees.Select(emp => new
            {
                StudentId = emp.Id,
                StudentName = emp.Name
            }).ToList();
        }
        #endregion

        #region Select Data with Index
        public void MethodDataWithIndex()
        {
            var method = _employees.Select((emp, index) => new
            {
                StudentId = index,
                StudentName = emp.Name
            }).ToList();
        }
        #endregion
    }
}
