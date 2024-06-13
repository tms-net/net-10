# Javascript
Создайте свое резюме (или переиспользуйте результат своего задания выполненного на занятии), используя Javascript и возможность изменять Объектную Модель Документов (DOM).

**Пример структуры DOM**
- Блок личных данных
    - имя
    - почта

- Блок опытк работы
    - Работа 1
        - Должность
        - Место работы
        - Обязанности
    - Работа 2
        - Должность
        - Место работы
        - Обязанности

- Блок образования
    - Образование 1
        - Учебное заведение
        - Специализация
    - Образование 2
        - Учебное заведение
        - Специализация

- О себе

**Выполнение задания**
Для написания кода Javascript используйте файл `resume.js`. Для проверки задания откройте файл `resume.html` в браузере.

При выполнении задания используйте методы DOM API браузера (объекты типов `Document` - https://developer.mozilla.org/ru/docs/Web/API/Document, `Node` - https://developer.mozilla.org/ru/docs/Web/API/Element, `Element` - https://developer.mozilla.org/ru/docs/Web/API/Node):
  - Поиск элементов: 
    - `Document.querySelector()`
    - `Document.getElementById()`
    - `Document.getElementsByTagName()`

  - Создание элементов: 
    - `Document.createElement()`
    - `document.createTextNode()`

  - Добавление и удаление элементов:
    - `Element.appendChild()`
    - `Element.remove()`
    - `Node.removeChild()`

  - Манипуляция стилями (`HTMLElement.style` - https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement/style)
    - `element.style.color = 'white'`
    - `element.setAttribute('class', 'my-class')`;

## Подтверждение выполнения

 - Создайте ветку (`branch`) в репозитории https://github.com/tms-net/net-10 с именем '{ФАМИЛИЯ}/{ОПИСАНИЕ_ЗАДАНИЯ}', например 'andrienko/lesson-4-oop'

 - Ветка должна быть создана на основе последней версии ветки `main`

 - Поместите свой проект в папку, соответствующую шаблону './homeworks/homework-{НОМЕР-ДЗ}/results/{ФАМИЛИЯ}'

 - Сделайте коммит (`commit`) в ветке с нужным набором изменений и соответствующим комментарием. Например, коммит после создания проекта 'Added console project' (на любом языке)

 - Отправьте изменения в удаленный репозиторий (`push`) и создайте `pull request` в ветку `main`

 - Один `pull request` должен соответствовать одному Домашнему Заданию