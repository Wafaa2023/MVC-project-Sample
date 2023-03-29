﻿using Project.Core.UnitOfWorks;
using Project.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project.Model
{
    public class ProjectSampleUnitOfWork : UnitOfWork, IProjectSampleUnitOfWork
    {
        public ProjectSampleUnitOfWork():base(new FostanyEntities())
        {
                
        }
    }
}
