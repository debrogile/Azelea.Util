using System;
using System.Collections.Generic;
using System.Linq;

namespace Azelea.Util
{
    /// <summary>
    /// 图
    /// </summary>
    /// <typeparam name="TV">顶点数据类型</typeparam>
    /// <typeparam name="TE">边数据类型</typeparam>
    public class Graph<TV, TE>
    {
        private IList<Vertex<TV>> _Vertexes = new List<Vertex<TV>>();
        private IList<Edge<TE>> _Edges = new List<Edge<TE>>();

        /// <summary>
        /// 顶点
        /// </summary>
        /// <param name="i">顶点序号</param>
        /// <returns>返回图中指定序号的顶点</returns>
        public Vertex<TV> Vertex(int i)
        {
            return _Vertexes[i];
        }

        /// <summary>
        /// 增加顶点
        /// </summary>
        /// <param name="element">顶点元素</param>
        /// <returns>返回顶点序号</returns>
        public int AddVertex(TV element)
        {
            var vertex = new Vertex<TV>(element);
            _Vertexes.Add(vertex);

            return _Vertexes.Count;
        }

        /// <summary>
        /// 删除顶点
        /// </summary>
        /// <param name="i">顶点序号</param>
        /// <returns>返回顶点元素</returns>
        public TV RemoveVertex(int i)
        {
            // 下标检查
            if (i >= _Vertexes.Count || i < 0)
            {
                throw new IndexOutOfRangeException();
            }

            var vertex = _Vertexes[i];
            var element = vertex.Data;
            // 删除顶点
            _Vertexes.RemoveAt(i);
            // 删除与该顶点关联的边
            var edges = _Edges.Where(e => e.Tail == vertex || e.Head == vertex);
            foreach (var edge in edges)
            {
                _Edges.Remove(edge);
            }

            return element;
        }

        /// <summary>
        /// 是否存在对应的边
        /// </summary>
        /// <param name="i">尾部节点序号</param>
        /// <param name="j">头部节点序号</param>
        /// <returns></returns>
        public bool IsExist(int i, int j)
        {
            // 下标检查
            if (i >= _Vertexes.Count || i < 0 ||
                j >= _Vertexes.Count || j < 0)
            {
                throw new IndexOutOfRangeException();
            }

            var tail = _Vertexes[i];
            var head = _Vertexes[j];
            var edge = _Edges.SingleOrDefault(e => e.Tail == tail && e.Head == tail);

            return edge != null;
        }

        /// <summary>
        /// 广度优先搜索
        /// </summary>
        /// <param name="visit">元素访问方法</param>
        public void BreadthFirst(Action<TV> visit)
        { }
    }
}
