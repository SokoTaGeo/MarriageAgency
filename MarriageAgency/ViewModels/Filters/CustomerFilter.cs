using MarriageAgency.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageAgency.ViewModels.Filters
{
    public class CustomerFilter
    {
        public int? ZodiacSignId { get; set; }
        public SelectList ZodiacSigns { get; set; }

        public CustomerFilter(int? zodiacSignId, IList<ZodiacSign> zodiacSigns)
        {
            zodiacSigns.Insert(0, new ZodiacSign()
            {
                Id = 0,
                Name = "All"
            });

            ZodiacSignId = zodiacSignId;
            ZodiacSigns = new SelectList(zodiacSigns, "Id", "Name", zodiacSignId);
        }
    }
}
