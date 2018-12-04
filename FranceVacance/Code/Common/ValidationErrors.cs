using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Code.Common
{
  public   class ValidationErrors
    { 
    public string FieldName { get; set; }
        public bool HaveError { get; set; }
        public string ErrorMessage { get; set; }


    }
}
