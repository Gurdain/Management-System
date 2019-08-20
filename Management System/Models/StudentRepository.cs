using Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Management_System.Models
{
    public class StudentRepository
    {
        ExceptionRepository exceptionrepo = new ExceptionRepository();
        SqlConnection constr = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public int Student_Create(Student student)
        {
            try
            {
                Guid guid = Guid.NewGuid();
                SqlCommand cmd = new SqlCommand("Student_Insert", constr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@Password", student.Password);
                cmd.Parameters.AddWithValue("@Mobile", student.Mobile);
                cmd.Parameters.AddWithValue("@StudentGuid", guid.ToString());
                cmd.Parameters.AddWithValue("@BranchId", student.BranchId);
                cmd.Parameters.Add("@StudentId", SqlDbType.Int);
                cmd.Parameters["@StudentId"].Direction = ParameterDirection.Output;
                constr.Open();
                cmd.ExecuteNonQuery();
                student.StudentId = Convert.ToInt32(cmd.Parameters["@StudentId"].Value);
                constr.Close();
            }
            catch (Exception ex)
            {
                Exceptions exception = new Exceptions
                {
                    ExceptionNumber = ex.HResult.ToString(),
                    ExceptionMessage = ex.Message,
                    ExceptionMethod = "Student_Create",
                    ExceptionUrl = ""
                };
                int r = exceptionrepo.Exception_Create(exception);
                if (r == 0)
                {
                    exceptionrepo.Exception_InsertInLogFile(exception);
                }
                if (constr.State != ConnectionState.Open)
                {
                    constr.Close();
                    constr.Open();
                }
            }
            return student.StudentId;
        }

        public List<Student> Student_Read()
        {
            List<Student> students = new List<Student>();
            try
            {
                SqlCommand cmd = new SqlCommand("Student_Read", constr);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                constr.Open();
                da.Fill(dt);
                constr.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    //if(dr["deletedOn"] != null)
                    //{
                    //    students.Add(new Student
                    //    {
                    //        StudentId = Convert.ToInt32(dr["StudentId"]),
                    //        StudentName = Convert.ToString(dr["StudentName"]),
                    //        Email = Convert.ToString(dr["Email"]),
                    //        Password = Convert.ToString(dr["Password"]),
                    //        Mobile = Convert.ToString(dr["Mobile"]),
                    //        Active = Convert.ToBoolean(dr["Active"]),
                    //        createdOn = Convert.ToDateTime(dr["createdOn"]),
                    //        modifiedOn = Convert.ToDateTime(dr["modifiedOn"]),
                    //        deletedOn = Convert.ToDateTime(dr["deletedOn"]),
                    //        isDeleted = Convert.ToBoolean(dr["isDeleted"]),
                    //        StudentGuid = Convert.ToString(dr["StudentGuid"]),
                    //        BranchId = Convert.ToInt32(dr["BranchId"])
                    //    }
                    //    );
                    //}
                    //else
                    //{
                        students.Add(new Student
                        {
                            StudentId = Convert.ToInt32(dr["StudentId"]),
                            StudentName = Convert.ToString(dr["StudentName"]),
                            Email = Convert.ToString(dr["Email"]),
                            Password = Convert.ToString(dr["Password"]),
                            Mobile = Convert.ToString(dr["Mobile"]),
                            Active = Convert.ToBoolean(dr["Active"]),
                            createdOn = Convert.ToDateTime(dr["createdOn"]),
                            modifiedOn = Convert.ToDateTime(dr["modifiedOn"]),
                            isDeleted = Convert.ToBoolean(dr["isDeleted"]),
                            StudentGuid = Convert.ToString(dr["StudentGuid"]),
                            BranchId = Convert.ToInt32(dr["BranchId"])
                        }
                        );
                    //}
                }
            }
            catch (Exception ex)
            {
                Exceptions exception = new Exceptions
                {
                    ExceptionNumber = ex.HResult.ToString(),
                    ExceptionMessage = ex.Message,
                    ExceptionMethod = "Student_Read",
                    ExceptionUrl = ""
                };
                int r = exceptionrepo.Exception_Create(exception);
                if (r == 0)
                {
                    exceptionrepo.Exception_InsertInLogFile(exception);
                }
                if (constr.State != ConnectionState.Open)
                {
                    constr.Close();
                    constr.Open();
                }
            }
            return students;
        }

        public Student Student_ReadById(int id)
        {
            Student student = new Student();
            try
            {
                SqlCommand cmd = new SqlCommand("Student_ReadById", constr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentId", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                constr.Open();
                da.Fill(dt);
                constr.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    //if(dr["deletedOn"] != null)
                    //{
                    //    student.StudentId = id;
                    //    student.StudentName = Convert.ToString(dr["StudentName"]);
                    //    student.Email = Convert.ToString(dr["Email"]);
                    //    student.Password = Convert.ToString(dr["Password"]);
                    //    student.Mobile = Convert.ToString(dr["Mobile"]);
                    //    student.Active = Convert.ToBoolean(dr["Active"]);
                    //    student.createdOn = Convert.ToDateTime(dr["createdOn"]);
                    //    student.modifiedOn = Convert.ToDateTime(dr["modifiedOn"]);
                    //    student.deletedOn = Convert.ToDateTime(dr["deletedOn"]);
                    //    student.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
                    //    student.StudentGuid = Convert.ToString(dr["StudentGuid"]);
                    //    student.BranchId = Convert.ToInt32(dr["BranchId"]);
                    //}
                    //else
                    //{
                        student.StudentId = id;
                        student.StudentName = Convert.ToString(dr["StudentName"]);
                        student.Email = Convert.ToString(dr["Email"]);
                        student.Password = Convert.ToString(dr["Password"]);
                        student.Mobile = Convert.ToString(dr["Mobile"]);
                        student.Active = Convert.ToBoolean(dr["Active"]);
                        student.createdOn = Convert.ToDateTime(dr["createdOn"]);
                        student.modifiedOn = Convert.ToDateTime(dr["modifiedOn"]);
                        student.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
                        student.StudentGuid = Convert.ToString(dr["StudentGuid"]);
                        student.BranchId = Convert.ToInt32(dr["BranchId"]);
                    //}
                }
            }
            catch (Exception ex)
            {
                Exceptions exception = new Exceptions
                {
                    ExceptionNumber = ex.HResult.ToString(),
                    ExceptionMessage = ex.Message,
                    ExceptionMethod = "Student_ReadById",
                    ExceptionUrl = ""
                };
                int r = exceptionrepo.Exception_Create(exception);
                if (r == 0)
                {
                    exceptionrepo.Exception_InsertInLogFile(exception);
                }
                if (constr.State != ConnectionState.Open)
                {
                    constr.Close();
                    constr.Open();
                }
            }
            return student;
        }

        public bool Student_Edit(Student student)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("Student_Update", constr);
                cmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@Password", student.Password);
                cmd.Parameters.AddWithValue("@Mobile", student.Mobile);
                cmd.CommandType = CommandType.StoredProcedure;
                constr.Open();
                result = cmd.ExecuteNonQuery();
                constr.Close();
            }
            catch (Exception ex)
            {
                Exceptions exception = new Exceptions
                {
                    ExceptionNumber = ex.HResult.ToString(),
                    ExceptionMessage = ex.Message,
                    ExceptionMethod = "Student_Edit",
                    ExceptionUrl = ""
                };
                int r = exceptionrepo.Exception_Create(exception);
                if (r == 0)
                {
                    exceptionrepo.Exception_InsertInLogFile(exception);
                }
                if (constr.State != ConnectionState.Open)
                {
                    constr.Close();
                    constr.Open();
                }
            }
            if (result >= 1)
            {
                return true;
            }
            return false;
        }

        public bool Student_Delete(int id)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("Student_Delete", constr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentId", id);
                constr.Open();
                result = cmd.ExecuteNonQuery();
                constr.Close();
            }
            catch (Exception ex)
            {
                Exceptions exception = new Exceptions
                {
                    ExceptionNumber = ex.HResult.ToString(),
                    ExceptionMessage = ex.Message,
                    ExceptionMethod = "Student_Delete",
                    ExceptionUrl = ""
                };
                int r = exceptionrepo.Exception_Create(exception);
                if (r == 0)
                {
                    exceptionrepo.Exception_InsertInLogFile(exception);
                }
                if (constr.State != ConnectionState.Open)
                {
                    constr.Close();
                    constr.Open();
                }
            }
            if (result >= 1)
            {
                return true;
            }
            return false;
        }

        public bool Student_ActivateAccount(string id)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("Student_Activate", constr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentGuid", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                constr.Open();
                result = cmd.ExecuteNonQuery();
                da.Fill(dt);
                constr.Close();
            }
            catch (Exception ex)
            {
                Exceptions exception = new Exceptions
                {
                    ExceptionNumber = ex.HResult.ToString(),
                    ExceptionMessage = ex.Message,
                    ExceptionMethod = "Student_ActivateAccount",
                    ExceptionUrl = ""
                };
                int r = exceptionrepo.Exception_Create(exception);
                if (r == 0)
                {
                    exceptionrepo.Exception_InsertInLogFile(exception);
                }
                if (constr.State != ConnectionState.Open)
                {
                    constr.Close();
                    constr.Open();
                }
            }
            if (result >= 1)
            {
                return true;
            }
            return false;
        }

        public Student Student_Login(string email, string password)
        {
            Student student = new Student();
            try
            {
                SqlCommand cmd = new SqlCommand("Student_Login", constr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                constr.Open();
                da.Fill(dt);
                constr.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    student.StudentId = Convert.ToInt32(dr["StudentId"]); ;
                    student.StudentName = Convert.ToString(dr["StudentName"]);
                    student.Email = Convert.ToString(dr["Email"]);
                    student.Password = Convert.ToString(dr["Password"]);
                    student.Mobile = Convert.ToString(dr["Mobile"]);
                    student.Active = Convert.ToBoolean(dr["Active"]);
                    student.createdOn = Convert.ToDateTime(dr["createdOn"]);
                    student.modifiedOn = Convert.ToDateTime(dr["modifiedOn"]);
                    student.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
                    student.StudentGuid = Convert.ToString(dr["StudentGuid"]);
                    student.BranchId = Convert.ToInt32(dr["BranchId"]);
                }
            }
            catch(Exception ex)
            {
                Exceptions exception = new Exceptions
                {
                    ExceptionNumber = ex.HResult.ToString(),
                    ExceptionMessage = ex.Message,
                    ExceptionMethod = "Student_Login",
                    ExceptionUrl = ""
                };
                int r = exceptionrepo.Exception_Create(exception);
                if (r == 0)
                {
                    exceptionrepo.Exception_InsertInLogFile(exception);
                }
                if (constr.State != ConnectionState.Open)
                {
                    constr.Close();
                    constr.Open();
                }
            }
            return student;
        }
    }
}