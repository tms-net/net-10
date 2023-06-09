# Основы C# - Массивы
Для изучения работы с типами C# предлагается сделать на выбор одно из заданий по работе с массивами. Дополнительно изучить что такое массивы и какое API предоставляет dotnet для работы с такими объектами можно по ссылкам [Обзор](https://learn.microsoft.com/ru-ru/dotnet/csharp/programming-guide/arrays/), [API](https://learn.microsoft.com/ru-ru/dotnet/api/system.array?view=net-7.0).

**Варианты заданий:**
  1. Измените порядок массива на противоположный
```
     Пример:
      Исходный массив: nums = [1,2,3,4]
      Результат выполнения: [4,3,2,1]
```
  2. Найдите четные (нечетные) элементы массива
```
     Пример:
      Исходный массив: nums = [1,2,3,4]
      Результат выполнения: [2,4]
```
  3. Найти бегущую сумму массива
```
     Пример:
      Исходный массив: nums = [1,2,3,4]
      Результат выполнения: [1,3,6,10] // [1,1+2,1+2+3,1+2+3+4]
     Объяснение:
      Бегущая сумма массива - это массив, который хранит сумму всех элементов до текущего элемента в исходном массиве (включая его).
```
  4. Дан массив целых чисел nums, поверните массив вправо на k шагов, где k неотрицательное число.
```  
    Пример:
      Исходный массив: nums = [1,2,3,4,5,6,7], k = 3
      Результат выполнения: [5,6,7,1,2,3,4]
     Объяснение:
        поверните на 1 шаг вправо: [7,1,2,3,4,5,6]
        поверните на 2 шага вправо: [6,7,1,2,3,4,5]
        поверните на 3 шага вправо: [5,6,7,1,2,3,4]
```
### Требования к программе
  1. Модифицируйте метод `SolveArrayTask()` в файле [Program.cs](../homework-04/Homework-4/Program.cs) для выполнения выбранного задания
  2. При необходимости создавайте свои методы, получайте параметры от пользователя для выполнения задания(й)
  3. Выведите рузультат в консоль

## Подтверждение выполнения
Задание можно предоставить в тренажере, однако эффективнее будет после выполнения задания (или этапов задания) использовать `git` репозиторий для сохранения Ваших изменений.

 - Создайте ветку (`branch`) в репозитории https://github.com/tms-net/net-10 с именем '{ФАМИЛИЯ}/{ОПИСАНИЕ_ЗАДАНИЯ}', например 'andrienko/lesson-3-basic'

 - Сделайте коммит (`commit`) в ветке с нужным набором изменений и соответствующим комментарием. Например, коммит после создания проекта 'Added console project' (на любом языке)

 - Отправьте изменения в удаленный репозиторий (`push`) и создайте `pull request` в ветку `main`