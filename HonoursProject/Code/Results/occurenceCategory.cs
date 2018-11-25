using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HonoursProject.Code.Results
{
    public class occurenceCategory
    {
        private int id;
        private string category;

        public int Id { get => id; set => id = value; }
        public string Category { get => category; set => category = value; }
    }
}