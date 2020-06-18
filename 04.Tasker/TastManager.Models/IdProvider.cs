using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TastManager.Models
{
    public class IdProvider : IIdProvider
    {
        //Field
        private static int id;

        //Propartie
        public int Id
        {
            get
            {
                return ++id;
            }
        }
    }
}
