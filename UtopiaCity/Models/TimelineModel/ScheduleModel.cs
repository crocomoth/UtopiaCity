using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models.TimelineModel
{
    public class ScheduleModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string Id { get; set; }

        [Display(Name = "Название")]
        public string ModelName{ get; set; }

        [Display(Name = "Название события")]
        public string EventName { get; set; }

        [Display(Name = "Тип события")]
        public string EventType { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Время начала")]
        public DateTime TimeOfStart{ get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Время окончания")]
        public DateTime TimeOfEnd{ get; set; }

    }
}
