﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.FeatureDtos
{
    public class ResultFeatureWithStatusDto
    {
        public int FeatureID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
