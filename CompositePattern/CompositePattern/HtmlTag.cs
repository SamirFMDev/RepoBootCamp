using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    abstract class HtmlTag
    {
        public abstract string getTagName();
        public abstract void setStartTag(string startTag);
        public abstract void setEndTag(string endTag);
        public virtual void setTagBody(string tagBody) {
            Console.WriteLine("setTagBody: Operation not supported for this object");
            throw new NotImplementedException();
        }
        public virtual void addChildTag(HtmlTag child) {
            Console.WriteLine("addChildTag: Operation not supported for this object");
            throw new NotImplementedException();
        }
        public virtual void removeChildTag(HtmlTag child) {
            Console.WriteLine("removeChildTag: Operation not supported for this object");
            throw new NotImplementedException();
        }
        public virtual List<HtmlTag> getChildren() {
            Console.WriteLine("getChildren: Operation not supported for this object");
            throw new NotImplementedException();
        }
        public abstract void generateHtml();
    }
}
