using Partners.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Partners.ViewModels
{
    public class PartnerVM
    {
        public int Id { get; set; }
        public List<Partner> PartnerList { get; set; } = new List<Partner>();
    }
}