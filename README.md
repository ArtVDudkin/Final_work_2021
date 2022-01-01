# `Описание решения задачи`

**Задача**: Написать программу, которая из имеющегося массива целых чисел формирует массив из четных чисел. Первоначальный массив можно ввести с клавиатуры, либо сгенерировать случайным образом. При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

## Для того, чтобы решить данную задачу нужно:
1. Определить, каким способом будут вводиться числа для заполнения массива (с клавиатуры, либо с помощью генератора случайных чисел) и реализовать программно выбранный способ ввода чисел.
2. Исходя из выбранного способа ввода чисел, сформировать первоначальный массив целых чисел. Если числа вводятся с клавиатуры (в одну строку через запятую), сформировать строку, проверить корректность ввода либо отформатировать строку, и далее получить из строки первоначальный массив с целыми числами.
3. Определить, сколько в первоначальном массиве содержится четных чисел, и создать итоговый массив соответствующего размера для хранения четных чисел.
4. Скопировать из первоначального массива в итоговый массив только четные числа.
5. Вывести на экран результат работы программы в требуемом формате [первоначальный массив] -> [итоговый массив]

## Описание примененных в решении методов

### `string ChooseInput(int value1, int value2)`

Т.к. в программе реализованы оба способа ввода чисел (с клавиатуры, либо с помощью генератора случайных чисел), метод вывод на экран сообщение пользователю о необходимости выбрать один из двух возможных вариантов (1 - для ввода с клавиатуры, 2 - для генерации случайным образом). При этом реализована проверка корректности ввода, ничего другого, кроме 1 или 2 ввести нельзя.

### `int[] CreateArray(int count)`

Возвращает целочисленный массив заданного размера *`count`*

### `string GetNumbers(string optionInput)`

Исходя из выбранного способа ввода чисел *`optionInput`*, метод формирует строку с числами для дальнейшей обработки. Если числа вводились с клавиатуры, текстовая строка обрабатывается с помощью метода `TextFormatter()`, который помогает исключить сбои в работе программы по причине некорректного ввода значений. Если выбран вариант генерации чисел случайным образом, итоговая строка включает от 3 до 9 целых чисел в диапазоне от -10 до 10. 

### `string TextFormatter(string text)` 

Метод форматирует строку с числами, введенную пользователем с клавиатуры, с целью предупреждения сбоев в работе программы из-за различных ошибок ввода:

* введены некорректные символы (спецсимволы, буквы и т.д.)
* введены несколько запятых или знаков "минус" подряд (например, 4,,,5 или --5) 
* знак минус введен после числа (например, 5-,3--)
* пользователь ничего не ввел и нажал Enter
* пользователь ввел вместо чисел нечто вроде ,,,---,, или "ящерица в стакане"

Примечание: *поскольку в дальнейшем строка используется для выделения из нее чисел с помощью метода `NumbersReader()`, для корректной работы этого метода в конце строки добавляется запятая, если она там отсутствует*.

### `int ElementsCounter(string inputText)`

Метод возвращает количество чисел, которые содержатся в исходной строке `inputText`. Поскольку числа в строке разделяются запятой и метод `TextFormatter()` искусственно добавляет запятую в конце строки, при этом удаляя все повторяющиеся запятые, количество чисел равно количеству запятых в строке.

### `int[] NumbersReader(string text)`

Обрабатывает откорректированную с помощью метода `TextFormatter()` строку, выделяя из нее числа, которые отделены друг от друга запятой, и возвращает массив целых чисел. Предварительно с помощью метода `ElementsCounter()` производится оценка, сколько чисел содержится в строке и создается целочисленный массив соответствующего размера. Выделение чисел происходит путем копирования во временную переменную temp символов от начала строки до первой встретившейся запятой. Далее значение temp конвертируется в целое число с записывается в массив. Начало строки и первая запятая отрезаются и далее выделение чисел ведется в оставшейся части строки.

### `int EvenCounter(int[] arr)`

Метод возвращает количество четных чисел, которые содержатся в исходном массиве. Это необходимо для оценки требуемого размера при создании итогового массива четных чисел.

### `int[] GetEvenNumbers(int[] arr)`

Метод обрабатывает исходный массив и возвращает массив состоящий только из четных чисел. Предварительно с помощью метода `EvenCounter()` производится оценка, сколько четных чисел содержится в исходном массиве и создается итоговый массив соответствующего размера.

### `void PrintArray(int[] arr)`

Выводит указанный в качестве параметра массив на экран в одну строку через запятую.

### `void PrintResult(int[] arrInit, int[] arrRes)`

Выводит на экран исходный массив и итоговый массив четных чисел в одну строку в требуемом формате, например, [1, 2, 3, 4] -> [2, 4].

**Примеры работы программы**:

[1, 2, 3, 4] -> [2, 4]

[1, 3, 4, 5, 7, 1, 3] -> [4]

[2, -4, 6] -> [2, -4, 6]

[1, 3, 5] -> []

[] -> []