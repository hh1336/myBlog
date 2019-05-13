using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frame.WebCore.Redis
{
    /// <summary>
    /// Redis帮助类
    /// </summary>
    public static class RedisHelper
    {
        /// <summary>
        /// redis链接对象
        /// </summary>
        private static IRedisClient redisClient;

        public static void Connection(string constr)
        {
            var redisManger = new RedisManagerPool(constr);      //Redis的连接字符串
            redisClient = redisManger.GetClient();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static async Task Add(string key, string value)
        {
            try
            {
                await Task.FromResult(redisClient.Add(key, value));
            }
            catch (Exception e)
            {

                throw new Exception("添加数据异常，错误为 ：" + e.Message);
            }

        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static async Task<string> FindByKey(string key)
        {
            var result = await Task.FromResult(redisClient.GetValue(key));
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static async Task<bool> DelByKey(string key)
        {
            return await Task.FromResult(redisClient.Remove(key));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static async Task<bool> Update(string key, string value)
        {
            return await Task.FromResult(redisClient.Set(key, value));
        }

    }
}
