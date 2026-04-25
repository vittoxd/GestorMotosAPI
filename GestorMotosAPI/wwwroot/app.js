document.addEventListener("DOMContentLoaded", function () {

    const URL_API = "/api/Moto";
    const URL_API_MECANICOS = "/api/Mecanicos";

    // ==================== MOTOS ====================

    async function cargarMotos() {
        try {
            const respuesta = await fetch(URL_API);
            const Motos = await respuesta.json();
            const tabla = document.getElementById("cuerpo-tabla");
            tabla.innerHTML = "";

            Motos.forEach(moto => {
                const fila = `
            <tr>
                <td>${moto.id}</td>
                <td>${moto.rutDueno}</td>
                <td>${moto.marca}</td>
                <td>${moto.modelo}</td>
                <td>${moto.año}</td>
                <td>${moto.kilometraje} km</td>
                <td>
                    <button class="btn-accion btn-editar" onclick="prepararEdicion(${moto.id})">✏️</button>
                    <button class="btn-accion btn-eliminar" onclick="eliminarMoto(${moto.id})">🗑️</button>
                </td>
            </tr>`;
                tabla.innerHTML += fila;
            });
        } catch (error) {
            console.error("¡Rayos! Algo salió mal:", error);
        }
    }

    cargarMotos();

    const formulario = document.getElementById("formulario_moto");
    formulario.addEventListener("submit", async function (evento) {
        evento.preventDefault();

        const idMoto = document.getElementById("input-id").value;
        const marca = document.getElementById("input-marca").value;
        const modelo = document.getElementById("input-modelo").value;
        const anio = document.getElementById("input-anio").value;
        const kilometraje = document.getElementById("input-kilometraje").value;
        const rutIngresado = document.getElementById("input-rut").value;

        let metodo = "POST";
        let urlEnvio = URL_API;

        if (idMoto) {
            metodo = "PUT";
            urlEnvio = `${URL_API}/${idMoto}`;
        }

        if (!validarRut(rutIngresado)) {
            mostrarMensaje("RUT Inválido. Usa el formato 12345678-9", true);
            return;
        }

        const moto = {
            id: idMoto ? parseInt(idMoto) : 0,
            rutDueno: rutIngresado,
            marca: marca,
            modelo: modelo,
            año: parseInt(anio),
            kilometraje: parseInt(kilometraje)
        };

        try {
            const response = await fetch(urlEnvio, {
                method: metodo,
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(moto)
            });

            if (response.ok) {
                const textoMensaje = idMoto ? "Moto actualizada con éxito" : "Moto registrada con éxito";
                mostrarMensaje(textoMensaje);
                formulario.reset();
                document.getElementById("input-id").value = "";
                cargarMotos();
                const boton = document.querySelector("#formulario_moto button[type='submit']");
                boton.innerText = "REGISTRAR MOTO 🚀";
            } else {
                mostrarMensaje("Error al procesar la solicitud", true);
            }
        } catch (error) {
            console.error("Error:", error);
            mostrarMensaje("No se pudo conectar con el servidor", true);
        }
    });

    // Buscador de motos
    const inputBusqueda = document.getElementById('input-busqueda');
    const cuerpoTabla = document.getElementById('cuerpo-tabla');

    inputBusqueda.addEventListener('input', function () {
        const texto = inputBusqueda.value.toLowerCase();
        const filas = cuerpoTabla.getElementsByTagName('tr');

        for (let i = 0; i < filas.length; i++) {
            const rut = filas[i].getElementsByTagName('td')[1].innerText.toLowerCase();
            const marca = filas[i].getElementsByTagName('td')[2].innerText.toLowerCase();
            const modelo = filas[i].getElementsByTagName('td')[3].innerText.toLowerCase();

            filas[i].style.display = (rut.includes(texto) || marca.includes(texto) || modelo.includes(texto)) ? "" : "none";
        }
    });

    // ==================== MECÁNICOS ====================

    async function cargarMecanicos() {
        try {
            const respuesta = await fetch(URL_API_MECANICOS);
            const mecanicos = await respuesta.json();
            const tabla = document.getElementById("cuerpo-tabla-mecanicos");
            tabla.innerHTML = "";

            mecanicos.forEach(mecanico => {
                const fila = `
            <tr>
                <td>${mecanico.id}</td>
                <td>${mecanico.rut}</td>
                <td>${mecanico.nombre}</td>
                <td>${mecanico.especialidad}</td>
                <td>${mecanico.telefono}</td>
                <td>
                    <button class="btn-accion btn-editar" onclick="prepararEdicionMecanico(${mecanico.id})">✏️</button>
                    <button class="btn-accion btn-eliminar" onclick="eliminarMecanico(${mecanico.id})">🗑️</button>
                </td>
            </tr>`;
                tabla.innerHTML += fila;
            });
        } catch (error) {
            console.error("Error al cargar mecánicos:", error);
        }
    }

    cargarMecanicos();

    const btnRegistrarPersonal = document.querySelector("#formulario_personal button");
    btnRegistrarPersonal.addEventListener("click", async function (evento) {
        evento.preventDefault();

        const idMecanico = document.getElementById("input-id-mecanico").value;
        const rut = document.getElementById("input-rut-mecanico").value;
        const nombre = document.getElementById("input-nombre-mecanico").value;
        const especialidad = document.getElementById("select-especialidad").value;
        const telefono = document.getElementById("input-telefono-mecanico").value;

        if (!validarRut(rut)) {
            mostrarMensaje("RUT Inválido. Usa el formato 12345678-9", true);
            return;
        }

        let metodo = "POST";
        let urlEnvio = URL_API_MECANICOS;

        if (idMecanico) {
            metodo = "PUT";
            urlEnvio = `${URL_API_MECANICOS}/${idMecanico}`;
        }

        const mecanico = {
            id: idMecanico ? parseInt(idMecanico) : 0,
            rut: rut,
            nombre: nombre,
            especialidad: especialidad,
            telefono: telefono
        };

        try {
            const response = await fetch(urlEnvio, {
                method: metodo,
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(mecanico)
            });

            if (response.ok) {
                const textoMensaje = idMecanico ? "Mecánico actualizado con éxito ✅" : "Trabajador registrado con éxito ✅";
                mostrarMensaje(textoMensaje);
                document.getElementById("formulario_personal").reset();
                document.getElementById("input-id-mecanico").value = "";
                cargarMecanicos();
                const boton = document.querySelector("#formulario_personal button");
                boton.innerText = "REGISTRAR TRABAJADOR!";
            } else {
                mostrarMensaje("Error al procesar la solicitud", true);
            }
        } catch (error) {
            console.error("Error:", error);
            mostrarMensaje("No se pudo conectar con el servidor", true);
        }
    });

    // Buscador de mecánicos
    const inputBusquedaMecanico = document.getElementById('input-busqueda-mecanico');
    const cuerpoTablaMecanicos = document.getElementById('cuerpo-tabla-mecanicos');

    inputBusquedaMecanico.addEventListener('input', function () {
        const texto = inputBusquedaMecanico.value.toLowerCase();
        const filas = cuerpoTablaMecanicos.getElementsByTagName('tr');

        for (let i = 0; i < filas.length; i++) {
            const rut = filas[i].getElementsByTagName('td')[1].innerText.toLowerCase();
            const nombre = filas[i].getElementsByTagName('td')[2].innerText.toLowerCase();

            filas[i].style.display = (rut.includes(texto) || nombre.includes(texto)) ? "" : "none";
        }
    });

    // ==================== COMPARTIDO ====================

    function mostrarMensaje(texto, esError = false) {
        const caja = document.getElementById("notificacion");
        caja.innerText = texto;
        caja.style.display = "block";
        caja.style.backgroundColor = esError ? "#ffcccc" : "#ccffcc";
        caja.style.color = esError ? "#990000" : "#006600";
        caja.style.border = `1px solid ${esError ? "#990000" : "#006600"}`;

        setTimeout(() => {
            caja.style.display = "none";
        }, 3000);
    }

    function validarRut(rutCompleto) {
        if (!/^[0-9]+[-|‐]{1}[0-9kK]{1}$/.test(rutCompleto)) return false;
        let tmp = rutCompleto.split('-');
        let digv = tmp[1];
        let rut = tmp[0];
        digv = digv.toLowerCase();
        return (dv(rut) == digv);
    }

    function dv(cuerpoRut) {
        let M = 0, S = 1;
        for (; cuerpoRut; cuerpoRut = Math.floor(cuerpoRut / 10)) {
            S = (S + cuerpoRut % 10 * (9 - M++ % 6)) % 11;
        }
        return S ? S - 1 : 'k';
    }

}); // FIN DOMContentLoaded

