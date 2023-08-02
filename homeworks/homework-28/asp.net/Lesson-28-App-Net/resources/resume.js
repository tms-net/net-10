// EventHandler<TArgs>
document.addEventListener("DOMContentLoaded", function(evt) {
    console.log(evt);

    console.log('resume.js start');

    var headerElement = document.createElement("div");
    headerElement.className = "header";

    headerElement.addEventListener('click', function(evt) {
        console.log('header click');
        console.log(evt);
    });

    var bannerElement = document.createElement("div");
    bannerElement.className = "name-banner";
    
    var buttonElement = document.createElement("button");
    buttonElement.innerText = "Hello";

    buttonElement.addEventListener('click', function(evt) {
        console.log('button click');
        evt.stopPropagation();
        
        // если есть поведение по умолчанию
        evt.preventDefault();
    });

    var h1Element = document.createElement("h1");
    h1Element.innerHTML = "<strong><em>Глеб Радывонюк</em></strong>";

    var lineElement = document.createElement("div");
    lineElement.className = "line";
    
    lineElement.addEventListener('click', function() {
        console.log('line click');
    });

    lineElement.appendChild(buttonElement);

    bannerElement.appendChild(h1Element);
    bannerElement.appendChild(lineElement);

    headerElement.appendChild(bannerElement);

    console.log(document.body);

    document.body.appendChild(headerElement);

    console.log('resume.js end');

    // div
    //  div - нажатие мышки
    //      h1
    //      div
    //          button
});


