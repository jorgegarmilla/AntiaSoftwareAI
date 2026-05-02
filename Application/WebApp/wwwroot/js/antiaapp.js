(function () {

    hideLoader();

    window.deleteElementById = function (id) {
        var element = document.getElementById(id);
        element.parentNode.removeChild(element);
    }
})();


function hideLoader() {

    var loader = document.getElementById('loadingdiv');
    var app = document.getElementById('app-container');

    if (!loader) {
        console.log('--> error: loader no encontrado');
        return;
    }

    if (!app) {
        console.log('--> error: app no encontrado');
        return;
    }

    // Hide the loader for any SSR-rendered content (app container is populated on the server).
    // For WASM pages (no prerendering) the container is empty at this point, so the loader
    // stays visible until WASM calls deleteElementById after it finishes loading.
    if (app.innerHTML && app.innerHTML.trim().length > 0) {
        loader.style.display = 'none';
    }
}

function isDevice() { return /android|webos|iphone|ipad|ipod|blackberry|iemobile|opera mini|mobile/i.test(navigator.userAgent); }