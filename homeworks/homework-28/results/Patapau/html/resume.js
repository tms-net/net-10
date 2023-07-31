// Используйте объект document для поиска и создания элементов DOM
// Используйте объекты Element для создания дерева DOM
// Используйте свойство style объектов Element для изменения стилей
function myResume() {
    // Personal Block
    var personalBlock = document.createElement("div");
    
    var personalHeader = document.createElement("h2");
    var personalHeaderTextNode = document.createTextNode("Личные данные");
    personalHeader.appendChild(personalHeaderTextNode);

    var name = document.createElement("p");
    var nameTextNode = document.createTextNode("Имя: Дмитрий Потапов");
    name.appendChild(nameTextNode);

    var email = document.createElement("p");
    var emailTextNode = document.createTextNode("Почта: potapov@gmail.com");
    email.appendChild(emailTextNode);
    
    personalBlock.appendChild(personalHeader);
    personalBlock.appendChild(name);
    personalBlock.appendChild(email);



    // Work block
    var workBlock = document.createElement("div");
  
    var workHeader = document.createElement("h2");
    var workHeaderTextNode = document.createTextNode("Опыт работы");
    workHeader.appendChild(workHeaderTextNode);

    var job = document.createElement("p");
    var jobTextNode = document.createTextNode("Должность: Системный администратор");
    job.appendChild(jobTextNode);

    var company = document.createElement("p");
    var companyTextNode = document.createTextNode("Место работы: ООО \"CKC\"");
    company.appendChild(companyTextNode);

    var responsibilities = document.createElement("p");
    var responsibilitiesTextNode = document.createTextNode("Обязанности: Обеспечение бесперебойной работы автоматизированных рабочих мест");
    responsibilities.appendChild(responsibilitiesTextNode);

    workBlock.appendChild(workHeader);
    workBlock.appendChild(job);
    workBlock.appendChild(company);
    workBlock.appendChild(responsibilities);



    // Education block
    var educationBlock = document.createElement("div");

    var educationHeader = document.createElement("h2");
    var educationTextNode = document.createTextNode("Образование");
    educationHeader.appendChild(educationTextNode);

    var institution = document.createElement("p");
    var institutionTextNode = document.createTextNode("Учебное заведение: Белорусско-Российский университет");
    institution.appendChild(institutionTextNode);

    var specialization = document.createElement("p");
    var specializationTextNode = document.createTextNode("Специализация: Автоматизированные системы обработки и отображения информации");
    specialization.appendChild(specializationTextNode);

    educationBlock.appendChild(educationHeader);
    educationBlock.appendChild(institution);
    educationBlock.appendChild(specialization);







    //About me block
    var aboutMeBlock = document.createElement("div");
    
    var aboutMeHeader = document.createElement("h2");
    var aboutMeTextNode = document.createTextNode("О себе");
    aboutMeHeader.appendChild(aboutMeTextNode);


    var aboutMe = document.createElement("p");
    var aboutTextNode = document.createTextNode("Увлекаюсь игрой на гитаре, чтением книг.");
    aboutMe.appendChild(aboutTextNode);

    aboutMeBlock.appendChild(aboutMeHeader);
    aboutMeBlock.appendChild(aboutMe);










    var rootElement = document.querySelector(".root");
    rootElement.appendChild(personalBlock);
    rootElement.appendChild(workBlock);
    rootElement.appendChild(educationBlock);
    rootElement.appendChild(aboutMeBlock);

  
    rootElement.style.flexDirection = "column"; 
    rootElement.style.textAlign = "center"; 



    personalHeader.style.color = 'blue'; 
    name.style.fontWeight = 'bold'; 
    name.style.display = 'inline-block';
    email.style.textDecoration = 'underline'; 

    workHeader.style.color = 'green'; 
    job.style.fontStyle = 'italic'; 

    educationHeader.style.color = 'purple'; 

    aboutMeHeader.style.backgroundColor = 'yellow'; 
 

    name.setAttribute('class', 'my-class');
    name.style.backgroundColor = 'gray';
    aboutMeBlock.style.display = 'inline-block';
}


document.addEventListener("DOMContentLoaded", myResume);