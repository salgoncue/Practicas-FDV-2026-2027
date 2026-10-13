# Práctica Movimiento Rectilíneo Uniforme FUNDAMENTOS DEL DESARROLLO DE VIDEOJUEGOS
## Curso: 2026-2027
### Salvador González Cueto

---

## Apartado 1

Desarrollamos el script [TranslateScript.cs](src/TranslateScript.cs) el cual traslada el objeto al que se le incorpora el componente en una dirección dada por el inspector.

- Ejecutar la traslación una única vez en el Start con unos valores de {1,1,1}
![Desplazar en start](media/1_start.gif)

- Ejecutar la traslación en cada frame sin multiplicar los valores.
![Desplazar en update](media/1_update.gif)

- Ejecutar la traslación en cada frame habiendo multiplicado los valores por 0.5 en el Start una única vez.
![Desplazar en update por 0.5](media/1_start_0.5.gif)

- Ejecutar la traslación en cada frame multiplicando los valores por 0.5.
![Desplaza en update por 0.5 cada frame](media/1_update_0.5.gif)

- Ejecutar la traslación en cada frame multiplicando los valores por 2.0.
![Desplaza en update por 2.0 cada frame](media/1_update_2.0.gif)

- Ejecutar la traslación en cada frame por los valores {0,0,0.5}.
![Desplaza con la y 0](media/1_y_0.gif)

- Ejecutar la traslación en cada frame por los valores {0,0.5,0.5}
![Desplaza con la y 0.5](media/1_y_0.5.gif)

---

## Apartado 2

Con el desarrollo del script [TranslateSpeedScript.cs](src/TranslateSpeedScript.cs) conseguimos un script que permite desplazarse en una dirección con una velocidad variable medida en conjunto con el tiempo.

- Establecemos el valor de la velocidad y comprobamos que cambiar el vector no afecta porque esta normalizado.
![Traslacion con velocidad](media/2_Speed.gif)

---

## Apartado 3

Desarrollamos el script [TranslateLookScript.cs](src/TranslateLookScript.cs) con el objetivo de orientar el objeto al que se le adjunta el componente con respecto un objeto dado por el inpsector.

- Comprobamos el resultado sin especificar el espacio utilizado para la traslación resultando en un desplazamiento con respecto a las coordenadas locales.
![Traslacion con respecto las coordenadas locales](media/3_SpaceLocal.gif)

- Comprobamos el resultado especificando el espacio utilizado para la traslación resultando en un desplazamiento con respecto a las coordenadas mundiales.
![Traslacion con respecto las coordenadas mundiales](media/3_SpaceWorld.gif)

---

## Apartado 4

Mediante el script [TranslateRayLookScript.cs](src/TranslateRayLookScript.cs) añadimos un Gizmo que permite visualizar el vector dirección.
![Visualizacion del gizmo](media/4_ray.gif)

---

## Apartado 5

Añadimos el script [MoveScript.cs](src/MoveScript.cs) al cubo, el cual permite desplazar al cubo mediante interacción del usuario, permitiendo acelerar la capsula pulsando la tecla "Espacio".
![Desplazamos el cubo con el input](media/5_move.gif)

---

## Apartado 6

Modificamos el script resultando en [TranslateRayForwardLookScript.cs](src/TranslateRayForwardLookScript.cs) el cual ahora no utiliza una dirección calculada sino que desplaza el objeto hacia el frente de dicho objeto.
![Visualizacion del gizmo](media/6_forward.gif)

---

## Apartado 7

Añadimos al script un factor de tolerancia resultando en [TranslateRayForwardLookJitteringScript.cs](src/TranslateRayForwardLookJitteringScript.cs) con el fin de evitar el efecto jittering de la capsula al llegar al punto establecido.

- Efecto jittering.
![Jittering](media/7_jittering.gif)

- Traslación del objeto sin efecto jittering.
![Traslacion sin jittering](media/7_tolerance.gif)

---

## Apartado 8

Creamos el script [SlerpScript.cs](src/SlerpScript.cs) con el fin de rotar la capsula de forma suave.
![Slerp de la capsula](media/8_slerp.gif)

---

## Apartado 10

Creamos el script [WaypointTraveler.cs](src/WaypointTraveler.cs) el cual es similar a [TranslateRayForwardLookJitteringScript.cs](src/TranslateRayForwardLookJitteringScript.cs) solo que en lugar de tener un objeto como objetivo, tiene un array el cual se compone de waypoints, una vez alcanza uno, se dirige al siguiente.
![Waypoints](media/10_waypoints.gif)

---

## Apartado 11

Descargamos el archivo "Utility.rar" del campus y seguimos las intrucciones del campus, dando el siguiente resultado.
![Target](media/11_target.gif)