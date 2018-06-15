using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Entity ;
using System.Globalization;

namespace DAL
{
    public class DALClass
    {
        // public static List<EntityEmployee> listObj = new List<EntityEmployee>();
        static SqlConnection connStr = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        // static SqlDataReader rdr;
        public static string result = null;
        EmpEntityList listObject = new EmpEntityList();



        public EmpEntityList GetAllDetails()
        {
            try
            { 
                SqlCommand cmd = new SqlCommand("Proc_Employee_Details", connStr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SQL_CMD_TYPE", "SELECT");
                if (connStr.State == ConnectionState.Closed)
                {
                    connStr.Open();
                }
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataSet tab = new DataSet();
                sd.Fill(tab);
                // int count1= tab.Tables[0].Rows.Count;
                listObject.Emplist = new List<EmployeeEntity>();
                listObject.DesnList = new List<LookupEntity>();
                listObject.DeptList = new List<LookupEntity>();
                listObject.SupervisorList = new List<EmployeeEntity>();

                if (tab.Tables.Count > 0)
                {
                    foreach (DataRow row in tab.Tables[0].Rows)
                    {
                        listObject.Emplist.Add(new EmployeeEntity
                        {
                            Id = Convert.ToInt32(row["ID"]),
                            Name = row["NAME"].ToString(),
                            DesgnationId = Convert.ToInt32(row["DESIGNATION_ID"]),
                            Designation = row["DESIGNATION_NAME"].ToString(),
                            Gender = row["GENDER"].ToString(),
                            DepartmentId = Convert.ToInt32(row["DEPARTMENT_ID"]),
                            Department = row["DEPARTMENT_NAME"].ToString(),
                            Experience = Convert.ToInt32(row["EXPERIENCE"]),
                            Skills = row["SKILLS"].ToString(),
                            EmailId = row["EMAIL_ID"].ToString(),
                            ContactNo = row["CONTACT_NUMBER"].ToString(),
                            SupervisorId = row["SUPERVISOR_ID"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["SUPERVISOR_ID"]),
                            Supervisor = row["SUPERVISOR"].ToString(),
                            DateOfBirth = Convert.ToDateTime(row["DATE_OF_BIRTH"].ToString()),
                            Address = row["ADDRESS"].ToString(),
                            InsertedBy = row["INSERTED_BY"] == DBNull.Value ? null : row["INSERTED_BY"].ToString(),
                            InsertedOn = row["INSERTED_ON"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["DATE_OF_BIRTH"].ToString()),
                            UpdatedBy = row["UPDATED_BY"] == DBNull.Value ? null : row["UPDATED_BY"].ToString(),
                            UpdatedOn = row["UPDATED_ON"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["DATE_OF_BIRTH"].ToString())
                        });

                    }
                }


                foreach (DataRow row in tab.Tables[1].Rows)
                {
                    listObject.DesnList.Add(
                           new LookupEntity()
                           {
                               Id = Convert.ToInt32(row["ID"]),
                               Name = row["NAME"].ToString()
                           });
                }

                foreach (DataRow row in tab.Tables[2].Rows)
                {
                    listObject.DeptList.Add(
                        new LookupEntity()
                        {
                            Id = Convert.ToInt32(row["ID"]),
                            Name = row["NAME"].ToString()
                        });
                }
                foreach (DataRow row in tab.Tables[3].Rows)
                {
                    listObject.SupervisorList.Add(
                        new EmployeeEntity()
                        {
                            Id = Convert.ToInt32(row["ID"]),
                            Supervisor = row["SUPERVISOR"].ToString()
                        });
                   
                }

                return listObject;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            finally
            {

                connStr.Close();

            }
        }

        public EmpEntityList GetAllEmps()
        {
            try
            {

                EmpEntityList listObject = new EmpEntityList();
                // List<EmployeeEntity> list = new List<EmployeeEntity>(); 
                SqlCommand cmd = new SqlCommand("Proc_Employee_Details", connStr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SQL_CMD_TYPE", "SELECT");
                if (connStr.State == ConnectionState.Closed)
                {
                    connStr.Open();
                }
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataSet tab = new DataSet();
                sd.Fill(tab);
                // int count1= tab.Tables[0].Rows.Count;
                listObject.Emplist = new List<EmployeeEntity>();
                listObject.DesnList = new List<LookupEntity>();
                listObject.DeptList = new List<LookupEntity>();
                listObject.SupervisorList = new List<EmployeeEntity>();

                if (tab.Tables.Count > 0)
                {
                    foreach (DataRow row in tab.Tables[0].Rows)
                    {
                        listObject.Emplist.Add(new EmployeeEntity
                        {
                            Id = Convert.ToInt32(row["ID"]),
                            Name = row["NAME"].ToString(),
                            DesgnationId = Convert.ToInt32(row["DESIGNATION_ID"]),
                            Designation = row["DESIGNATION_NAME"].ToString(),
                            Gender = row["GENDER"].ToString(),
                            DepartmentId = Convert.ToInt32(row["DEPARTMENT_ID"]),
                            Department = row["DEPARTMENT_NAME"].ToString(),
                            Experience = Convert.ToInt32(row["EXPERIENCE"]),
                            Skills = row["SKILLS"].ToString(),
                            EmailId = row["EMAIL_ID"].ToString(),
                            ContactNo = row["CONTACT_NUMBER"].ToString(),
                            SupervisorId = row["SUPERVISOR_ID"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["SUPERVISOR_ID"]),
                            Supervisor = row["SUPERVISOR"].ToString(),
                            DateOfBirth = Convert.ToDateTime(row["DATE_OF_BIRTH"].ToString()),
                            Address = row["ADDRESS"].ToString(),
                            InsertedBy = row["INSERTED_BY"] == DBNull.Value ? null : row["INSERTED_BY"].ToString(),
                            InsertedOn = row["INSERTED_ON"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["DATE_OF_BIRTH"].ToString()),
                            UpdatedBy = row["UPDATED_BY"] == DBNull.Value ? null : row["UPDATED_BY"].ToString(),
                            UpdatedOn = row["UPDATED_ON"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["DATE_OF_BIRTH"].ToString())
                        });

                    }
                   
                }
                return listObject;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            finally
            {

                connStr.Close();

            }
        }
    }
}
//public  string AddEmployee(EntityEmployee e)
//{
//    try
//    {

//        SqlCommand cmd = new SqlCommand("Proc_Employee_Details", connStr);
//        cmd.CommandType = CommandType.StoredProcedure;

//        cmd.Parameters.AddWithValue("@NAME", e.NAME);
//        cmd.Parameters.AddWithValue("@DESIGNATION_ID", e.DESIGNATION_ID);
//        cmd.Parameters.AddWithValue("@GENDER", e.GENDER);
//        cmd.Parameters.AddWithValue("@DEPARTMENT_ID", e.DEPARTMENT_ID);
//        cmd.Parameters.AddWithValue("@EXPERIENCE", e.EXPERIENCE);
//        cmd.Parameters.AddWithValue("@SKILLS", e.SKILLS);
//        cmd.Parameters.AddWithValue("@EMAIL_ID", e.EMAIL_ID);
//        cmd.Parameters.AddWithValue("@CONTACT_NUMBER", e.CONTACT_NUMBER);
//        cmd.Parameters.AddWithValue("@SUPERVISOR_ID", e.SUPERVISOR_ID);
//        cmd.Parameters.AddWithValue("@DATE_OF_BIRTH", e.DATE_OF_BIRTH);
//        cmd.Parameters.AddWithValue("@ADDRESS", e.ADDRESS);
//        cmd.Parameters.AddWithValue("@INSERTED_BY", e.INSERTED_BY);
//        cmd.Parameters.AddWithValue("@INSERTED_ON", e.INSERTED_ON);
//        //cmd.Parameters.AddWithValue("@UPDATED_BY", e.UPDATED_BY);
//        //cmd.Parameters.AddWithValue("@UPDATED_ON", e.UPDATED_ON);
//        cmd.Parameters.AddWithValue("@SQL_CMD_TYPE", "INSERT");

//        if (connStr.State == ConnectionState.Closed)
//        {
//            connStr.Open();
//        }
//        //SqlDataAdapter sd = new SqlDataAdapter(cmd);
//        result = cmd.ExecuteNonQuery().ToString();
//        return result;
//    }
//    catch
//    {
//        return result = "";
//    }

//    finally {
//        connStr.Close();
//    }


//}

//public  string UpdateEmployee(EntityEmployee e)
//{
//    try
//    {

//        SqlCommand cmd = new SqlCommand("Proc_Employee_Details", connStr);
//        cmd.CommandType = CommandType.StoredProcedure;

//        cmd.Parameters.AddWithValue("@NAME", e.NAME);
//        cmd.Parameters.AddWithValue("@DESIGNATION_ID", e.DESIGNATION_ID);
//        cmd.Parameters.AddWithValue("@GENDER", e.GENDER);
//        cmd.Parameters.AddWithValue("@DEPARTMENT_ID", e.DEPARTMENT_ID);
//        cmd.Parameters.AddWithValue("@EXPERIENCE", e.EXPERIENCE);
//        cmd.Parameters.AddWithValue("@SKILLS", e.SKILLS);
//        cmd.Parameters.AddWithValue("@EMAIL_ID", e.EMAIL_ID);
//        cmd.Parameters.AddWithValue("@CONTACT_NUMBER", e.CONTACT_NUMBER);
//        cmd.Parameters.AddWithValue("@SUPERVISOR_ID", e.SUPERVISOR_ID);
//        cmd.Parameters.AddWithValue("@DATE_OF_BIRTH", e.DATE_OF_BIRTH);
//        cmd.Parameters.AddWithValue("@ADDRESS", e.ADDRESS);
//        cmd.Parameters.AddWithValue("@INSERTED_BY", e.INSERTED_BY);
//        cmd.Parameters.AddWithValue("@INSERTED_ON", e.INSERTED_ON);
//        cmd.Parameters.AddWithValue("@UPDATED_BY", e.UPDATED_BY);
//        cmd.Parameters.AddWithValue("@UPDATED_ON", e.UPDATED_ON);
//        cmd.Parameters.AddWithValue("@SQL_CMD_TYPE", "UPDATE");

//        if (connStr.State == ConnectionState.Closed)
//        {
//            connStr.Open();
//        }
//        //SqlDataAdapter sd = new SqlDataAdapter(cmd);
//        result = cmd.ExecuteScalar().ToString();
//        return result;
//    }
//    catch
//    {
//        return result = "";
//    }

//    finally
//    {
//        connStr.Close();
//    }
//}
//public static int DeleteEmp(int id)
//{
//    int res;
//    try
//    {
//        SqlCommand cmd = new SqlCommand("Proc_Employee_Details", connStr);
//        cmd.CommandType = CommandType.StoredProcedure;
//        cmd.Parameters.AddWithValue("@SQL_CMD_TYPE", "DELETE");
//        cmd.Parameters.AddWithValue("@SQL_CMD_TYPE", id);
//        res = cmd.ExecuteNonQuery();
//        return res;
//    }
//    catch {
//        return res=0;
//    }
//} 