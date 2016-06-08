namespace Azelea.Util
{
    /// <summary>
    /// 表示图的顶点
    /// </summary>
    public interface IVertex
    { }

    /// <summary>
    /// 图的顶点
    /// </summary>
    /// <typeparam name="T">顶点数据类型</typeparam>
    public class Vertex<T> : IVertex
    {
        /// <summary>
        /// 顶点元素
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 入度
        /// </summary>
        public int InDegree { get; private set; }
        /// <summary>
        /// 出度
        /// </summary>
        public int OutDegree { get; private set; }
        /// <summary>
        /// 顶点状态
        /// </summary>
        public VertexStatus Status { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public Vertex()
        {
            InDegree = OutDegree = 0;
            Status = VertexStatus.UNDISCOVERED;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="element">顶点元素</param>
        public Vertex(T element) : this()
        {
            Data = element;
        }
    }

    /// <summary>
    /// 顶点状态
    /// </summary>
    public enum VertexStatus
    {
        /// <summary>
        /// 未发现
        /// </summary>
        UNDISCOVERED,
        /// <summary>
        /// 已发现
        /// </summary>
        DISCOVERED,
        /// <summary>
        /// 已访问
        /// </summary>
        VISITED
    }
}
