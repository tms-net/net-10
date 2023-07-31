// Используйте объект document для поиска и создания элементов DOM
// Используйте объекты Element для создания дерева DOM
// Используйте свойство style объектов Element для изменения стилей
const bodyElement = document.body;
const firstChildNode = bodyElement.firstChild;
const lastChildNode = bodyElement.lastChild;

const childNodes = bodyElement.childNodes;

console.log(childNodes);

console.log(firstChildNode);
console.log(lastChildNode);

console.log(bodyElement.hasChildNodes());

for(let node of childNodes) {
    console.log(node);
}

const bodyChildren = bodyElement.children;
console.log(bodyChildren);

const element1 = document.querySelectorAll('.main_info');
console.log(element1);

const element2 = document.querySelectorAll('.info_contacts');
console.log(element2);

const element3 = document.querySelectorAll('.footer_content');
console.log(element3);

const elementById = document.getElementById('info_name');
console.log(elementById);

const subItems = element2[0].querySelectorAll("li");
console.log(subItems);


//var document = new Document();
//var elemByID = Document.getElementById('info_name');
//var elemSelector = Document.querySelector();
//var elemByTagName = Document.getElementsByTagName('div');

const element4 = document.querySelector('.info_name');
const newElement = document.createElement('div');
newElement.className = 'alert';
newElement.innerHTML = '<strong>Всем привет!</strong> Вы прочитали важное сообщение.';
element4.append(newElement);
setTimeout(() => newElement.remove(), 1000);
    




//console.log(newElement);
const element5 = document.querySelector('.side_info');
const newText = document.createTextNode('Hello!');
//element5.before(newText);
console.log(newText);

element4.style.color = "red";

//const cloneNewElement = element1.cloneNode();
//element4.after(cloneNewElement);


//newElement.remove();