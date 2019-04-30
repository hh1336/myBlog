using Frame.WebCore.LoginManager.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Frame.WebCore.User
{
    public static class UserManager
    {
        /// <summary>
        /// 保存用户信息的管道
        /// </summary>
        private static Dictionary<string, LoginVerificationResultDto> UserInfoMiddleware = new Dictionary<string, LoginVerificationResultDto>();

        /// <summary>
        /// 记录保存的用户信息的过期时间
        /// </summary>
        private static Dictionary<string, DateTime> MonitorUserInfo = new Dictionary<string, DateTime>();

        /// <summary>
        /// 用于中间调度
        /// </summary>
        private static List<string> Log = new List<string>();

        /// <summary>
        /// 设置用户自动退出时间
        /// </summary>
        private static int OutTime;

        /// <summary>
        /// 添加一个用户信息
        /// </summary>
        /// <param name="data"></param>
        public static async Task Add(LoginVerificationResultDto data)
        {
            try
            {
                lock (UserInfoMiddleware)
                {
                    UserInfoMiddleware.TryAdd(data.AccountNumber, data);
                }
                lock (MonitorUserInfo)
                {
                    MonitorUserInfo.TryAdd(data.AccountNumber, DateTime.Now.AddMinutes(OutTime));
                }



                //Thread thread = new Thread(s => RemoveInfoToMinute(data.AccountNumber));
                //thread.Start();

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        /// <summary>
        /// 删除MonitorUserInfo
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static async Task RemoveMonitorUserInfo(string key)
        {
            try
            {
                if (MonitorUserInfo.ContainsKey(key))
                {
                    lock (MonitorUserInfo)
                    {
                        MonitorUserInfo.Remove(key);
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// 删除管道中用户的信息
        /// </summary>
        /// <param name="UserInfoKey"></param>
        /// <returns></returns>
        public static async Task RemoveInfo(string UserInfoKey)
        {
            try
            {
                if (UserInfoMiddleware.ContainsKey(UserInfoKey))
                {
                    lock (UserInfoMiddleware)
                    {
                        UserInfoMiddleware.Remove(UserInfoKey);
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// 根据key获取用户信息
        /// </summary>
        /// <param name="UserInfoKey"></param>
        /// <returns></returns>
        public static async Task<LoginVerificationResultDto> Get(string UserInfoKey)
        {
            try
            {
                if (UserInfoMiddleware.ContainsKey(UserInfoKey))
                {
                    return await Task.FromResult(UserInfoMiddleware[UserInfoKey]);
                }
            }
            catch (Exception)
            {

            }
            return new LoginVerificationResultDto() { ResultBool = false };
        }

        /// <summary>
        /// 获取当前登陆的人数
        /// </summary>
        /// <returns></returns>
        public static async Task<int> LoginCount()
        {
            return await Task.FromResult(UserInfoMiddleware.Count);
        }

        /// <summary>
        /// 监控登陆的用户数据
        /// </summary>
        /// <returns></returns>
        public static async Task Monitor(int outTime = 30)
        {
            OutTime = outTime;
            bool isStart = true;
            //每20秒扫描是否有过期的用户信息
            while (isStart)
            {
                foreach (var item in MonitorUserInfo)
                {
                    if (DateTime.Now >= MonitorUserInfo[item.Key])
                    {
                        await RemoveInfo(item.Key);

                        Log.Add(item.Key);
                    }
                }
                foreach (var item in Log)
                {
                    await RemoveMonitorUserInfo(item);
                }
                Log.RemoveRange(0, Log.Count);
                System.Threading.Thread.Sleep(10000);
            }
        }
    }
}
