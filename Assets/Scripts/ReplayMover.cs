using System;
using UnityEngine;

namespace DefaultNamespace
{
 [RequireComponent(typeof(PositionSaver))]   //требовать компонент
 public class ReplayMover : MonoBehaviour
 {
  private PositionSaver _save;

  private int _index;
  private PositionSaver.Data _prev;
  private float _duration;   //продолжительность

  private void Start()
  {
   ////todo comment: зачем нужны эти проверки?     -убедиться о наличие обьекта как и раньше, чтоб избежать ошибки.
   if (!TryGetComponent(out _save) || _save.Records.Count == 0)
   {
    Debug.LogError("Records incorrect value", this);
    //todo comment: Для чего выключается этот компонент? -чтоб сохранить другие компоненты активными
    enabled = false;
   }
  }

  private void Update()
  {
   var curr = _save.Records[_index];
   //todo comment: Что проверяет это условие (с какой целью)? -настало ли время пря перехода на другую позицию
   if (Time.time > curr.Time)
   {
    _prev = curr;
    _index++;
    //todo comment: Для чего нужна эта проверка? -проверить не воспроизвели ли мы все записи
    if (_index >= _save.Records.Count)
    {
     enabled = false;
     Debug.Log($"<b>{name}</b> finished", this);
    }
   }
   //todo comment: Для чего производятся эти вычисления (как в дальнейшем они применяются)?
   var delta = (Time.time - _prev.Time) / (curr.Time - _prev.Time); //-проверяет и записывает прошлое время и текущее для плавного перехода 

   //todo comment: Зачем нужна эта проверка?  
   if (float.IsNaN(delta)) delta = 0f;
   //todo comment: Опишите, что происходит в этой строчке так подробно, насколько это возможно
   transform.position = Vector3.Lerp(_prev.Position, curr.Position, delta);  //-где объект был и где он будет
  }
 }
}