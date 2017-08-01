using InsertCourse.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertCourse.Service
{
    public interface IInsertCourseService
    {
        List<CourseCreditStatus> GetCourseCreditStatus();
        List<CourseTransferStatus> GetCourseTransferStatus();
        List<CourseBasicSkillsStatus> GetCourseBasicSkillsStatus();
        List<CourseSAMPriorityCode> GetCourseSAMPriorityCode();
        List<CoursePriorToCollegeLevel> GetCoursePriorToCollegeLevel();
        List<CourseNonCreditCategory> GetCourseNonCreditCategory();
        void InsertCourse(CommunityCollegeCourse course);
    }
}
