using OpenQA.Selenium;
using System.Collections;
using System.Collections.Generic;

namespace Framework.Selenium
{
    public class Elements : IReadOnlyCollection<IWebElement>
    {

        private readonly IList<IWebElement> _elements;

        public Elements(IList<IWebElement> list)
        { 
            _elements = list;
        }

        public IList<IWebElement> Current => _elements ?? throw new System.NullReferenceException("_element is null.");

        public By FoundBy { get; set; }

        public bool IsEmpty => Count == 0;


        public int Count => _elements.Count;

        public IEnumerator<IWebElement> GetEnumerator()
        {
            return Current.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Current.GetEnumerator();
        }
    }
}
