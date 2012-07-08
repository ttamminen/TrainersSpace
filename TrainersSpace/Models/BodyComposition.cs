using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainersSpace.Models
{
    public class BodyComposition
    {
        public decimal Weight { get; set; }
        public decimal BodyFat { get; set; }
        public decimal SkeletalMuscle { get; set; }
        public decimal BodyMassIndex { get; set; }
        public uint VisceralFat { get; set; }
        public uint RestingMetabolism { get; set; }
    }
}