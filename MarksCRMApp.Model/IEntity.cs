﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarksCRMApp.Model
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
