﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Presentation.Abstractions
{
    public interface IMenuAction : IAction
    {
        IList<IAction> Actions { get; set; }
    }
}