using Management_System.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Utility;

namespace Management_System.Controllers
{
    public class HomeController : Controller
    {
        public StudentRepository studentrepo = new StudentRepository();
        public FacultyRepository facultyrepo = new FacultyRepository();
        public BranchRepository branchrepo = new BranchRepository();
        public SubjectRepository subjectrepo = new SubjectRepository();
        public AssignmentRepository assignmentrepo = new AssignmentRepository();
        public HomeworkRepository homeworkrepo = new HomeworkRepository();
        public ExceptionRepository exceptionrepo = new ExceptionRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        // Method to Read the total number of Students from the database.
        public ActionResult Student_Read()
        {
            List<Student> data = studentrepo.Student_Read();
            return View("Student_Read", data);
        }
        // Method to Read a specific Student from the database.
        public ActionResult Student_ReadById(int id)
        {
            Student data = studentrepo.Student_ReadById(id);
            return View("Student_ReadById", data);
        }
        // Method to Insert a Student in the database.
        public ActionResult Student_Create()
        {
            List<Branch> data = branchrepo.Branch_Read();
            ViewBag.data = data;
            return View();
        }
        // Method to Edit a specific Student in the database.
        public ActionResult Student_Edit(int id)
        {
            Student student = studentrepo.Student_ReadById(id);
            return View("Student_Edit", student);
        }
        // Method to Delete a Student from the database.
        public ActionResult Student_Delete(int id)
        {
            bool deleted = studentrepo.Student_Delete(id);
            return View("Student_Delete", studentrepo.Student_ReadById(id));
        }
        // Method to Activate a Student's Account in the database.
        public ActionResult Student_ActivateAccount(string id)
        {
            bool success = studentrepo.Student_ActivateAccount(id);
            if (success)
            {
                return View("Student_ActivateAccount");
            }
            return View();
        }
        // Method to Login a Student.
        public ActionResult Student_Login()
        {
            return View("Student_Login");
        }
        // Method to Logout a Student.
        public ActionResult Student_Logout()
        {
            Session.Clear();
            return View("Student_Login");
        }
        // Method to Read the total number of Faculties from the database.
        public ActionResult Faculty_Read()
        {
            List<Faculty> data = facultyrepo.Faculty_Read();
            return View("Faculty_Read", data);
        }
        // Method to Read a specific Faculty from the database.
        public ActionResult Faculty_ReadById(int id)
        {
            Faculty data = facultyrepo.Faculty_ReadById(id);
            return View("Faculty_ReadById", data);
        }
        // Method to Insert a Faculty in the database.
        public ActionResult Faculty_Create()
        {
            List<Subject> data = subjectrepo.Subject_Read();
            ViewBag.data = data;
            return View();
        }
        // Method to Edit a specific Faculty in the database.
        public ActionResult Faculty_Edit(int id)
        {
            Faculty faculty = facultyrepo.Faculty_ReadById(id);
            return View("Faculty_Edit", faculty);
        }
        // Method to Delete a specific Faculty in the database.
        public ActionResult Faculty_Delete(int id)
        {
            bool deleted = facultyrepo.Faculty_Delete(id);
            return View("Faculty_Delete", facultyrepo.Faculty_ReadById(id));
        }
        // Method to Activate a Faculty Account from the database.
        public ActionResult Faculty_ActivateAccount(string id)
        {
            bool success = facultyrepo.Faculty_ActivateAccount(id);
            if (success)
            {
                return View("Faculty_ActivateAccount");
            }
            return View();
        }
        // Method to Login a Faculty.
        public ActionResult Faculty_Login()
        {
            return View("Faculty_Login");
        }
        // Method to Logout Faculty.
        public ActionResult Faculty_Logout()
        {
            Session.Clear();
            return View("Faculty_Login");
        }
        // Method to Redirect to Faculty Dashboard.
        public ActionResult Faculty_Dashboard()
        {
            Faculty data = facultyrepo.Faculty_ReadById(Convert.ToInt32(Session["facultyId"]));
            return View("Faculty_Dashboard", data);
        }
        // Method to Read all the Branches from the database.
        public ActionResult Branch_Read()
        {
            List<Branch> data = branchrepo.Branch_Read();
            return View("Branch_Read", data);
        }
        // Method to Read a specific Branch from the database.
        public ActionResult Branch_ReadById(int id)
        {
            Branch data = branchrepo.Branch_ReadById(id);
            return View("Branch_ReadById", data);
        }
        // Method to Insert a Branch in the database.
        public ActionResult Branch_Create()
        {
            return View();
        }
        // Method to Update a Branch in the database.
        public ActionResult Branch_Edit(int id)
        {
            Branch branch = branchrepo.Branch_ReadById(id);
            return View("Branch_Edit", branch);
        }
        // Method to Delete a Branch from the database.
        public ActionResult Branch_Delete(int id)
        {
            bool deleted = branchrepo.Branch_Delete(id);
            return View("Branch_Delete", branchrepo.Branch_ReadById(id));
        }
        // Method to Read all the Subjects from the database.
        public ActionResult Subject_Read()
        {
            List<Subject> data = subjectrepo.Subject_Read();
            return View("Subject_Read", data);
        }
        // Method to Read a specific Subject from the database.
        public ActionResult Subject_ReadById(int id)
        {
            Subject data = subjectrepo.Subject_ReadById(id);
            return View("Subject_ReadById", data);
        }
        // Method to Insert a Subject in the database.
        public ActionResult Subject_Create()
        {
            return View();
        }
        // Method to Update a Subject in the database.
        public ActionResult Subject_Edit(int id)
        {
            Subject subject = subjectrepo.Subject_ReadById(id);
            return View("Subject_Edit", subject);
        }
        // Method to Delete a Subject from the database.
        public ActionResult Subject_Delete(int id)
        {
            bool deleted = subjectrepo.Subject_Delete(id);
            return View("Subject_Delete", subjectrepo.Subject_ReadById(id));
        }
        // Method to Read all the Assignment from the database.
        public ActionResult Assignment_Read()
        {
            List<Assignment> data = assignmentrepo.Assignment_Read();
            return View("Assignment_Read", data);
        }
        // Method to Redirect to Student Dashboard.
        public ActionResult Assignment_Read_Student()
        {
            List<Assignment> data = assignmentrepo.Assignment_Read();
            return View("Assignment_Read_Student", data);
        }
        // Method to Read a specific Assignment from the database.
        public ActionResult Assignment_ReadById(int id)
        {
            Assignment data = assignmentrepo.Assignment_ReadById(id);
            return View("Assignment_ReadById", data);
        }
        // Method to Update a Assignment in the database.
        public ActionResult Assignment_Edit(int id)
        {
            Assignment data = assignmentrepo.Assignment_ReadById(id);
            return View("Assignment_Edit", data);
        }
        // Method to Delete a Assignment from the database.
        public ActionResult Assignment_Delete(int id)
        {
            bool deleted = assignmentrepo.Assignment_Delete(id);
            return View("Assignment_Delete", assignmentrepo.Assignment_ReadById(id));
        }
        // Method to Read all the Homework from the database.
        public ActionResult Homework_Read()
        {
            List<Homework> data = homeworkrepo.Homework_Read();
            return View("Homework_Read", data);
        }
        // Method to Redirect to Uploaded Homework by a Student.
        public ActionResult Homework_Read_Student()
        {
            List<Homework> data = homeworkrepo.Homework_Read();
            return View("Homework_Read_Student", data);
        }
        // Method to Read a specific Homework from the database.
        public ActionResult Homework_ReadById(int id)
        {
            Homework data = homeworkrepo.Homework_ReadById(id);
            return View("Homework_ReadById", data);
        }
        // Method to Update a Homework in the database.
        public ActionResult Homework_Edit(int id)
        {
            Homework data = homeworkrepo.Homework_ReadById(id);
            return View("Homework_Edit", data);
        }
        // Method to Delete a Homework from the database.
        public ActionResult Homework_Delete(int id)
        {
            bool deleted = homeworkrepo.Homework_Delete(id);
            return View("Homework_Delete", homeworkrepo.Homework_ReadById(id));
        }
        // Method to Upload a Homework in the database.
        public ActionResult Homework_Upload()
        {
            List<Assignment> assignments = assignmentrepo.Assignment_Read();
            for(int i = 0; i < assignments.Count; i++)
            {
                if (assignments[i].isDeleted)
                {
                    assignments.Remove(assignments[i--]);
                }
            }
            ViewBag.Data = assignments;
            return View("Homework_Upload");
        }
        // Method to Insert a Subject in the database.
        [HttpPost]
        public ActionResult Student_Create(Student student)
        {
            int success = studentrepo.Student_Create(student);
            if (success >= 0)
            {
                Student_ActivateAccount(student);
            }
            List<Student> data = studentrepo.Student_Read();
            return View("Student_Read", data);
        }
        // Method to Update a Assignment in the database.
        [HttpPost]
        public ActionResult Student_Edit(Student student)
        {
            bool edited = studentrepo.Student_Edit(student);
            List<Student> data = studentrepo.Student_Read();
            return View("Student_Read", data);
        }
        // Method to Delete a Assignment from the database.
        [HttpPost]
        public ActionResult Student_Delete()
        {
            List<Student> data = studentrepo.Student_Read();
            return View("Student_Read", data);
        }
        // Method to Activate a Student Account from the database.
        [HttpPost]
        public ActionResult Student_ActivateAccount(Student student)
        {
            try
            {
                Student data = studentrepo.Student_ReadById(student.StudentId);
                Emails email = new Emails();
                email.Send_Mail(data.Email, "gurdain.singh@clanstech.com", "Registration Confirmation", string.Format("Dear User,<BR>please click the following link to activate your account .<BR> <a href=http://"
                                + Request.Url.Host + ":"
                                + Request.Url.Port + Url.Action("Student_ActivateAccount", "Home", new { id = data.StudentGuid })
                                + ">" + "Click Here to Activate Account" + "</a>"));
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
                exceptionrepo.Exception_Create(exception);
            }
            return View("Student_ActivateAccount");
        }
        // Method to Login a Student.
        [HttpPost]
        public ActionResult Student_Login(string email, string password)
        {
            try
            {
                Student student = studentrepo.Student_Login(email, password);
                if (student.Active)
                {
                    Session["studentId"] = student.StudentId;
                    Session["studentName"] = student.StudentName;
                    List<Assignment> data = assignmentrepo.Assignment_Read();
                    return View("Assignment_Read_Student", data);
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
                exceptionrepo.Exception_Create(exception);
            }
            ViewBag.Message = "Incorrect E-mail or Password";
            return View();
        }
        // Method to Insert a Student in the database.
        [HttpPost]
        public ActionResult Faculty_Create(Faculty faculty)
        {
            int success = facultyrepo.Faculty_Create(faculty);
            if (success >= 0)
            {
                Faculty_ActivateAccount(faculty);
            }
            List<Faculty> data = facultyrepo.Faculty_Read();
            return View("Faculty_Read", data);
        }
        // Method to Update a Faculty in the database.
        [HttpPost]
        public ActionResult Faculty_Edit(Faculty faculty)
        {
            bool edited = facultyrepo.Faculty_Edit(faculty);
            List<Faculty> data = facultyrepo.Faculty_Read();
            return View("Faculty_Read", data);
        }
        // Method to Delete a Faculty from the database.
        [HttpPost]
        public ActionResult Faculty_Delete()
        {
            List<Faculty> data = facultyrepo.Faculty_Read();
            return View("Faculty_Read", data);
        }
        // Method to Activate a Faculty Account from the database.
        [HttpPost]
        public ActionResult Faculty_ActivateAccount(Faculty faculty)
        {
            try
            {
                Faculty data = facultyrepo.Faculty_ReadById(faculty.FacultyId);
                Emails email = new Emails();
                email.Send_Mail(data.Email, "gurdain.singh@clanstech.com", "Registration Confirmation", string.Format("Dear User,<BR>please click the following link to activate your account .<BR> <a href=http://"
                                + Request.Url.Host + ":"
                                + Request.Url.Port + Url.Action("Faculty_ActivateAccount", "Home", new { id = data.FacultyGuid })
                                + ">" + "Click Here to Activate Account" + "</a>"));
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
                exceptionrepo.Exception_Create(exception);
            }
            return View("Faculty_ActivateAccount");
        }
        // Method to Login a Faculty.
        [HttpPost]
        public ActionResult Faculty_Login(string email, string password)
        {
            try
            {
                Faculty faculty = facultyrepo.Faculty_Login(email, password);
                if (faculty.Active)
                {
                    Session["facultyId"] = faculty.FacultyId;
                    Session["facultyName"] = faculty.FacultyName;
                    return View("Faculty_Dashboard");
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
                exceptionrepo.Exception_Create(exception);
            }
            ViewBag.Message = "Incorrect E-mail or Password";
            return View();
        }
        // Method to Insert a Branch in the database.
        [HttpPost]
        public ActionResult Branch_Create(Branch branch)
        {
            int success = branchrepo.Branch_Create(branch);
            List<Branch> data = branchrepo.Branch_Read();
            return View("Branch_Read", data);
        }
        // Method to Update a Branch in the database.
        [HttpPost]
        public ActionResult Branch_Edit(Branch branch)
        {
            bool edited = branchrepo.Branch_Edit(branch);
            List<Branch> data = branchrepo.Branch_Read();
            return View("Branch_Read", data);
        }
        // Method to Delete a Branch from the database.
        [HttpPost]
        public ActionResult Branch_Delete()
        {
            List<Branch> data = branchrepo.Branch_Read();
            return View("Branch_Read", data);
        }
        // Method to Insert a Subject in the database.
        [HttpPost]
        public ActionResult Subject_Create(Subject subject)
        {
            int success = subjectrepo.Subject_Create(subject);
            List<Subject> data = subjectrepo.Subject_Read();
            return View("Subject_Read", data);
        }
        // Method to Update a Subject in the database.
        [HttpPost]
        public ActionResult Subject_Edit(Subject subject)
        {
            bool edited = subjectrepo.Subject_Edit(subject);
            List<Subject> data = subjectrepo.Subject_Read();
            return View("Subject_Read", data);
        }
        // Method to Delete a Subject from the database.
        [HttpPost]
        public ActionResult Subject_Delete()
        {
            List<Subject> data = subjectrepo.Subject_Read();
            return View("Subject_Read", data);
        }
        // Method to Upload a Assignment.
        [HttpPost]
        public ActionResult Assignment_Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                Assignment assignment = new Assignment();
                assignment.AssignmentName = Path.GetFileName(file.FileName);
                assignment.Type = Path.GetExtension(file.FileName);
                assignment.Path = Path.Combine(Server.MapPath("~/Assignments/"), assignment.AssignmentName);
                assignment.FacultyId = Convert.ToInt32(Session["facultyId"]);
                file.SaveAs(assignment.Path);
                assignmentrepo.Assignment_Create(assignment);
            }
            List<Assignment> data = assignmentrepo.Assignment_Read();
            return RedirectToAction("Assignment_Read", data);
        }
        // Method to Update a Assignment in the database.
        [HttpPost]
        public ActionResult Assignment_Edit(Assignment assignment)
        {
            bool edited = assignmentrepo.Assignment_Edit(assignment);
            List<Assignment> data = assignmentrepo.Assignment_Read();
            return View("Assignment_Read", data);
        }
        // Method to Delete a Assignment from the database.
        [HttpPost]
        public ActionResult Assignment_Delete()
        {
            List<Assignment> data = assignmentrepo.Assignment_Read();
            return View("Assignment_Read", data);
        }
        // Method to Upload a Homework.
        [HttpPost]
        public ActionResult Homework_Upload(int assignmentId, HttpPostedFileBase file)
        {
            List<Assignment> data = assignmentrepo.Assignment_Read();
            if (file != null && file.ContentLength > 0)
            {
                Assignment assignment = assignmentrepo.Assignment_ReadById(assignmentId);
                Homework homework = new Homework();
                DateTime t1 = assignment.createdOn.ToLocalTime();
                TimeSpan t2 = DateTime.Now.Subtract(t1);

                if (t2.TotalHours < 24)
                {
                    if(DateTime.Now.TimeOfDay > TimeSpan.Parse("9:00:00.000") && DateTime.Now.TimeOfDay < TimeSpan.Parse("18:00:00.000"))
                    {
                        homework.HomeworkName = Path.GetFileName(file.FileName);
                        homework.Type = Path.GetExtension(file.FileName);
                        homework.Path = Path.Combine(Server.MapPath("~/Homework/"), homework.HomeworkName);
                        homework.StudentId = Convert.ToInt32(Session["studentId"]);
                        homework.FacultyId = assignment.FacultyId;
                        file.SaveAs(homework.Path);
                        homeworkrepo.Homework_Create(homework);
                        Faculty_Notification(homework.FacultyId, homework.StudentId, true);
                        ViewBag.Message = "Uploaded Successfully";
                        return View("Assignment_Read_Student", data);
                    }
                    else
                    {
                        ViewBag.Message = "Please upload between 9 a.m. and 6 p.m.";
                        return View("Assignment_Read_Student", data);
                    }
                }
                else
                {
                    ViewBag.Message = "You can no longer Upload the Homework for this Assignment";
                    Faculty_Notification(homework.FacultyId, homework.StudentId, false);
                    return View("Assignment_Read_Student", data);
                }
            }
            ViewBag.Message = "Error Uploading the Homework";
            return RedirectToAction("Assignment_Read_Student", data);
        }
        // Method to Update a Assignment in the database.
        [HttpPost]
        public ActionResult Homework_Edit(Homework homework)
        {
            bool edited = homeworkrepo.Homework_Edit(homework);
            List<Homework> data = homeworkrepo.Homework_Read();
            return View("Homework_Read", data);
        }
        // Method to Delete a Assignment from the database.
        [HttpPost]
        public ActionResult Homework_Delete()
        {
            List<Homework> data = homeworkrepo.Homework_Read();
            return View("Homework_Read", data);
        }
        // Method to Notify a Faculty in the database.
        public void Faculty_Notification(int FId, int SId, bool submitted)
        {
            try
            {
                Faculty faculty = facultyrepo.Faculty_ReadById(FId);
                Student student = studentrepo.Student_ReadById(SId);
                if (submitted)
                {
                    Emails email = new Emails();
                    email.Send_Mail(faculty.Email, "gurdain.singh@clanstech.com", student.StudentName + " Homework Submission", string.Format("Dear User,<BR><BR>         The student named "
                            + student.StudentName
                            + " has successfully submitted the Homework for the assignment you uploaded, on time.<BR><BR>Sincerely,<BR>Clanstech Team."));
                }
                else
                {
                    Emails email = new Emails();
                    email.Send_Mail(faculty.Email, "gurdain.singh@clanstech.com", student.StudentName + " Homework Submission", string.Format("Dear User,<BR><BR>         The student named "
                            + student.StudentName
                            + " has failed to submit the Homework for the assignment you uploaded, on time.<BR><BR>Sincerely,<BR>Clanstech Team."));
                }
            }
            catch (Exception ex)
            {
                Exceptions exception = new Exceptions
                {
                    ExceptionNumber = ex.HResult.ToString(),
                    ExceptionMessage = ex.Message,
                    ExceptionMethod = "Faculty_Notification",
                    ExceptionUrl = ""
                };
                exceptionrepo.Exception_Create(exception);
            }
            ViewBag.Message = "Message has been sent Successfully";
            return;
        }
        // Method to Notify a Student in the database.
        public void Student_Notification(int id, bool time)
        {
            try
            {
                if (time)
                {
                    Student data = studentrepo.Student_ReadById(id);
                    Emails email = new Emails();
                    email.Send_Mail(data.Email, "gurdain.singh@clanstech.com", data.StudentName + " Homework Submission", string.Format("Dear "
                        + data.StudentName
                        + ",<BR><BR>         You have not submitted the Homework for an assignment, yet. Please do so within 12 hours.<BR><BR>Sincerely,<BR>Clanstech Team."));
                }
                else
                {
                    Student data = studentrepo.Student_ReadById(id);
                    Emails email = new Emails();
                    email.Send_Mail(data.Email, "gurdain.singh@clanstech.com", data.StudentName + " Homework Submission", string.Format("Dear "
                        + data.StudentName
                        + ",<BR><BR>         You were not able to submit the Homework for an assignment. This will affect your overall grade.<BR><BR>Sincerely,<BR>Clanstech Team."));
                }
            }
            catch (Exception ex)
            {
                Exceptions exception = new Exceptions
                {
                    ExceptionNumber = ex.HResult.ToString(),
                    ExceptionMessage = ex.Message,
                    ExceptionMethod = "Student_Notification",
                    ExceptionUrl = ""
                };
                exceptionrepo.Exception_Create(exception);
            }
            ViewBag.Message = "Message has been sent Successfully";
            return;
        }
        // Method to Check Homework Submission in the database.
        public static void CheckSubmission()
        {
            StudentRepository studentrepo = new StudentRepository();
            FacultyRepository facultyrepo = new FacultyRepository();
            AssignmentRepository assignmentrepo = new AssignmentRepository();
            HomeworkRepository homeworkrepo = new HomeworkRepository();
            HomeController hc = new HomeController();

            List<Assignment> assignments = assignmentrepo.Assignment_Read();
            List<Student> students = studentrepo.Student_Read();
            List<Faculty> faculties = facultyrepo.Faculty_Read();
            List<Homework> homeworks = homeworkrepo.Homework_Read();
            for(int i = 0; i < students.Count; i++)
            {
                for(int j = 0; j < assignments.Count; j++)
                {
                    DateTime t1 = assignments[j].createdOn.ToLocalTime();
                    TimeSpan t2 = DateTime.Now.Subtract(t1);
                    //if (t2.TotalHours <= 24)
                    //{
                    //    for(int k = 0; k < homeworks.Count; k++)
                    //    {
                    //        if (students[i].StudentId == homeworks[k].StudentId && homeworks[k].FacultyId == assignments[j].FacultyId)
                    //        {
                    //            students.Remove(students[i]);
                    //            break;
                    //        }
                    //    }
                    //    break;
                    //}
                    //else
                    //{
                        for(int k = 0; k < homeworks.Count; k++)
                        {
                            DateTime t3 = homeworks[k].createdOn.ToLocalTime();
                            TimeSpan t4 = t1.Subtract(t3);
                            if(students[i].StudentId == homeworks[k].StudentId && homeworks[k].FacultyId == assignments[j].FacultyId && t4.TotalHours < 24)
                            {
                                students.Remove(students[i]);
                                break;
                            }
                        }
                    //}
                }
            }
            for(int i = 0; i < students.Count; i++)
            {
                for(int j = 0; j < assignments.Count; j++)
                {
                    DateTime t1 = assignments[j].createdOn.ToLocalTime();
                    TimeSpan t2 = DateTime.Now.Subtract(t1);
                    if(t2.TotalHours > 12 && t2.TotalHours < 23)
                    {
                        hc.Student_Notification(students[i].StudentId, true);
                    }
                    else if(t2.TotalHours >= 24 && t2.TotalHours < 30)
                    {
                        hc.Student_Notification(students[i].StudentId, false);
                        for(int k = 0; k < faculties.Count; k++)
                        {
                            if(assignments[k].FacultyId == faculties[k].FacultyId)
                            {
                                hc.Faculty_Notification(faculties[k].FacultyId, students[i].StudentId, false);
                            }
                        }
                    }
                }
            }
            return;
        }

    }
}