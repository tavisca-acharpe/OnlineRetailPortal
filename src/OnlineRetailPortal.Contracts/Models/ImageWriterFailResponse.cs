﻿using OnlineRetailPortal.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Contracts.Models
{
    public class ImageWriterFailResponse : IImageWriterResponse
    {
        public int Code { get;  set; }

        public string Response { get; set; }
    }
}
