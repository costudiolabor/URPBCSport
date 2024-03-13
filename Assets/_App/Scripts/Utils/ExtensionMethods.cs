using System;
using System.Collections;
using System.Linq;
using System.Threading;
using UnityEngine;

namespace FootballAR
{
    public static class ExtensionMethods
    {
        #region Coroutine Runner

        [ExecuteInEditMode]
        public class CoroutineRunner : MonoBehaviour
        {
            ~CoroutineRunner()
            {
                Destroy(gameObject);
            }
        }

        private static CoroutineRunner operation;

        private const HideFlags HIDE_FLAGS = HideFlags.DontSaveInEditor | HideFlags.HideInHierarchy |
                                             HideFlags.HideInInspector | HideFlags.NotEditable |
                                             HideFlags.DontSaveInBuild;

        public static Coroutine Run(this IEnumerator iEnumerator)
        {
            CoroutineRunner[] operations = Resources.FindObjectsOfTypeAll<CoroutineRunner>();
            if (operations.Length == 0)
            {
                operation = new GameObject("[CoroutineRunner]").AddComponent<CoroutineRunner>();
                operation.hideFlags = HIDE_FLAGS;
                operation.gameObject.hideFlags = HIDE_FLAGS;
            }
            else
            {
                operation = operations[0];
            }

            return operation.StartCoroutine(iEnumerator);
        }

        public static void Stop(this Coroutine coroutine)
        {
            if (operation != null)
            {
                operation.StopCoroutine(coroutine);
            }
        }

        #endregion
    }
}
