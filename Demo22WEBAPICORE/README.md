# COMO HACER LOGIN

Haz login con tu endpoint /login.
(es email: admin password: 1234, ignora lo otro dejalo como esta)

Copia el token JWT que se devuelve.

En la parte superior de Swagger, haz clic en "Authorize" (debería aparecer un ícono de candado 🔒).

(Incluyendo la palabra Bearer y un espacio)

Haz clic en "Authorize" y luego "Close".

Ahora prueba el endpoint /protegido, y debe devolver 200 OK si el token es válido.