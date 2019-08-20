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
    public class SubjectRepository
    {
        ExceptionRepository exceptionrepo = new ExceptionRepository();
        SqlConnection constr = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public int Subject_Create(Subject subject)
        {
            try
            {
                List<Subject> subjects = new List<Subject>();
                subjects = Subject_Read();
                for (int i = 0; i < subjects.Count; i++)
                {
                    if (subject.SubjectName == subjects[i].SubjectName && subjects[i].isDeleted != false)
                    {
                        return -1;
                    }
                }
                SqlCommand cmd = new SqlCommand("Subject_Insert", constr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SubjectName", subject.SubjectName);
                cmd.Parameters.Add("@SubjectId", SqlDbType.Int);
                cmd.Parameters["@SubjectId"].Direction = ParameterDirection.Output;
                constr.Open();
                cmd.ExecuteNonQuery();
                subject.SubjectId = Convert.ToInt32(cmd.Parameters["@SubjectId"].Value);
                constr.Close();
            }
            catch (Exception ex)
            {
                Exceptions exception = new Exceptions
                {
                    ExceptionNumber = ex.HResult.ToString(),
                    ExceptionMessage = ex.Message,
                    ExceptionMethod = "Subject_Create",
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
            return subject.SubjectId;
        }

        public List<Subject> Subject_Read()
        {
            List<Subject> subjects = new List<Subject>();
            try
            {
                SqlCommand cmd = new SqlCommand("Subject_Read", constr);
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
                    //    subjects.Add(new Subject
                    //    {
                    //        SubjectId = Convert.ToInt32(dr["SubjectId"]),
                    //        SubjectName = Convert.ToString(dr["SubjectName"]),
                    //        createdOn = Convert.ToDateTime(dr["createdOn"]),
                    //        modifiedOn = Convert.ToDateTime(dr["modifiedOn"]),
                    //        deletedOn = Convert.ToDateTime(dr["deletedOn"]),
                    //        isDeleted = Convert.ToBoolean(dr["isDeleted"])
                    //    }
                    //    );
                    //}
                    //else
                    //{
                        subjects.Add(new Subject
                        {
                            SubjectId = Convert.ToInt32(dr["SubjectId"]),
                            SubjectName = Convert.ToString(dr["SubjectName"]),
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
                    ExceptionMethod = "Subject_Read",
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
            return subjects;
        }

        public Subject Subject_ReadById(int id)
        {
            Subject subject = new Subject();
            try
            {
                SqlCommand cmd = new SqlCommand("Subject_ReadById", constr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SubjectId", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                constr.Open();
                da.Fill(dt);
                constr.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    if(dr["deletedOn"] != null)
                    {
                        subject.SubjectId = id;
                        subject.SubjectName = Convert.ToString(dr["SubjectName"]);
                        subject.createdOn = Convert.ToDateTime(dr["createdOn"]);
                        subject.modifiedOn = Convert.ToDateTime(dr["modifiedOn"]);
                        subject.deletedOn = Convert.ToDateTime(dr["deletedOn"]);
                        subject.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
                    }
                    else
                    {
                        subject.SubjectId = id;
                        subject.SubjectName = Convert.ToString(dr["SubjectName"]);
                        subject.createdOn = Convert.ToDateTime(dr["createdOn"]);
                        subject.modifiedOn = Convert.ToDateTime(dr["modifiedOn"]);
                        subject.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Exceptions exception = new Exceptions
                {
                    ExceptionNumber = ex.HResult.ToString(),
                    ExceptionMessage = ex.Message,
                    ExceptionMethod = "Subject_ReadById",
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
            return subject;
        }

        public bool Subject_Edit(Subject subject)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("Subject_Update", constr);
                cmd.Parameters.AddWithValue("@SubjectId", subject.SubjectId);
                cmd.Parameters.AddWithValue("@SubjectName", subject.SubjectName);
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
                    ExceptionMethod = "Subject_Edit",
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

        public bool Subject_Delete(int id)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("Subject_Delete", constr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SubjectId", id);
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
                    ExceptionMethod = "Subject_Delete",
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