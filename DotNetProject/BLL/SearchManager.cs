﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
   public class SearchManager
    {
        public static Books GetBooksByCategory(string category)
        {
            return SearchDBManager.GetBooksByCategory(category);
        }
    }
}
