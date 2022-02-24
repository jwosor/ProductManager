﻿using ProductManager.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Entitites
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
