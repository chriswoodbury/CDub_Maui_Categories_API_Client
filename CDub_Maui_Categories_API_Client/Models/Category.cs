using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDub_Maui_Categories_API_Client.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public int DisplayOrder { get; set; }
    }
}
