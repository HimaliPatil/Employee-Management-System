using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using DTO;

namespace BLL
{
    public class BLLClass
    {
     // public static List<DTOClass> listDto; 

        public DtoList GetDtoData()
        {
            try
            {
                DALClass Obj = new DALClass();
                DtoList listDto = new DtoList();
                listDto.Emplist = new List<DTOClass>();
                EmpEntityList emp = Obj.GetAllDetails();
                foreach (var data in emp.Emplist)
                {
                    DTOClass dt = new DTOClass
                    {
                        Id = data.Id,
                        Name = data.Name,
                        DesgnationId = data.DesgnationId,
                        Designation=data.Designation,
                        Gender = data.Gender,
                        DepartmentId = data.DepartmentId,
                        Department=data.Department,
                        Experience = data.Experience,
                        Skills = data.Skills,
                        EmailId = data.EmailId,
                        ContactNo = data.ContactNo,
                        SupervisorId = data.SupervisorId,
                        Supervisor=data.Supervisor,
                        DateOfBirth = data.DateOfBirth,
                        Address = data.Address,
                        InsertedBy = data.InsertedBy,
                        InsertedOn = data.InsertedOn,
                        UpdatedBy = data.UpdatedBy,
                        UpdatedOn = data.UpdatedOn
                    };
                    listDto.Emplist.Add(dt);
                }

                listDto.DesnList = new List<LookupDTO>();
                foreach (var data in emp.DesnList)
                {
                    LookupDTO desgObj = new LookupDTO()
                    {
                        Id = data.Id,
                        Name = data.Name
                    };
                    listDto.DesnList.Add(desgObj);
                }

                listDto.DeptList = new List<LookupDTO>();
                foreach (var data in emp.DeptList)
                {
                    LookupDTO deptObj = new LookupDTO()
                    {
                        Id = data.Id,
                        Name = data.Name
                    };

                    listDto.DeptList.Add(deptObj);
                }
                listDto.SupervisorList = new List<DTOClass>();
                int c=emp.SupervisorList.Count();

                foreach (var data in emp.SupervisorList)
                {
                    DTOClass superObj = new DTOClass()
                    {
                        Id = data.Id,
                        Supervisor = data.Supervisor
                    };
                    listDto.SupervisorList.Add(superObj);
                }
                return listDto;
            }
            catch 
            {
                return null;
            }
        }
    }
}
