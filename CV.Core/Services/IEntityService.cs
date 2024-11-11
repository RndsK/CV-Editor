﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV.Core.Models;

namespace CV.Core.Services
{
    public interface IEntityService<T> where T : Entity
    {
        T? GetById(int id);
        ServiceResult Create(T entity);
        ServiceResult Delete(T entity);
        ServiceResult Update(T entity);
        IEnumerable<T> List();
    }
}
