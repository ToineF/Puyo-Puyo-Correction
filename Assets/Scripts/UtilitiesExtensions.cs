using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AntoineFoucault.Utilities
{
    public static class MathExtentions
    {
        /// <summary>
        /// Normalize an angle between -180 and 180 degrees
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static float NormalizeAngle(this float a)
        {
            return a - 180f * Mathf.Floor((a + 180f) / 180f);
        }

        /// <summary>
        /// Correctly clamps an angle between a minimum and a maximum value
        /// </summary>
        /// <param name="current"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float ClampAngle(float current, float min, float max)
        {
            float dtAngle = Mathf.Abs(((min - max) + 180) % 360 - 180);
            float hdtAngle = dtAngle * 0.5f;
            float midAngle = min + hdtAngle;

            float offset = Mathf.Abs(Mathf.DeltaAngle(current, midAngle)) - hdtAngle;
            if (offset > 0)
                current = Mathf.MoveTowardsAngle(current, midAngle, offset);
            return current;
        }

        /// <summary>
        /// Returns the modulo of a postive or a negative integer
        /// </summary>
        /// <param name="x"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static int Modulo(this int x, int m)
        {
            return (x % m + m) % m;
        }
    }

    public static class VectorExtensions
    {
        #region Set One Param

        #region Vector3
        public static void SetX(this ref Vector3 v, float x)
        {
            v = new Vector3(x, v.y, v.z);
        }
        public static void SetY(this ref Vector3 v, float y)
        {
            v = new Vector3(v.x, y, v.z);
        }
        public static void SetZ(this ref Vector3 v, float z)
        {
            v = new Vector3(v.x, v.y, z);
        }
        #endregion

        #region Vector2
        public static void SetX(this ref Vector2 v, float x)
        {
            v = new Vector2(x, v.y);
        }
        public static void SetY(this ref Vector2 v, float y)
        {
            v = new Vector2(v.x, y);
        }
        #endregion

        #region Vector3Int
        public static void SetX(this ref Vector3Int v, int x)
        {
            v = new Vector3Int(x, v.y, v.z);
        }
        public static void SetY(this ref Vector3Int v, int y)
        {
            v = new Vector3Int(v.x, y, v.z);
        }
        public static void SetZ(this ref Vector3Int v, int z)
        {
            v = new Vector3Int(v.x, v.y, z);
        }
        #endregion

        #region Vector2Int
        public static void SetX(this ref Vector2Int v, int x)
        {
            v = new Vector2Int(x, v.y);
        }
        public static void SetY(this ref Vector2Int v, int y)
        {
            v = new Vector2Int(v.x, y);
        }
        #endregion

        #endregion

        #region Add One Param

        #region Vector3
        public static void AddX(this ref Vector3 v, float x)
        {
            v = new Vector3(v.x + x, v.y, v.z);
        }
        public static void AddY(this ref Vector3 v, float y)
        {
            v = new Vector3(v.x, v.y + y, v.z);
        }
        public static void AddZ(this ref Vector3 v, float z)
        {
            v = new Vector3(v.x, v.y, v.z + z);
        }
        #endregion

        #region Vector2
        public static void AddX(this ref Vector2 v, float x)
        {
            v = new Vector2(v.x + x, v.y);
        }
        public static void AddY(this ref Vector2 v, float y)
        {
            v = new Vector2(v.x, v.y + y);
        }
        #endregion

        #region Vector3Int
        public static void AddX(this ref Vector3Int v, int x)
        {
            v = new Vector3Int(v.x + x, v.y, v.z);
        }
        public static void AddY(this ref Vector3Int v, int y)
        {
            v = new Vector3Int(v.x, v.y + y, v.z);
        }
        public static void AddZ(this ref Vector3Int v, int z)
        {
            v = new Vector3Int(v.x, v.y, v.z + z);
        }
        #endregion

        #region Vector2Int
        public static void AddX(this ref Vector2Int v, int x)
        {
            v = new Vector2Int(v.x + x, v.y);
        }
        public static void AddY(this ref Vector2Int v, int y)
        {
            v = new Vector2Int(v.x, v.y + y);
        }
        #endregion

        #endregion

        #region Set Two Params

        #region Vector2
        public static void SetXX(this ref Vector2 v, Vector2 t)
        {
            v = new Vector2(t.x, t.x);
        }
        public static void SetYY(this ref Vector2 v, Vector2 t)
        {
            v = new Vector2(t.y, t.y);
        }
        public static void SetZZ(this ref Vector2 v, Vector3 t)
        {
            v = new Vector2(t.z, t.z);
        }
        public static void SetXY(this ref Vector2 v, Vector2 t)
        {
            v = new Vector2(t.x, t.y);
        }
        public static void SetYX(this ref Vector2 v, Vector2 t)
        {
            v = new Vector2(t.y, t.x);
        }
        public static void SetXZ(this ref Vector2 v, Vector3 t)
        {
            v = new Vector2(t.x, t.z);
        }
        public static void SetZX(this ref Vector2 v, Vector3 t)
        {
            v = new Vector2(t.z, t.x);
        }
        public static void SetYZ(this ref Vector2 v, Vector3 t)
        {
            v = new Vector2(t.y, t.z);
        }
        public static void SetZY(this ref Vector2 v, Vector3 t)
        {
            v = new Vector2(t.z, t.y);
        }
        #endregion

        #region Vector3
        public static void SetXX(this ref Vector3 v, Vector2 t)
        {
            v = new Vector2(t.x, t.x);
        }
        public static void SetYY(this ref Vector3 v, Vector2 t)
        {
            v = new Vector2(t.y, t.y);
        }
        public static void SetZZ(this ref Vector3 v, Vector3 t)
        {
            v = new Vector2(t.z, t.z);
        }
        public static void SetXY(this ref Vector3 v, Vector2 t)
        {
            v = new Vector2(t.x, t.y);
        }
        public static void SetYX(this ref Vector3 v, Vector2 t)
        {
            v = new Vector2(t.y, t.x);
        }
        public static void SetXZ(this ref Vector3 v, Vector3 t)
        {
            v = new Vector2(t.x, t.z);
        }
        public static void SetZX(this ref Vector3 v, Vector3 t)
        {
            v = new Vector2(t.z, t.x);
        }
        public static void SetYZ(this ref Vector3 v, Vector3 t)
        {
            v = new Vector2(t.y, t.z);
        }
        public static void SetZY(this ref Vector3 v, Vector3 t)
        {
            v = new Vector2(t.z, t.y);
        }
        #endregion

        #region Vector2Int
        public static void SetXX(this ref Vector2Int v, Vector2Int t)
        {
            v = new Vector2Int(t.x, t.x);
        }
        public static void SetYY(this ref Vector2Int v, Vector2Int t)
        {
            v = new Vector2Int(t.y, t.y);
        }
        public static void SetZZ(this ref Vector2Int v, Vector3Int t)
        {
            v = new Vector2Int(t.z, t.z);
        }
        public static void SetXY(this ref Vector2Int v, Vector2Int t)
        {
            v = new Vector2Int(t.x, t.y);
        }
        public static void SetYX(this ref Vector2Int v, Vector2Int t)
        {
            v = new Vector2Int(t.y, t.x);
        }
        public static void SetXZ(this ref Vector2Int v, Vector3Int t)
        {
            v = new Vector2Int(t.x, t.z);
        }
        public static void SetZX(this ref Vector2Int v, Vector3Int t)
        {
            v = new Vector2Int(t.z, t.x);
        }
        public static void SetYZ(this ref Vector2Int v, Vector3Int t)
        {
            v = new Vector2Int(t.y, t.z);
        }
        public static void SetZY(this ref Vector2Int v, Vector3Int t)
        {
            v = new Vector2Int(t.z, t.y);
        }
        #endregion

        #region Vector3Int
        public static void SetXX(this ref Vector3Int v, Vector2Int t)
        {
            v = new Vector3Int(t.x, t.x);
        }
        public static void SetYY(this ref Vector3Int v, Vector2Int t)
        {
            v = new Vector3Int(t.y, t.y);
        }
        public static void SetZZ(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.z, t.z);
        }
        public static void SetXY(this ref Vector3Int v, Vector2Int t)
        {
            v = new Vector3Int(t.x, t.y);
        }
        public static void SetYX(this ref Vector3Int v, Vector2Int t)
        {
            v = new Vector3Int(t.y, t.x);
        }
        public static void SetXZ(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.x, t.z);
        }
        public static void SetZX(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.z, t.x);
        }
        public static void SetYZ(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.y, t.z);
        }
        public static void SetZY(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.z, t.y);
        }
        #endregion


        #endregion

        #region Set Three Params

        #region Vector3
        public static void SetXXX(this ref Vector3 v, Vector3 t)
        {
            v = new Vector3(t.x, t.x, t.x);
        }
        public static void SetYYY(this ref Vector3 v, Vector3 t)
        {
            v = new Vector3(t.y, t.y, t.y);
        }
        public static void SetZZZ(this ref Vector3 v, Vector3 t)
        {
            v = new Vector3(t.z, t.z, t.z);
        }
        public static void SetYXX(this ref Vector3 v, Vector3 t)
        {
            v = new Vector3(t.y, t.x, t.x);
        }
        public static void SetXYX(this ref Vector3 v, Vector3 t)
        {
            v = new Vector3(t.x, t.y, t.x);
        }
        public static void SetXXY(this ref Vector3 v, Vector3 t)
        {
            v = new Vector3(t.x, t.x, t.y);
        }
        public static void SetZXX(this ref Vector3 v, Vector3 t)
        {
            v = new Vector3(t.z, t.x, t.x);
        }
        public static void SetXZX(this ref Vector3 v, Vector3 t)
        {
            v = new Vector3(t.x, t.z, t.x);
        }
        public static void SetXXZ(this ref Vector3 v, Vector3 t)
        {
            v = new Vector3(t.x, t.x, t.z);
        }
        public static void SetXYY(this ref Vector3 v, Vector3 t)
        {
            v = new Vector3(t.x, t.y, t.y);
        }
        public static void SetYXY(this ref Vector3 v, Vector3 t)
        {
            v = new Vector3(t.y, t.x, t.y);
        }
        public static void SetYYX(this ref Vector3 v, Vector3 t)
        {
            v = new Vector3(t.y, t.y, t.x);
        }
        public static void SetZYY(this ref Vector3 v, Vector3 t)
        {
            v = new Vector3(t.z, t.y, t.y);
        }
        public static void SetYZY(this ref Vector3 v, Vector3 t)
        {
            v = new Vector3(t.y, t.z, t.y);
        }
        public static void SetYYZ(this ref Vector3 v, Vector3 t)
        {
            v = new Vector3(t.y, t.y, t.z);
        }
        public static void SetXZZ(this ref Vector3 v, Vector3 t)
        {
            v = new Vector3(t.x, t.z, t.z);
        }
        public static void SetZXZ(this ref Vector3 v, Vector3 t)
        {
            v = new Vector3(t.z, t.x, t.z);
        }
        public static void SetZZX(this ref Vector3 v, Vector3 t)
        {
            v = new Vector3(t.z, t.z, t.x);
        }
        public static void SetYZZ(this ref Vector3 v, Vector3 t)
        {
            v = new Vector3(t.y, t.z, t.z);
        }
        public static void SetZYZ(this ref Vector3 v, Vector3 t)
        {
            v = new Vector3(t.z, t.y, t.z);
        }
        public static void SetZZY(this ref Vector3 v, Vector3 t)
        {
            v = new Vector3(t.z, t.z, t.y);
        }
        #endregion

        #region Vector3Int
        public static void SetXXX(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.x, t.x, t.x);
        }
        public static void SetYYY(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.y, t.y, t.y);
        }
        public static void SetZZZ(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.z, t.z, t.z);
        }
        public static void SetYXX(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.y, t.x, t.x);
        }
        public static void SetXYX(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.x, t.y, t.x);
        }
        public static void SetXXY(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.x, t.x, t.y);
        }
        public static void SetZXX(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.z, t.x, t.x);
        }
        public static void SetXZX(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.x, t.z, t.x);
        }
        public static void SetXXZ(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.x, t.x, t.z);
        }
        public static void SetXYY(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.x, t.y, t.y);
        }
        public static void SetYXY(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.y, t.x, t.y);
        }
        public static void SetYYX(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.y, t.y, t.x);
        }
        public static void SetZYY(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.z, t.y, t.y);
        }
        public static void SetYZY(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.y, t.z, t.y);
        }
        public static void SetYYZ(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.y, t.y, t.z);
        }
        public static void SetXZZ(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.x, t.z, t.z);
        }
        public static void SetZXZ(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.z, t.x, t.z);
        }
        public static void SetZZX(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.z, t.z, t.x);
        }
        public static void SetYZZ(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.y, t.z, t.z);
        }
        public static void SetZYZ(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.z, t.y, t.z);
        }
        public static void SetZZY(this ref Vector3Int v, Vector3Int t)
        {
            v = new Vector3Int(t.z, t.z, t.y);
        }
        #endregion

        #endregion

    }

    public static class CollectionsExtensions
    {
        public static T GetRandomItem<T>(this IList<T> list)
        {
            return list[UnityEngine.Random.Range(0, list.Count)];
        }

        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int index = UnityEngine.Random.Range(0, list.Count);
                list.ExchangeAt(index, i);
            }
            return list;
        }

        public static void ExchangeAt<T>(this IList<T> list, int i1, int i2)
        {
            T value = list[i1];
            list[i1] = list[i2];
            list[i2] = value;
        }

        public static int[] FindAllIndexof<T>(this IEnumerable<T> values, T val)
        {
            return values.Select((b, i) => object.Equals(b, val) ? i : -1).Where(i => i != -1).ToArray();
        }
    }

    public static class TransformExtensions
    {
        public static void ResetTransform(this Transform transform)
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        public static void SetTransform(this Transform transform, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            transform.position = position;
            transform.rotation = rotation;
            transform.localScale = scale;
        }

        public static void SetTransform(this Transform transform, Transform targetTransform)
        {
            transform.position = targetTransform.position;
            transform.rotation = targetTransform.rotation;
            transform.localScale = targetTransform.localScale;
        }
    }

    public static class GameObjectExtensions
    {
        /// <summary>
        /// ActivatesDeactivates all GameObjects from a IEnumerable, depending on the given true or false/ value.
        /// </summary>
        /// <param name="gameObjects"></param>
        /// <param name="value"></param>
        public static void SetAllActive(this IEnumerable<GameObject> gameObjects, bool value)
        {
            foreach (GameObject go in gameObjects)
            {
                go.SetActive(value);
            }
        }
        public static Transform Clear(this Transform transform)
        {
            while (transform.childCount > 0)
            {
                GameObject.Destroy(transform.GetChild(0).gameObject);
            }
            return transform;
        }

        public static Transform ClearImmediate(this Transform transform)
        {
            while (transform.childCount > 0)
            {
                GameObject.DestroyImmediate(transform.GetChild(0).gameObject);
            }

            return transform;
        }
    }

    public static class LayerExtensions
    {
        public static bool IsInLayerMask(int layer, LayerMask layermask)
        {
            return layermask == (layermask | (1 << layer));
        }
    }

    public static class GizmoExtensions
    {
        public static void DrawSphereCast(Vector3 origin, float radius, Vector3 direction, float maxDistance, Color? color = null)
        {
            color = color ?? Color.white;
            Gizmos.color = (Color)color;
            Gizmos.DrawWireSphere(origin, radius);
            Gizmos.DrawLine(origin, origin + direction * maxDistance);
            Gizmos.DrawWireSphere(origin + direction * maxDistance, radius);
        }
    }
}