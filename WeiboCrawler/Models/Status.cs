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
        
        public static Status CreateByAPI(NetDimension.Weibo.Entities.status.Entity statusInfo)
        {
            Status myStatusInfo = new Status();

            myStatusInfo.CreatedAt =                statusInfo.CreatedAt;
            myStatusInfo.ID =                       statusInfo.ID;
            myStatusInfo.Text =                     statusInfo.Text;

            myStatusInfo.Source =                   statusInfo.Source;
            myStatusInfo.Favorited =                statusInfo.Favorited;
            myStatusInfo.Truncated =                statusInfo.Truncated;

            myStatusInfo.ThumbnailPictureUrl =      statusInfo.ThumbnailPictureUrl;
            myStatusInfo.MiddleSizePictureUrl =     statusInfo.MiddleSizePictureUrl;
            myStatusInfo.OriginalPictureUrl =       statusInfo.OriginalPictureUrl;

            myStatusInfo.RepostsCount =             statusInfo.RepostsCount;
            myStatusInfo.CommentsCount =            statusInfo.CommentsCount;
            if (statusInfo.RetweetedStatus != null) myStatusInfo.RetweetedStatusID = statusInfo.RetweetedStatus.ID;

            return myStatusInfo;
        }
    }
}
