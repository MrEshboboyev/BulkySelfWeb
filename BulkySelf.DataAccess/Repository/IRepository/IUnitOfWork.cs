﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkySelf.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IStudentRepository Student { get; }
        IProductRepository Product { get; }
        void Save();
    }
}
