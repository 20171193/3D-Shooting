/******************************************************
 * <������Ʈ Ǯ��>
 * ����ϰ� ����ϴ� ������Ʈ�� ������� ���
 ** ����ϰ� ����/�����Ǵ� ������Ʈ �� 
 *
 * 
 * 
*******************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern
{
    public class ObjectPooler : MonoBehaviour
    {
        [SerializeField]
        private PooledObject prefab;
        private Stack<PooledObject> objectPool;

        [SerializeField]
        private int poolSize;

        public void CreatePool()
        {
            if (poolSize < 1)
            {
                Debug.Log("has not been allocated : poolSize");
                return;
            }

            objectPool = new Stack<PooledObject>(poolSize);

            for (int i = 0; i < poolSize; i++)
            {
                // Create pool
                PooledObject instance = Instantiate(prefab);
                instance.gameObject.SetActive(false);
                objectPool.Push(instance);
            }
        }

        public PooledObject GetPool()
        {
            // When retrieving from the pool, activate 
            if (objectPool.Count > 0)
            {
                PooledObject instance = objectPool.Pop();
                instance.gameObject.SetActive(true);
                return objectPool.Pop();
            }
            else
                return Instantiate(prefab);

        }

        public void ReturnPool(PooledObject instance)
        {
            // When returning to the pool, deactivate.
            instance.gameObject.SetActive(false);
            objectPool.Push(instance);
        }
    }

    public class PooledObject : MonoBehaviour
    {
        // This class with frequent creation and deletion.

    }
}