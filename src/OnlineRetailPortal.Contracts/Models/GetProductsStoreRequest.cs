﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Contracts
{
    public class GetProductsStoreRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}