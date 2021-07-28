﻿using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models.TimelineModel
{
    public class PermitedModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string PermissionStatus { get; set; }
        public string Season { get; set; }
        public int SpeedOfWind { get; set; }
        public bool GovernmentStatus { get; set; }
        public string Rainfall { get; set; }
        public string TimeOfDay { get; set; }  
    }
}
