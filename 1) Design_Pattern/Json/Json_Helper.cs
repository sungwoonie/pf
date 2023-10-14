using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Json_Helper
{
    public static T[] FromJson<T>(string json)
    {
        Data_To_Json<T> data = JsonUtility.FromJson<Data_To_Json<T>>(json);
        return data.datas;
    }

    public static string ToJson<T>(T[] array)
    {
        Data_To_Json<T> data = new Data_To_Json<T>();
        data.datas = array;
        return JsonUtility.ToJson(data);
    }

    [System.Serializable]
    private class Data_To_Json<T>
    {
        public T[] datas;
    }
}
