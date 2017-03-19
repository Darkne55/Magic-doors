using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	public enum RotationAxes { 
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}
	public float sensitivityHor = 9.0f; 
	public float sensitivityVert = 9.0f; // Объявляем переменные, задающие поворот в вертикальной плоскости.
	public float minimumVert = -35.0f;
	public float maximumVert = 35.0f;
	private float _rotationX = 0; // Объявляем закрытую переменную для угла поворота по вертикали.

	public RotationAxes axes = RotationAxes.MouseXAndY; // Объявляем общедоступную переменную, которая появится в редакторе Unity.
	
     void Start() {
         //Отключаем влияние среды на человека
         Rigidbody body = GetComponent<Rigidbody>();
         if (body != null) // Проверяем, существует ли этот компонент.
         body.freezeRotation = true;
    }
    void Update() {
		if (axes == RotationAxes.MouseX) {
			// это поворот в горизонтальной плоскости
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
		}
		else if (axes == RotationAxes.MouseY) {
			// это поворот в вертикальной плоскости
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert; 
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0); 
		}
		else {
			// это комбинированный поворот  Сюда поместим код для комбинированного вращения.
             _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
             _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
             float delta = Input.GetAxis("Mouse X") * sensitivityHor; 
             float rotationY = transform.localEulerAngles.y + delta; 
             transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            
             
            
		}   
       

	}
}
