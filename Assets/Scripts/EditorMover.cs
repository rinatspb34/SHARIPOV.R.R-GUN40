using UnityEngine;

namespace DefaultNamespace
{
 
 [RequireComponent(typeof(PositionSaver))]
 public class EditorMover : MonoBehaviour     //редактор двигает 
 {
  private PositionSaver _save;    //сохранитель позиции
  private float _currentDelay;    //текущая задержка 
  
  //todo comment: Что произойдёт, если _delay > _duration?     //возможно условие кода не успеет выполниться из-за длинной задержки

  [SerializeField][Range(0.2f, 1.0f)]           //
  private float _delay = 0.5f;   

           //задержка  
   [SerializeField][Range(0.2f, 5f)]
  private float _duration = 5f;     //продолжительность

  private void Start()
  {
   //todo comment: Почему этот поиск производится здесь, а не в начале метода Update?
   _save = GetComponent<PositionSaver>();  //чтоб не вызывать эту операцию постоянно, а лишь вначале 
   _save.Records.Clear();

   if (_duration <= _delay)               //
            {
              _duration = _delay * 5f;
         }

  }

  private void Update()
  {
   

   _duration -= Time.deltaTime;     //уменьшаем пока не кончится
   if (_duration <= 0f)
   {
    enabled = false;        
    Debug.Log($"<b>{name}</b> finished", this);
    return;
   }
   
   //todo comment: Почему не написать (_delay -= Time.deltaTime;) по аналогии с полем _duration?
   _currentDelay -= Time.deltaTime;   // потому что delay это фиксированное значение и не должно уменьшаться
   if (_currentDelay <= 0f)
   {
    _currentDelay = _delay;
    _save.Records.Add(new PositionSaver.Data
    {
     Position = transform.position,
     //todo comment: Для чего сохраняется значение игрового времени?   //для точности и корректной работы
     Time = Time.time,
    });
   }
  }
 }
}