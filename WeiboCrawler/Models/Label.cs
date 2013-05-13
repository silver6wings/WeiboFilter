using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiboCrawler.Models
{
    [Serializable()]
    public class Label
    {
        public string Category { get; internal set; }
        public string UserID { get; internal set; }
        public string StatusID { get; internal set; }

        public Label(string Category, string StatusID, string UserID)
        {
            this.Category = Category;
            this.StatusID = StatusID;
            this.UserID = UserID;
        }
    }
}
