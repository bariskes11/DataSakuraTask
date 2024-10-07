using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


/// <summary>
///  this is for setting up follow distance  manually 
/// </summary>
public class PlayerFollowModifier : MonoBehaviour
{
    [Header("This is a simple modifier to configure enemy follow distance.")]
    [SerializeField] private float distanceVal=1F;
    [SerializeField] private float yOffset = 1F;
    [SerializeField] private Transform playerTransform;

    private void Awake()
    {
        // remove component on run
        Destroy(this);
    }

    private List<PlayerFollowGuide> GetFollowGuideCubes()
    {
      return  this.gameObject.GetComponentsInChildren<PlayerFollowGuide>().ToList();
    }

    [ContextMenu("Set Distance Values")]
    public void SetValues()
    {
        List<PlayerFollowGuide> followerCubes = GetFollowGuideCubes();
        if (followerCubes == null)
        {
#if UNITY_EDITOR
            Debug.LogError("There is no guide cube to iterate...");
#endif

            return;
        }

        foreach (PlayerFollowGuide cube in followerCubes)
        {
            Vector3 val = cube.transform.localPosition;
            float muliplayerx = val.x > 0 ? 1 : -1;
            float muliplayerz = val.z > 0 ? 1 : -1;
            float newX = val.x == 0 ? 0 : distanceVal;
            float newz = val.z == 0 ? 0 : distanceVal;
            Vector3 result = new Vector3(newX * muliplayerx, yOffset, newz * muliplayerz);
            cube.transform.localPosition = result;
            if (playerTransform != null)
                cube.transform.LookAt(playerTransform);
        }
    }
}