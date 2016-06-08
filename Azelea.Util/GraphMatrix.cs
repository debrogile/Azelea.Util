using System.Collections.Generic;

namespace Azelea.Util
{
    /// <summary>
    /// 基于邻接矩阵实现的图
    /// </summary>
    /// <typeparam name="TV">顶点数据类型</typeparam>
    /// <typeparam name="TE">边数据类型</typeparam>
    public class GraphMatrix<TV, TE> : Graph<TV, TE>
    {
        private IList<Vertex<TV>> Vertexes = new List<Vertex<TV>>();
        private IList<IList<Edge<TE>>> Edges = new List<IList<Edge<TE>>>();

        /// <summary>
        /// 构造函数
        /// </summary>
        public GraphMatrix()
        {
            var a = Vertexes[0];            
            var b = Edges[0][0];

            var c = new LinkedList<int>();
            var dd = c.AddFirst(1);
        }
    }
}
