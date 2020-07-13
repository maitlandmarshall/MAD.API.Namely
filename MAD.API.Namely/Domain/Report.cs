﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAD.API.Namely.Domain
{
    public class Report
    {
        public List<ReportColumn> Columns { get; set; }

        public List<JToken[]> Content { get; set; }
    }
}
