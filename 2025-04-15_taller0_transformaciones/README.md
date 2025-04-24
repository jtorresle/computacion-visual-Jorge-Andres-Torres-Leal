# Prompts

Para realizar los proyectos se hizo uso de la IA de ChatGPT en su versión GPT-4o, y para obtener los codigos y algunas explicaciones que terminaron por nutrir las descripciones se usaron los siguientes prompts:

## Prompt Python

💻 Python (Colab o Jupyter Notebook)
Herramientas: matplotlib, numpy, imageio
Crear una figura 2D con puntos o formas
Aplicar traslación, rotación y escala usando matrices de transformación
Generar una animación (usando bucles o interpolación)
Animar la transformación en función del tiempo (t) o del frame
Exportar como GIF animado con imageio
Opcional: mostrar la matriz resultante de cada transformación y cómo cambia con el tiempo

----------------------------------------------------------------------------------------------------------------------

## Prompt Threejs
Escenario:
Crear un proyecto con Vite y React Three Fiber
Agregar un objeto 3D (cubo o esfera)
Aplicar animaciones con useFrame para:
Trasladar el objeto por una trayectoria senoidal o circular
Rotarlo sobre su propio eje con incremento en cada frame
Escalarlo suavemente con una función temporal (Math.sin(clock.elapsedTime))
Bonus: incluir OrbitControls para navegar la escena


----------------------------------------------------------------------------------------------------------------------
## Prompt Processing

La siguiente tarea debe ser realizada en Processing:

Escenario:
Crear un sketch simple (2D o 3D)
Dibujar una figura geométrica (rect, ellipse o box)
Aplicar transformaciones usando:
translate(), rotate(), scale()
pushMatrix() y popMatrix() para aislar transformaciones
frameCount, millis() o sin() para crear transformaciones en el tiempo
Ejemplo: un cubo que gira, se traslada de forma ondulada y se escala cíclicamente en función del tiempo transcurrido

--------------------------------
## Prompt Unity 

Ayúdame con lo siguiente:

🎮 Unity (versión LTS)(Opcional)
Escenario:
Crear un proyecto vacío en 3D
Agregar un cubo o esfera a la escena
Crear un script en C# que aplique:
Traslación aleatoria por eje X o Y cada ciertos segundos
Rotación constante dependiente de Time.deltaTime
Escalado oscilante en función de Mathf.Sin(Time.time)
Requisitos: usar transform.Translate(), transform.Rotate(), transform.localScale

--------------------------------
# Threejs

Este proyecto utiliza **React Three Fiber** para crear una escena 3D interactiva con un objeto (cubo) que tiene animaciones aplicadas. Las animaciones incluyen:

- **Traslación aleatoria** (movimiento oscilante a lo largo del eje X).
- **Rotación continua** sobre el eje Y.
- **Escalado oscilante** en función de la función temporal `Math.sin`.

Además, se integra el control de cámara mediante **OrbitControls** para permitir la navegación interactiva en la escena.

---

## 🚀 Requisitos

Para ejecutar este proyecto, asegúrate de tener instalado:

- **Node.js** (v16 o superior).
- **npm** (v7 o superior).

---

## 🔧 Instalación

1. Clona este repositorio o crea un nuevo proyecto en Vite:
   ```bash
   git clone <repositorio-url>
   cd <nombre-del-proyecto>
   ```

2. Instala las dependencias:
   ```bash
   npm install
   ```

---

## 📂 Estructura del Proyecto

El proyecto tiene la siguiente estructura básica:

```
/src
  /App.jsx         // Componente principal con la escena 3D y animaciones.
  /index.js        // Punto de entrada de la aplicación.
  /styles.css      // Estilos de la aplicación.
```

---

## 🎮 Descripción del Código

### 1. **Componente `AnimatedBox`**

Este componente define un **cubo 3D** (usando `boxGeometry`) que tiene animaciones aplicadas a su **posición**, **rotación** y **escala**:

