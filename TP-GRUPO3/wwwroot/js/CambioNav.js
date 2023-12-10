document.addEventListener('DOMContentLoaded', function (event) {

    switch (window.location.pathname) {

        case '/Usuario':
            document.getElementById('usuarioNav').style.fontWeight = 'bold';
            break;

        case '/Producto':
            document.getElementById('prodNav').style.fontWeight = 'bold';
            break;

        case '/Home/Privacy':
            document.getElementById('privNav').style.fontWeight = 'bold';
            break;

        case '/Carrito':
            document.getElementById('carritoNav').style.fontWeight = 'bold';
            break;
    }
});