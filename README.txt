Задачи Олега:

Task Manager
	
	- Создание заданий
	- Редактирование заданий
	- Удаление заданий

namespace TaskSystem

	abstract class Task { string Message, DateTime Date }

	class SoundAlert : Task { string SoundName }

	class ConsoleLog : Task {}

	class Menu {}

Tasks.json
[{Task},{Task},{Task}]

List<Task> 