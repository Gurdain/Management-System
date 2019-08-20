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
    public class BranchRepository
    {
        ExceptionRepository exceptionrepo = new ExceptionRepository();
        SqlConnection constr = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public int Branch_Create(Branch branch)
        {
            
            try
            {
                List<Branch> branches = Branch_Read();
                for(int i = 0; i < branches.Count; i++)
                {
                    if(branch.BranchName == branches[i].BranchName && branches[i].isDeleted == false)
                    {
                        return -1;
                    }
                }
                SqlCommand cmd = new SqlCommand("Branch_Insert", constr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BranchName", branch.BranchName);
                cmd.Parameters.Add("@BranchId", SqlDbType.Int);
                cmd.Parameters["@BranchId"].Direction = ParameterDirection.Output;
                constr.Open();
                cmd.ExecuteNonQuery();
                branch.BranchId = Convert.ToInt32(cmd.Parameters["@BranchId"].Value);
                constr.Close();
            }
            catch (Exception ex)
            {
                Exceptions exception = new Exceptions
                {
                    ExceptionNumber = ex.HResult.ToString(),
                    ExceptionMessage = ex.Message,
                    ExceptionMethod = "Branch_Create",
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
            return branch.BranchId;
        }

        public List<Branch> Branch_Read()
        {
            List<Branch> branches = new List<Branch>();
            try
            {
                SqlCommand cmd = new SqlCommand("Branch_Read", constr);
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
                    //    branches.Add(new Branch
                    //    {
                    //        BranchId = Convert.ToInt32(dr["BranchId"]),
                    //        BranchName = Convert.ToString(dr["BranchName"]),
                    //        createdOn = Convert.ToDateTime(dr["createdOn"]),
                    //        modifiedOn = Convert.ToDateTime(dr["modifiedOn"]),
                    //        deletedOn = Convert.ToDateTime(dr["deletedOn"]),
                    //        isDeleted = Convert.ToBoolean(dr["isDeleted"])
                    //    }
                    //    );
                    //}
                    //else
                    //{
                        branches.Add(new Branch
                        {
                            BranchId = Convert.ToInt32(dr["BranchId"]),
                            BranchName = Convert.ToString(dr["BranchName"]),
                            createdOn = Convert.ToDateTime(dr["createdOn"]),
                            modifiedOn = Convert.ToDateTime(dr["modifiedOn"]),
                            isDeleted = Convert.ToBoolean(dr["isDeleted"])
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
                    ExceptionMethod = "Branch_Read",
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
            return branches;
        }

        public Branch Branch_ReadById(int id)
        {
            Branch branch = new Branch();
            try
            {
                SqlCommand cmd = new SqlCommand("Branch_ReadById", constr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BranchId", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                constr.Open();
                da.Fill(dt);
                constr.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    //if(dr["deletedOn"] != null)
                    //{
                    //    branch.BranchId = id;
                    //    branch.BranchName = Convert.ToString(dr["BranchName"]);
                    //    branch.createdOn = Convert.ToDateTime(dr["createdOn"]);
                    //    branch.modifiedOn = Convert.ToDateTime(dr["modifiedOn"]);
                    //    branch.deletedOn = Convert.ToDateTime(dr["deletedOn"]);
                    //    branch.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
                    //}
                    //else
                    //{
                        branch.BranchId = id;
                        branch.BranchName = Convert.ToString(dr["BranchName"]);
                        branch.createdOn = Convert.ToDateTime(dr["createdOn"]);
                        branch.modifiedOn = Convert.ToDateTime(dr["modifiedOn"]);
                        branch.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
                    //}
                }
            }
            catch (Exception ex)
            {
                Exceptions exception = new Exceptions
                {
                    ExceptionNumber = ex.HResult.ToString(),
                    ExceptionMessage = ex.Message,
                    ExceptionMethod = "Branch_ReadById",
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
            return branch;
        }

        public bool Branch_Edit(Branch branch)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("Branch_Update", constr);
                cmd.Parameters.AddWithValue("@BranchId", branch.BranchId);
                cmd.Parameters.AddWithValue("@BranchName", branch.BranchName);
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
                    ExceptionMethod = "Branch_Edit",
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

        public bool Branch_Delete(int id)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("Branch_Delete", constr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BranchId", id);
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
                    ExceptionMethod = "Branch_Delete",
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