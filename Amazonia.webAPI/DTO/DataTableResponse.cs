﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazonia.webAPI.DTO
{
    public class DataTableResponse
    {

      
            public int Draw { get; set; }
            public long RecordsTotal { get; set; }
            public int RecordsFiltered { get; set; }
            public object[] Data { get; set; }
            public string Error { get; set; }
        


    }
}
