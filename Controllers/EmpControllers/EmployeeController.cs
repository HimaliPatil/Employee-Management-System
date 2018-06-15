using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using BLL;
using Entity;
using DAL;
using EmployeeManagement.Models.ClassesEmp;

namespace EmployeeManagement.Controllers.EmpControllers
{
    public class EmployeeController : Controller
    {
       // List<Employee> modelList;
      
        // GET: Employee
        public ActionResult Index()
        {
            

            return View();
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        //public ActionResult Create()
        //{

        //    return View();
        //}

        // POST: Employee/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create(EmpModelList e)
        {
            Console.WriteLine("Hello" + e.Emp.Name );
            Console.WriteLine("Hello" + e.Emp.);
            try
            {


                //EntityEmployee obj = new EntityEmployee
                //{
                //    // ID = e.ID,
                //    NAME = e.NAME,
                //    DESIGNATION_ID = e.DESIGNATION_ID,
                //    GENDER = e.GENDER,
                //    DEPARTMENT_ID = e.DEPARTMENT_ID,
                //    EXPERIENCE = e.EXPERIENCE,
                //    SKILLS = e.SKILLS,
                //    EMAIL_ID = e.EMAIL_ID,
                //    CONTACT_NUMBER = e.CONTACT_NUMBER,
                //    SUPERVISOR_ID = e.SUPERVISOR_ID,
                //    DATE_OF_BIRTH = e.DATE_OF_BIRTH,
                //    ADDRESS = e.ADDRESS,
                //    INSERTED_BY = e.INSERTED_BY,
                //    INSERTED_ON = e.INSERTED_ON,
                //    UPDATED_BY = e.UPDATED_BY,
                //    UPDATED_ON = e.UPDATED_ON
                //};

                //string result = DALClass.AddEmployee(obj);

                return RedirectToAction("OnPageLoad");
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                return RedirectToAction("OnPageLoad");
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee e)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {

            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee e)
        {
            try
            {
                // TODO: Add delete logic here
                //DALClass.DeleteEmp(id);
                return RedirectToAction("GetAllEmps");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult OnPageLoad()
        {
            EmpModelList mainObj = new EmpModelList();
            BLLClass bllObj = new BLLClass();
            mainObj.DesnList = new List<LookupData>();
            mainObj.DeptList = new List<LookupData>();
            mainObj.SupervisorList = new List<Employee>();
            DtoList list = new DtoList();
            list.DesnList = new List<LookupDTO>();
            list.DeptList = new List<LookupDTO>();
            list.SupervisorList = new List<DTOClass>();
            list = bllObj.GetDtoData();
            foreach (var data in list.DesnList)
            {
                LookupData desgObj = new LookupData()
                {
                    Id = data.Id,
                    Name = data.Name
                };

                mainObj.DesnList.Add(desgObj);

            }

            foreach (var data in list.DeptList)
            {
                LookupData deptObj = new LookupData()
                {
                    Id = data.Id,
                    Name = data.Name
                };

                mainObj.DeptList.Add(deptObj);

            }

            foreach (var data in list.SupervisorList)
            {
                Employee superObj = new Employee()
                {
                    Id = data.Id,
                    Supervisor = data.Supervisor
                };

                mainObj.SupervisorList.Add(superObj);

            }

            return View(mainObj);
        }
       
       
        [HttpGet]
        public JsonResult GetAllEmpsDetails()
        {
            try {
                BLLClass bllObj = new BLLClass();
                //  listobj = orig.ConvertAll(x => new Employee{ SomeValue = x.SomeValue });  OR
                EmpModelList mainObj = new EmpModelList();
                List<DTOClass> list = new List<DTOClass>();
                list = bllObj.GetDtoData().Emplist;
                mainObj.Emplist = new List<Employee>();
             foreach (var data in list)
                {
                    Employee empObj = new Employee()
                    {
                        Id=data.Id,
                        Name=data.Name,
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
                    mainObj.Emplist.Add(empObj);
                }
                var json = new { isSuccess = true, data = mainObj.Emplist };
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var json = new
                {
                    isSuccess = false,
                    message = ex.Message
                };              

                return Json(json, JsonRequestBehavior.AllowGet);
             }       
        }
        //public JsonResult GetDesignation()
        //{
        //    try
        //    {
        //        BLLClass bllObj = new BLLClass();
        //        EmpModelList mainObj = new EmpModelList();
        //        foreach (var data in bllObj.GetDtoData().DesnList)
        //        {
        //            LookupData desgObj = new LookupData()
        //            {
        //                Id = data.Id,
        //                Name = data.Name
        //            };

        //            mainObj.DesnList.Add(desgObj);

        //        }
        //        var json = new { isSuccess = true, data = mainObj.DesnList };
        //        return Json(json, JsonRequestBehavior.AllowGet);
        //    }
        //    catch(Exception ex)
        //    {
        //        var json = new
        //        {
        //            isSuccess = false,
        //            message = ex.Message
        //        };

        //        return Json(json, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //public JsonResult GetAllDept()
        //{
        //    try
        //    {
        //        BLLClass bllObj = new BLLClass();
        //        EmpModelList mainObj = new EmpModelList();
        //        foreach (var data in bllObj.GetDtoData().DeptList)
        //        {
        //            LookupData deptObj = new LookupData()
        //            {
        //                Id = data.Id,
        //                Name = data.Name
        //            };

        //            mainObj.DeptList.Add(deptObj);

        //        }
        //        var json = new { isSuccess = true, data = mainObj.DeptList };
        //        return Json(json, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        var json = new
        //        {
        //            isSuccess = false,
        //            message = ex.Message
        //        };

        //        return Json(json, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //public JsonResult GetAllSupervisor()
        //{
        //    try
        //    {
        //        BLLClass bllObj = new BLLClass();
        //        EmpModelList mainObj = new EmpModelList();
        //        foreach (var data in bllObj.GetDtoData().SupervisorList)
        //        {
        //            Employee superObj = new Employee()
        //            {
        //                Id = data.Id,
        //                Name = data.Name
        //            };

        //            mainObj.SupervisorList.Add(superObj);

        //        }
        //        var json = new { isSuccess = true, data = mainObj.SupervisorList };
        //        return Json(json, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        var json = new
        //        {
        //            isSuccess = false,
        //            message = ex.Message
        //        };

        //        return Json(json, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}
