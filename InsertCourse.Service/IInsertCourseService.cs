using InsertCourse.Shared;
using System.Collections.Generic;

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
