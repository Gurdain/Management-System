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
    public class AssignmentRepository
    {
        ExceptionRepository exceptionrepo = new ExceptionRepository();
        SqlConnection constr = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public int Assignment_Create(Assignment assignment)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Assignment_Insert", constr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AssignmentName", assignment.AssignmentName);
                cmd.Parameters.AddWithValue("@Path", assignment.Path);
                cmd.Parameters.AddWithValue("@Type", assignment.Type);
                cmd.Parameters.AddWithValue("@FacultyId", assignment.FacultyId);
                cmd.Parameters.Add("@AssignmentId", SqlDbType.Int);
                cmd.Parameters["@AssignmentId"].Direction = ParameterDirection.Output;
                constr.Open();
                cmd.ExecuteNonQuery();
                assignment.AssignmentId = Convert.ToInt32(cmd.Parameters["@AssignmentId"].Value);
                constr.Close();
            }
            catch (Exception ex)
            {
                Exceptions exception = new Exceptions
                {
                    ExceptionNumber = ex.HResult.ToString(),
                    ExceptionMessage = ex.Message,
                    ExceptionMethod = "Assignment_Create",
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
            return assignment.AssignmentId;
        }

        public List<Assignment> Assignment_Read()
        {
            List<Assignment> assignments = new List<Assignment>();
            try
            {
                SqlCommand cmd = new SqlCommand("Assignment_Read", constr);
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
                        assignments.Add(new Assignment
                        {
                            AssignmentId = Convert.ToInt32(dr["AssignmentId"]),
                            AssignmentName = Convert.ToString(dr["AssignmentName"]),
                            Path = Convert.ToString(dr["Path"]),
                            Type = Convert.ToString(dr["Type"]),
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
                    ExceptionMethod = "Assignment_Read",
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
            return assignments;
        }

        public Assignment Assignment_ReadById(int id)
        {
            Assignment assignment = new Assignment();
            try
            {
                SqlCommand cmd = new SqlCommand("Assignment_ReadById", constr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AssignmentId", id);
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
                        assignment.AssignmentId = id;
                        assignment.AssignmentName = Convert.ToString(dr["AssignmentName"]);
                        assignment.Path = Convert.ToString(dr["Path"]);
                        assignment.Type = Convert.ToString(dr["Type"]);
                        assignment.FacultyId = Convert.ToInt32(dr["FacultyId"]);
                        assignment.createdOn = Convert.ToDateTime(dr["createdOn"]);
                        assignment.modifiedOn = Convert.ToDateTime(dr["modifiedOn"]);
                        assignment.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
                    //}
                }
            }
            catch (Exception ex)
            {
                Exceptions exception = new Exceptions
                {
                    ExceptionNumber = ex.HResult.ToString(),
                    ExceptionMessage = ex.Message,
                    ExceptionMethod = "Assignment_ReadById",
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
            return assignment;
        }

        public bool Assignment_Edit(Assignment assignment)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("Assignment_Update", constr);
                cmd.Parameters.AddWithValue("@AssignmentId", assignment.AssignmentId);
                cmd.Parameters.AddWithValue("@AssignmentName", assignment.AssignmentName);
                cmd.Parameters.AddWithValue("@Path", assignment.Path);
                cmd.Parameters.AddWithValue("@Type", assignment.Type);
                cmd.Parameters.AddWithValue("@FacultyId", assignment.FacultyId);
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
                    ExceptionMethod = "Assignment_Edit",
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

        public bool Assignment_Delete(int id)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("Assignment_Delete", constr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AssignmentId", id);
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
                    ExceptionMethod = "Assignment_Delete",
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