// ==================== FUNCIONES GLOBALES ====================
// Estas van FUERA del DOMContentLoaded para que los onclick del HTML puedan accederlas

function mostrarSeccion(idSeccion, boton) {
    document.querySelectorAll('.seccion-app').forEach(sec => {
        sec.style.display = 'none';
    });
    document.getElementById(idSeccion).style.display = 'flex';
    document.querySelectorAll('.nav-btn').forEach(btn => {
        btn.classList.remove('active');
    });
    boton.classList.add('active');
}

async function prepararEdicion(id) {
    try {
        const respuesta = await fetch(`/api/Moto/${id}`);
        const moto = await respuesta.json();

        document.getElementById("input-id").value = moto.id;
        document.getElementById("input-rut").value = moto.rutDueno;
        document.getElementById("input-marca").value = moto.marca;
        document.getElementById("input-modelo").value = moto.modelo;
        document.getElementById("input-anio").value = moto.año;
        document.getElementById("input-kilometraje").value = moto.kilometraje;

        const boton = document.querySelector("#formulario_moto button[type='submit']");
        boton.innerText = "Actualizar Cambios 🔄";
        window.scrollTo(0, 0);
    } catch (error) {
        console.error("Error al cargar datos para edición:", error);
    }
}

async function eliminarMoto(id) {
    if (!confirm("¿Estás seguro de que quieres eliminar esta moto? 🧐")) return;

    try {
        const respuesta = await fetch(`/api/Moto/${id}`, { method: "DELETE" });

        if (respuesta.ok) {
            location.reload();
        } else {
            alert("No se pudo eliminar la moto ❌");
        }
    } catch (error) {
        console.error("Error al eliminar:", error);
    }
}

async function prepararEdicionMecanico(id) {
    try {
        const respuesta = await fetch(`/api/Mecanicos/${id}`);
        const mecanico = await respuesta.json();

        document.getElementById("input-id-mecanico").value = mecanico.id;
        document.getElementById("input-rut-mecanico").value = mecanico.rut;
        document.getElementById("input-nombre-mecanico").value = mecanico.nombre;
        document.getElementById("select-especialidad").value = mecanico.especialidad;
        document.getElementById("input-telefono-mecanico").value = mecanico.telefono;

        const boton = document.querySelector("#formulario_personal button");
        boton.innerText = "Actualizar Cambios 🔄";
        window.scrollTo(0, 0);
    } catch (error) {
        console.error("Error al cargar datos para edición:", error);
    }
}

async function eliminarMecanico(id) {
    if (!confirm("¿Estás seguro de que quieres eliminar este trabajador? 🧐")) return;

    try {
        const respuesta = await fetch(`/api/Mecanicos/${id}`, { method: "DELETE" });

        if (respuesta.ok) {
            location.reload();
        } else {
            alert("No se pudo eliminar el trabajador ❌");
        }
    } catch (error) {
        console.error("Error al eliminar:", error);
    }
}