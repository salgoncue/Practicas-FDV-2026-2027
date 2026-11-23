# Práctica Cámara Cinemachine FUNDAMENTOS DEL DESARROLLO DE VIDEOJUEGOS
## Curso: 2026-2027
### Salvador González Cueto

---

## Apartado 1

Cámara sin zona muerta.
![Ejercicio_1_SinDeadZone.gif](media/Ejercicio_1_SinDeadZone.gif)

Cámara con zona muerta.
![Ejercicio_1_ConDeadZone.gif](media/Ejercicio_1_ConDeadZone.gif)

---

## Apartado 2

Cámara sin zona muerta con una zona de confinamiento del tamaño de la cámara.
![Ejercicio_2_SinDeadZone.gif](media/Ejercicio_2_SinDeadZone.gif)

Cámara con zona muerta con una de confinamiento del tamaño de la escena.
![Ejercicio_2_ConDeadZone.gif](media/Ejercicio_2_ConDeadZone.gif)

---

## Apartado 3

Se crea el script [InterpolateForCamera.cs](src/InterpolateForCamera.cs) para mover la cámara.

Cámara con 3 targets con el mismo peso.
![Ejercicio_3_1.gif](media/Ejercicio_3_1.gif)

Cámara con 2 targets con el distinto peso, el de la izquierda tiene 0.85 y el de la derecha 1.
![Ejercicio_3_2.gif](media/Ejercicio_3_2.gif)

---

## Apartado 4

Utilizando el script [CameraZoom.cs](src/CameraZoom.cs) se modifica el OrtographicSize para que utilice 180px de alto o 360px.
![Ejercicio_4.gif](media/Ejercicio_4.gif)

---

## Apartado 5

Utilizando el script [SwapCameras.cs](src/SwapCameras.cs) se puede cambiar la cámara activa mediante la prioridad utilizando el click derecho del ratón o mediante una función que se puede asignar a un botón de interfaz de usuario.

Mediante click derecho.
![Ejercicio_5_Input.gif](media/Ejercicio_5_Input.gif)

Mediante botón.
![Ejercicio_5_Button.gif](media/Ejercicio_5_Button.gif)

---

## Apartado 6

Utilizando el script [ModifyScaleTime.cs](src/ModifyScaleTime.cs) se modifica la escala para tener una cámara lenta o rápida según el tag del objeto con el que colisiona el jugador.

Cámara lenta.
![Ejercicio_6_Slow.gif](media/Ejercicio_6_Slow.gif)

Cámara rápida.
![Ejercicio_6_Fast.gif](media/Ejercicio_6_Fast.gif)

---

## Apartado 7

Utilizando el script [CollisionSwapCameras.cs](src/CollisionSwapCameras.cs) que funciona como [SwapCameras.cs](src/SwapCameras.cs) al colisionar el jugador con el objeto. La cámara cambia entre una cámara confinada y con zona muerta, y una cámara sin confinar y sin zona muerta.
![Ejercicio_7.gif](media/Ejercicio_7.gif)