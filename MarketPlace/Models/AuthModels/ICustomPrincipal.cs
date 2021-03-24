using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Models.AuthModels {
  interface ICustomPrincipal:IPrincipal {
    int UserID { get; set; }
  }
}
