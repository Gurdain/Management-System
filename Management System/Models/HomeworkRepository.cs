using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Utility;

namespace Management_System.Models
{
    public class HomeworkRepository
    {
        ExceptionRepository exceptionrepo = new ExceptionRepository();
        SqlConnection constr = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public int Homework_Create(Homework homework)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Homework_Insert", constr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HomeworkName", homework.HomeworkName);
                cmd.Parameters.AddWithValue("@Path", homework.Path);
                cmd.Parameters.AddWithValue("@Type", homework.Type);
                cmd.Parameters.AddWithValue("@StudentId", homework.StudentId);
                cmd.Parameters.AddWithValue("@FacultyId", homework.FacultyId);
                cmd.Parameters.Add("@HomeworkId", SqlDbType.Int);
                cmd.Parameters["@HomeworkId"].Direction = ParameterDirection.Output;
                constr.Open();
                cmd.ExecuteNonQuery();
                homework.HomeworkId = Convert.ToInt32(cmd.Parameters["@HomeworkId"].Value);
                constr.Close();
            }
            catch (Exception ex)
            {
                Exceptions exception = new Exceptions
                {
                    ExceptionNumber = ex.HResult.ToString(),
                    ExceptionMessage = ex.Message,
                    ExceptionMethod = "Homework_Insert",
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
            return homework.HomeworkId;
        }

        public List<Homework> Homework_Read()
        {
            List<Homework> homeworks = new List<Homework>();
            try
            {
                SqlCommand cmd = new SqlCommand("Homework_Read", constr);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                constr.Open();
                da.Fill(dt);
                constr.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    //if (dr["deletedOn"] != null)
                    //{
                    //    assignments.Add(new Assignment
                    //    {
                    //        AssignmentId = Convert.ToInt32(dr["AssignmentId"]),
                    //        AssignmentName = Convert.ToString(dr["AssignmentName"]),
                    //        Path = Convert.ToString(dr["Path"]),
                    //        Type = Convert.ToString(dr["Type"]),
                    //        FacultyId = Convert.ToInt32(dr["FacultyId"]),
                    //        createdOn = Convert.ToDateTime(dr["createdOn"]),
                    //        modifiedOn = Convert.ToDateTime(dr["modifiedOn"]),
                    //        deletedOn = Convert.ToDateTime(dr["deletedOn"]),
                    //        isDeleted = Convert.ToBoolean(dr["isDeleted"])
                    //    }
                    //    );
                    //}
                    //else
                    //{
                    homeworks.Add(new Homework
                    {
                        HomeworkId = Convert.ToInt32(dr["HomeworkId"]),
                        HomeworkName = Convert.ToString(dr["HomeworkName"]),
                        Path = Convert.ToString(dr["Path"]),
                        Type = Convert.ToString(dr["Type"]),
                        StudentId = Convert.ToInt32(dr["StudentId"]),
                        FacultyId = Convert.ToInt32(dr["FacultyId"]),
                        createdOn = Convert.ToDateTime(dr["createdOn"]),
                        modifiedOn = Convert.ToDateTime(dr["modifiedOn"]),
                        isDeleted = Convert.ToBoolean(dr["isDeleted"]),
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
                    ExceptionMethod = "Homework_Read",
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
            return homeworks;
        }

        public Homework Homework_ReadById(int id)
        {
            Homework homework = new Homework();
            try
            {
                SqlCommand cmd = new SqlCommand("Homework_ReadById", constr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HomeworkId", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                constr.Open();
                da.Fill(dt);
                constr.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    //if(dr["deletedOn"] != null)
                    //{
                    //    assignment.AssignmentId = id;
                    //    assignment.AssignmentName = Convert.ToString(dr["AssignmentName"]);
                    //    assignment.Path = Convert.ToString(dr["Path"]);
                    //    assignment.Type = Convert.ToString(dr["Type"]);
                    //    assignment.FacultyId = Convert.ToInt32(dr["FacultyId"]);
                    //    assignment.createdOn = Convert.ToDateTime(dr["createdOn"]);
                    //    assignment.modifiedOn = Convert.ToDateTime(dr["modifiedOn"]);
                    //    assignment.deletedOn = Convert.ToDateTime(dr["deletedOn"]);
                    //    assignment.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
                    //}
                    //else
                    //{
                    homework.HomeworkId = id;
                    homework.HomeworkName = Convert.ToString(dr["HomeworkName"]);
                    homework.Path = Convert.ToString(dr["Path"]);
                    homework.Type = Convert.ToString(dr["Type"]);
                    homework.StudentId = Convert.ToInt32(dr["StudentId"]);
                    homework.FacultyId = Convert.ToInt32(dr["FacultyId"]);
                    homework.createdOn = Convert.ToDateTime(dr["createdOn"]);
                    homework.modifiedOn = Convert.ToDateTime(dr["modifiedOn"]);
                    homework.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
                    //}
                }
            }
            catch (Exception ex)
            {
                Exceptions exception = new Exceptions
                {
                    ExceptionNumber = ex.HResult.ToString(),
                    ExceptionMessage = ex.Message,
                    ExceptionMethod = "Homework_ReadById",
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
            return homework;
        }

        public bool Homework_Edit(Homework homework)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("Homework_Update", constr);
                cmd.Parameters.AddWithValue("@HomeworkId", homework.HomeworkId);
                cmd.Parameters.AddWithValue("@HomeworkName", homework.HomeworkName);
                cmd.Parameters.AddWithValue("@Path", homework.Path);
                cmd.Parameters.AddWithValue("@Type", homework.Type);
                cmd.Parameters.AddWithValue("@StudentId", homework.StudentId);
                cmd.Parameters.AddWithValue("@FacultyId", homework.FacultyId);
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
                    ExceptionMethod = "Homework_Update",
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

        public bool Homework_Delete(int id)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("Homework_Delete", constr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HomeworkId", id);
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
                    ExceptionMethod = "Homework_Delete",
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
    }
}