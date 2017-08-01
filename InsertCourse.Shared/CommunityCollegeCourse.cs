using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertCourse.Shared
{
    public class CommunityCollegeCourse
    {
        public int Id { get; set; }
        public int CollegeId { get; set; }
        public Guid CourseId { get; set; }
        public string CommunityCollegeCourseId { get; set; }
        public string CourseTitle { get; set; }
        public bool CourseStatus { get; set; }
        public string CourseControlNumber { get; set; }
        public string CourseDepartmentNumber { get; set; }
        public string CourseTOPCode { get; set; }
        public int CourseCreditStatus { get; set; }
        public int CourseTransferStatus { get; set; }
        public decimal CourseCreditMaximum { get; set; }
        public decimal CourseCreditMinimum { get; set; }
        public int CourseBasicSkillsStatus { get; set; }
        public int CourseSAMPriorityCode { get; set; }
        public int CourseCOOPWorkEXStatus { get; set; }
        public int CourseClassificationStatus { get; set; }
        public int CourseSpecialClassStatus { get; set; }
        public int CoursePriorToCollegeLevel { get; set; }
        public int CourseNonCreditCategory { get; set; }
        public int FundingAgencyCategory { get; set; }
        public int CourseProgramStatus { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
