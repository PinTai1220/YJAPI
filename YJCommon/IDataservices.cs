using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YJCommon
{
    /// <summary>
    /// 抽象类
    /// </summary>
    /// <typeparam name="TEntity">数据实例</typeparam>
    /// <typeparam name="CEntity">该继承类</typeparam>
    public abstract class IDataservices<TEntity, CEntity>
        where TEntity : class, new()
        where CEntity : class, new()
    {
        #region 单例模式

        private static CEntity _instance;
        private static object locker = new object();
        public static CEntity GetInstance()
        {
            if (_instance == null)
            {
                lock (locker)
                {
                    if (_instance == null)
                    {
                        _instance = new CEntity();
                    }
                }
            }
            return _instance;
        }

        #endregion


        public abstract int Create(TEntity t);
        public abstract int Delete(int id);
        public abstract int Update(TEntity t);
        public abstract TEntity ShowById(int id);
        public abstract List<TEntity> Show();
    }
}
