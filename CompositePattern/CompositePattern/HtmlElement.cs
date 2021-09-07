using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    class HtmlElement : HtmlTag
    {
        private string tagName { get; set; }
        private string startTag { get; set; }
        private string endTag { get; set; }
        private string tagBody { get; set; }

        public HtmlElement(string tagName)
        {
            this.tagName = tagName;
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
        public override void setTagBody(string tagBody)
        {
            this.tagBody = tagBody;
        }
        public override void generateHtml()
        {
            Console.WriteLine($"{startTag}{tagBody}{endTag}");
        }
    }
}
