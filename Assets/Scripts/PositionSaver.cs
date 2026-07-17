

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
namespace DefaultNamespace
{
 public class PositionSaver : MonoBehaviour        //сохранение позиции
 {

[Serializable]
  public struct Data  
  {
   public Vector3 Position;
   public float Time;
  }

  
[SerializeField, ReadOnlyAttribute, Tooltip("Для заполнения этого поля воспользуйтесь контекстным меню и командой 'Create File'")]
  private TextAsset _json;

[field: SerializeField, HideInInspector]                         
  public List<Data> Records { get; private set; }       //список Записи

  private void Awake()
  {

   //todo comment: Что будет, если в теле этого условия не сделать выход из метода?
   if (_json == null)    //-будет бесконечная проверка на существование json
   {
    gameObject.SetActive(false);
    Debug.LogError("Please, create TextAsset and add in field _json");
    return;
   }

                        //из перезаписи Json
   JsonUtility.FromJsonOverwrite(_json.text, this);   
                                                         //todo comment: Для чего нужна эта проверка (что она позволяет избежать)?
   if (Records == null)     
    Records = new List<Data>(10);                     //Ответ: это проверка для предотвращения ошибки.

  }

  

  private void OnDrawGizmos()  
  {
   //todo comment: Зачем нужны эти проверки (что они позволляют избежать)?
   if (Records == null || Records.Count == 0) return;//-Эти проверки помогают извежать ошибки 
   var data = Records;                               //-и выходят из условия в случае отсутствия элемента!
   var prev = data[0].Position;

   Gizmos.color = Color.green;
   Gizmos.DrawWireSphere(prev, 0.3f);

   //todo comment: Почему итерация начинается не с нулевого элемента?
   //-чтоб можно было сравнить с прошлым значением 0==1, 1==2, 2==3

   for (int i = 1; i < data.Count; i++)
   {
    var curr = data[i].Position;
    Gizmos.DrawWireSphere(curr, 0.3f);
    Gizmos.DrawLine(prev, curr);
    prev = curr;
   }
  }
  

#if UNITY_EDITOR

  [ContextMenu("Create File")]
  private void CreateFile()
  {
   //todo comment: Что происходит в этой строке?
   var stream = File.Create(Path.Combine(Application.dataPath, "Path.txt"));

   //todo comment: Подумайте для чего нужна эта строка? (а потом проверьте догадку, закомментировав) 
         //-создает файл Path.txt в папке Assets и дает возможность туда записываать и переменная stream отвечает за это.
                   

   stream.Dispose();
   UnityEditor.AssetDatabase.Refresh();

   //В Unity можно искать объекты по их типу, для этого используется префикс "t:"
   //После нахождения, Юнити возвращает массив гуидов (которые в мета-файлах задаются, например)

   var guids = UnityEditor.AssetDatabase.FindAssets("t:TextAsset");
   foreach (var guid in guids)
   {
    //Этой командой можно получить путь к ассету через его гуид
    var path = UnityEditor.AssetDatabase.GUIDToAssetPath(guid);
    //Этой командой можно загрузить сам ассет
    var asset = UnityEditor.AssetDatabase.LoadAssetAtPath<TextAsset>(path);
    //todo comment: Для чего нужны эти проверки?
    if(asset != null && asset.name == "Path")   //проверка на существование файла
    {
     _json = asset;
     UnityEditor.EditorUtility.SetDirty(this);
     UnityEditor.AssetDatabase.SaveAssets();
     UnityEditor.AssetDatabase.Refresh();
     //todo comment: Почему мы здесь выходим, а не продолжаем итерироваться?
     return;  //-файл найден и дальнейший поиск лишний 
    }
   }
  }

 

private void OnDestroy()
{
    
    if (_json != null)
    {
        string json = JsonUtility.ToJson(this, true);
        File.WriteAllText(AssetDatabase.GetAssetPath(_json), json);
  AssetDatabase.Refresh();
    }
}

#endif
 }
}