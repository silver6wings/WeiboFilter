using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PanGu;
using PanGu.Dict;

namespace WeiboCrawler
{
    class WordDivider
    {
        public static List<string> panguDivide(String s)
        {
            Segment segment = new Segment();           

            ICollection<WordInfo> words = segment.DoSegment(s);
            List<string> wordsResult = new List<string>();

            foreach (WordInfo wordInfo in words)
            {
                if (wordInfo == null) continue;
                wordsResult.Add(wordInfo.Word);
            }

            return wordsResult;
        }
    }
}