﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.logic.interfaces
{
    public interface ICard
    {

        String Command { get; }

        String Value { get; }

        String Text { get; }
    }
}