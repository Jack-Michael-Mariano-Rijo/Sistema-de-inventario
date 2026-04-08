# 📌 Sistema de Inventario con Arquitectura por Capas

## 📖 Descripción

Este proyecto consiste en el desarrollo de un **Sistema de Inventario** implementado con **arquitectura por capas**, utilizando **C#**, **.NET**, **SQL Server** y desarrollado en **Visual Studio Community**.

El sistema incluye un **módulo de inicio de sesión**, el cual permite validar el acceso de los usuarios antes de utilizar las funcionalidades del sistema.

Una vez dentro, el usuario puede realizar **movimientos de productos**, los cuales se dividen en:

* **Entradas de productos:**
  Se registra el ingreso de productos al inventario, seleccionando un **proveedor**, lo que permite aumentar automáticamente el stock.

* **Salidas de productos:**
  Se registra la salida de productos, seleccionando un **cliente**, lo que reduce el stock disponible en el inventario.

Además, el sistema genera un **reporte de movimientos**, donde se registran todas las operaciones realizadas, mostrando la siguiente información:

* Usuario que realizó el movimiento
* Tipo de movimiento (entrada o salida)
* Proveedor o cliente
* Producto
* Cantidad
* Fecha del movimiento

Este sistema permite llevar un control organizado del inventario, aplicando buenas prácticas de desarrollo mediante la separación en capas: **Presentación (UI), Lógica de Negocio (BLL) y Acceso a Datos (DAL)**.

---

## 🛠 Tecnologías Utilizadas

* **Lenguaje:** C#
* **Framework:** .NET
* **Base de datos:** SQL Server
* **IDE:** Visual Studio Community

---

## 🏗 Arquitectura por Capas

El sistema está dividido en las siguientes capas:

### 🔹 Capa de Presentación (UI)

Encargada de la interfaz gráfica y la interacción con el usuario (formularios, login, movimientos, reportes).

### 🔹 Capa de Negocio (BLL)

Contiene la lógica del sistema, validaciones y reglas para el manejo del inventario.

### 🔹 Capa de Datos (DAL)

Gestiona la conexión con la base de datos y realiza las operaciones CRUD.

---

## ⚙ Funcionalidades del Sistema

* Inicio de sesión de usuarios
* Registro de entradas de productos
* Registro de salidas de productos
* Control automático de stock
* Selección de proveedor o cliente según el tipo de movimiento
* Generación de reportes de movimientos

---

## ▶ Uso o Ejecución

1. Clonar el repositorio.
2. Abrir el proyecto en **Visual Studio Community**.
3. Configurar la cadena de conexión a **SQL Server**.
4. Ejecutar la aplicación.
5. Iniciar sesión y comenzar a gestionar el inventario.

---

## 🎓 Contexto Académico

* **Nivel:** Secundaria Técnico Profesional
* **Módulo Formativo:** Desarrollo de Aplicaciones
* **Proyecto:** Sistema de Inventario por Capas
* **Año escolar:** 2026

---
<img width="485" height="456" alt="Captura de pantalla 2026-04-08 110159" src="https://github.com/user-attachments/assets/15843d04-deba-4257-b41a-c5be182e8477" />
<img width="1156" height="785" alt="Captura de pantalla 2026-04-08 110213" src="https://github.com/user-attachments/assets/6c32c8fa-99ff-45fd-9514-9ee89241d863" />
<img width="1153" height="789" alt="Captura de pantalla 2026-04-08 110220" src="https://github.com/user-attachments/assets/c2d6f5d9-1aee-4f29-832c-d5c323361dca" />
<img width="1162" height="787" alt="Captura de pantalla 2026-04-08 110226" src="https://github.com/user-attachments/assets/90c46a57-d7db-4a25-8abf-f80c9f5aa1fb" />
<img width="1156" height="780" alt="Captura de pantalla 2026-04-08 110233" src="https://github.com/user-attachments/assets/48056482-e5d2-4ad6-83fc-072fcd816841" />
<img width="1156" height="780" alt="Captura de pantalla 2026-04-08 110233" src="https://github.com/user-attachments/assets/48056482-e5d2-4ad6-83fc-072fcd816841" />
<img width="879" height="636" alt="Captura de pantalla 2026-04-08 110250" src="https://github.com/user-attachments/assets/d91e5dbe-cc20-4d91-929b-5c6c13a4f93d" />
<img width="879" height="636" alt="Captura de pantalla 2026-04-08 110250" src="https://github.com/user-attachments/assets/d91e5dbe-cc20-4d91-929b-5c6c13a4f93d" />

---
## 👤 Autor

**Jack Michael**
