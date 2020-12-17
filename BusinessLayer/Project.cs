using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Contract_Employee_Payments_Core_App.BusinessLayer
{
    //project with name and estimated hours
    public class Project
    {
        public int Id { get; set; }

        public string  ProjectName { get; set; }

        public int EstimatedHours { get; set; }

        [NotMapped]
        public string ProjectCode { get {

                return ProjectName + "_" + Id;
            
            
            
            } }

    }
}