- **Traslación en el eje X**: El cubo se mueve de manera oscilante a lo largo del eje X utilizando una función seno de `elapsedTime`:
  ```javascript
  ref.current.position.x = Math.sin(state.clock.elapsedTime) * 2;
  ```

- **Rotación constante en el eje Y**: El cubo gira sobre su propio eje Y con cada **frame** usando `delta`:
  ```javascript
  ref.current.rotation.y += delta;
  ```

- **Escalado oscilante**: La escala del cubo varía de forma suave usando `Math.sin(state.clock.elapsedTime)`:
  ```javascript
  ref.current.scale.set(
    1 + Math.sin(state.clock.elapsedTime) * 0.5,
    1 + Math.sin(state.clock.elapsedTime) * 0.5,
    1 + Math.sin(state.clock.elapsedTime) * 0.5
  );
  ```

### 2. **Componente `App`**

El componente `App` configura el **Canvas** de **React Three Fiber** donde la escena 3D es renderizada. En él se integran los siguientes elementos:

- **`<Canvas>`**: Contenedor donde se renderiza la escena 3D.
- **`<ambientLight>` y `<spotLight>`**: Fuentes de luz para iluminar la escena.
- **`<OrbitControls />`**: Permite a los usuarios navegar por la escena interactuando con el ratón.
- **Componente `AnimatedBox`**: El cubo animado es renderizado aquí.

---

## 📜 Cómo Ejecutar el Proyecto

1. Ejecuta el servidor de desarrollo:
   ```bash
   npm run dev
   ```

