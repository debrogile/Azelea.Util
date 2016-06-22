namespace Azelea.Util
{
    /// <summary>
    /// 图的边
    /// </summary>
    /// <typeparam name="T">边的数据类型</typeparam>
    public class Edge<T>
    {
        /// <summary>
        /// 边元素
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 尾部顶点
        /// </summary>
        public IVertex Tail { get; private set; }
        /// <summary>
        /// 头部顶点
        /// </summary>
        public IVertex Head { get; private set; }
        /// <summary>
        /// 权重
        /// </summary>
        public int Weight { get; private set; }
        /// <summary>
        /// 边类型
        /// </summary>
        public EdgeType Type { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tail">尾部顶点</param>
        /// <param name="head">头部顶点</param>
        public Edge(IVertex tail, IVertex head)
        {
            Tail = tail;
            Head = head;
            Type = EdgeType.UNDETERMINED;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tail">尾部顶点</param>
        /// <param name="head">头部顶点</param>
        /// <param name="element">边元素</param>
        public Edge(IVertex tail, IVertex head, T element) : this(tail, head)
        {
            Data = element;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tail">尾部顶点</param>
        /// <param name="head">头部顶点</param>
        /// <param name="element">边元素</param>
        /// <param name="weight">权重</param>
        public Edge(IVertex tail, IVertex head, T element, int weight) : this(tail, head, element)
        {
            Weight = weight;
        }
    }

    /// <summary>
    /// 边类型
    /// </summary>
    public enum EdgeType
    {
        /// <summary>
        /// 未确定
        /// </summary>
        UNDETERMINED,
        /// <summary>
        /// 树
        /// </summary>
        TREE,
        /// <summary>
        /// 
        /// </summary>
        CROSS,
        /// <summary>
        /// 
        /// </summary>
        FORWARD,
        /// <summary>
        /// 
        /// </summary>
        BACKWARD
    }
}
