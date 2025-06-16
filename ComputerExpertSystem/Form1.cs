using CLIPSNET; // Подключаем библиотеку CLIPS
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ComputerExpertSystem
{
	public partial class Form1 : Form
	{
		// Создаем экземпляр окружения CLIPS
		private CLIPSNET.Environment _clips = new CLIPSNET.Environment();

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// Заполняем выпадающие списки при загрузке формы
			InitializeComboBoxes();

			// Загружаем файл с правилами
			try
			{
				// Устанавливаем текущую директорию в папку с .exe файлом,
				// чтобы CLIPS правильно находил файл правил.
				Directory.SetCurrentDirectory(Application.StartupPath);

				string rulesFileName = "rules.clp";
				string rulesPath = Path.Combine(Application.StartupPath, rulesFileName);

				if (!File.Exists(rulesPath))
				{
					MessageBox.Show($"Файл правил '{rulesFileName}' не найден в папке с программой.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					this.Close(); // Закрываем приложение, если правил нет
					return;
				}

				_clips.Clear();

				// РЕШЕНИЕ: Заменяем все обратные слэши на прямые иначе CLIPS воспринимает путь как команду!!!
				string normalizedPath = rulesPath.Replace("\\", "/");

				// Передаем в CLIPS уже исправленный путь
				_clips.Eval($"(load \"{normalizedPath}\")");

				// Опционально: смотрим факты и правила
				_clips.Eval("(watch facts)");
				_clips.Eval("(watch rules)");

				_clips.Reset();
			}
			catch (Exception ex)
			{
				// Формируем детальное сообщение об ошибке
				string errorMessage = $"Произошла ошибка при загрузке правил CLIPS.\n\n" +
									  $"Время ошибки: {DateTime.Now}\n" +
									  $"Сообщение: {ex.Message}\n\n" +
									  $"Источник: {ex.Source}\n\n" +
									  $"Трассировка стека:\n{ex.ToString()}";

				// Определяем путь к файлу лога на рабочем столе
				string logFilePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop), "clips_error_log.txt");

				// Пытаемся записать ошибку в файл
				try
				{
					File.WriteAllText(logFilePath, errorMessage);
				}
				catch
				{
					// Если не удалось записать файл, ничего страшного, просто покажем ошибку на экране
				}

				// Показываем сообщение пользователю
				MessageBox.Show("Критическая ошибка при загрузке файла правил 'rules.clp'.\n\n" +
								"Подробный отчет об ошибке сохранен на вашем рабочем столе в файле 'clips_error_log.txt'.",
								"Ошибка загрузки правил", MessageBoxButtons.OK, MessageBoxIcon.Error);

				this.Close(); // Закрываем приложение после критической ошибки
			}
		}

		private void InitializeComboBoxes()
		{
			// Варианты использования
			comboIspolzovanie.Items.Add(new ComboBoxItem("Игры", "igry"));
			comboIspolzovanie.Items.Add(new ComboBoxItem("Офисная работа", "ofis"));
			comboIspolzovanie.Items.Add(new ComboBoxItem("Разработка/Программирование", "razrabotka"));
			comboIspolzovanie.Items.Add(new ComboBoxItem("Создание контента (видео, 3D)", "kontent"));
			comboIspolzovanie.SelectedIndex = 0;

			// Уровни производительности
			comboProizvoditelnost.Items.Add(new ComboBoxItem("Низкая", "nizkaya"));
			comboProizvoditelnost.Items.Add(new ComboBoxItem("Средняя", "srednyaya"));
			comboProizvoditelnost.Items.Add(new ComboBoxItem("Высокая", "vysokaya"));
			comboProizvoditelnost.SelectedIndex = 1;
		}

		private void buttonPoluchit_Click(object sender, EventArgs e)
		{
			// Очищаем предыдущие факты и сбрасываем движок
			_clips.Reset();

			// Получаем данные из формы
			int byudzhet = (int)numericByudzhet.Value;
			string ispolzovanie = ((ComboBoxItem)comboIspolzovanie.SelectedItem).Value;
			string proizvoditelnost = ((ComboBoxItem)comboProizvoditelnost.SelectedItem).Value;

			// Формируем факт для CLIPS
			string factString = $"(user_input (byudzhet {byudzhet}) (ispolzovanie {ispolzovanie}) (proizvoditelnost {proizvoditelnost}))";

			// Добавляем факт в рабочую память CLIPS
			_clips.AssertString(factString);

			// Запускаем обработку правил
			_clips.Run();

			// Ищем итоговый факт с рекомендацией
			var fact = _clips.FindFact("rekomendatsiya");

			if (fact != null)
			{
				// Получаем мультислот с компонентами
				MultifieldValue mv = fact.GetSlotValue("komponenty") as MultifieldValue;
				if (mv != null)
				{
					StringBuilder result = new StringBuilder();
					foreach (var component in mv)
					{
						// Добавляем каждую строку в результат
						result.AppendLine(component.ToString());
					}
					textRekomendatsiya.Text = result.ToString();
				}
			}
			else
			{
				textRekomendatsiya.Text = "К сожалению, не удалось подобрать конфигурацию по вашим параметрам. Попробуйте изменить критерии.";
			}
		}

		private void buttonSbros_Click(object sender, EventArgs e)
		{
			// Сбрасываем значения на форме
			numericByudzhet.Value = 75000;
			comboIspolzovanie.SelectedIndex = 0;
			comboProizvoditelnost.SelectedIndex = 1;
			textRekomendatsiya.Text = "";
			_clips.Reset(); // Сбрасываем движок CLIPS
		}
	}

	// Вспомогательный класс для хранения пар "Текст-Значение" в ComboBox
	public class ComboBoxItem
	{
		public string Text { get; set; }
		public string Value { get; set; }

		public ComboBoxItem(string text, string value)
		{
			Text = text;
			Value = value;
		}

		public override string ToString()
		{
			return Text;
		}
	}
}