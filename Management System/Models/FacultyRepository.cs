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
    public class FacultyRepository
    {
        ExceptionRepository exceptionrepo = new ExceptionRepository();
        SqlConnection constr = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public int Faculty_Create(Faculty faculty)
        {
            try
            {
                Guid guid = Guid.NewGuid();
                SqlCommand cmd = new SqlCommand("Faculty_Insert", constr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FacultyName", faculty.FacultyName);
                cmd.Parameters.AddWithValue("@Email", faculty.Email);
                cmd.Parameters.AddWithValue("@Password", faculty.Password);
                cmd.Parameters.AddWithValue("@Mobile", faculty.Mobile);
                cmd.Parameters.AddWithValue("@FacultyGuid", guid.ToString());
                cmd.Parameters.AddWithValue("@SubjectId", faculty.SubjectId);
                cmd.Parameters.Add("@FacultyId", SqlDbType.Int);
                cmd.Parameters["@FacultyId"].Direction = ParameterDirection.Output;
                constr.Open();
                cmd.ExecuteNonQuery();
                faculty.FacultyId = Convert.ToInt32(cmd.Parameters["@FacultyId"].Value);
                constr.Close();
            }
            catch (Exception ex)
            {
                Exceptions exception = new Exceptions
                {
                    ExceptionNumber = ex.HResult.ToString(),
                    ExceptionMessage = ex.Message,
                    ExceptionMethod = "Faculty_Create",
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
            return faculty.FacultyId;
        }

        public List<Faculty> Faculty_Read()
        {
            List<Faculty> faculties = new List<Faculty>();
            try
            {
                SqlCommand cmd = new SqlCommand("Faculty_Read", constr);
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
                    //    faculties.Add(new Faculty
                    //    {
                    //        FacultyId = Convert.ToInt32(dr["FacultyId"]),
                    //        FacultyName = Convert.ToString(dr["FacultyName"]),
                    //        Email = Convert.ToString(dr["Email"]),
                    //        Password = Convert.ToString(dr["Password"]),
                    //        Mobile = Convert.ToString(dr["Mobile"]),
                    //        Active = Convert.ToBoolean(dr["Active"]),
                    //        createdOn = Convert.ToDateTime(dr["createdOn"]),
                    //        modifiedOn = Convert.ToDateTime(dr["modifiedOn"]),
                    //        deletedOn = Convert.ToDateTime(dr["deletedOn"]),
                    //        isDeleted = Convert.ToBoolean(dr["isDeleted"]),
                    //        FacultyGuid = Convert.ToString(dr["FacultyGuid"]),
                    //        SubjectId = Convert.ToInt32(dr["SubjectId"])
                    //    }
                    //    );
                    //}
                    //else
                    //{
                        faculties.Add(new Faculty
                        {
                            FacultyId = Convert.ToInt32(dr["FacultyId"]),
                            FacultyName = Convert.ToString(dr["FacultyName"]),
                            Email = Convert.ToString(dr["Email"]),
                            Password = Convert.ToString(dr["Password"]),
                            Mobile = Convert.ToString(dr["Mobile"]),
                            Active = Convert.ToBoolean(dr["Active"]),
                            createdOn = Convert.ToDateTime(dr["createdOn"]),
                            modifiedOn = Convert.ToDateTime(dr["modifiedOn"]),
                            isDeleted = Convert.ToBoolean(dr["isDeleted"]),
                            FacultyGuid = Convert.ToString(dr["FacultyGuid"]),
                            SubjectId = Convert.ToInt32(dr["SubjectId"])
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
                    ExceptionMethod = "Faculty_Read",
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
            return faculties;
        }

        public Faculty Faculty_ReadById(int id)
        {
            Faculty faculty = new Faculty();
            try
            {
                SqlCommand cmd = new SqlCommand("Faculty_ReadById", constr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FacultyId", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                constr.Open();
                da.Fill(dt);
                constr.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    faculty.FacultyId = id;
                    faculty.FacultyName = Convert.ToString(dr["FacultyName"]);
                    faculty.Email = Convert.ToString(dr["Email"]);
                    faculty.Password = Convert.ToString(dr["Password"]);
                    faculty.Mobile = Convert.ToString(dr["Mobile"]);
                    faculty.Active = Convert.ToBoolean(dr["Active"]);
                    faculty.createdOn = Convert.ToDateTime(dr["createdOn"]);
                    faculty.modifiedOn = Convert.ToDateTime(dr["modifiedOn"]);
                    faculty.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
                    faculty.FacultyGuid = Convert.ToString(dr["FacultyGuid"]);
                    faculty.SubjectId = Convert.ToInt32(dr["SubjectId"]);
                }
            }
            catch (Exception ex)
            {
                Exceptions exception = new Exceptions
                {
                    ExceptionNumber = ex.HResult.ToString(),
                    ExceptionMessage = ex.Message,
                    ExceptionMethod = "Faculty_ReadById",
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
            return faculty;
        }

        public bool Faculty_Edit(Faculty faculty)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("Faculty_Update", constr);
                cmd.Parameters.AddWithValue("@FacultyId", faculty.FacultyId);
                cmd.Parameters.AddWithValue("@FacultyName", faculty.FacultyName);
                cmd.Parameters.AddWithValue("@Email", faculty.Email);
                cmd.Parameters.AddWithValue("@Password", faculty.Password);
                cmd.Parameters.AddWithValue("@Mobile", faculty.Mobile);
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
                    ExceptionMethod = "Faculty_Edit",
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

        public bool Faculty_Delete(int id)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("Faculty_Delete", constr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FacultyId", id);
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
                    ExceptionMethod = "Faculty_Delete",
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

        public bool Faculty_ActivateAccount(string id)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("Faculty_Activate", constr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FacultyGuid", id);
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
                    ExceptionMethod = "Faculty_ActivateAccount",
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

        public Faculty Faculty_Login(string email, string password)
        {
            Faculty faculty = new Faculty();
            try
            {
                SqlCommand cmd = new SqlCommand("Faculty_Login", constr);
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
                    faculty.FacultyId = Convert.ToInt32(dr["FacultyId"]); ;
                    faculty.FacultyName = Convert.ToString(dr["FacultyName"]);
                    faculty.Email = Convert.ToString(dr["Email"]);
                    faculty.Password = Convert.ToString(dr["Password"]);
                    faculty.Mobile = Convert.ToString(dr["Mobile"]);
                    faculty.Active = Convert.ToBoolean(dr["Active"]);
                    faculty.createdOn = Convert.ToDateTime(dr["createdOn"]);
                    faculty.modifiedOn = Convert.ToDateTime(dr["modifiedOn"]);
                    faculty.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
                    faculty.FacultyGuid = Convert.ToString(dr["FacultyGuid"]);
                    faculty.SubjectId = Convert.ToInt32(dr["SubjectId"]);
                }
            }
            catch (Exception ex)
            {
                Exceptions exception = new Exceptions
                {
                    ExceptionNumber = ex.HResult.ToString(),
                    ExceptionMessage = ex.Message,
                    ExceptionMethod = "Faculty_Login",
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
            return faculty;
        }
    }
}