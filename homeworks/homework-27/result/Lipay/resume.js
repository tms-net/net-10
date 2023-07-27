// Используйте объект document для поиска и создания элементов DOM
// Используйте объекты Element для создания дерева DOM
// Используйте свойство style объектов Element для изменения стилей
var document = new Document();
var elemByID = Document.getElementById('info_name');
var elemSelector = Document.querySelector();
var elemByTagName = Document.getElementsByTagName('div');

let div = document.createElement('div');
div.className = "alert";
div.innerHTML = "<strong>Всем привет!</strong> Вы прочитали важное сообщение.";
info_name.append(div);
