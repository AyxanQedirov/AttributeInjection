﻿using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class TestRepository : ITestRepository
    {
        public string GetName()
        {
            return "Test Repository";
        }
    }
}
