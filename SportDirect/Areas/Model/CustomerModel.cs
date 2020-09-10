using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Areas.Model
{
   public class CustomerModel
    {
        public string Title { get; set; }
        public string Image { get; set; }

        //Filter Model  
        public string CategoriesTitle { get; set; }
        public string FrameColor { get; set; }
    }
}
