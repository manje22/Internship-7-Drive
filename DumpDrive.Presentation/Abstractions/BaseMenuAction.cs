﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DumpDrive.Presentation.Extentions;

namespace DumpDrive.Presentation.Abstractions
{
    public class BaseMenuAction : IMenuAction
    {
        public int MenuIndex { get; set; }

        public string Name { get; set; } = "NoName action";
        public IList<IAction> Actions { get; set; }

        public BaseMenuAction(IList<IAction> actions)
        {
            actions.SetActionIndexes();
            Actions = actions;
        }

        public virtual void Open()
        {

        }
    }
}
