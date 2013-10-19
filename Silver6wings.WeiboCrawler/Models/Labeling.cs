using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silver6wings.WeiboTools
{
    [Serializable()]
    public class Labeling
    {
        public string Category { get; internal set; }
        public string Text { get; internal set; }
        public string StatusID { get; internal set; }
        public string UserID { get; internal set; }

        public Labeling(string Category, string Text, string StatusID, string UserID)
        {
            this.Category = Category;
            this.Text = Text;
            this.StatusID = StatusID;
            this.UserID = UserID;
        }
    }
}