2. Abre tu navegador y accede a [http://localhost:3000](http://localhost:3000) para ver la escena en vivo.

---

## 📦 Paquetes Usados

Este proyecto utiliza los siguientes paquetes de Node.js:

- **React**: Biblioteca para construir interfaces de usuario.
- **React Three Fiber**: Biblioteca para trabajar con **Three.js** dentro de **React**.
- **Three.js**: Biblioteca de JavaScript para gráficos 3D.
- **@react-three/drei**: Herramientas útiles para React Three Fiber, incluyendo **OrbitControls**.

---

# Python

## 🔧 Descripción del Código

### 1. **Definición de la Figura:**
   Se crea un **triángulo equilátero** en 2D utilizando **NumPy**. Los vértices del triángulo se definen en coordenadas cartesianas.

   ```python
   triangle = np.array([
       [0, 0],
       [1, 0],
       [0.5, np.sqrt(3)/2],
       [0, 0]  # Para cerrar el triángulo
   ]).T  # Transponemos para que las columnas sean puntos (2 x N)
   ```

### 2. **Matrices de Transformación:**
   - **Traslación:** Mueve el triángulo a lo largo de los ejes **X** y **Y**.
   - **Rotación:** Rota el triángulo alrededor de su centro.
   - **Escalado:** Cambia el tamaño del triángulo.

   Estas transformaciones se definen con funciones que devuelven las matrices correspondientes:

   ```python
   def translation_matrix(tx, ty):
       return np.array([
           [1, 0, tx],
           [0, 1, ty],
           [0, 0, 1]
       ])
   ```

### 3. **Conversión a Coordenadas Homogéneas:**
   Las coordenadas 2D se convierten a **coordenadas homogéneas** (agregando una tercera dimensión), necesarias para trabajar con matrices de transformación.

   ```python
   def to_homogeneous(points):
       return np.vstack([points, np.ones((1, points.shape[1]))])
   ```

   Luego, las coordenadas homogéneas se convierten nuevamente a 2D después de aplicar las transformaciones:

   ```python
   def from_homogeneous(points_h):
       return points_h[:2, :] / points_h[2, :]
   ```

### 4. **Generación de la Animación:**
   Se generan **60 frames** donde cada uno aplica una combinación de transformaciones (traslación, rotación y escalado) a lo largo del tiempo. Cada frame se guarda como una imagen PNG.

   ```python
   for t in range(num_frames):
       tt = t / num_frames
       tx = 2 * np.sin(2 * np.pi * tt)
       ty = 2 * np.cos(2 * np.pi * tt)
       theta = 2 * np.pi * tt
       sx = 1 + 0.5 * np.sin(2 * np.pi * tt)
       sy = 1 + 0.5 * np.cos(2 * np.pi * tt)
   ```

### 5. **Creación y Guardado de los Frames:**
   Cada frame se guarda como un archivo PNG en una carpeta temporal llamada `frames`. Luego, todos los frames se combinan en un archivo **GIF** usando `imageio`.

   ```python
   imageio.mimsave("animacion_transformaciones.gif", frames, duration=0.05)
   ```

---

## 🧠 Explicación de la Animación

- **Traslación Senoidal:** El triángulo se mueve de manera oscilante a lo largo de los ejes X y Y, siguiendo una trayectoria senoidal.
- **Rotación Continua:** El triángulo gira continuamente sobre su propio eje.
- **Escalado Oscilante:** El triángulo aumenta y disminuye su tamaño suavemente con el tiempo.

# Processing

## 🚀 Descripción del Proyecto

El proyecto crea una animación en 3D utilizando **Processing**, donde un cubo realiza las siguientes animaciones:

- **Movimiento ondulado**: el cubo se traslada a lo largo de los ejes X e Y siguiendo una trayectoria senoidal y cosenoidal.
- **Rotación constante**: el cubo rota sobre los ejes X e Y de manera constante.
- **Escalado cíclico**: el cubo cambia de tamaño de forma oscilante utilizando una función seno.

La escena se ilumina para mejorar la visualización 3D.

---

## 🛠️ Descripción del Código

### 1. **`setup()`**:
   - Se configura el lienzo en modo **3D** con un tamaño de 600x600 píxeles.
   - Se desactiva el contorno de los objetos con `noStroke()` para que el cubo sea completamente sólido.

```java
void setup() {
  size(600, 600, P3D); // Modo 3D
  noStroke();
}
```

### 2. **`draw()`**:
   - Se establece un fondo oscuro para la escena.
   - Se activa la luz ambiental con `lights()` para iluminar los objetos en 3D.
   - Se calcula el tiempo en segundos con `millis()` para animar el cubo de forma dinámica.

```java
void draw() {
  background(30);  // Fondo oscuro
  lights();        // Luz para mejor visualización 3D
  float t = millis() / 1000.0; // Tiempo en segundos
```

### 3. **Movimiento Ondulado**:
   - Se utiliza **`sin(t)`** y **`cos(t)`** para mover el cubo en las coordenadas **X** y **Y** con un movimiento ondulado.

```java
// Coordenadas de movimiento ondulado
float x = sin(t) * 100;
float y = cos(t * 1.5) * 75;
```

### 4. **Escalado Cíclico**:
   - Se aplica un **escalado cíclico** utilizando **`Math.sin(t)`** para aumentar y reducir el tamaño del cubo de manera oscilante.

```java
// Escalado cíclico
float scaleFactor = 1 + 0.5 * sin(t * 2);
```

### 5. **Transformaciones**:
   - **`pushMatrix()`** y **`popMatrix()`** se usan para aislar las transformaciones del cubo (traslación, rotación, escalado), de modo que no afecten a otros objetos que puedan añadirse en el futuro.
   
   - Se aplica una **traslación** al cubo para centrarlo en la pantalla y moverlo con las coordenadas calculadas.

```java
pushMatrix(); // Aislar transformaciones
translate(width / 2 + x, height / 2 + y, 0); // Mover al centro + onda
```

### 6. **Rotación**:
   - Se aplica rotación al cubo sobre los ejes **X** y **Y**, en función del tiempo, para dar el efecto de movimiento continuo.

```java
rotateX(t);  // Rotación sobre el eje X
rotateY(t * 1.2); // Rotación sobre el eje Y
```

### 7. **Dibujo del Cubo**:
   - Se dibuja un cubo con el tamaño 100x100x100 usando `box(100)` y se le aplica un color **morado** con `fill()`.

```java
fill(150, 100, 255); // Color morado
box(100); // Dibujar cubo
```

---

## 🧠 Explicación de la Animación

- **Movimiento Ondulado**: El cubo se mueve siguiendo una trayectoria **senoidal y cosenoidal**, creando un **efecto de onda**.
- **Rotación**: El cubo rota sobre los ejes **X** y **Y** de forma continua.
- **Escalado**: El cubo cambia de tamaño de forma oscilante, haciendo que parezca que **crece y se reduce** con el tiempo.

# Unity


## 🚀 Descripción del Proyecto

Animar un objeto 3D dentro de Unity mediante transformaciones sencillas. El objeto realiza las siguientes acciones:

- **Rotación constante** sobre el eje Y.
- **Escalado oscilante** utilizando la función **`Mathf.Sin(Time.time)`**.
- **Traslación aleatoria** sobre los ejes **X** o **Y** cada cierto intervalo de tiempo.

---

## 🔧 Descripción del Código

### 1. **Variables públicas**
   - **`velocidadRotacion`**: Controla la velocidad de rotación del objeto sobre el eje Y.
   - **`intervaloMovimiento`**: Define cada cuántos segundos el objeto se mueve aleatoriamente.
   - **`distanciaMovimiento`**: Controla la distancia máxima que el objeto puede recorrer en un solo movimiento.
   - **`escalaOriginal`**: Guarda la escala inicial del objeto para luego poder aplicarle el escalado oscilante.

### 2. **Método `Start()`**
   - Se inicializa la **escala original** del objeto para poder aplicar transformaciones sin afectar su tamaño original.

   ```csharp
   void Start()
   {
       escalaOriginal = transform.localScale;
   }
   ```

### 3. **Método `Update()`**
   Se ejecuta cada frame y contiene las animaciones del objeto:

   - **Rotación constante**:  
     Se usa `transform.Rotate()` para hacer que el objeto rote alrededor del eje Y a una velocidad constante definida por **`velocidadRotacion`**.

     ```csharp
     transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
     ```

   - **Escalado oscilante**:  
     Usamos la función `Mathf.Sin(Time.time)` para crear un factor de escala que oscile entre 0.7 y 1.3, haciendo que el objeto crezca y se reduzca suavemente.

     ```csharp
     float factorEscala = 0.3f * Mathf.Sin(Time.time) + 1f;
     transform.localScale = escalaOriginal * factorEscala;
     ```

   - **Traslación aleatoria**:  
     Cada cierto tiempo (definido por **`intervaloMovimiento`**), el objeto se mueve aleatoriamente sobre los ejes **X** o **Y** usando `transform.Translate()`. El **tiempoTranscurrido** se reinicia cada vez que el movimiento se realiza.

     ```csharp
     if (tiempoTranscurrido >= intervaloMovimiento)
     {
         Vector3 direccion = Vector3.zero;
         if (Random.value > 0.5f)
             direccion = Vector3.right;
         else
             direccion = Vector3.up;

         transform.Translate(direccion * distanciaMovimiento);
         tiempoTranscurrido = 0f;
     }
     ```

---

## 🧠 Explicación de las Funciones

### **`transform.Rotate()`**:
Rotación del objeto sobre los ejes **X**, **Y** o **Z**. En este caso, solo afecta al eje **Y** para hacer que el objeto gire constantemente.

### **`Mathf.Sin()`**:
Esta función matemática produce un valor entre **-1 y 1** a medida que **`Time.time`** avanza, lo que permite crear un **efecto de oscilación** en el escalado.

### **`transform.Translate()`**:
Mueve el objeto en el espacio. En este caso, la dirección del movimiento es aleatoria entre el eje **X** o **Y** cada cierto tiempo, y la distancia es controlada por **`distanciaMovimiento`**.
