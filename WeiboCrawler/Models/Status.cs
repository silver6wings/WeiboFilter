using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiboCrawler
{
    [Serializable()]
    public class Status
    {
        public string CreatedAt { get; internal set; }
        public string ID { get; internal set; }
        public string Text { get; internal set; }

        public string Source { get; internal set; }
        public bool Favorited { get; internal set; }
        public bool Truncated { get; internal set; }

        public string ThumbnailPictureUrl { get; internal set; }
        public string MiddleSizePictureUrl { get; internal set; }
        public string OriginalPictureUrl { get; internal set; }
        
        public int RepostsCount { get; internal set; }
        public int CommentsCount { get; internal set; }
        public string RetweetedStatusID { get; internal set; }
        
        public Status(NetDimension.Weibo.Entities.status.Entity statusInfo)
        {
            this.CreatedAt =                statusInfo.CreatedAt;
            this.ID =                       statusInfo.ID;
            this.Text =                     statusInfo.Text;

            this.Source =                   statusInfo.Source;
            this.Favorited =                statusInfo.Favorited;
            this.Truncated =                statusInfo.Truncated;

            this.ThumbnailPictureUrl =      statusInfo.ThumbnailPictureUrl;
            this.MiddleSizePictureUrl =     statusInfo.MiddleSizePictureUrl;
            this.OriginalPictureUrl =       statusInfo.OriginalPictureUrl;

            this.RepostsCount =             statusInfo.RepostsCount;
            this.CommentsCount =            statusInfo.CommentsCount;
            if (statusInfo.RetweetedStatus != null) this.RetweetedStatusID = statusInfo.RetweetedStatus.ID;
        }
    }
}
