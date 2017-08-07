using InsertCourse.Service;
using InsertCourse.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace InsertCourse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //load button
        public void loadButton_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        //background worker
        public void insertCourse_DoWork(object sender, EventArgs e)
        {
            int id = 0;
            List<string> listOfNames = new List<string>();
            if (!string.IsNullOrWhiteSpace(pathToCSV.Text))
            {
                string[] files = Directory.GetFiles(pathToCSV.Text);

                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);

                    int collegeId = 0;
                    bool parsableName = int.TryParse(Regex.Match(fi.Name, @"\d+").Value, out collegeId);

                    if (parsableName)
                    {
                        List<CommunityCollegeCourse> communityCollegeCourses = GetCourses(collegeId, fi.FullName);

                        foreach (CommunityCollegeCourse course in communityCollegeCourses)
                        {
                            InsertCourse(course);
                        }
                    }
                    else
                    {
                        string rejects = fi.Name;
                        listOfNames.Add(rejects);
                    }
                }
                MessageBox.Show(string.Join(",", listOfNames));
                MessageBox.Show("DONE");
            }
            else
            {
                MessageBox.Show("PLEASE FILL OUT THE FORM ACCORDINGLY.");
            }
        }

        public List<CommunityCollegeCourse> GetCourses(int collegeId, string path)
        {
            List<CommunityCollegeCourse> communityCollegeCourses = new List<CommunityCollegeCourse>();
            InsertCourseService getCourseService = new InsertCourseService();

            List<CourseCreditStatus> courseCreditStatus = getCourseService.GetCourseCreditStatus();
            List<CourseTransferStatus> courseTransferStatus = getCourseService.GetCourseTransferStatus();
            List<CourseBasicSkillsStatus> courseBasicSkillsStatus = getCourseService.GetCourseBasicSkillsStatus();
            List<CourseSAMPriorityCode> courseSAMPriorityCode = getCourseService.GetCourseSAMPriorityCode();
            List<CoursePriorToCollegeLevel> coursePriorToCollegeLevel = getCourseService.GetCoursePriorToCollegeLevel();
            List<CourseNonCreditCategory> courseNonCreditCategory = getCourseService.GetCourseNonCreditCategory();

            decimal maxVal = 0;
            decimal minVal = 0;
            using (var sr = new StreamReader(path))
            {
                var csv = new CsvHelper.CsvReader(sr);

                while (csv.Read())
                {
                    communityCollegeCourses.Add(new CommunityCollegeCourse()
                    {
                        CollegeId = collegeId,
                        CourseId = Guid.NewGuid(),
                        CommunityCollegeCourseId = csv.GetField("Course ID") != null ? csv.GetField("Course ID").Trim() : "N/A",
                        CourseTitle = csv.GetField("Course Title") != null ? csv.GetField("Course Title").Trim() : "N/A",
                        CourseStatus = true,
                        CourseControlNumber = csv.GetField("Control Number") != null ? csv.GetField("Control Number").Trim() : "N/A",
                        CourseDepartmentNumber = "N/A",
                        CourseTOPCode = csv.GetField("TOP Code") != null ? csv.GetField("TOP Code").Trim() : "N/A",
                        CourseCreditStatus = csv.GetField("Credit Status") != null ? courseCreditStatus.Where(x => x.Description == csv.GetField("Credit Status").Trim()).FirstOrDefault() != null ? courseCreditStatus.Where(x => x.Description == csv.GetField("Credit Status").Trim()).DefaultIfEmpty().FirstOrDefault().Id : 0 : 0,
                        CourseTransferStatus = csv.GetField("Transfer Status") != null ? courseTransferStatus.Where(x => x.Description == csv.GetField("Transfer Status").Trim()).FirstOrDefault() != null ? courseTransferStatus.Where(x => x.Description == csv.GetField("Transfer Status").Trim()).Single().Id : 0 : 0,
                        CourseCreditMaximum = decimal.TryParse(csv.GetField("Maximum Units"), out maxVal) != true ? 0 : maxVal,
                        CourseCreditMinimum = decimal.TryParse(csv.GetField("Minimum Units"), out minVal) != true ? 0 : minVal,
                        CourseBasicSkillsStatus = csv.GetField("Basic Skills Status") != null ? courseBasicSkillsStatus.Where(x => x.Description == csv.GetField("Basic Skills Status").Trim()).FirstOrDefault() != null ? courseBasicSkillsStatus.Where(x => x.Description == csv.GetField("Basic Skills Status").Trim()).Single().Id : 0 : 0,
                        CourseSAMPriorityCode = csv.GetField("SAM Status") != null ? courseSAMPriorityCode.Where(x => x.Description == csv.GetField("SAM Status").Trim()).FirstOrDefault() != null ? courseSAMPriorityCode.Where(x => x.Description == csv.GetField("SAM Status").Trim()).Single().Id : 0 : 0,
                        CourseCOOPWorkEXStatus = 0,
                        CourseClassificationStatus = 0,
                        CourseSpecialClassStatus = 0,
                        CoursePriorToCollegeLevel = csv.GetField("Prior To Transfer Status") != null ? coursePriorToCollegeLevel.Where(x => x.Description == csv.GetField("Prior To Transfer Status").Trim()).FirstOrDefault() != null ? coursePriorToCollegeLevel.Where(x => x.Description == csv.GetField("Prior To Transfer Status").Trim()).Single().Id : 0 : 0,
                        CourseNonCreditCategory = csv.GetField("Non-Credit Category") != null ? courseNonCreditCategory.Where(x => x.Description == csv.GetField("Non-Credit Category").Trim()).FirstOrDefault() != null ? courseNonCreditCategory.Where(x => x.Description == csv.GetField("Non-Credit Category").Trim()).Single().Id : 0 : 0,
                        FundingAgencyCategory = 0,
                        CourseProgramStatus = 0,
                        DateUpdated = DateTime.Now,
                        DateCreated = DateTime.Now
                    });
                }
            }

            return communityCollegeCourses;
        }

        public void InsertCourse(CommunityCollegeCourse course)
        {
            InsertCourseService insertCourse = new InsertCourseService();

            insertCourse.InsertCourse(course);
        }

        public void WriteCoursesToCSV(CommunityCollegeCourse course)
        {
            if (course != null)
            {
                using (var sw = new StreamWriter("test.csv", true))
                {
                    var writer = new CsvHelper.CsvWriter(sw);

                        writer.WriteField(course.CourseId);
                        writer.WriteField(course.CommunityCollegeCourseId);
                        writer.WriteField(course.CollegeId);
                        writer.WriteField(course.CourseTitle);
                        writer.WriteField(course.CourseStatus);
                        writer.WriteField(course.CourseControlNumber);
                        writer.WriteField(course.CourseDepartmentNumber);
                        writer.WriteField(course.CourseTOPCode);
                        writer.WriteField(course.CourseCreditStatus);
                        writer.WriteField(course.CourseTransferStatus);
                        writer.WriteField(course.CourseCreditMaximum);
                        writer.WriteField(course.CourseCreditMinimum);
                        writer.WriteField(course.CourseBasicSkillsStatus);
                        writer.WriteField(course.CourseSAMPriorityCode);
                        writer.WriteField(course.CourseCOOPWorkEXStatus);
                        writer.WriteField(course.CourseClassificationStatus);
                        writer.WriteField(course.CourseSpecialClassStatus);
                        writer.WriteField(course.CoursePriorToCollegeLevel);
                        writer.WriteField(course.CourseNonCreditCategory);
                        writer.WriteField(course.FundingAgencyCategory);
                        writer.WriteField(course.CourseProgramStatus);
                        writer.WriteField(course.DateUpdated);
                        writer.WriteField(course.DateCreated);

                        writer.NextRecord();
                }
            }
        }
    }
}
