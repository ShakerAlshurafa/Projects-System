﻿using SPCS.Models.user;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPCS.Models.project
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Overview { get; set; } = null!;
        public string Status { get; set; } = null!;


        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;


        public Workgroup? Workgroup { get; set; }


        public ICollection<ProjectFeatures> Features { get; set; } = new List<ProjectFeatures>();
        public ICollection<ProjectTechnology> Technology { get; set; } = new List<ProjectTechnology>();
        public ICollection<ProjectGoal> Goals { get; set; } = new List<ProjectGoal>(); // One-to-Many
        public ICollection<ProjectAudience> Audience { get; set; } = new List<ProjectAudience>();
    }
}