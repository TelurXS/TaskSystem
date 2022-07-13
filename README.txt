Структура Task`a:
{
    "Type":"тип задания",
    "Arguments":"аргуиент исполнения",
    "Date":"дата и время исполнения",
    "State": 0, 
}

State:
    0 - Ожидает исполнения
    1 - Выполнен

Типа заданий и их действия:
	(Готово)
	- MessageTask - открывает диалоговое окно с сообщением (Arguments: "сообщение")
	- SoundAlertTask - проигрывает определённый звук в формате .wav (Arguments: "путь/к/звуку.wav")
	- OpenProgramTask - отрывает определённую программу (Arguments: "путь/к/программе.exe")
	- SoundAndMessageTask - сместь MessageTask и SoundAlertTask (Arguments: "путь/к/звуку.wav|сообщение")
	
	(Концепт)
	- null
