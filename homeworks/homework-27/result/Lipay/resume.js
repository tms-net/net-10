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

const newElement = document.createElement('div');
div.className = "alert";
div.innerHTML = "<strong>Всем привет!</strong> Вы прочитали важное сообщение.";
elementById.append(div);

