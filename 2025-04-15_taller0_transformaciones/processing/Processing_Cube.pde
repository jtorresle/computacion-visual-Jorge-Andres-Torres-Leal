void setup() {
  size(600, 600, P3D); // Modo 3D
  noStroke();
}

void draw() {
  background(30);
  lights(); // Luz para mejor visualización 3D

  float t = millis() / 1000.0; // Tiempo en segundos

  // Coordenadas de movimiento ondulado
  float x = sin(t) * 100;
  float y = cos(t * 1.5) * 75;
  
  // Escalado cíclico
  float scaleFactor = 1 + 0.5 * sin(t * 2);
  
  pushMatrix(); // Aislar transformaciones

  // Mover al centro + onda
  translate(width / 2 + x, height / 2 + y, 0);

  // Rotaciones
  rotateX(t);
  rotateY(t * 1.2);
  
  // Escalado
  scale(scaleFactor);

  // Dibujar cubo
  fill(150, 100, 255);
  box(100);

  popMatrix();
}
