using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Frame.ApplicationCore.Common
{
    /// <summary>
    /// 公共方法类
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// 将字符串进行MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] data = md5.ComputeHash(buffer);
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        /// <summary>
        /// IQueryable的扩展方法，用于分页
        /// </summary>
        /// <typeparam name="TSource">实体类型</typeparam>
        /// <param name="source">需要进行分页的数据</param>
        /// <param name="limit">每页显示条数</param>
        /// <param name="page">从第几页开始</param>
        /// <param name="field">排序的字段</param>
        /// <param name="order">排序规则</param>
        /// <returns></returns>
        public static async Task<IPageList<TSource>> ToPageList<TSource>(this IQueryable<TSource> source, int limit, int page) where TSource : class, new()
        {
            if (source.Count() == 0) return new IPageList<TSource>() { code = 0, message = "无数据", data = new List<TSource>(), total = 1, count = 0 };
            //计算取第几页的值
            int skip = (page - 1) * limit;
            //计算取几条
            int take = source.Count() < limit ? source.Count() : limit;
            //取出对应页数的数据
            var query = source.Skip(skip).Take(take);

            var data = await query.ToListAsync();

            //返回数据
            return new IPageList<TSource>()
            {
                data = data,
                total = source.Count() / limit < 1 ? 1 : source.Count() / limit,
                code = data.Count() > 0 ? 200 : -1,
                count = source.Count(),
                message = data.Count() > 0 ? "加载成功" : "没有数据"
            };
        }

        /// <summary>
        /// 对数据进行排序，用于IQueryable<>类型
        /// </summary>
        /// <typeparam name="TSource">实体</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="field">排序字段</param>
        /// <param name="order">排序规则</param>
        /// <returns></returns>
        public static IQueryable<TSource> Sort<TSource>(this IQueryable<TSource> source, string field, string order) where TSource : class, new()
        {
            if (source.Count() == 0) return source;
            //如果传过来的是null或空的排序方式，则按照降序来排序
            if (string.IsNullOrEmpty(order)) order = "asc";

            if (order.Equals("asc")) order = "OrderBy";
            else if (order.Equals("desc")) order = "OrderByDescending";

            //定义一个TSource类型的变量，值为field
            ParameterExpression param = Expression.Parameter(typeof(TSource), field);
            //查找TSource中，是否有field这个公共变量
            PropertyInfo pi = typeof(TSource).GetProperty(field);

            //创建一个type数组，索引0保存所指向的实体类型，索引1保存得到的公共变量的类型
            Type[] types = new Type[2];
            types[0] = typeof(TSource);
            types[1] = pi.PropertyType;
            //生成Linq表达式树
            Expression expr = Expression.Call(typeof(Queryable), order, types, source.Expression, Expression.Lambda(Expression.Property(param, field), param));
            //执行Linq语句
            IQueryable<TSource> query = source.Provider.CreateQuery<TSource>(expr);

            return query;
        }


        /// <summary>
        /// 对数据进行排序，用于IQueryable<>类型
        /// </summary>
        /// <typeparam name="TSource">实体</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="field">排序字段</param>
        /// <param name="order">排序规则</param>
        /// <returns></returns>
        public static IQueryable<TSource> Sort<TSource>(this Task<IQueryable<TSource>> source, string field, string order) where TSource : class, new()
        {
            if (source.Result.Count() == 0) return source.Result;
            //如果传过来的是null或空的排序方式，则按照降序来排序
            if (string.IsNullOrEmpty(order)) order = "asc";

            if (order.Equals("asc")) order = "OrderBy";
            else if (order.Equals("desc")) order = "OrderByDescending";

            //定义一个TSource类型的变量，值为field
            ParameterExpression param = Expression.Parameter(typeof(TSource), field);
            //查找TSource中，是否有field这个公共变量
            PropertyInfo pi = typeof(TSource).GetProperty(field);

            //创建一个type数组，索引0保存所指向的实体类型，索引1保存得到的公共变量的类型
            Type[] types = new Type[2];
            types[0] = typeof(TSource);
            types[1] = pi.PropertyType;
            //生成Linq表达式树
            Expression expr = Expression.Call(typeof(Queryable), order, types, source.Result.Expression, Expression.Lambda(Expression.Property(param, field), param));
            //执行Linq语句
            IQueryable<TSource> query = source.Result.Provider.CreateQuery<TSource>(expr);

            return query;
        }
    }

    /// <summary>
    /// 分页的泛型类，用于定义返回的类型
    /// </summary>
    /// <typeparam name="T">实体</typeparam>
    public class IPageList<T>
    {
        /// <summary>
        /// 共多少页
        /// </summary>
        public int total { set; get; }

        /// <summary>
        /// 数据
        /// </summary>
        public List<T> data { set; get; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string message { set; get; }

        /// <summary>
        /// 加载状态码
        /// </summary>
        public int code { set; get; }

        /// <summary>
        /// 一共多少条数据
        /// </summary>
        public int count { set; get; }
    }
}
