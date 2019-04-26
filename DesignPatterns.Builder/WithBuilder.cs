using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Builder
{
    public class HtmlElement
    {
        public HtmlElement()
        {

        }
        public HtmlElement(string name, string text, bool isClosed = false)
        {
            Name = name;
            Text = text;
            IsClosed = isClosed;
        }


        public string Name, Text;
        public bool IsClosed;

        public List<HtmlElement> HtmlElements = new List<HtmlElement>();
        private const int indentSize = 2;

        private string ToStringImp(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.AppendLine($"{i}<{Name}>");
            if (!string.IsNullOrEmpty(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.AppendLine(Text);
            }

            foreach (var e in HtmlElements)
            {
                sb.Append(e.ToStringImp(indent + 1));
            }

            if (IsClosed)
            {
                sb.AppendLine($"{i}</{Name}>");
            }
            else
            {
                sb.AppendLine($"{i}<{Name}>");
            }

            return sb.ToString();
        }
        public override string ToString()
        {
            return ToStringImp(0);
        }
    }
    public class HtmlBuilder
    {
        private readonly string rootName;
        private readonly bool isClosed;

        HtmlElement root = new HtmlElement();
        public HtmlBuilder(string rootName, bool isClosed = false)
        {
            this.rootName = rootName;
            this.isClosed = isClosed;

            root.Name = rootName;
            root.IsClosed = isClosed;
        }


        public void AddChild(string childName, string childText, bool isClosed = false)
        {
            var e = new HtmlElement(childName, childText, isClosed);
            root.HtmlElements.Add(e);
        }

        public HtmlBuilder AddChildAsFluent(string childName, string childText, bool isClosed = false)
        {
            var e = new HtmlElement(childName, childText, isClosed);
            root.HtmlElements.Add(e);
            return this;
        }
        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement { Name = rootName };
        }
    }

    public class WithBuilder
    {
        public void Run()
        {
            var builder = new HtmlBuilder("html", true);
            builder.AddChild("head", "This is head", true);
            builder.AddChild("body", "This is body", true);
            builder.AddChild("foot", "This is foot", true);
            Console.WriteLine(builder.ToString());

        }

        public void RunForFluent()
        {
            var builder = new HtmlBuilder("html", true);
            builder
                .AddChildAsFluent("head", "This is head", true)
                .AddChildAsFluent("body", "This is body", true)
                .AddChildAsFluent("foot", "This is foot", true);

            Console.WriteLine(builder.ToString());
        }
    }
}
