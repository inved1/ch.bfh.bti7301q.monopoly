﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.logic.interfaces
{
    public interface IBuyable
    {
        int price { get; }

        //all buyables have rent...
        int CurrentRent { get; }

        string TradeString { get; }

        
    }
}
