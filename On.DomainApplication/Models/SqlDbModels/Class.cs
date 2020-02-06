using System;
using System.Collections.Generic;
using System.Text;

namespace Domain_Application.Models.SqlDbModels
{
    public class Class
    {
        #region Construtores

        public Class()
        {
           // this.Students = new List<UserInfo>();
        }

        public Class(string name, short year, int schoolId, int gradeId, int shiftTypeId)
        {
            //this.Id = Guid.NewGuid();
            this.Name = name;
            this.Year = year;
            this.SchoolId = schoolId;
            this.GradeId = gradeId;
            this.ShiftTypeId = shiftTypeId;

            this.CreatedDate = DateTime.UtcNow;
            this.LastUpdate = DateTime.UtcNow;
            this.Excluded = false;
        }


        public Class(string name, short year, int schoolId, int gradeId, int shiftTypeId, bool excluded)
        {
            //this.Id = Guid.NewGuid();
            this.Name = name;
            this.Year = year;
            this.SchoolId = schoolId;
            this.GradeId = gradeId;
            this.ShiftTypeId = shiftTypeId;

            this.CreatedDate = DateTime.UtcNow;
            this.LastUpdate = DateTime.UtcNow;
            this.Excluded = excluded;
        }

        #endregion

        #region Properties

        //TODO trocar id para guid
        //public Guid Id { get; private set; }
        public int Id { get; private set; }

        public string Name { get; private set; }

        public short Year { get; private set; }

        public int SchoolId { get; private set; }
       // public virtual SchoolInfo School { get; private set; }

        public int GradeId { get; private set; }
        //public virtual Grade Grade { get; private set; }

        public int ShiftTypeId { get; private set; }
        //public virtual ShiftType ShiftType { get; private set; }

        public DateTime CreatedDate { get; private set; }
        public DateTime LastUpdate { get; private set; }
        public bool Excluded { get; private set; }

        //public virtual IList<UserInfo> Students { get; private set; }
        //public virtual IList<ClassSubjectTeacher> ClassSubjectTeachers { get; private set; }

        //em caso da classe ser criada por uma planilha
        public Guid? SourceId { get; set; }

        #endregion

        #region Métodos

        public void Exclude(bool excluded = true)
        {
            this.Excluded = excluded;
            this.LastUpdate = DateTime.UtcNow;
        }

        public void SetName(string name)
        {
            this.Name = name;
            this.LastUpdate = DateTime.UtcNow;
        }

        public void SetYear(short year)
        {
            this.Year = year;
            this.LastUpdate = DateTime.UtcNow;
        }

        public void SetSchoolId(int schoolId)
        {
            this.SchoolId = schoolId;
            this.LastUpdate = DateTime.UtcNow;
        }

        public void SetGradeId(int gradeId)
        {
            this.GradeId = gradeId;
            this.LastUpdate = DateTime.UtcNow;
        }

        public void SetShiftTypeId(int shiftTypeId)
        {
            this.ShiftTypeId = shiftTypeId;
            this.LastUpdate = DateTime.UtcNow;
        }

        //public void SetShiftType(ShiftType shiftType)
        //{
        //    this.ShiftType = shiftType;
        //    this.LastUpdate = DateTime.UtcNow;
        //}

        //public void SetStudents(IList<UserInfo> students)
        //{
        //    this.Students = students;
        //    this.LastUpdate = DateTime.UtcNow;
        //}

        //public void SetClassSubjectTeachers(IList<ClassSubjectTeacher> classSubjectTeachers)
        //{
        //    this.ClassSubjectTeachers = classSubjectTeachers;
        //    this.LastUpdate = DateTime.UtcNow;
        //}

        //public void AddStudent(UserInfo user)
        //{
        //    this.Students.Add(user);
        //    this.LastUpdate = DateTime.UtcNow;
        //}

        #endregion
    }
}

