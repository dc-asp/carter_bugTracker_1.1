﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using carter_bugTracker_1._1.Models;

namespace carter_bugTracker_1._1.Helpers
{
    public abstract class CommonHelper
    {
        protected static ApplicationDbContext db = new ApplicationDbContext();
        protected static UserRolesHelper roleHelper = new UserRolesHelper();
        protected static ProjectsHelper projectHelper = new ProjectsHelper();

    }
}