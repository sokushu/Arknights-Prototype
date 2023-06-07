using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Framework
{
    public class ObjectPool<PoolType>
    {
        private const int POOL_DEDAULT_SIZE = 128;
        private readonly static Dictionary<string, object> Pools = new Dictionary<string, object>();
        public static ObjectPool<PoolType> CreateNewPool(int poolSize = POOL_DEDAULT_SIZE)
        {
            string typeFullName = typeof(PoolType).FullName;
            if (Pools.TryGetValue(typeFullName, out object objPool))
            {
                ObjectPool<PoolType> result = (ObjectPool<PoolType>)objPool;
                if (poolSize != POOL_DEDAULT_SIZE)
                    result.ChangePoolSize(poolSize);
                return result;
            }
            ObjectPool<PoolType> pool = new ObjectPool<PoolType>(poolSize);
            Pools.Add(typeFullName, pool);
            return pool;
        }

        private PoolType[] __PoolType;

        private ObjectPool(int poolSize)
        {
            __PoolType = new PoolType[poolSize];
        }

        private void ChangePoolSize(int newSize)
        {
            PoolType[] poolTypes = new PoolType[newSize];
            Array.Copy(__PoolType, poolTypes, __PoolType.Length > poolTypes.Length ? poolTypes.Length : __PoolType.Length);
            __PoolType = poolTypes;
        }

        public void Add(PoolType poolType)
        {

        }

        public PoolType MakeNew()
        {
            return Activator.CreateInstance<PoolType>();
        }
    }
}
