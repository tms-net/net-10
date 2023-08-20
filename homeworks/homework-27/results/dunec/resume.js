document.addEventListener("DOMContentLoaded", function(ev) {

    var headerElement = document.createElement("div");
    headerElement.className = "Header";
    document.body.appendChild(headerElement);

    var h1Element = document.createElement("h1");
    h1Element.innerHTML = "Я - это Я";
    h1Element.style.fontWeight = "bold";
    headerElement.appendChild(h1Element);
    
    var imgElement = document.createElement("img");
    imgElement.src = "https://sun9-12.userapi.com/impg/h-853cgIALoQXEpOzRVSCgfU812qw8JDFXgACA/o1Bv-gMPfQQ.jpg?size=420x519&quality=96&sign=81ed34673bfbbf5ff337ccccfe4bdbf0&type=album"; 
    imgElement.width = "126";
    imgElement.height = "156";
    headerElement.appendChild(imgElement);   

    var bodyElement = document.createElement("div");
    bodyElement.className = "Body";
    document.body.appendChild(bodyElement);

    var addressElement = document.createElement("div");
    addressElement.className = "Address";    
    bodyElement.appendChild(addressElement);

    var addressTitleElement = document.createElement("h3");
    addressTitleElement.style.fontWeight = "bold";
    addressTitleElement.innerHTML = "Адрес";
    addressElement.appendChild(addressTitleElement);

    var adressSectionLeft = document.createElement("section");
    adressSectionLeft.style.display = "table";
    adressSectionLeft.style.float = "left";
    adressSectionLeft.style.marginRight = "10px";
    addressElement.appendChild(adressSectionLeft);
    
    var adressTextElementLeft = document.createElement("p");
    adressTextElementLeft.innerHTML = "<b>Город:</b><p><b>Улица:</b><p><b>№ здания:</b>";
    adressSectionLeft.appendChild(adressTextElementLeft);

    var adressSectionRight = document.createElement("section");
    adressSectionRight.style.display = "table";
    adressSectionRight.style.clear = "";
    addressElement.appendChild(adressSectionRight);

    var adressTextElementRight = document.createElement("p");
    adressTextElementRight.innerHTML = "тот, в котором я и живу<p>та, на которой стоит дом, в котором я и живу<p>такой, в каком я снимаю квартиру";
    adressSectionRight.appendChild(adressTextElementRight);

    var contactsElement = document.createElement("div");
    contactsElement.className = "Contacts";
    bodyElement.appendChild(contactsElement);    
    
    var contactsTitleElement = document.createElement("h3");
    contactsTitleElement.style.fontWeight = "bold";
    contactsTitleElement.innerHTML = "Контакты";
    contactsElement.appendChild(contactsTitleElement);

    var contactsSectionLeft = document.createElement("section");
    contactsSectionLeft.style.display = "table";
    contactsSectionLeft.style.float = "left";
    contactsSectionLeft.style.marginRight = "10px";
    contactsElement.appendChild(contactsSectionLeft);

    var contactsTextElement = document.createElement("p");
    contactsTextElement.innerHTML = "<b>Телефон:</b><p><b>E-mail:</b>";
    contactsSectionLeft.appendChild(contactsTextElement);
    
    var contactsSectionRight = document.createElement("section");
    contactsSectionRight.style.display = "table";
    contactsSectionRight.style.clear = "";
    contactsElement.appendChild(contactsSectionRight);

    var contactsTextElement = document.createElement("p");
    contactsTextElement.innerHTML = "тот, с которого я звоню<p>тот, который я и использую";
    contactsSectionRight.appendChild(contactsTextElement);
    
    var experienceElement = document.createElement("div");
    experienceElement.className = "Experience";
    bodyElement.appendChild(experienceElement);

    var experienceTitleElement = document.createElement("h3");
    experienceTitleElement.style.fontWeight = "bold";
    experienceTitleElement.innerHTML = "Опыт";
    experienceElement.appendChild(experienceTitleElement);

    var experienceSectionLeft = document.createElement("section");
    experienceSectionLeft.style.display = "table";
    experienceSectionLeft.style.float = "left";
    experienceSectionLeft.style.marginRight = "10px";
    experienceElement.appendChild(experienceSectionLeft);

    var experiencetextElement = document.createElement("p");
    experiencetextElement.innerHTML = "<b>Школа:</b><p><b>Университет:</b><p><b>Работа:</b>";
    experienceSectionLeft.appendChild(experiencetextElement);
    
    var experienceSectionRight = document.createElement("section");
    experienceSectionRight.style.display = "table";
    experienceSectionRight.style.clear = "";
    experienceElement.appendChild(experienceSectionRight);

    var experiencetextElement = document.createElement("p");
    experiencetextElement.innerHTML = "та, которую я закончил<p>тот, из которого я выпустился<p>5 лет как под наркозом я работал <s>говновозом</s> на таможне, ой-ой-ой..., не программистом, не сисадмином, а <s>вонючим говночистом</s> старшим инспектором, ой-ой-ой...";
    experienceSectionRight.appendChild(experiencetextElement);

}
);



// Используйте объект document для поиска и создания элементов DOM
// Используйте объекты Element для создания дерева DOM
// Используйте свойство style объектов Element для изменения стилей