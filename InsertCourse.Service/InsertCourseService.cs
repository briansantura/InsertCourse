using Dapper;
using InsertCourse.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertCourse.Service
{
    public class InsertCourseService : IInsertCourseService
    {
        const string CONNECTION_STRING = "sike";
        public List<CourseCreditStatus> GetCourseCreditStatus()
        {
            string query =
@"SELECT Id, Description 
FROM CourseCreditStatus
";
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                return conn.Query<CourseCreditStatus>(query).ToList();
            }
        }
        public List<CourseTransferStatus> GetCourseTransferStatus()
        {
            string query =
@"SELECT Id, Description 
FROM CourseTransferStatus
";
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                return conn.Query<CourseTransferStatus>(query).ToList();
            }
        }
        public List<CourseBasicSkillsStatus> GetCourseBasicSkillsStatus()
        {
            string query = 

@"SELECT Id, Description 
FROM CourseBasicSkillsStatus
";
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                return conn.Query<CourseBasicSkillsStatus>(query).ToList();
            }
        }
        public List<CourseSAMPriorityCode> GetCourseSAMPriorityCode()
        {
            string query =
@"SELECT Id, Description 
FROM CourseSAMPriorityCode
";
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                return conn.Query<CourseSAMPriorityCode>(query).ToList();
            }
        }

        public List<CoursePriorToCollegeLevel> GetCoursePriorToCollegeLevel()
        {
            string query = 
@"SELECT Id, Description 
FROM CoursePriorToCollegeLevel";
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                return conn.Query<CoursePriorToCollegeLevel>(query).ToList();
            }
        }
        public List<CourseNonCreditCategory> GetCourseNonCreditCategory()
        {
            string query = 
@"SELECT Id, Description 
FROM CourseNonCreditCategory
";
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                return conn.Query<CourseNonCreditCategory>(query).ToList();
            }
        }

        public void InsertCourse(CommunityCollegeCourse course)
        {
            string query = string.Format
(
@"Insert INTO CommunityCollegeCourse 
(
CourseId,
CommunityCollegeCourseId,
CollegeId, CourseTitle, 
CourseStatus, CourseControlNumber,
CourseDepartmentNumber, CourseTOPCode,
CourseCreditStatus, CourseTransferStatus,
CourseCreditMaximum, CourseCreditMinimum,
CourseSAMPriorityCode,CourseBasicSkillsStatus,
CourseCOOPWorkEXStatus,CourseClassificationStatus,
CourseSpecialClassStatus, CoursePriorToCollegeLevel, 
CourseNonCreditCategory, FundingAgencyCategory, 
CourseProgramStatus, DateUpdated, 
DateCreated
)
Values
(
NEWID(),
@CommunityCollegeCourseId,
@CollegeId, @CourseTitle,
@CourseStatus, @CourseControlNumber,
@CourseDepartmentNumber, @CourseTOPCode,
@CourseCreditStatus, @CourseTransferStatus,
@CourseCreditMaximum, @CourseCreditMinimum,
@CourseSAMPriorityCode, @CourseBasicSkillsStatus,
@CourseCOOPWorkEXStatus, @CourseClassificationStatus,
@CourseSpecialClassStatus, @CoursePriorToCollegeLevel,
@CourseNonCreditCategory, @FundingAgencyCategory,
@CourseProgramStatus, @DateUpdated,
@DateCreated
)"
);
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                conn.Execute(query, new
                {
                    CollegeId = course.CollegeId,
                    CommunityCollegeCourseId = course.CommunityCollegeCourseId,
                    CourseTitle = course.CourseTitle,
                    CourseStatus = course.CourseStatus,
                    CourseControlNumber = course.CourseControlNumber,
                    CourseDepartmentNumber = course.CourseDepartmentNumber,
                    CourseTOPCode = course.CourseTOPCode,
                    CourseCreditStatus = course.CourseCreditStatus,
                    CourseTransferStatus = course.CourseTransferStatus,
                    CourseCreditMaximum = course.CourseCreditMaximum,
                    CourseCreditMinimum = course.CourseCreditMinimum,
                    CourseSAMPriorityCode = course.CourseSAMPriorityCode,
                    CourseBasicSkillsStatus = course.CourseBasicSkillsStatus,
                    CourseCOOPWorkEXStatus = course.CourseCOOPWorkEXStatus,
                    CourseClassificationStatus = course.CourseClassificationStatus,
                    CourseSpecialClassStatus = course.CourseSpecialClassStatus,
                    CoursePriorToCollegeLevel = course.CoursePriorToCollegeLevel,
                    CourseNonCreditCategory = course.CourseNonCreditCategory,
                    FundingAgencyCategory = course.FundingAgencyCategory,
                    CourseProgramStatus = course.CourseProgramStatus,
                    DateUpdated = course.DateUpdated,
                    DateCreated = course.DateCreated
                });
            }
        }
    }
}
