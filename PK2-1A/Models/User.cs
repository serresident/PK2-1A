﻿using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK2_1A.Models
{
    public class User : BindableBase
    {
        public bool isAuthorized = false;
        public bool IsAuthorized
        {
            get { return isAuthorized; }
            set { SetProperty(ref isAuthorized, value); }
        }
    }

}
