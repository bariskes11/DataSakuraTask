using UnityEngine;
using System.Collections;
using UnityEngine.Pool;
using System;

public abstract class PoolerBase<T> : MonoBehaviour where T : MonoBehaviour
{
    private T prefab;
    private ObjectPool<T> pool;
    private ObjectPool<T> pooler
    {
        get
        {
            if (pool == null) throw new InvalidOperationException("Call InitPoolFirst");
            return pool;
        }
        set { pool = value; }
    }
    protected void InitPool(T prefab, int initialNumber, int max, bool collectionChecks = true)
    {
        this.prefab = prefab;
        this.pooler = new ObjectPool<T>(
            CreateSetup,
            GetSetup,
            ReleaseSetup,
            DestroySetup,
            collectionChecks,
            initialNumber,
            max);
    }

    #region Overrides
    private  T CreateSetup() => Instantiate(prefab);
    private  void GetSetup(T obj)
    {
        obj.gameObject.SetActive(true);
        obj.transform.position = Vector3.zero;

    }
    protected virtual void ReleaseSetup(T obj) => obj.gameObject.SetActive(false);
    protected virtual void DestroySetup(T obj) => Destroy(obj);
    #endregion
    #region Getters
    public T Get() => pooler.Get();
    public void Release(T obj) => pooler.Release(obj);
    #endregion
}

