window.onload = function(){

var h1 = document.createElement("h1");
var nameHeader = document.createTextNode("Nikita Kachura");
h1.appendChild(nameHeader);

var contactsP = document.createElement("p");
var h2 = document.createElement("h2");
var contactHeader = document.createTextNode("Contacts");
h2.appendChild(contactHeader);

var boldPhone = document.createElement("b");
var phoneText = document.createTextNode("phone: ")
boldPhone.appendChild(phoneText);

var number = document.createTextNode("+37529123456789\n");

contactsP.appendChild(h2);
contactsP.appendChild(boldPhone);
contactsP.appendChild(number);

var h2Header = document.createElement("h2");
h2Header.appendChild(document.createTextNode("WORK EXPERIENCE"));

var experienceP = document.createElement("p");
var boldJob = document.createElement("b");
boldJob.appendChild(document.createTextNode("QA Engineer"));

var br = document.createElement("br");

var boldProject = document.createElement("b");
boldProject.appendChild(document.createTextNode("Project: "));

var projectDescription = document.createTextNode("A real-time streaming web application that allows remote observers receive streams from robot-surgeon cameras.");

experienceP.appendChild(boldJob);
experienceP.appendChild(br);
experienceP.appendChild(boldProject);
experienceP.appendChild(projectDescription);

document.body.append(h1,contactsP, h2Header, experienceP)

}
