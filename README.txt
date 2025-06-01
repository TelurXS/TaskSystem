Структура Task`a:
{
    "Type":"тип завдання",
    "Arguments":"аргументи виконання",
    "Time":"дата та час виконання",
    "State": 0, 
}

State:
    0 - Очікує виконання
    1 - Виконано

Типи завданнь та їх дії:
	(Готово)
	- MessageTask - відкриває діалогове вікно з повідомленням (Arguments: "повідомлення")
	- SoundAlertTask - програє певний звук у форматі .wav (Arguments: "шлях/до/звуку.wav")
	- OpenProgramTask - відкриває певну програму (Arguments: "шлях/до/програми.exe")
	- SoundAndMessageTask - суміш MessageTask та SoundAlertTask (Arguments: "шлях/до/завдання.wav|повідомлення")
	
	(Концепт)
	- null
