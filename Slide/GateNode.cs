using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slide
{
    public class GateNode<T> : IEnumerable<GateNode<T>>
    {
        public T Data { get; set; }
        public GateNode<T> Parent { get; set; }
        public ICollection<GateNode<T>> Children { get; set; }

        private ICollection<GateNode<T>> ElementsIndex { get; set; }
        public int Level { get; set; }

        public GateNode(T data)
        {
            this.Data = data;
            this.Children = new LinkedList<GateNode<T>>();
            this.ElementsIndex = new LinkedList<GateNode<T>>();
            this.ElementsIndex.Add(this);
        }

        public GateNode<T> AddChild(GateNode<T> childNode)
        {
            this.Children.Add(childNode);
            this.RegisterChildForSearch(childNode);
            return childNode;
        }

        private void RegisterChildForSearch(GateNode<T> node)
        {
            ElementsIndex.Add(node);
            if (Parent != null)
                Parent.RegisterChildForSearch(node);
        }

        public GateNode<T> FindTreeNode(Func<GateNode<T>, bool> predicate)
        {
            return this.ElementsIndex.FirstOrDefault(predicate);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<GateNode<T>> GetEnumerator()
        {
            yield return this;
            foreach (var directChild in this.Children)
            {
                foreach (var anyChild in directChild)
                    yield return anyChild;
            }
        }
    }

}
