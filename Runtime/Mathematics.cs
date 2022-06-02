using System.Collections.Generic;
using UnityEngine;

namespace SimpleMan.Utilities
{
    public static class Methematics
    {
        public static T GetClosest<T>(Vector3 point, IEnumerable<T> collection) where T : Component
        {
            return GetClosest(point, collection, out float distance);
        }

        public static T GetClosest<T>(Vector3 point, IEnumerable<T> collection, out float distanceToClosestObject) where T : Component
        {
            if (collection == null)
                throw new System.ArgumentNullException("Collection");

            T closestObject = null;
            distanceToClosestObject = float.MaxValue;
            float distance;
            foreach (var item in collection)
            {
                distance = Vector3.Distance(point, item.transform.position);
                if (distance < distanceToClosestObject)
                {
                    distanceToClosestObject = distance;
                    closestObject = item;
                }
            }

            return closestObject;
        }

        public static Vector2[] GetPointsOnCircle(float radius, int pointsCount)
        {
            return GetPointsOnCircle(Vector3.zero, radius, pointsCount);
        }

        public static Vector2[] GetPointsOnCircle(Vector2 center, float radius, int pointsCount)
        {
            Vector2[] points = new Vector2[pointsCount];


            float degrees = 360;
            float angle = 360 / pointsCount;


            for (int i = 0; i < pointsCount; i++)
            {
                points[i] = center + new Vector2((float)Mathf.Cos((degrees) * Mathf.Deg2Rad) * radius, (float)Mathf.Sin((degrees) * Mathf.Deg2Rad) * radius);
                degrees -= angle;
            }


            return points;
        }

        public static Vector2 GetPointOnCircle(float radius, float angle)
        {
            return GetPointOnCircle(Vector2.zero, radius, angle);
        }

        public static Vector2 GetPointOnCircle(Vector2 center, float radius, float angle)
        {
            return new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad) * radius, Mathf.Cos(angle * Mathf.Deg2Rad) * radius) + center;
        }
    }
}