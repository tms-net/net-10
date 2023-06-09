﻿# Основы C# - Делегаты и события
В продолжение темы изучения взаимодействия между компонентами с помощью делегатов и событий, предлагается разработать программу, которая имитирует торговую платформу.

Функционал программы разбит на 3 группы, каждую из которых выполняет одна команда.

**UI - Пользовательский интерфейс**

    - Основной символ (тикер) -> ввод пользователя
         - Текущее значение цены
         - Информация по символу

    - Сопутствующие символы
        - Значение
        - Изменение (↑ | ↓)

    - Возможность изменения частоты InfoUpdated += (Handler)
    - Функции над данными

Основная часть работы должна выполняться в методе `Main()` ([Program.cs](./sample/TradingApp/TradingApp/Program.cs)), также приветствуется создание любых других сопутствующих компонентов.

**Получение данных**

    - Получить данные по тикеру и частоте
        - InfoUpdated()
        - Использовать делегат для уведомления компонент пользовательского интерфейса о наличии новых цен на акции.
        - Класс должен получать новые данные каждые X секунд и уведомлять компонент пользовательского интерфейса.
    - Получение данных для похожих символов
  
Основная часть работы должна выполняться в классе `TradingDataRetreiver` ([TradingDataRetreiver.cs](./sample/TradingApp/TradingApp/TradingDataRetreiver.cs)), также приветствуется создание любых других сопутствующих компонентов.

**Торговая логика**

    - Купить/Продать
         По рыночной цене
         Ордер
         Цена достигла значения X
    - Отмена ордера при значении Y 80
    - Баланс

Основная часть работы должна выполняться в классе `TradingLogic` ([TradingLogic.cs](./sample/TradingApp/TradingApp/TradingLogic.cs)), также приветствуется создание любых других сопутствующих компонентов.

**Взаимодействие**

Взаимодействие между компонентами и командами должно происходить на уровне интерфейсов и договоренностей о том, как они должны быть определены. 

Начальный интерфейс взаимодействия (`ITradingLogic`, `ITradingDataRetreiver`)находится в ветке `main`. При изменении интерфейса по договоренности между командами вносятся изменения в ветку `main`.

## Процесс выполнения

Группа разбивается на команды, которые должны разработать соответствующий функционал. Отдельные части функционала могут быть разделены между членами команды.

Каждая команда создает ветку для своих изменений, итоговая синхронизация осуществляется в ветке `main`.
