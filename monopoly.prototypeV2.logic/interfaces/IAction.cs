﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.prototypeV2.logic.classes;

namespace monopoly.prototypeV2.logic.interfaces
{
    public interface IAction
    {
        string getName();
        void runAction();
    }
}
