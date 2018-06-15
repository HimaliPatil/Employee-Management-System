using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models.ClassesEmp
{

    //main class to pass view 
    public class EmpModelList
    {
        public List<Employee> Emplist { get; set; }
        public List<LookupData> DesnList { get; set; }
        public List<LookupData> DeptList { get; set; }
        public List<Employee> SupervisorList { get; set; }

        public Employee Emp;
        public LookupData LData;

        public EmpModelList()
        {
            Emp = new Employee();
            LData = new LookupData();
        }

    }
    public class LookupData
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DesgnationId { get; set; }
        public string Designation { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public int Experience { get; set; }

        public string Skills { get; set; }

        public string EmailId { get; set; }

        public string ContactNo { get; set; }

        public int? SupervisorId { get; set; }
        public string Supervisor { get; set; }
        public Nullable<DateTime> DateOfBirth { get; set; }

        public string Address { get; set; }
        public string InsertedBy { get; set; }
        public Nullable<DateTime> InsertedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }

    }
}

     