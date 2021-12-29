using System;
using System.Collections;
using UnityEngine;

namespace Controller
{
    public class URLController
    {
        public IEnumerator POST(Action<String> callback, String url, object[,] parameters)
        {
            var Data = new WWWForm();
            if (parameters.Length > 0)
            {
                for (int i = 0; i < parameters.GetLength(0); i++)
                {
                    if (parameters[i, 0] != null)
                    {
                        var name = parameters[i, 0].ToString();
                        var value = parameters[i, 1].ToString();
                        Data.AddField(name, value);
                    }
                }
            }

            var Query = new WWW(url, Data);
            yield return Query;

            if (Query.error != null)
            {
                Debug.Log("1 Server does not respond : " + Query.error);
            }
            else
            {
                if (Query.text == "response")
                {
                    Debug.Log("2 Server responded correctly");
                }
                else
                {
                    callback(Query.text);
                }
            }

            Query.Dispose();
        }
    }
}