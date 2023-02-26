﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FMSNew.Models
{
    public class GetWorkExperienceData
    {
        public int WorkID { get; set; }
        public int FacultyID { get; set; }
        public string Faculty_Name { get; set; }
        public string Course { get; set; }
        public string Skills { get; set; }
        public string Experience { get; set; }
    }

    public class GetBookPublishData
    {
        public int PublishID { get; set; }
        public int FacultyID { get; set; }
        public string Faculty_Name { get; set; }
        public string BookName { get; set; }
        public Nullable<System.DateTime> Publish_Date { get; set; }
    }
}