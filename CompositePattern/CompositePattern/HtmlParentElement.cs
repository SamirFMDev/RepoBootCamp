using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    class HtmlParentElement : HtmlTag
    {
        private string tagName { get; set; }
        private string startTag { get; set; }
        private string endTag { get; set; }
        private List<HtmlTag> childrenTag { get; set; }

        public HtmlParentElement(string tagName)
        {
            this.tagName = tagName;
            this.childrenTag = new();
        }

        public override string getTagName()
        {
            return tagName;
        }
        public override void setStartTag(string startTag)
        {
            this.startTag = startTag;
        }
        public override void setEndTag(string endTag)
        {
            this.endTag = endTag;
        }
        public override void addChildTag(HtmlTag childTag)
        {
            childrenTag.Add(childTag);
        }
        public override void removeChildTag(HtmlTag childTag)
        {
            childrenTag.Remove(childTag);
        }
        public override List<HtmlTag> getChildren()
        {
            return childrenTag;
        }
        public override void generateHtml()
        {
            Console.WriteLine(startTag);
            foreach(HtmlTag childTag in childrenTag)
                childTag.generateHtml();
            Console.WriteLine(endTag);
        }        
    }
}
