using System;
using System.Collections.Generic;

namespace WdprPretparkDenhaag.Models
{
    public class PlanningItem
    {
        public Guid Id { get; set; }
        public Guid PlanningId { get; set; }
        public Guid TijdSlotId { get; set; }
        public Guid AttractieId {get; set; }
    }
}